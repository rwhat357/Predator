(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('ChecksCtrl', ChecksCtrl)
        .controller('CheckDetailsCtrl', CheckDetailsCtrl);

    function ChecksCtrl($filter, $http, $uibModal, toastr, checkResource, appSettings) {

        var vm = this;
        vm.inserted = {};
        vm.checks = [];
        vm.printQueue = [];
		vm.sortType     = 'accountNum'; // set the default sort type
		vm.sortReverse  = false;  // set the default sort order
		vm.searchText   = '';     // set the default search/filter term

        vm.openCheckDetailsModal = openCheckDetailsModal;
        vm.printSelectedChecks = printSelectedChecks;
        vm.removeSelectedChecks = removeSelectedChecks;
        vm.selectCheck = selectCheck;
        vm.removeCheck = removeCheck;

        activate();

        /////////////////////////////////

        function activate(){
	        checkResource.query(function(data){
	        	vm.checks = data;
	        })
        }

	    function selectCheck() {
	        vm.printQueue = $filter('filter')(vm.checks, {
	            checked: true
	        });
	        toastr.success('Print queue updated!');
	    }

        function openCheckDetailsModal(check){
		    var modalInstance = $uibModal.open({
				animation: true,
				templateUrl: 'app/search/checkDetailsModal.html',
				controller: 'CheckDetailsCtrl as vm',
				size: 'lg',
				resolve: {
					checks: function () {
				 		return vm.checks;
					},
					check: function(){
						var retrievedCheck = checkResource.get( { id: check.idCheck }, function() {

						});

						return retrievedCheck;
					}
				}
			})
        }

	    
	    function removeSelectedChecks() {

        	_.each(vm.printQueue, function(check, i){
        		removeCheck(check);
        	});

        	vm.printQueue = [];
	        toastr.success('Removed checks!');
	    }

        function printSelectedChecks(){
        	
			var doc = new jsPDF();

			var letter = 	
"																									\n\
Dear ___Joe__                                                                                       \n\
\n\
This is to inform you that your check dated __________, 20__, payable                               \n\
\n\
to________________, in the amount of $__________, has been returned to us due to                    \n\
\n\
insufficient funds.                                                                                 \n\
\n\
We realize that such mishaps do occur and therefore are bringing this matter to your                \n\
\n\
attention so that you will take the opportunity to correct this error and issue us a new            \n\
\n\
check.                                                                                              \n\
\n\
It is our policy to retain the old check until a new check is issued and cleared as we have         \n\
\n\
unfortunately realized that there are some people who do not honor their debts. If a new            \n\
\n\
check is not issued and the old check does not clear we will pursue legal action to the full        \n\
\n\
extend of the law.                                                                                  \n\
\n\
We are confident that you will resolve this matter and look forward to doing business               \n\
\n\
with you again in the future.                                                                       \n\
\n\
Our thanks for your attention to this matter.                                                       \n\
\n\
Very truly yours,                                                                                   \n\
\n\
__________Koopa Krew Inc________________";

			doc.setFontSize(12);
			doc.text(12, 10, letter);
			doc.save('InvalidCheckLetter.pdf');
        }

        // vm.saveCheck = saveCheck;
        // vm.removeCheck = removeCheck;
        // vm.addCheck = addCheck;


        // //////////////////

        // function saveCheck (data, id){
	       //  //$scope.check not updated yet
	       //  angular.extend(data, {
	       //      id: id
	       //  });
	       //  return $http.post('/saveCheck', data);
        // }

        function removeCheck (check){
     //    	_.each(vm.checks, function(vmCheck, i){

     //    		if ( check.idCheck === vmCheck.idCheck){

					// // var checkToDelete = checkResource.get( { id: check.idCheck }, function() {
					// // 	 checkToDelete.$delete(function(data) {
					// // 		gone forever!
				 //    //      console.log(data);
		   //          //      vm.checks.splice(i, 1);
					// // 	 });
					// // });

        			// $http.delete(appSettings.serverPath + '/api/CheckDisplayRow/' + check.idCheck )
        			// 	.then(function(data){
		         // 			vm.checks.splice(i, 1); //gone forever!
        			// 	});
     //    		}
     //    	});

        	for ( var i = 0; i < vm.checks.length; i++ ){

        		if ( vm.checks[i].idCheck == check.idCheck  ){
        			$http.delete(appSettings.serverPath + '/api/CheckDisplayRow/' + check.idCheck )
        				.then(function(data){
		         			vm.checks.splice(i, 1); //gone forever!
        				});

        			vm.checks.splice(i, 1); //gone forever!
        			return;
        		}
        	}

        }
    }

    function CheckDetailsCtrl($modalInstance, checks, check, toastr){
		var vm = this;
		vm.checks = checks;
		vm.check = check;
		vm.close = close;
		vm.saveCheck = saveCheck;

		function close () {
			$modalInstance.dismiss('close');
		};

		function saveCheck (check) {
	        toastr.success('Saved Check!!!!');
		};
    }


})();
