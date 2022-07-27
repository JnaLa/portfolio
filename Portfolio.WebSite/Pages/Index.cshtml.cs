using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.WebSite.Models;
using Portfolio.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePortfolioService PortfolioService;
        public IEnumerable<Experience> Experiences { get; private set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFilePortfolioService portfolioService)
        {
            _logger = logger;
            PortfolioService = portfolioService;
        }

        public void OnGet()
        {
            Experiences = PortfolioService.GetExperience();
        }
    }
}
