(function() {
    'use strict';

    angular
    	.module('PredatorApp')
    	.factory('LoginSvc',  LoginSvc);

    function LoginSvc($cookieStore, $state){
    	
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

                // Put cookie
                $cookieStore.put('predator_username', user.username);
                $cookieStore.put('predator_password', user.password);
        	}

        }

        function getUserInfo(){
        	return userInfo;
        }

        function getIsAuthenticated(){

            // Get cookie
            var PredatorLoginCookie = $cookieStore.get('predator_username');

            if ( PredatorLoginCookie === 'admin' ) {
                //$state.go('search');
                return true;
            } 

            //$state.go('login');
            return false;
        }


    }

})();
