(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('AddCheckCtrl', AddCheckCtrl);

    function AddCheckCtrl(toastr) {

        var vm = this;
        vm.name = 'Fredy';

        vm.check = {
            offenseLevel: 1
        };
        vm.checks = [];

        vm.addCheck = addCheck;
        vm.clearAllFields = clearAllFields;

        ////////////////////////////////


        function addCheck(){
            vm.checks.push(vm.check);
            toastr.success('Successfully added.');
            clearAllFields();
        }

        function clearAllFields(){
            vm.check = {
                offenseLevel: 1
            };
        }


    }



})();

