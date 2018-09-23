
'use strict'

app.controller('phoneController', function (productService) {

    var vm = this;
    vm.message = "Golriz";
    alert(1);
    var promiseGet = productService.GetPhoneList();

    promiseGet.then(function (p1) {vm.phones = p1.data },
        
        function (errorP1) { alert('Failure Loading!' + errorP1) })



    vm.SearchPhoneByFilter = function () {

        alert(vm.Name + " " + vm.PrTypeP + " " + vm.PrTypeT+ "123");
        var GetSearchResult = productService.GetPhonesByFilter(vm.Name, vm.PrTypeP, vm.PrTypeT);

    }

    
})

  

app.filter("jsDate", function () {

    return function (x) {
        if (x !== null)
            return new Date(parseInt(x.substr(6)));
        else
            return '';
    };


});





