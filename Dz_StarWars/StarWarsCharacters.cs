using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dz_StarWars
{
    [Serializable]
    public class StarWarsCharacters
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string Hair_color { get; set; }

        [JsonProperty("skin_color")]
        public string Skin_color { get; set; }

        [JsonProperty("eye_color")]
        public string Eye_color { get; set; }

        [JsonProperty("birth_year")]
        public string Birth_year { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public StarWarsCharacters() { }       
        public void Show()
        {
            Console.WriteLine("\nname:\t\t" + Name +
                "\nheight:\t\t" + Height +
                "\nmass:\t\t" + Mass +
                "\nhair_color:\t" + Hair_color +
                "\nskin_color:\t" + Skin_color +
                "\neye_color:\t" + Eye_color +
                "\nbirth_year:\t" + Birth_year +
                "\ngender:\t\t" + Gender +
                "\nhomeworld:\t" + Homeworld);
            foreach (var film in Films)
            {
                Console.WriteLine("films:\t\t" + film);
            }
            foreach (var view in Species)
            {
                Console.WriteLine("species:\t" + view);
            }
            foreach (var vechile in Vehicles)
            {
                Console.WriteLine("vechiles:\t" + vechile);
            }
            foreach (var starship in Starships)
            {
                Console.WriteLine("starships:\t" + starship);
            }
            Console.WriteLine("created:\t" + Created +
                "\nedited:\t\t" + Edited +
                "\nurl:\t\t" + Url + "\n\n");
        }

    }
}
