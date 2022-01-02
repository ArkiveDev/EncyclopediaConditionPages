using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager;

namespace EncyclopediaExpanded
{
    public static class Localization
    {
        public static ModEntry modEntry;

        public static void AddEnglishStrings() 
        {
            LocalizationPack LP = new LocalizationPack();
            LP.Locale = Kingmaker.Localization.Shared.Locale.enGB;

            using (StreamReader sr = new StreamReader( modEntry.Path + "Localization\\enGB.json"))
            {
                string json = sr.ReadToEnd();
                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach(KeyValuePair<string,string> pair in dict)
                {
                    LP.Strings.Add(pair.Key + "Title", pair.Key + " Condition");
                    LP.Strings.Add(pair.Key + "Description", pair.Value);
                }
            }
            LocalizationManager.CurrentPack.AddStrings(LP);

        }
    }
}
