using System.Reflection;
using HarmonyLib;
using Verse;

namespace TinyWorkbenches;

[HarmonyPatch]
public static class AmmoInjector_ToggleRecipeOnBench
{
    private static MethodInfo toggleRecipeOnBenchMethod;
    private static ThingDef tinyAmmoBench;

    public static bool Prepare()
    {
        return ModLister.GetActiveModWithIdentifier("CETeam.CombatExtended", true) != null;
    }

    public static MethodBase TargetMethod()
    {
        toggleRecipeOnBenchMethod = AccessTools.Method("CombatExtended.AmmoInjector:ToggleRecipeOnBench");
        tinyAmmoBench = ThingDef.Named("TWB_AmmoBenchMini");
        return toggleRecipeOnBenchMethod;
    }

    public static void Postfix(RecipeDef recipeDef, ThingDef benchDef, bool ammoEnabled)
    {
        if (benchDef.defName != "AmmoBench")
        {
            return;
        }

        toggleRecipeOnBenchMethod.Invoke(null, [recipeDef, tinyAmmoBench, ammoEnabled]);
    }
}