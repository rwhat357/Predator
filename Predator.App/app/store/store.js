(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('StoreCtrl', StoreCtrl);

    function StoreCtrl() {

        var vm = this;
        vm.name = 'Fredy';
    }



})();
