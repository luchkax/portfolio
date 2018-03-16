var app = angular.module('app', ['ngRoute', 'ngMaterial']);

app.controller('ctrl', ['$scope']);
app.controller('pController', ['$scope']);
app.controller('pFormController', ['$scope']);
app.controller('pFormEditController', ['$scope']);
app.controller('EditCompanyController', ['$scope']);

app.config(function($routeProvider, $locationProvider){
    $routeProvider.when('/list', {
        templateUrl: '/Templates/list.html',
        controller: 'pController'
    })
    $routeProvider.when('/form', {
        templateUrl: '/Templates/Form.html',
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
