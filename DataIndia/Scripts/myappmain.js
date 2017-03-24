var app = angular.module('mainApp', []);

app.controller('MainCtrl', ['$scope' ,'$http',function($scope,$http)
{
    $scope.message = "Welcome to Angular .NET MVC 5";
    $scope.loadStates = false;

    $scope.GetStatesData = function () {

        $scope.loadStates = true;
        $scope.states = {};
        $http.get('/DataIndia/api/states')
        .then(function onSuccess(response)
        {
                
            $scope.states = response.data;
        })
        .catch(function onError(response) {
            $scope.ResponseDetails = "Data: " + data +
                "<br />status: " + status +
                "<br />headers: " + (header) +
                "<br />config: " + (config);
        });


    };


  
}]);
