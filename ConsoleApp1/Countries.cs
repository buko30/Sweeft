using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Countries
    {
    static async Task Main(string[] args)
    {
        string url = "https://restcountries.com/v3.1/all";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response
                var countries = JsonSerializer.Deserialize<Country[]>(responseBody);

                // Create .txt document for each country
                foreach (var country in countries)
                {
                    string fileName = $"{country.Name.Official}.txt";
                    using (StreamWriter writer = File.CreateText(fileName))
                    {
                        writer.WriteLine($"Region: {country.Region}");
                        writer.WriteLine($"Subregion: {country.Subregion}");
                        writer.WriteLine($"Latitude: {string.Join(", ", country.Latlng)}");
                        writer.WriteLine($"Area: {country.Area}");
                        writer.WriteLine($"Population: {country.Population}");
                    }
                }

                Console.WriteLine("Text files created successfully!");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Failed to retrieve data: {ex.Message}");
            }
        }
    }

    public class Country
    {
        public OfficialName Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public double[] Latlng { get; set; }
        public double Area { get; set; }
        public int Population { get; set; }
    }

    public class OfficialName
    {
        public string Official { get; set; }
    }
}

    }
