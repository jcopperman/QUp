QupApp.controller("projectsCtrl", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/api/Projects'
    }).then(function successCallback(response) {
        debugger;
    }, function errorCallback(response) {
        // called asynchronously if an error occurs
        // or server returns response with an error status.
    });
});