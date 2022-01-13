using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraperScript.WebScraper.Models
{
    public enum MangaSite
    {
        // add enum, sitename
        Mangago,
        Bato
    }

    public class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string CurrentChapter { get; set; }
        public string LatestChapter { get; set; }
        public bool IsUpdated { get; set; }
        public MangaSite SourceSite { get; set; }
    }
}
