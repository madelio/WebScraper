namespace WebScraperScript.WebScraper.Services
{
    /// <summary>
    ///  TODO: if output filename doesn't exist, just return the text
    ///  TODO: does the same streamwriter get reused if it's coming from the same object? imo it does
    /// </summary>
    public interface ISiteScanner
    {
        public void SaveHtmlToFile(string url, string outputFilename = null);
        public void SaveHtmlToFile(string[] urls, string outputFilename = null);
        public string GetRawHtml(string url);
    }
}
