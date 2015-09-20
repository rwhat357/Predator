(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('ChecksCtrl', ChecksCtrl);

    function ChecksCtrl($filter, $http) {

        var vm = this;
        vm.inserted = {};

        vm.saveCheck = saveCheck;
        vm.removeCheck = removeCheck;
        vm.addCheck = addCheck;
        vm.checks = 
        [
	        {
	        	id: 0,
	        	name: 'Fredy Whatley',
	        	address: '445 Myrtle Avenue Laurel, MD 20707',
	        	date: '01/03/2012',
	        	payToTheOrderOf: 'Bob Jones University',
	        	amount:'$300.00',
	        	bankName: 'PNC',
	        	checkNumber:'34234545',
	        	accountNumber:'12342',
	        	routingNumber:'14234fff',
	        	bounced:true
	        },
	        {
	        	id: 1,
	        	name: 'Jon Doe',
	        	address: '881 Adams Street Fuquay Varina, NC 27526',
	        	date: '11/03/2014',
	        	payToTheOrderOf: 'Grocery Store',
	        	amount:'$500.00',
	        	bankName: 'TD',
	        	checkNumber:'454353455345',
	        	accountNumber:'1233',
	        	routingNumber:'124f24fv',
	        	bounced:true
	        },
	        {
	        	id: 2,
	        	name: 'Bradley Nelson',
	        	address: '390 Woodland Drive Grayslake, IL 60030',
	        	date: '10/23/2015',
	        	payToTheOrderOf: 'Walmart',
	        	amount:'$800.00',
	        	bankName: 'Wells Fargo',
	        	checkNumber:'34534534',
	        	accountNumber:'1234234',
	        	routingNumber:'1241234v',
	        	bounced:false
	        },
	        {
	        	id: 3,
	        	name: 'Joshua Wormley',
	        	address: '385 2nd Avenue Navarre, FL 32566',
	        	date: '12/14/2011',
	        	payToTheOrderOf: 'Gamingrap Inc.',
	        	amount:'$3300.00',
	        	bankName: 'PNC',
	        	checkNumber:'34534534',
	        	accountNumber:'3412',
	        	routingNumber:'13v214',
	        	bounced:false
	        },
	        

        ]

        //////////////////

        function saveCheck (data, id){
	        //$scope.check not updated yet
	        angular.extend(data, {
	            id: id
	        });
	        return $http.post('/saveCheck', data);
        }

        function removeCheck (index){
	        vm.checks.splice(index, 1);
        }

        function addCheck (){
	        vm.inserted = {
	            id: vm.checks.length + 1,
	            name: '',
	            address: '',
	            routingNumber: '',
	            accountNumber: ''
	        };
	        vm.checks.push(vm.inserted);
        }
    }



})();
