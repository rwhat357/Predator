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

        	if (vm.printQueue.length < 1){
				toastr.error('Please select checks to delete!');
        		return;
        	}

			var doc = new jsPDF();
			doc.setFontSize(11);

			_.each(vm.printQueue, function(_check, i){
				builLetterA(doc, _check);
				doc.addPage();
			});


			doc.save('InvalidCheckLetter.pdf');

        }

                          // "idStore": 1,
                          // "checkNum": 79,
                          // "amount": 44444,
                          // "dateWritten": new Date(),
                          // "amountPaid": -1,
                          // "paidDate": null,
                          // "routingNum": 122345678,
                          // "accountNum": 9989731,
                          // "fName": "Leanora",
                          // "lName": "Price",
                          // "fName2": "",
                          // "lName2": "",
                          // "address": "1751 Cinder Zephyr Corners",
                          // "city": " Village Five",
                          // "state": "VA",
                          // "zipcode": 22159,
                          // "phoneNum": " (571) 858-1989",
                          // "bName": "Bank of Greenville",
                          // "bAddress": "1700 Wade Hampton Blvd",
                          // "bCity": "Greenville",
                          // "bState": "SC",
                          // "bZipcode": 12345,
                          // "idStoreGroup": 1,
                          // "sName": "Greenville 1",
                          // "sAddress": "Test",
                          // "sCity": "Greenville",
                          // "sState": "SC",
                          // "sZipcode": 29617

        // HELPER FUNCTION to printSelectedChecks
        function builLetterA(doc, check){

        	var dt = new Date();
		    var str = vm.letterA.replace("{sendDate}", dt.getFullYear() + "/" + (dt.getMonth() + 1) + "/" + dt.getDate() );
		    str = str.replace("{checkAddress}", check.address);
		    str = str.replace("{accountName}", check.fName + ' ' + check.lName);
		    str = str.replace("{checkDate}", check.dateWritten);
		    str = str.replace("{storeName}", check.idStore);
		    str = str.replace("{checkAmnt}", check.amount);
		    str = str.replace("{storeManager}", 'Store Manager');

			doc.text(20, 30, str);

        }
        // HELPER FUNCTION to printSelectedChecks
        function builLetterB(doc, check){
        	var myString = 'Date:{sendDate} A rather long string of English text, an error message ' +
		      'actually that just keeps going and going -- an error ' +
		      'message to make the Energizer bunny blush (right through ' +
		      'those Schwarzenegger shades)! Where was I? Oh yes, ' +
		      'youve got an error and all the extraneous whitespace is ' +
		      'just gravy.  Have a nice day.';
		    var res = myString.replace("{sendDate}", "1/3/2015");
			doc.text(12, 10, res);
			doc.addPage();
        }
        // HELPER FUNCTION to printSelectedChecks
        function builLetterC(doc, check){
        	var myString = 'Date:{sendDate} A rather long string of English text, an error message ' +
		      'actually that just keeps going and going -- an error ' +
		      'message to make the Energizer bunny blush (right through ' +
		      'those Schwarzenegger shades)! Where was I? Oh yes, ' +
		      'youve got an error and all the extraneous whitespace is ' +
		      'just gravy.  Have a nice day.';
		    var res = myString.replace("{sendDate}", "1/3/2015");
			doc.text(12, 10, res);
			doc.addPage();
        }

        function removeCheck (check){

        	for ( var i = 0; i < vm.checks.length; i++ ){

        		if ( vm.checks[i].idCheck == check.idCheck  ){
        			$http.delete(appSettings.serverPath + '/api/CheckDisplayRow/' + check.idCheck )
        				.then(function(data){
		         			vm.checks.splice(i, 1); //gone forever!
        				});
        			return;
        		}
        	}

        }

	
	     vm.letterA = 
'                                                                                                 \n'+
'Date: {sendDate}                                                                                 \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'To: {checkAddress}                                                                               \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'Dear : {accountName}                                                                             \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'This is to inform you that your check dated {checkDate}, payable to {storeName}, in the amount of\n'+
'${checkAmnt}, has been returned to us due to insufficient funds.                                 \n'+
'                                                                                                 \n'+
'We realize that such mishaps do occur and therefore are bringing this matter to your attention so\n'+
'that you will take the opportunity to correct this error and issue us a new check.               \n'+
'                                                                                                 \n'+
'It is our policy to retain the old check until a new check is issued and cleared as we have      \n'+
'unfortunately realized that there are some people who do not honor their debts. If a new check   \n'+
'is not issued and the old check does not clear we will pursue legal action to the full extend    \n'+
'of the law.                                                                                      \n'+
'                                                                                                 \n'+
'We are confident that you will resolve this matter and look forward to doing business with       \n'+
'you again in the future.                                                                         \n'+
'                                                                                                 \n'+
'Our thanks for your swift attention to this matter.                                              \n'+
'                                                                                                 \n'+
'Very truly yours,                                                                                \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'                                                                                                 \n'+
'---------------------------                                                                      \n'+
'{storeManager}                                                                                   \n';



				    // var letterB =    "Date: {sendDate}


								// 	To: {checkAddress}


								// 	Dear : {accountName}



								// 	This is a second letter to inform you that your check dated {checkDate}, payable to{storeName}, in the amount of ${checkAmnt}, has been returned to us due to insufficient funds.


								// 	Unless full payment of the check is received by cash together with ${fee} in bank fees, I will file a small claims court claim against you.
								// 	The claim will also request damages for the amount of the check, ${checkAmnt}, plus ${fee} damages assessed, for a total claim of ${totalAmnt} against you.
								// 	We realize that such mishaps do occur and therefore are bringing this matter to your attention through one more grace letter so that you will take the opportunity to correct this error and issue us a new check.

								// 	It is our policy to retain the old check until a new check is issued and cleared as we have unfortunately realized that there are some people who do not honor their debts. If a new check is not issued and the old check does not clear we will pursue legal action to the full extend of the law.

								// 	We are confident that you will resolve this matter and look forward to doing business with you again in the future.

								// 	Thank you for your attention to this matter.

								// 	{storeManager}

								// 	";

				    // var letterC = 	"Date:{sendDate}
								// 	{accountName}
								// 	{checkAddress}
								// 	Dear {accountName}:
								// 	The check you wrote for ${checkAmnt}, dated {checkDate}, which was made payable to {storeName}, was returned by {bankName} because the account was either closed OR the account had insufficient funds.
								// 	Unless full payment of the check is received by cash within 30 days after the date this demand letter was mailed, together with ${fee} in bank fees, and $10, the cost of mailing this demand letter by certified mail, I will file a small claims court claim against you.
								// 	The claim will also request damages for the amount of the check, ${checkAmnt}, plus ${fee} damages assessed, for a total claim of ${totalAmnt} against you.
								// 	You may wish to contact a lawyer to discuss your legal rights and responsibilities.
								// 	Please send your payment to:
								// 	{storeManager}
								// 	{storeAddress} 
								// 	~KoopaKrew Inc.";
		
		vm.letter = 	
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
