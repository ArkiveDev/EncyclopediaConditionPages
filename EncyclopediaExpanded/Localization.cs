using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncyclopediaExpanded
{
    public static class Localization
    {
        static readonly (string , string )[] enGBConditionStringsTuples =
        {
            ("ShakenTitle","Shaken Condition"),
            ("ShakenDescription","A shaken character takes a –2 penalty on attack rolls, saving throws, skill checks, and ability checks." )

        };

        public static void AddEnglishStrings() 
        {
            LocalizationPack LP = new LocalizationPack();
            LP.Locale = Kingmaker.Localization.Shared.Locale.enGB;
            foreach((string,string) tuple in enGBConditionStringsTuples)
            {
                LP.Strings.Add(tuple.Item1, tuple.Item2);
            }

            LocalizationManager.CurrentPack.AddStrings(LP);
        }
    }
}
