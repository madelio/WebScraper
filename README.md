# WebScraper

This project contains 4 branches: 
1. [web-scraper-script](https://github.com/madelio/WebScraper/tree/web-scraper-script/WebScraperScript):
	- This branch contains a script that saves 3 hardcoded urls into html files
2. [web-scraper-api](https://github.com/madelio/WebScraper/tree/web-scraper-api/WebScraperScript/WebScraper):
	- This branch builds onto the previous step and creates an API which takes in an encoded url string as it's input and outputs its html content
3. [web-scraper](https://github.com/madelio/WebScraper/tree/web-scraper/web-extractor):
	 - This builds onto the 2 previous steps and creates an EmberJS app as an interface for a user to enter any list of urls and output those results onto the interface
	 - This requires running both the API and UI projects to work 
4. [main](https://github.com/madelio/WebScraper)
	- All code from the above 3 has been merged into the `main` branch, so it is advisable to use this branch for testing/evaluation by following the directions in the WebScraperScript, WebScraperAPI, and web-extractor folders.
.
