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

    this.DeleteEmp = function(id){
        var req = $http.post('/delete_employee/' + id);
        console.log(req);
        return req;
    }
})