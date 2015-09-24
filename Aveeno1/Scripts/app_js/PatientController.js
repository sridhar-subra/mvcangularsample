app.controller("PatientController", function ($scope, $http, $location, $routeParams) {
    var apiBaseAddress = "http://localhost:19361/";   
    var onLoadAllPatientsComplete = function (response) {
        $scope.statusMessage = "";
        $scope.Patients = response.data;
    };

    var onLoadAllPatientsError = function (response)
    {    
        $scope.statusMessage = response.data.exceptionMessage;
    }

    $scope.loadAllPatients = function () {
        $scope.statusMessage = "Loading patient data, please wait...";
        $http.get(apiBaseAddress + "api/patient").then(onLoadAllPatientsComplete, onLoadAllPatientsError);
    }

    $scope.statusMessage = "";
    $scope.formStatus = "Insert";

    $scope.clearPatient=function(){
        $scope.patient = null;
        $scope.statusMessage = "";
        $scope.formStatus = "Insert";
    }

    $scope.insertPatient = function () {       
        if ($scope.patientForm.$invalid)
            return;
        if ($routeParams.id == null || $scope.formStatus=="Insert") {
            //insert
            return $http.post(apiBaseAddress + "api/patient", $scope.patient)
                .then(function (response) {
                    $scope.patient.patientId = response.data;
                    $scope.statusMessage = "Inserted Sucessfully";
                    $scope.formStatus = "Update";
                },
                function (response) {
                    if (response.status == 500)
                        $scope.statusMessage = response.data.exceptionMessage;
                }
                )
        }
        else
        {
            //update
            return $http.put(apiBaseAddress + "api/patient/" + $routeParams.id, $scope.patient)
                .then(function (response) {                    
                    $scope.statusMessage = "Updated Sucessfully";
                },
                function (response) {
                    if (response.status == 500)
                        $scope.statusMessage = "Unable to save.."
                }
                )

        }
    }

    $scope.getPatient = function () {
        if ($routeParams.id == null)
            return;
        $http.get(apiBaseAddress + "api/patient/" + $routeParams.id).then(
            function (response) {
                $scope.patient = response.data;
                $scope.formStatus = "Update";
            },
            function (response) {
                if (response.status == 500)
                    $scope.statusMessage = response.data.exceptionMessage;
            }
            )
    }

    $scope.deletePatient = function () {
        bootbox.confirm("Are you sure you want to delete ?", function (result) {
            if (result) {
                $http.delete(apiBaseAddress + "api/patient/" + $routeParams.id).then(
                function (response) {
               $scope.patient = null;
               $scope.formStatus = "Insert";
                },
                function (response) {
                if (response.status == 500)
                   $scope.statusMessage = response.data.ExceptionMessage;
                }
           )
            }
        });
 
    }

    $scope.getChartData = function () {
        $scope.statusMessage = "Loading chart, please wait.."
        $http.get(apiBaseAddress + "api/statistics").then(
            function (response) {
                $scope.statusMessage = "";
                patientChart.drawChart(response.data);                
            },
            function (response) {
                if (response.status == 500)
                    $scope.statusMessage = response.data.exceptionMessage;
            }
            )
    }

    $scope.getAllLogs = function () {
        $scope.statusMessage ="Loading, please wait.."
        $http.get(apiBaseAddress + "api/log").then(
            function (response) {
                $scope.statusMessage = "";
                $scope.logs = response.data;
            },
            function (response) {
                if (response.status == 500)
                    $scope.statusMessage = response.data.exceptionMessage;
            }
            )
    }
  
});