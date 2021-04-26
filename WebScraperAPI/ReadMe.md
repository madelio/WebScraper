# WebScraperAPI

This is a simple API that uses the WebScraperScript to GET the raw html content from a passed in URL Script

## Prerequisites

You will need the following things properly installed on your computer.

* [Visual Studio](https://visualstudio.microsoft.com/downloads/)
* [Google Chrome](https://google.com/chrome/)

## Set up

* `git clone https://github.com/madelio/WebScraper.git`
* `cd WebScraper\WebScraperAPI`

## Running / Development

1. Open the API project in Visual Studio
2. Run IIS Express
3. Observe the browser popup with the sample API call

## Usage
You can use Postman or simply the browser to query different urls
1. Encode the URL you'd like to test
	1. Open dev tools in Google Chrome
	2. Click the Console tab
	3. Run `encodeURIComponent(<sampleUrl>)`
2. Get the string value output and pass to the endpoint: `https://localhost:44379/api/siteData/<encodedUrl>`
3. If the url is valid, it should return an object with a url and rawHtmlContent property

## Testing
1. Right Click the `WebScraperAPITests` project and select `Run Tests`