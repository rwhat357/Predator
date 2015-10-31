(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('LoginCtrl', LoginCtrl);

    function LoginCtrl(toastr, $state, LoginSvc) {

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
        	toastr.success('Successfully logged in!');
        	LoginSvc.authenticate(vm.user);
        	$state.go('search');
        }


        function register(){
        	toastr.success('Successfully registered!');
        }



    }



})();
