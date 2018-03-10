// MODULE
var app = angular.module('app', ['ngRoute']);

// app.controller('pController', pController);

app.controller('pController',  function($scope){
    $scope.data = null;
    $scope.word = "hello world";
});