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
            Log.Message(
                $"[TinyWorkbenches]: Cloning {originalBench.AllRecipes.Count} recipes from {originalBench.LabelCap} to {bench.LabelCap}");
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
        }
    }
}