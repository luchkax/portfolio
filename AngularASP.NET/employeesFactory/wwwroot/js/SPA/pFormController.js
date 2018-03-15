app.controller('pFormController', function($scope, pService){
    $scope.data = null;
    $scope.company = null;
     $scope.companies = null;

    pService.getInfo().then(function(d){
        $scope.data = d.data;
    }, function(){
        alert('Failed');
    });

    $scope.loadUsers = function() {
        var arr = [];
        angular.forEach($scope.data, function(value, key){
        arr.push({ id: value.companyId, name: value.name })
        return arr;
        })
    };

    $scope.submitForm = function() {
        var Person = {};
        Person.FirstName = $scope.FirstName;
        Person.LastName = $scope.LastName;
        Person.Email = $scope.Email;
        Person.CompanyId = $scope.CompanyId;

        var promisePost = pService.postForm(Person);
        console.log($scope.CompanyId);
    }, function (err) {
        alert("Some error occured");
    };
})