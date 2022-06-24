using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace WebRequests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var application = new application { username = "testuser", password = "Passwortstring", timeStamp = DateTime.Now }; //Test Objekt erstellen
            string response = WebRequest("http://127.0.0.1:5000/auth", JsonConvert.SerializeObject(application), HttpMethod.Post); //Anfrage senden
            Console.WriteLine(response); //Server Antwort in der Console ausgeben lassen.
            Console.ReadLine();
        }
        /// <summary>
        /// Anfrage erstellen
        /// </summary>
        /// <param name="url">URL bzw. Endpunkt des Servers, z.B.: api.p90ez.com/auth</param>
        /// <param name="application">Body im Json Format</param>
        /// <param name="method">HTTP Methode (Get, Post, Patch,...)</param>
        /// <returns></returns>
        internal static string WebRequest(string url, string application, HttpMethod method)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var request = new HttpRequestMessage //Anfrage erstellen
                    {
                        Method = method,
                        RequestUri = new Uri(url),
                        Content = new StringContent(application, Encoding.UTF8, "application/json"), //Content ist der Body der Anfrage, hier haben wir den Media Type auf 'application/json', da wir mit Json Strings arbeiten.
                    };
                    var response = client.SendAsync(request).Result; //Anfrage senden und Antwort abwarten
                    return response.Content.ReadAsStringAsync().Result; //Body der antwort als String zurück geben
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message); //Wenn fehler -> in Console ausgeben lassen
            }
            return null;
        }
        //Klasse für meine Test API
        class application
        {
            public string username { get; set; }
            public string password { get; set; }
            public DateTime timeStamp { get; set; }
        }
    }
}
