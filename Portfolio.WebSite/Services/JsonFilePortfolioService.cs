using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Portfolio.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace Portfolio.WebSite.Services
{
    public class JsonFilePortfolioService
    {
        public JsonFilePortfolioService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "portfolio.json"); }
        }

        public IEnumerable<Experience> GetExperience()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Experience[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
