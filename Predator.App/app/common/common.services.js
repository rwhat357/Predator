(function() {
    'use strict';

    angular
    	.module('common.services', ['ngResource'])
    	.constant('appSettings',
    		{
    			serverPath: 'http://localhost:80/Predator.Api'
    			//serverPath: 'http://158.158.143.144:80/Predator.Api' // for live server
    		});

})();
