/// <reference path="../module/hrlConnectApp.js" />

hrlConnectApp.controller("AutoCompleteController", function ($scope) {
    $scope.EnterPriseList = [];
    $scope.SelectedEnterpriseId = null;
    $scope.SelectedName = function (selected) {
        if (selected) {
            $scope.SelectedEnterpriseId = selected.originalObject.Name;
        }
    }
    $scope.EnterPriseList = [{ "Id": 1, "Name": "gautam.nayak" }, { "Id": 2, "Name": "jane.k.sharma" }];
    
});