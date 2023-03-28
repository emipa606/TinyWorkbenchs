using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace TinyWorkbenches;

[StaticConstructorOnStartup]
public class TinyWorkbenches
{
    static TinyWorkbenches()
    {
        foreach (var bench in DefDatabase<ThingDef>.AllDefsListForReading.Where(def => def.defName.StartsWith("TWB_")))
        {
            var originalBench = ThingDef.Named(bench.defName.Replace("TWB_", "").Replace("Mini", ""));
            foreach (var recipeDef in originalBench.AllRecipes)
            {
                if (bench.recipes == null)
                {
                    bench.recipes = new List<RecipeDef>();
                }

                if (!bench.recipes.Contains(recipeDef))
                {
                    bench.recipes.Add(recipeDef);
                }
            }

            foreach (var workGiverDef in DefDatabase<WorkGiverDef>.AllDefsListForReading)
            {
                if (workGiverDef.fixedBillGiverDefs?.Contains(originalBench) == true)
                {
                    workGiverDef.fixedBillGiverDefs.Add(bench);
                }
            }

            var affectionComp = bench.GetCompProperties<CompProperties_AffectedByFacilities>();
            if (affectionComp == null)
            {
                continue;
            }

            var originalComp = originalBench.GetCompProperties<CompProperties_AffectedByFacilities>();
            if (originalComp == null)
            {
                continue;
            }

            affectionComp.linkableFacilities = originalComp.linkableFacilities;
        }

        foreach (var facility in DefDatabase<ThingDef>.AllDefsListForReading.Where(def =>
                     def.HasComp(typeof(CompFacility))))
        {
            facility.GetCompProperties<CompProperties_Facility>().ResolveReferences(facility);
        }
    }
}