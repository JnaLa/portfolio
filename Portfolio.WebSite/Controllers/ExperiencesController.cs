using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebSite.Models;
using Portfolio.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        public ExperiencesController(JsonFileExperienceService experienceService)
        {
            this.ExperienceService = experienceService;
        }

        public JsonFileExperienceService ExperienceService { get; }
        
        [HttpGet]
        public IEnumerable<Experience> Get()
        {
            return ExperienceService.GetExperiences();
        }

        //[HttpPatch] "[FromBody]"
        //[Route("Rate")]
        //[HttpGet]
        //public ActionResult Get([FromQuery] string ExperienceId, 
        //    [FromQuery] int Grade)
        //{
        //    ExperienceService.AddRating(ExperienceId, Grade);
        //    return Ok();
        //}
    }
}
