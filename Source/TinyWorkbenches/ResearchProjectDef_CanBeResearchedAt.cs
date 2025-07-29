using HarmonyLib;
using RimWorld;
using Verse;

namespace TinyWorkbenches;

[HarmonyPatch(typeof(ResearchProjectDef), nameof(ResearchProjectDef.CanBeResearchedAt), typeof(Building_ResearchBench),
    typeof(bool))]
public static class ResearchProjectDef_CanBeResearchedAt
{
    public static void Postfix(Building_ResearchBench bench, bool ignoreResearchBenchPowerStatus,
        ResearchProjectDef __instance, ref bool __result)
    {
        if (__result)
        {
            return;
        }

        if (__instance.requiredResearchBuilding != ThingDef.Named("HiTechResearchBench"))
        {
            return;
        }


        if (bench.def != TinyWorkbenches.TWB_HiTechResearchBenchMini)
        {
            return;
        }

        if (!ignoreResearchBenchPowerStatus)
        {
            var comp = bench.GetComp<CompPowerTrader>();
            if (comp is { PowerOn: false })
            {
                return;
            }
        }

        if (!__instance.requiredResearchFacilities.NullOrEmpty())
        {
            var affectedByFacilities = bench.TryGetComp<CompAffectedByFacilities>();
            if (affectedByFacilities == null)
            {
                return;
            }

            var linkedFacilitiesListForReading = affectedByFacilities.LinkedFacilitiesListForReading;
            int i;
            for (i = 0; i < __instance.requiredResearchFacilities.Count; i++)
            {
                if (linkedFacilitiesListForReading.Find(x =>
                        x.def == __instance.requiredResearchFacilities[i] &&
                        affectedByFacilities.IsFacilityActive(x)) == null)
                {
                    return;
                }
            }
        }

        __result = true;
    }
}