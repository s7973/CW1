using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var osoba = new Person { name = "Rafał" };

            var httpClient = new HttpClient();
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(content);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }

            }
        }
    }
}
