# web-extractor

This README outlines the details of collaborating on this Ember application.
This app is created as a way to add any urls to a textbox and get the HTML contents of the url site back

## Prerequisites

You will need the following things properly installed on your computer.

* [Git](https://git-scm.com/)
* [Node.js](https://nodejs.org/) (with npm)
* [Ember CLI](https://ember-cli.com/)
* [Google Chrome](https://google.com/chrome/)

## Installation

* `git clone https://github.com/madelio/WebScraper.git`
* `cd WebScraper\web-extractor`
* `npm install`

## Running / Development

### Run API Server to access the api
* Run the [WebScraperAPI](https://github.com/madelio/WebScraper/tree/web-scraper/WebScraperAPI) in order access the Web API in localhost

### Run Ember Project

* `ember serve`
* Visit your app at [http://localhost:4200](http://localhost:4200).
* Visit your tests at [http://localhost:4200/tests](http://localhost:4200/tests).

## Usage
1. Enter urls in the text input, for multiple urls simply add the url on a new line
2. Hit Submit
3. If the urls are valid, the html string for each url will be output in the Results area


### Running Tests

* `ember test`
* `ember test --server`

### Linting

* `npm run lint:hbs`
* `npm run lint:js`
* `npm run lint:js -- --fix`

### Building

* `ember build` (development)
* `ember build --environment production` (production)

## Further Reading / Useful Links

* [ember.js](https://emberjs.com/)
* [ember-cli](https://ember-cli.com/)
* Development Browser Extensions
  * [ember inspector for chrome](https://chrome.google.com/webstore/detail/ember-inspector/bmdblncegkenkacieihfhpjfppoconhi)
  * [ember inspector for firefox](https://addons.mozilla.org/en-US/firefox/addon/ember-inspector/)
