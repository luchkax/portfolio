var app = angular.module('app', ['ngRoute']);

app.controller('main', ['$scope']);
app.controller('first', ['$scope']);
app.controller('second', ['$scope']);


app.config(function($routeProvider, $locationProvider){
    $routeProvider.when('/', {
        templateUrl: '/first.html',
        controller: 'first'
    });

    $routeProvider.when('/list', {
        templateUrl: '/second.html',
        controller: 'second'
    });

    // $routeProvider.otherwise({
    //     redirectTo: '/'
    // });
})
