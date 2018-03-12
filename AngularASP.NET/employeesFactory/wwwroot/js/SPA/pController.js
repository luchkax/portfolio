app.controller('pController', function($scope, pService){
    $scope.data = null;
    $scope.word = "hello world";

pService.getInfo().then(function(d){
        $scope.data = d.data;
    }, function(){
        alert('Failed');
    });

    pService.getInfoEmp().then(function(d){
        $scope.emp = d.data;
    }, function(){
        alert('Failed');
    });
});
pController.$inject = ['$scope'];

// var pController =  function($scope){
//     $scope.data = null;
//     $scope.word = "hello world";
// };


