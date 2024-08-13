using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // json parser
using System.Net.Http;
using System.Net.Http.Headers; // httpclient

namespace Week5Programming
{
    public static class APIExample
    {
        /*
         * GET, query strings, parameters, etc
         * OPTIONS
         */
        public static async Task<string> APIExampleRunAsync()
        {

            string URI = "https://pokeapi.co/api/v2/"; 
            string parameters = "pokemon"; // ?limit=100000&offset=0
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URI);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.GetAsync(parameters);

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync(); // get the JSON string of the request body
                JsonDocument json = JsonDocument.Parse(jsonString);
                var jsonArray = json.RootElement.GetProperty("results");

                for (int i = 0; i < jsonArray.GetArrayLength(); i++)
                {
                    Pokemon poke = jsonArray[i].Deserialize<Pokemon>()!;
                    Console.WriteLine(poke.name);
                }

                //Dictionary<string, string> pokemondict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString)!;

                //Console.WriteLine(pokemonDict.ToString());
                return jsonString;
            }
            else
            {
                Console.WriteLine("There was an issue with your request: Status code: " + res.StatusCode);
                return "";
            }
        }
    }
}
