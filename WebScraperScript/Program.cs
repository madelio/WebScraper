using System;
using WebScraperScript.WebScraper.Services;

namespace WebScraperScript
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Scraping!");
            var scanner = new SiteScanner();
            scanner.SaveHtmlToFile("https://www.york.ac.uk/teaching/cws/wws/webpage1.html", "simpleSite");
            Console.WriteLine("End Scraping!");
        }
    }
}
