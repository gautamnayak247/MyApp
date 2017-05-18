hrlConnectApp.controller("addPeopleController", function ($scope, $http) {
    $scope.successMessage = false;
    $scope.errorMessage = true;
    alert("Addpeople controller called");
    $scope.IsProjectDisabled = true;
    $scope.IsSupervisorDisabled = true;


    //Getting Career Level
    $scope.CareerLevel = "";
    $scope.MyDuId = "";
    $http({
        method: "Get",
        url: "/ReferenceData/GetCareerLevel"
    }).then(function mySucces(response) {
        $scope.CareerLevel = response.data;
    }, function myError(response) {
        console.log(response.statusText);
    });

    //Getting Employment Type
    $scope.EmploymentType = "";

    $http({
        method: "Get",
        url: "/ReferenceData/GetEmploymentType"
    }).then(function mySucces(response) {
        $scope.EmploymentType = response.data;
    }, function myError(response) {
        console.log(response.statusText);
    });

    //Getting Du List
    $scope.Du = "";
    $http({
        method: "Get",
        url: "/ReferenceData/GetDu"
    }).then(function mySucces(response) {
        $scope.Du = response.data;
    }, function myError(response) {
        console.log(response.statusText);
    });

    //loading project list based on du Id selected.
    $scope.Project = "";
    $scope.supervisor = "";
    $scope.GetProject = function (selectedDu) {
        $scope.MyDuId = selectedDu.DuId;
        $http({
            method: "Get",
            url: "/ReferenceData/GetProject?duId=" + selectedDu.DuId
        }).then(function mySucces(response) {
            $scope.IsProjectDisabled = false;
            $scope.Project = response.data;
        }, function myError(response) {
            console.log(response.statusText);
        });

        //getting supervisor list
        $http({
            method: "Get",
            url: "/ReferenceData/GetSupervisor?duId=" + selectedDu.DuId
        }).then(function mySucces(response) {
            $scope.IsSupervisorDisabled = false;
            $scope.supervisor = response.data
        }, function myError(response) {
            console.log(response.statusText);
        });
    }


    //inserting to database
    $scope.AddPeoples = function (data) {
        console.log(data);
        var isConfirmed = confirm("Please confirm if you want to add " + data.Name);
        var peopleData = {
            "Name": data.Name, "EnterpriseId": data.EnterpriseId, "Mobile": data.Mobile, "CLFK": data.selectedCareerLevel.CLID, "EmploymentTypeFK": data.selectedEmploymentType.Id,
            "DuId": data.selectedDu.DuId, "ProjectId": data.selectedProject.ProjectId, "SupervisorFK": 1, "AccentureDOJ": data.AccentureDoj, "ProjectDOJ": data.ProjectDoj, "IsActive": data.IsActive,
            "Email": data.Email + "@accenture.com"
        };
        var myData = { people: peopleData };
        console.log(peopleData);
        if (isConfirmed) {
            $http({
                method: "Post",
                url: "/ReferenceData/AddPeoples",
                data: myData
            }).then(function mySucces(response) {
                console.log(response);
                if (response.data) {
                    $scope.successMessage = response.data;
                    $scope.errorMessage = !response.data;
                }
                else {
                    $scope.successMessage = !response.data;
                    $scope.errorMessage = response.data;
                }
            }, function myError(response) {
                $scope.err = response.statusText;
            });
        }
    }//flag values

    //reseting form values
    $scope.ResetAddPeopleForm = function (formModel) {
        angular.copy({}, formModel);
    }
});