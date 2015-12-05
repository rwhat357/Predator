(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('LoginCtrl', LoginCtrl);

    function LoginCtrl(toastr, $state, LoginSvc, $cookies) {

        var vm = this;
        vm.name = 'Fredy LoginCtrl';
    	vm.user = {
    		username: '',
    		password: '',
    	}


        vm.login = login;
        vm.register = register;
        vm.resetPassword = resetPassword;

        /////////////////////

        function login(){
            LoginSvc.authenticate(vm.user);  
        }

        function register(){
        	toastr.error('Feature not implemented yet!');
        }

        function resetPassword(){
            toastr.error('Feature not implemented yet!');
        }


    }



})();
