using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebScraperAPI.Controllers;
using WebScraperScript.WebScraper.Models;
using WebScraperScript.WebScraper.Services;

namespace WebScraperAPI.WebScraperAPI.Tests.Controllers
{
    [TestFixture]
    public class SiteDataControllerTests
    {
        private Mock<ISiteScanner> _mockSiteScanner;
        private SiteDataController _siteDataController;

        [SetUp]
        public void Setup()
        {
            _mockSiteScanner = new Mock<ISiteScanner>();
            _siteDataController = new SiteDataController(_mockSiteScanner.Object);
        }
        [Test]
        public async Task GetSiteData_ValidUrlArray_Returns_SiteDataList()
        {
            _mockSiteScanner.Setup(s => s.GetSiteData("http://validurl.com"))
                .Returns(Task.FromResult(new SiteData()
                {
                    Url = "http://validurl.com",
                    RawHtmlContent = "<div>sampleRawHtmlContent1</div>"
                }));

            var result = await _siteDataController.Get("http://validurl.com");
            Assert.IsInstanceOf<OkObjectResult>(result);

            var objectResult = (ObjectResult)result;
            var value = objectResult.Value;
            Assert.IsInstanceOf<SiteData>(value);
        }

        [Test]
        public async Task GetSiteData_InvalidUrlArray_Returns_NotFound()
        {
            _mockSiteScanner.Setup(s => s.GetSiteData("invalidUrl.com")).Throws<Exception>();

            var result = await _siteDataController.Get("invalidUrl.com");
            Assert.IsInstanceOf<NotFoundObjectResult>(result);
        }
    }
}
