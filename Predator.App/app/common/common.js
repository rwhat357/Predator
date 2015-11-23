(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('CommonCtrl', CommonCtrl);

    function CommonCtrl(LoginSvc) {

        var vm = this;
        vm.name = 'Fredy CommonCtrl';

        vm.canSeeHeader = canSeeHeader;

        /////////////////////


        function canSeeHeader(){
        	return LoginSvc.getIsAuthenticated();
        }



    }



})();
