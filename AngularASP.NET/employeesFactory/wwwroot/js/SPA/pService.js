app.service("pService", function($http){
    this.getInfo = function(){
        var req = $http.get('/api/companies');
        return req;
    }

    this.getInfoEmp = function(){
        var req = $http.get('/api/employees');
        return req;
    }
})