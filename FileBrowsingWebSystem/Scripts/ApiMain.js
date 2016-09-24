var app = angular.module('FileBrowsingApp', []);

app.controller('AppController', function ($scope, $http) {

    $http.get("/api/directory/")
        .then(function (response) {

            $scope.pathlist = response.data.PathList;
            $scope.dirs = response.data.Dirs;
            $scope.files = response.data.Files;
        }, function errorCallback(response) {
            console.log("error", response);
        });

    getCountOfFiles("server");

    $scope.dirClick = function (dir) {

        var fullpath = $scope.pathlist.toString().replace(/,/g, "/");
        fullpath = (fullpath.length !== 0) ? fullpath + "/" : fullpath;

        getCountOfFiles(fullpath + dir);

        $http.get("/api/directory/?path=" + fullpath + dir)
            .then(function (response) {

                $scope.pathlist = response.data.PathList;
                $scope.dirs = response.data.Dirs;
                $scope.files = response.data.Files;

                console.log(response);

            },
            function errorCallback(response) {
                console.log("error", response);
        });
    }

    $scope.pathClick = function (index) {
        var fullpath = "";

        if (index === -1) {
            fullpath = "server";
        }
        else {
            fullpath = $scope.pathlist.slice(0, index+1).toString().replace(/,/g, "/");
        }
        getCountOfFiles(fullpath);

        $http.get("/api/directory/?path=" + fullpath)
            .then(function(response) {

                $scope.pathlist = response.data.PathList;
                $scope.dirs = response.data.Dirs;
                $scope.files = response.data.Files;

                console.log(response);

            },
            function errorCallback(response) {
                console.log("Message: " + response.data.ExceptionMessage + "\nError type: " + response.data.ExceptionType);
                //console.log("error", response);
        });
    }

    function getCountOfFiles(path) {
        $http.get("/api/directory/getfiles/?path="+path)
        .then(function (response) {
            $scope.less10 = response.data.FilesLess10;
            $scope.others = response.data.FilesOthers;
            $scope.more100 = response.data.FilesMore100;
        }, function errorCallback(response) {

            $scope.less10 = 0;
            $scope.others = 0;
            $scope.more100 = 0;

            console.log("Message: " + response.data.ExceptionMessage + "\nError type: " + response.data.ExceptionType);
            //console.log("error", response);
        });
    }

});
