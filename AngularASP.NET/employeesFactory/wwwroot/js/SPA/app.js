var app = angular.module('app', ['ngRoute', 'ngMaterial']);

app.controller('ctrl', ['$scope']);
app.controller('pController', ['$scope']);
app.controller('pFormController', ['$scope']);
app.controller('pFormEditController', ['$scope']);
app.controller('EditCompanyController', ['$scope']);

app.config(function($routeProvider, $httpProvider, $locationProvider){
    $routeProvider.when('/list', {
        templateUrl: 'Views/list.cshtml',
        controller: 'pController'
    })
    $routeProvider.when('/form', {
        templateUrl: '/wwwroot/js/SPA/Views/Form.cshtml',
        controller: 'pFormController'
    }) 
    // $routeProvider.when('/editCompany', {
    //     templateUrl: 'Views/editCompany.html',
    //     controller: 'FormEditController'
    // }) 
  
    // $routeProvider.otherwise({
    //     redirectTo: ''
    // });
    // $locationProvider.hashPrefix('');
})
