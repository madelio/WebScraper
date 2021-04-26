using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using WebScraperScript.WebScraper.Models;
using WebScraperScript.WebScraper.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
