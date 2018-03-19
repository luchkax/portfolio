var app = angular.module('app', ['ngRoute', 'ngMaterial']);

app.controller('ctrl', ['$scope']);
app.controller('pController', ['$scope']);
app.controller('pFormController', ['$scope']);
app.controller('pFormEditController', ['$scope']);
app.controller('EditCompanyController', ['$scope']);

app.config(function($routeProvider,$httpProvider, $locationProvider){

    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }

    $routeProvider.when('/list', {
        templateUrl: '/js/SPA/Templates/list.html',
        controller: 'pController'
    })
    $routeProvider.when('/Form', {
        templateUrl: '/js/SPA/Templates/Form.html',
        controller: 'pFormController'
    })
    // $routeProvider.when('/editCompany', {
    //     templateUrl: 'Views/editCompany.html',
    //     controller: 'FormEditController'
    // }) 
  
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    $locationProvider.hashPrefix('');
})
