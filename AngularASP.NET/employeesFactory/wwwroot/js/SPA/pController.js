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
    })

    $scope.deleteEmployee = function (e){
        var getData = pService.DeleteEmp(e.employeeId);
        console.log(e.employeeId + " controller "+ e.firstName);
        getData.then(function(msg) {
            pService.getInfoEmp().then(function(d){
                $scope.emp = d.data;
            }, function(){
                alert('Failed');
            });
        }, function(){
            alert('Error Occured in the record');
        });
    }
});



