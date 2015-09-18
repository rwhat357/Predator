(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('ContactCtrl', ContactCtrl);

    function ContactCtrl() {

        var vm = this;
        vm.name = 'Fredy';
    }



})();

