using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Json_Tutorial
{
    internal class Program
    {
        //Beispiel: Klasse im Json-Format speichern, wieder lesen und einen Wert ausgeben
        static void Main(string[] args)
        {
            Config config = new Config()                                                //Neues Objekt der Klasse 'Config' erstellen und mit Werten befüllen
            {
                token = "t0k3n",
                port = 2121,
                timeStamp = DateTime.Now,
                tags = new List<string>() { "string1", "string2", "string3" }
            };
            JsonToFile(config, "config.json");                                          //JsonToFile Methode aufrufen und Config Objekt übergeben
            Config configFromFile = ConfigReader("config.json");                        //ConfigReader Methode aufrufen und Rückgabe in Variable 'json' speichern
            Console.WriteLine(configFromFile.token);                                    //Token in Console ausgeben
        }
        /// <summary>
        /// Schreibt ein Objekt einer Klasse im Json Format in eine Datei
        /// </summary>
        /// <param name="Object">zu speicherndes Objekt</param>
        /// <param name="path">Zielpfad oder Name der Datei</param>
        public static void JsonToFile(object Object, string path)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();                //Optionen erstellen
            options.WriteIndented = true;                                               //option für "schöne" (mehrzeilige) Schreibweise
            string json = JsonSerializer.Serialize(Object, typeof(Object), options);    //Object zu (Json) String convertieren
            File.WriteAllText("config.json", json);                                     //string in Datei schreiben
        }
        /// <summary>
        /// Erstellt ein Objekt der Klasse 'Config' aus der angegebenen Datei
        /// </summary>
        /// <param name="path">Pfad oder Name der Datei</param>
        /// <returns>ein Objekt der Klasse 'Config'</returns>
        public static Config ConfigReader(string path)
        {
            string json = File.ReadAllText(path);                                       //Datei lesen und in string 'json' speichern
            return JsonSerializer.Deserialize<Config>(json);                            //string 'json' zu Config object konvertieren und zurückgeben
        }
        public class Config                                                             //Beispielklasse Config
        {
            public string token { get; set; }
            public int port { get; set; }
            public DateTime timeStamp { get; set; }
            public List<string> tags { get; set; }
        }
    }
}
