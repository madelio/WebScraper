using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraperAPI.Models;
using WebScraperScript.WebScraper.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebScraperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        // GET: api/<ScraperController>
        [HttpGet]
        public Site Get()
        {
            var scraper = new SiteScanner();
            var testUrl = "https://www.york.ac.uk/teaching/cws/wws/webpage1.html";
            return new Site()
            {
                Url = testUrl,
                Content = scraper.GetRawHtml(testUrl)
            };
        }

        // GET api/<ScraperController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // POST api/<ScraperController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ScraperController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ScraperController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
