import Controller from '@ember/controller';
import { computed } from '@ember/object';
import { bool } from '@ember/object/computed';

export default Controller.extend({
    inputUrls: '',
    encodedUrls: computed('inputUrls', function () {
        return this.inputUrls.split('\n')
        .filter(u => this.isValidUrl(u))
        .map(url => encodeURIComponent(url));
    }),
    errorMessages: computed(function() {
        return { invalidUrlFormat: 'Error: Invalid URL Format' }
    }),
    showResults: computed('inputUrls', function () {
        return this.inputUrls !== '';
    }),
    isValidUrl(url) {
     var pattern = new RegExp('^(https?:\\/\\/)?'+ // protocol
        '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|'+ // domain name
        '((\\d{1,3}\\.){3}\\d{1,3}))'+ // OR ip (v4) address
        '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*'+ // port and path
        '(\\?[;&a-z\\d%_.~+=-]*)?'+ // query string
        '(\\#[-a-z\\d_]*)?$','i'); // fragment locator
    return !!pattern.test(url);

    },
    hasError: bool('error'),
    actions: {
        getSiteData() {
            if (this.inputUrls == '') return;

            this.set('isLoading', true);
            const siteDataEndpoint = "https://localhost:44379/api/siteData/";
            Promise.all(this.encodedUrls.map(encodedUrl => fetch(siteDataEndpoint + encodedUrl)))
                .then(responses => Promise.all(responses.map(result => result.json())))
                .then(results => this.set('results', results))
                .catch(error => this.set('error', error))
                .finally(() => this.set('isLoading', false));
        }
    }

});
