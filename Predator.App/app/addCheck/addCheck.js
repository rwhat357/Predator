(function() {
    'use strict';

    angular.module('PredatorApp')
        .controller('AddCheckCtrl', AddCheckCtrl);

    function AddCheckCtrl($http, toastr, appSettings) {

        var vm = this;
        vm.check = {
            offenseLevel: 1
        };
        vm.checks = [];

        vm.addCheck = addCheck;
        vm.autoFillSampleData = autoFillSampleData;
        vm.clearAllFields = clearAllFields;

        ////////////////////////////////

        function addCheck(){

          $http({
            method: 'POST',
            url: appSettings.serverPath + '/api/CheckDisplayRow',
            data: vm.check,
          }).then(function successCallback(response) {
                  toastr.success('Successfully added.');
                  clearAllFields();
            }, function errorCallback(response) {
                  console.error(response);
            });

        }

        function clearAllFields(){
            vm.check = {};
        }

        function autoFillSampleData(){
            var sampleData = {
                          "idStore": 1,
                          "checkNum": 79,
                          "amount": 44444,
                          "dateWritten": new Date(),
                          "amountPaid": -1,
                          "paidDate": null,
                          "routingNum": 122345678,
                          "accountNum": 9989731,
                          "fName": "Leanora",
                          "lName": "Price",
                          "fName2": "",
                          "lName2": "",
                          "address": "1751 Cinder Zephyr Corners",
                          "city": " Village Five",
                          "state": "VA",
                          "zipcode": 22159,
                          "phoneNum": " (571) 858-1989",
                          "bName": "Bank of Greenville",
                          "bAddress": "1700 Wade Hampton Blvd",
                          "bCity": "Greenville",
                          "bState": "SC",
                          "bZipcode": 12345,
                          "idStoreGroup": 1,
                          "sName": "Greenville 1",
                          "sAddress": "Test",
                          "sCity": "Greenville",
                          "sState": "SC",
                          "sZipcode": 29617
                        }
            vm.check = sampleData;
        }


    }



})();

