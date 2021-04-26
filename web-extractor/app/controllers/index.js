import Controller from '@ember/controller';
import { computed } from '@ember/object';
import { bool } from '@ember/object/computed';
import { isPresent } from '@ember/utils';

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
        return isPresent(url) && (url.startsWith('http://') || url.startsWith('https://'));
    },
    fetch(url) {
        // wrapper function for in-built fetch api for testing purposes
        return fetch(url);
    },
    hasError: bool('error'),
    actions: {
        getSiteData() {
            if (!isPresent(this.encodedUrls)) return;

            this.set('isLoading', true);
            const siteDataEndpoint = "https://localhost:44379/api/siteData/";
            Promise.all(this.encodedUrls.map(encodedUrl => this.fetch(siteDataEndpoint + encodedUrl)))
                .then(responses => Promise.all(responses.map(result => result.json())))
                .then(results => this.set('results', results))
                .catch(error => this.set('error', error))
                .finally(() => this.set('isLoading', false));
        }
    }
});
