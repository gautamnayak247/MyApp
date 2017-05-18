/// <reference path="../module/hrlConnectApp.js" />
hrlConnectApp.controller("referenceDataManagePeopleController", function ($scope, $http) {

    //get add people screen
    $scope.PartialView = "AddPeople";

 
    //$scope.GetAddPeopleView = function () {
    //    $http({
    //        method: "GET",
    //        url: "/ReferenceData/AddPeople"
    //    }).then(function mySucces() {
    //        console.log("success called");
    //    }, function myError(response) {
    //        $scope.err = response.statusText;
    //    });
    //}

    //get delete people screen
    $scope.GetDeletePeopleView = function () {
        $http({
            method: "GET",
            url: "/ReferenceData/DeletePeople"
        }).then(function mySucces() {
            console.log("success called!");
        }, function myError(response) {
            $scope.err = response.statusText;
        });
    }


});