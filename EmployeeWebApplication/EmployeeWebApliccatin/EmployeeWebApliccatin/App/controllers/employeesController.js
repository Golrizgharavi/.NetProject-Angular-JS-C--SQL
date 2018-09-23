

'use strict';

app.controller('employeesController', function (employeeService) {


    var vm = this;
    vm.message = "Micreez Team";

    var promiseGet = employeeService.GetEmployeesList();

    promiseGet.then(function (p1) { vm.employees = p1.data },

        function (errorP1) { alert('Failure Loading!' + errorP1) })





});


app.filter("jsDate", function () {
    
    return function (x) {
        if (x !== null)
            return new Date(parseInt(x.substr(6)));
        else
            return '';
    };
   
   
});