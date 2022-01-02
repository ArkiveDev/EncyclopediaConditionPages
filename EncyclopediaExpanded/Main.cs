﻿using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityModManagerNet;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Localization;
using UnityEngine;

namespace EncyclopediaExpanded
{
    public class Main
    {
        public static UnityModManager.ModEntry.ModLogger Logger;

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            Localization.modEntry = modEntry;
            Harmony harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            return true;
        }

        [HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init))]
        public static class AddBlueprintsInCode
        {
            [HarmonyPostfix]
            public static void Init(ref BlueprintsCache __instance)
            {
                Main.Logger.Log("BlueprintsCache start");

                Localization.AddEnglishStrings();

                BlueprintGuid combatModsGuid = BlueprintGuid.Parse("d214e02b38add2c48a334a12c1e83003");
                BlueprintEncyclopediaPage combatMods = (BlueprintEncyclopediaPage)__instance.Load(combatModsGuid);

                String[] conditions =
                {
                    "Ability damage",
                    "Ability drain",
                    "Bleeding",
                    "Blinded",
                    "Charmed",
                    "Confused",
                    "Difficult terrain",
                    "Frightened",
                    "Grappled",
                    "Helpless",
                    "Invisible",
                    "Madness",
                    "Nauseated",
                    "Panicked",
                    "Prone",
                    "Paralyzed",
                    "Petrified",
                    "Shaken",
                    "Sickened",
                    "Sleeping",
                    "Slowed",
                    "Staggered",
                    "Stunned",
                    "Weakened"
                };
                foreach (string condition in conditions)
                {
                    PageCreator.CreateConditionPage(condition, combatMods, ref __instance);
                }
                //PageCreator.CreateConditionPage("Shaken",combatMods, ref __instance);

                Main.Logger.Log("BlueprintsCache finish");
            }
        }
    }
}
