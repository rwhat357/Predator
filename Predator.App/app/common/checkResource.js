(function() {
    'use strict';

    angular
    	.module('common.services')
    	.factory('checkResource',  checkResource);

    function checkResource($resource, appSettings){
    	return $resource(appSettings.serverPath + '/api/check/:id');
    }

})();
