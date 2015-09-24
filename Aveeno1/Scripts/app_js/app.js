var app = angular.module('PatientApp', ["ngRoute"])

app.config(["$routeProvider", "$locationProvider",'$httpProvider',
    function ($routeProvider, $locationProvier, $httpProvider) {
        $routeProvider.caseInsensitiveMatch = true;
        $routeProvider
            .when("/GetAllPatients",{
            templateUrl:"spa/DisplayAllPatients.html",
            controller:"PatientController"
            })
          .when("/newPatient", {
              templateUrl: "spa/NewEditPatient.html",
              controller: "PatientController"
          })
        .when("/Patient/:id", {
            templateUrl: "spa/NewEditPatient.html", 
            controller: "PatientController"
        })
         .when("/default", {
             templateUrl: "spa/DefaultView.html",
             controller: "PatientController",

         })
        .when("/chart", {
            templateUrl: "spa/chart.html",
            controller: "PatientController",
        })
        .when("/log", {
            templateUrl: "spa/DisplayLog.html",
            controller: "PatientController",
        })
         .when("/help", {
             templateUrl: "spa/help.html",
             controller: "PatientController",
         })
         .when("/webapierror", {
             templateUrl: "spa/webapierrorlog.html",
             controller: "PatientController",
         })
        .when("/mvcerror", {
            templateUrl: "spa/mvcerrorlog.html",
            controller: "PatientController",
        })
    }
]);

