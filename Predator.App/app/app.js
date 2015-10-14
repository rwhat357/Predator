(function() {
    'use strict';

    var app = angular
        .module('PredatorApp', 
            [
                'common.services',
                'ngSanitize',
                'ui.router',
                'xeditable',
                'ui.bootstrap',
                'ngAnimate' 
                //"ngMockE2E"
            ]);

    app.run(function(editableOptions) {
        editableOptions.theme = 'bs3';
    });

    app.config(function($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/checks");
        $stateProvider

        .state('home', {
          url: '^/home',
          templateUrl: 'app/home/home.html',
          controller:'HomeCtrl as vm',
          title : 'Home',
        })
        .state('checks', {
          url: '^/checks',
          templateUrl: 'app/checks/checks.html',
          controller:'ChecksCtrl as vm',
          title : 'Checks',
        })
        .state('about', {
          url: '^/about',
          templateUrl: 'app/about/about.html',
          controller:'AboutCtrl as vm',
          title : 'About',
        })        
        .state('contact', {
          url: '^/contact',
          templateUrl: 'app/contact/contact.html',
          controller:'ContactCtrl as vm',
          title : 'Contact',
        })
    
    });

    // app.run(['$httpBackend', function ($httpBackend) {

    //   $httpBackend.whenGET('/groups').respond([{
    //       id: 1,
    //       text: 'user'
    //   }, {
    //       id: 2,
    //       text: 'customer'
    //   }, {
    //       id: 3,
    //       text: 'vip'
    //   }, {
    //       id: 4,
    //       text: 'admin'
    //   }]);

    //   $httpBackend.whenPOST(/\/saveCheck/).respond(function(method, url, data) {
    //       data = angular.fromJson(data);
    //       return [200, {
    //           status: 'ok'
    //       }];
    //   });

    //   $httpBackend.whenGET(/\.html$/).passThrough();

    // }]);
    

}());
