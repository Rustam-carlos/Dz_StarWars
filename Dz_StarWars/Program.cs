using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace Dz_StarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите идентификатор персонажа из саги \"Звездные войны\": ");
                string identifier = Console.ReadLine();
                string path = $"https://swapi.co/api/people/" + identifier + "/";

                List<StarWarsCharacters> characters = new List<StarWarsCharacters>();

                XmlSerializer formatter = new XmlSerializer(typeof(List<StarWarsCharacters>));

                bool check = false;
                string information = "Информация о таком персонаже в нашей базе отсутствует, " +
                        "выполняем запрос на сайт \"Swapi.co\"...";

                try
                {
                    using (FileStream fs = new FileStream("file.xml", FileMode.OpenOrCreate))
                    {
                        characters = (List<StarWarsCharacters>)formatter.Deserialize(fs);

                        foreach (var person in characters)
                        {
                            if (person.Url == path)
                            {
                                person.Show();
                                check = true;
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine(); break;
                            }
                        }
                    }
                    Console.WriteLine(information);
                }
                catch (Exception)
                {
                    Console.WriteLine(information);
                }

                if (!check)
                {
                    try
                    {
                        string json;

                        using (WebClient client = new WebClient())
                        {
                            json = client.DownloadString(path);
                        }

                        var personage = JsonConvert.DeserializeObject<StarWarsCharacters>(json);
                        personage.Show();

                        characters.Add(personage);
                        using (FileStream fs = new FileStream("file.xml", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, characters);
                        }
                        Console.Write("Нажмите Enter чтобы продолжить...");
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nК сожалению, персонаж с таким идентификатором отсутствует.");
                        Console.Write("Нажмите Enter чтобы продолжить...");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
    }
}
