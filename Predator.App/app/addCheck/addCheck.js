(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('AddCheckCtrl', AddCheckCtrl);

    function AddCheckCtrl() {

        var vm = this;
        vm.name = 'Fredy';

        vm.check = {};
        vm.checks = [];

        vm.addCheck = addCheck;

        ////////////////////////////////


        function addCheck(check){
        	checks.push(check);
        }

    }



})();

