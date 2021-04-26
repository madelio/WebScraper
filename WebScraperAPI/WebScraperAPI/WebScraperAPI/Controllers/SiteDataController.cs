using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using WebScraperScript.WebScraper.Models;
using WebScraperScript.WebScraper.Services;

namespace WebScraperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteDataController : ControllerBase
    {
        private readonly ISiteScanner _siteScanner;
        public SiteDataController(ISiteScanner siteScanner)
        {
            _siteScanner = siteScanner;
        }


        //Sample call: https://localhost:44379/api/siteData/https%3A%2F%2Fwww.york.ac.uk%2Fteaching%2Fcws%2Fwws%2Fwebpage1.html
        [HttpGet("{url}")]
        public async Task<IActionResult> Get(string url)
        {
            try
            {
                var siteData = await _siteScanner.GetSiteData(HttpUtility.UrlDecode(url));
                return Ok(siteData);
            }
            catch
            {
                return NotFound(new SiteData() { 
                    Url = url
                });
            }

        }
    }
}
