using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Portfolio.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace Portfolio.WebSite.Services
{
    public class JsonFileExperienceService
    {
        public JsonFileExperienceService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "portfolio.json"); }
        }

        public IEnumerable<Experience> GetExperiences()
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

        //public void AddGrades(string experienceId, int grade)
        //{
        //    var experiences = GetExperiences();

        //    var query = experiences.First(x => x.Id == experienceId);

        //    if (query.grade == null)
        //    {
        //        query.grade = new int[] { grade };
        //    }
        //    else
        //    {
        //        var grades = query.grade.tolist();
        //        grades.add(grade);
        //        query.grade = grades.toarray();
        //    }

        //    using (var outputStream = File.OpenWrite(JsonFileName))
        //    {
        //        JsonSerializer.Serialize<IEnumerable<Experience>>(
        //            new Utf8JsonWriter(outputStream, new JsonWriterOptions
        //            {
        //                SkipValidation = true,
        //                Indented = true
        //            }),
        //            experiences
        //        );
        //    }
        //}
    }
}
