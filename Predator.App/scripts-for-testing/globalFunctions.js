/* global inject */

function sharedSetup() {
    inject(function ($injector) {

        // inject services
        var $httpBackend = $injector.get("$httpBackend");

        // mock requests the app makes on init
        $httpBackend.whenGET("app/config.json").respond({
            "build": "local dev",
            "apiEndpoint": "",
            "avatarUrl": "https://flucphoto/Employee_Photos/",
            "avatarFileExtension": ".jpg"
        });
        $httpBackend.whenGET('app/home/home.html').respond();
        $httpBackend.whenGET('System/Users/current').respond({}); //respond with a valid object
    });
}