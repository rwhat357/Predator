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

        /////////////////////

        function login(){
            LoginSvc.authenticate(vm.user);

            if (LoginSvc.getIsAuthenticated()){
                $state.go('search');
                toastr.success('Successfully logged in!');
            } else {
                toastr.error('Username or password was incorrect!');
                $state.go('login');
            }
            
        }

        function register(){
        	toastr.error('Feature not implemented yet!');
        }



    }



})();
