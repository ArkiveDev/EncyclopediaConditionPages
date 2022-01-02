using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Encyclopedia;
using Kingmaker.Blueprints.Encyclopedia.Blocks;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EncyclopediaExpanded
{
    public static class PageCreator
    {
        // Creates an encyclopedia page for condition "condition" and adds it as child page under parentPage
        // Requires strings in the current LocalizaionPack with keys "<condition>Description" and "<condition>Title"
        public static void CreateConditionPage(String condition, BlueprintEncyclopediaPage parentPage, ref BlueprintsCache instance)
        {
            BlueprintEncyclopediaBlockText conditionBlock = ScriptableObject.CreateInstance<BlueprintEncyclopediaBlockText>(); //log error suggested use ScriptableObject.CreateInstance instead of new ()
            conditionBlock.Text = new LocalizedString() { Key = condition + "Description" };
            BlueprintEncyclopediaPage conditionPage = new BlueprintEncyclopediaPage();
            conditionPage.Blocks.Add(conditionBlock);
            conditionPage.Title = new LocalizedString() { Key = condition + "Title" };
            conditionPage.AssetGuid = new BlueprintGuid(Guid.NewGuid());
            instance.AddCachedBlueprint(conditionPage.AssetGuid, (SimpleBlueprint)conditionPage);

            parentPage.ChildPages.Add(conditionPage.ToReference<BlueprintEncyclopediaPageReference>());
        }
    }
}
