using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace TinyWorkbenches;

[HarmonyPatch]
public static class MainTabWindow_Research_DrawResearchBenchRequirements
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        var parentType = typeof(MainTabWindow_Research);
        var nestedTypes =
            parentType.GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        foreach (var nested in nestedTypes)
        {
            if (!nested.Name.Contains("DisplayClass"))
            {
                continue;
            }

            var methods = nested.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.Name.Contains("DrawResearchBenchRequirements") && method.Name.Contains("b__"))
                {
                    yield return method;
                }
            }
        }
    }

    public static void Postfix(Building x, ref bool __result)
    {
        if (__result)
        {
            return;
        }

        if (x.def == TinyWorkbenches.TWB_HiTechResearchBenchMini)
        {
            __result = true;
        }
    }
}