



app.service('productService', function ($http) {

    this.GetPhoneList = function () {


        return $http({

            method: "Get",
            url: "/GetData.aspx?q=2&pr=p", //product = phone
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {

            data = eval('(' + JSON.stringify(data) + ')');
            //alert(data);
            //alert('success' + JSON.stringify(data))
        }).error(function (data) {

            alert('failed' + JSON.stringify(data));

        });
    };

    this.getProductCount = function () {

        return $http({
            method: "GET",
            url: "/GetData.aspx?q=3", //Product Count
            headers: { 'Content-Type': 'application/json' },
        }).success(function (data) {
           

        }).error(function (data) {

            alert(JSON.stringify(data));
        });

    };


    this.GetPhonesByFilter = function (Name, prTypeP, prTypeT) {

        var jsonData = JSON.stringify(
            {
                n: Name,
                TP: prTypeP,
                TT: prTypeT
            }
        );

        alert(jsonData)
        return $http({

            method: "POST",
            url: '/GetPhoneByFilter',
            dataType: "json",
            header: {
                "Content-Type": "application/json; charset=utf-8"
            },

            param: jsonData

            //param: { n: name, TP: prTypeP, TT: prTypeT }

           
        }).success(function (response) {
            $scope.response = response;
            alert(param + 'success');


            }).error(function (error) {

                alert(param + 'error');
            $scope.error = error;
        });

       
    }


   // var Indata = { param: 'val1', .....}
   // $http({
     //   url: "time.php",
     //   method: "POST",
     //   params: Indata
   // })

})


