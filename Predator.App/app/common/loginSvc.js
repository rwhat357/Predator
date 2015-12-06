(function() {
    'use strict';

    angular
    	.module('PredatorApp')
    	.factory('LoginSvc',  LoginSvc);

    // https://docs.angularjs.org/api/ngCookies/service/$cookieStore#example
    // http://www.w3schools.com/js/js_cookies.asp
    function LoginSvc( $cookieStore, $state, $http, appSettings, toastr ){
    	
    	var loggedInUser = '';
    	var service  = {
            authenticate: authenticate,
            getUserInfo: getUserInfo,
            getIsAuthenticated: getIsAuthenticated,
            logout: logout
        };

        return service;

        ////////////////////////

        function authenticate(user) {

            var users; 

            $http.get(appSettings.serverPath + '/api/staff')
                .success(function(data) {
                    users = data;

                    var foundUser = _.find(users, function(_user){
                        return ( _user.username == user.username && _user.password == user.password );
                    });

                    if (foundUser == undefined){
                        toastr.error('Username or password was incorrect!');
                        $state.go('login');
                    } else {
                        loggedInUser = foundUser.username;

                        // Put cookie
                        $cookieStore.put('predator_username', user.username);
                        $cookieStore.put('predator_password', user.password);

                        $state.go('search');
                        toastr.success('Successfully logged in!');
                    }

                });
        }

        function getUserInfo(){
        	return userInfo;
        }

        function getIsAuthenticated(){

            // Get cookie
            var PredatorLoginCookie = $cookieStore.get('predator_username');

            if ( PredatorLoginCookie ) {
                return true;
            } 
            return false;
        }

        function logout(){
            // https://docs.angularjs.org/api/ngCookies/service/$cookieStore#example
            // Removing a cookie
            loggedInUser = '';
            $cookieStore.remove('predator_username');
            $cookieStore.remove('predator_password');

            $state.go('login');
            toastr.success('Successfully logged out!');
        }
    }

})();
