(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('EditCheckCtrl', EditCheckCtrl);

    function EditCheckCtrl($http, $state, $stateParams, toastr, appSettings, checkResource) {

        var vm = this;
        vm.check = $stateParams.checkToEdit;
        vm.updateCheck = updateCheck;
        vm.clearAllFields = clearAllFields;


        ////////////////////////////////

        function updateCheck(){

        	// get single for safe update
	   //      checkResource.get( { id:  vm.check.idCheck }, function(data) {

				// });

	        $http({
	          method: 'PUT',
	          url: appSettings.serverPath + '/api/CheckDisplayRow/' + vm.check.idCheck,
	          data: vm.check,
	        }).then(function successCallback(response) {
	                toastr.success('Successfully updated.');
	                $state.go('search');
	          }, function errorCallback(response) {
	                console.error(response);
	          });

        }

        function clearAllFields(){
            vm.check = {};
        }


    }



})();

