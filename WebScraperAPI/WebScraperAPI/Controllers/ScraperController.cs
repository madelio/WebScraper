using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebScraperAPI.Models;
using WebScraperScript.src.WebScraper.Models;
using WebScraperScript.WebScraper.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebScraperAPI.Controllers
{
    //TODO change this name to SiteDataController
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        //// GET: api/<ScraperController>
        //[HttpGet]
        //public Site Get()
        //{
        //    var scraper = new SiteScanner();
        //    var testUrl = "https://www.york.ac.uk/teaching/cws/wws/webpage1.html";
        //    return new Site()
        //    {
        //        Url = testUrl,
        //        Content = scraper.GetRawHtml(testUrl)
        //    };
        //}

        // GET api/<ScraperController>/5
        //[HttpGet("{url}")]
        //public SiteData Get(string url)
        //{
        //    var decodedUrl = HttpUtility.UrlDecode(url);
        //    var scraper = new SiteScanner();
        //    return scraper.GetSiteData(decodedUrl);
        //}

        [HttpGet]
        public List<SiteData> Get([FromQuery] string[] urls)
        {
            //    var decodedUrl = HttpUtility.UrlDecode(url);
            var decodedUrls = urls.Select(url => HttpUtility.UrlDecode(url)).ToArray();
            var scraper = new SiteScanner();
            return scraper.GetSiteData(decodedUrls);
        }


        // POST api/<ScraperController>
        //[HttpPost]
        //public ActionResult<SiteData> Post([FromBody] Site site)
        //{
        //    var scraper = new SiteScanner();
        //    return Created("",scraper.GetSiteData(site.Url));
        //}

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
