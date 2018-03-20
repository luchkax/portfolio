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
    $routeProvider.when('/employee_form', {
        templateUrl: '/js/SPA/Templates/empForm.html',
        controller: 'pFormController'
    })
    $routeProvider.when('/company_form', {
        templateUrl: '/js/SPA/Templates/compForm.html',
        controller: 'pFormController'
    }) 
  
    $routeProvider.otherwise({
        redirectTo: '/'
    });
    $locationProvider.hashPrefix('');
})
