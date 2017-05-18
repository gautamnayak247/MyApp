/// <reference path="../module/hrlConnectApp.js" />
hrlConnectApp.controller('reportController', function ($scope, $http) {
    $scope.IsSearchByEnterpriseId = false;
    //$scope.DuNames = "";

    //getDuNames
    $http({
        method: "GET",
        url: "/Report/GetDuNames"
    }).then(function mySucces(response) {
        $scope.DuNames = response.data;
    }, function myError(response) {
        $scope.err = response.statusText;
    });

    //Get UnmappedPeopleList
    $scope.GetUnmappedPeopleList = function (duSelected) {
        $http({
            method: "GET",
            url: "/Report/GetActiveUnmappedPeople?duId=" + duSelected.DuId
        }).then(function mySucces(response) {
            $scope.UnmappedPeopleList = response.data;
            $scope.IsUnmappedPeopleDataAvailable = true;
            console.log($scope.UnmappedPeopleList);
        }, function myError(response) {
            $scope.err = response.statusText;
        });
    }

    $scope.GetReportDetails = function (itemChosen) {
        if (itemChosen == "ActiveUnMappedPeople") {
            $scope.IsSearchByEnterpriseId = false;
            $scope.IsSearchByDuName = true;
            $scope.IsUnmappedPeopleDataAvailable = false;
        }
        else {
            $scope.IsSearchByEnterpriseId = true;
            $scope.IsSearchByDuName = false;
        }
    }

    $scope.GetReportData = function (reportName, duName) {
        alert(reportName);
        alert(duName.DuName);
    }
    $scope.ConnectsIDone = function () {

    }


});
