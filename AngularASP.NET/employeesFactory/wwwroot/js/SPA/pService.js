app.service("pService", function($http){
    this.getInfo = function(){
        var req = $http.get('/api/companies');
        return req;
    }

    this.getInfoEmp = function(){
        var req = $http.get('/api/employees');
        return req;
    }

    this.postForm = function(Person){
        var req = $http.post('/addEmployee', Person);
        return req;
    }

    this.postCompanyForm = function(Company){
        var req = $http.post('/addCompany', Company);
        return req;
    }

    this.updateCompanyPost = function(Company){
        var req = $http.post('/updateCompany', Company)
        return req;
    }

    this.updateEmployeePost = function(Employee){
        var req = $http.post('/update_employee', Employee)
        return req;
    }

    this.DeleteEmp = function(id){
        var req = $http.post('/delete_employee/' + id);
        console.log(req);
        return req;
    }

    this.DeleteComp = function(id){
        var req = $http.post('/delete_company/' + id);
        console.log(req);
        return req;
    }
})