(function() {
    'use strict';

    var app = angular.module('PredatorApp')
        .controller('CommonCtrl', CommonCtrl);

    function CommonCtrl($http, $window, $state, LoginSvc, toastr) {

        var vm = this;
        vm.name = 'Fredy CommonCtrl';

        vm.canSeeHeader = canSeeHeader;
        vm.seeReports = seeReports;
        vm.logout = logout;

        /////////////////////


        function canSeeHeader(){
            return LoginSvc.getIsAuthenticated();
        }

        function seeReports(){
            var data = $.param({
                json: JSON.stringify({
                    isLoggedIn: true
                })
            });

            $http.post("/../reports/index.php", data)
                .success(function (data, status) {
                    $window.open('/../reports/index.php', '_blank');
                    console.log("successfully run post");
                })
                .error(function (response){
                    console.error("Failed to post");
                });
        }

        function logout(){
            LoginSvc.logout();
        }

    }



})();
