(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('HomeCtrl', HomeCtrl);

    function HomeCtrl() {

        var vm = this;
        vm.name = 'Fredy';
    }



})();

