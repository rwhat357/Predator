(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('AddClerkManagerCtrl', AddClerkManagerCtrl);

    function AddClerkManagerCtrl(toastr) {

        var vm = this;
        vm.name = 'Fredy';

        vm.manager = {};
        vm.managers = [];

        vm.addClerkManager = addClerkManager;
        vm.clearAllFields = clearAllFields;

        ////////////////////////////////

        function addClerkManager(){
            vm.checks.push(vm.check);
            toastr.success('Successfully added.');
            clearAllFields();
        }

        function clearAllFields(){
            vm.manager = {};
        }


    }



})();

