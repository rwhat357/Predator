(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('DeleteCheckCtrl', DeleteCheckCtrl);

    function DeleteCheckCtrl() {

        var vm = this;
        vm.name = 'Fredy Delete';

        vm.check = {};
        vm.checks = [];

        vm.deleteCheck = deleteCheck;

        ////////////////////////////////


        function deleteCheck(check){
        	console.log("removed!");
        }

    }



})();

