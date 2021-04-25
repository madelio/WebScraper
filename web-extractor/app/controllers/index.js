import Controller from '@ember/controller';
import { computed } from '@ember/object';
import {  bool } from '@ember/object/computed';
import { isPresent } from '@ember/utils';

export default Controller.extend({
    classNames: ['web-extractor'],
    inputUrls: '',
    content: '',
    queryString: computed('inputUrls', function() {
        return this.inputUrls.split('\n').map(url => `urls=${encodeURIComponent(url)}`).join('&');
    }),
    showResults: computed('inputUrls',function() {
        return this.inputUrls !== '';
    }),
    showContent: computed('content', function() {
        return isPresent(this.results);
    }),
    hasError: bool('error'),
    actions: {
        getSiteData() {
            this.set('isLoading', true);
           fetch(`https://localhost:44379/api/scraper?${this.queryString}`)
            .then(response => response.json())
            .then(results => {
                this.set('results', results);
            })
            .catch(error => {
                this.set('error', error);
                console.log(error);
            })
            .finally(() => this.set('isLoading', false));
        }
    }

});
