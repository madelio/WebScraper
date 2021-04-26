import { module, test } from 'qunit';
import { setupTest } from 'ember-qunit';

module('Unit | Controller | index', function(hooks) {
  setupTest(hooks);

  test('Encoded urls returns an array of valid urls taken from the inputUrls', function(assert) {
    let controller = this.owner.lookup('controller:index');
    controller.set('inputUrls', 'http://google.com\nfakeURL\n\nhttp://yahoo.com\ngoogle.com')
    assert.deepEqual(controller.encodedUrls, ['http%3A%2F%2Fgoogle.com', 'http%3A%2F%2Fyahoo.com']);
  });

  test('isValidUrl returns true for valid urls', function(assert) {
    let controller = this.owner.lookup('controller:index');
    assert.equal(controller.isValidUrl(''), false, 'Empty strings are not valid');
    assert.equal(controller.isValidUrl('google.com'), false, 'Without http or https the url is not valid');
  });

  test('getSiteData does not execute if encodedUrls are empty', function(assert) {
    let controller = this.owner.lookup('controller:index');
    let fetchRan = false;
    controller.fetch = () => {
      fetchRan = true;
    }
    controller.send('getSiteData');
    assert.equal(fetchRan, false);
  });
});
