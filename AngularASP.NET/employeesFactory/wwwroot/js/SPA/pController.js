app.controller('pController', function($scope, pService){
    $scope.word = "Developed by Nazariy Luchka";

    $scope.preGetInfo = pService.getInfo().then(function(d){
        $scope.data = d.data;

        angular.forEach($scope.data, function (obj) {
            obj["showEdit"] = true;
        })
    }, function(){
        alert('Failed');
    });

    $scope.toggleEdit = function (index) {
        $scope.data[index].EditMode = true;

        $scope.EditItem.Name = $scope.data[index].name;
        $scope.EditItem.Email = $scope.data[index].address;
    }

    $scope.updateCompany = function($index) {
        var company = $scope.data[$index]
        console.log(company);
        var getData = pService.updateCompanyPost(company);
        window.location = "/#/", $scope.preGetInfo;
        getData.success(function (data, status) {
        });
    }

    $scope.preGetInfoEmp = pService.getInfoEmp().then(function(d){
        $scope.emp = d.data;

        angular.forEach($scope.emp, function (obj) {
            obj["showEdit"] = true;
        })
    }, function(){
        alert('Failed');
    })

    $scope.EditItem = {};

    $scope.toggleEditE = function (index) {
        $scope.emp[index].EditMode = true;

        $scope.EditItem.Name = $scope.emp[index].firstName;
        $scope.EditItem.Email = $scope.emp[index].email;
        $scope.EditItem.CompanyId = $scope.emp[index].companyId;
    }
    
    $scope.cancelEmployee = function(index) {
        $scope.emp[index].firstName = $scope.EditItem.Name;
        $scope.emp[index].email = $scope.EditItem.Email;
        $scope.emp[index].companyId = $scope.EditItem.CompanyId;

        $scope.emp[index].EditMode = false;
        $scope.EditItem = {};
    }

    $scope.updateEmployee = function($index) {
        var employee = $scope.emp[$index]
        console.log(employee);
        var getData = pService.updateEmployeePost(employee);
        // window.location = "/#/", $scope.preGetInfo;
        getData.success(function (data, status) {
            employee.EditMode = false;
        });
    }

    $scope.deleteEmployee = function (e){
        var getData = pService.DeleteEmp(e.employeeId);
        console.log(e.employeeId + e.firstName);
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

    $scope.deleteCompany = function (i){
        var getCompData = pService.DeleteComp(i.companyId);
        console.log(i.companyId + i.name);
        getCompData.then(function(msg) {
            pService.getInfo().then(function(d){
                $scope.data = d.data;
        
                angular.forEach($scope.data, function (obj) {
                    obj["showEdit"] = true;
                })
            }, function(){
                alert('Failed');
            });
        }, function(){
            alert('Error Occured in the record');
        });
    }
});



