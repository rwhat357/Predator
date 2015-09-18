(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('AboutCtrl', AboutCtrl);

    function AboutCtrl() {

        var vm = this;
        vm.name = 'Fredy';
    }



})();
