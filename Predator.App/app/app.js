(function() {
    'use strict';

    var app = angular
        .module('PredatorApp', 
            [
                'ngResource',
                'ngSanitize',
                'ui.router'
            ]);


    app.config(function($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/home");
        $stateProvider

        .state('home', {
          url: '^/home',
          templateUrl: 'app/home/home.html',
          controller:'HomeCtrl as vm',
          title : 'Home',
        })
        .state('accounts', {
          url: '^/accounts',
          templateUrl: 'app/accounts/accounts.html',
          controller:'AccountsCtrl as vm',
          title : 'Account',
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
    

}());
