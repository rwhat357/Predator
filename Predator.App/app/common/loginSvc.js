(function() {
    'use strict';

    angular
    	.module('PredatorApp')
    	.factory('LoginSvc',  LoginSvc);

    function LoginSvc(){
    	
    	var userInfo = {
    		username: '',
    		password: '',
    		email: '',
    		level: ''
    	}

    	var isAuthenticated = false;

    	var service  = {
            authenticate: authenticate,
            getUserInfo: getUserInfo,
            getIsAuthenticated: getIsAuthenticated
        };

        return service;

        ////////////////////////

        function authenticate(user) {

        	//TODO: populate userInfo by checking
        	userInfo = {
        		username: 'admin',
        		password: 'admin',
        		email: 'admin@predator.com',
        		level: 3
        	}

        	if (user.username == 'admin' && user.password == 'admin'){
        		isAuthenticated = true;
        	}

        }

        function getUserInfo(){
        	return userInfo;
        }

        function getIsAuthenticated(){
        	return isAuthenticated;
        }


    }

})();
