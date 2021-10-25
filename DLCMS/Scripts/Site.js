var app = angular.module('myApp', []);
var baseUrl = '@Url.Content("~/")'
var url = baseUrl + 'Api/AllAPIs';
//$scope.jobID = 0;

app.controller('Jobs', function ($scope, $http) {

    $scope.TitleWP = '';
    $scope.DescriptionWP = '';
    $scope.NameWP = '';
    var baseUrldept = '@Url.Content("~/")';
    var urldept = baseUrldept + 'Api/SubDepartmentApi';


    $scope.deptname = "";
    $scope.subdeptname = "";
    $scope.subsubdeptname = "";
    $scope.subsubsubdeptname = "";

    $scope.changesubDepartment = function () {
        $http({
            method: 'GET',
            url: '/CURD_WebSitePages/getnodesundernode/' + $scope.deptname
        }).then(function mySuccess(response) {
            $scope.SubDepartmentList = response.data;
        }, function myError(response) {
            alert(response.statusText);
        });
    };


    $scope.changesubsubDepartment = function () {
        $http({
            method: 'GET',
            url: '/CURD_WebSitePages/getnodesundernode/' + $scope.subdeptname
        }).then(function mySuccess(response) {
            $scope.SubSubDepartmentList = response.data;
        }, function myError(response) {
            alert(response.statusText);
        });
    };

    $scope.changesubsubsubDepartment = function () {
        $http({
            method: 'GET',
            url: baseUrldept + 'CURD_WebSitePages/getnodesundernode/' + $scope.subsubdeptname
        }).then(function mySuccess(response) {
            $scope.SubSubSubDepartmentList = response.data;
        }, function myError(response) {
            alert(response.statusText);
        });
    };







    $scope.initialise = function (title, description,Name){
        $scope.TitleWP = title;
        $scope.DescriptionWP = description;
        $scope.NameWP = Name;
    };




        $scope.StaffName = "";
    $scope.getReference = function (referenceNumber) {
        $http({
            method: 'GET',
            url: '/Api/AllAPIs',
            params: { ID: referenceNumber }
        }).then(function (response) {
            $scope.myData = response.data;
        });
    };


    $("#Name").blur(function () {
        $("#Filename").val($("#Name").val().replace(/\ /g, '-'));
    });

    //$("#Title").blur(function () {
    //    if ($("#Description").val().length < 1)
    //    {
    //        $("#Page_Title").val($("#Title").val());
    //        $("#Description").val($("#Title").val());
    //        $("#Keywords").val($("#Title").val());
    //    }
    //});

    var url1 = baseUrl + 'Api/StaffList';
    $(".staff").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Api/StaffList',
                data: { ID: request.term },
                dataType: 'json',
                type: 'GET',
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item,
                            value: item
                        }
                    }));
                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    console.log('some error occured', textStatus, errorThrown);
                }
            });
        },
        select: function (event, ui) {
            $(this).val(ui.item.label);
            return false;
        },
        minLength: 2
    });

});