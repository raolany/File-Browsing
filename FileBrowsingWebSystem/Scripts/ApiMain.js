var app = angular.module('FileBrowsingApp', []);

app.controller('AppController', function ($scope, $http) {

    $http.get("/api/path/")
        .success(function (response) {

            $scope.host = response.Host;
            $scope.pathlist = response.PathList;
            $scope.dirs = response.Dirs;
            $scope.files = response.Files;

        }, function errorCallback(response) {

            console.log("error", response);
        });

    $scope.dirClick = function (dir) {

        var fullpath = $scope.pathlist.toString().replace(/,/g, "/");
        fullpath = (fullpath.length !== 0) ? fullpath + "/" : fullpath;

        $http.get("/api/path/?path=" + fullpath + dir)
            .success(function (response) {

                $scope.host = response.Host;
                $scope.pathlist = response.PathList;
                $scope.dirs = response.Dirs;
                $scope.files = response.Files;

                console.log(response);

            },
            function errorCallback(response) {
                console.log("error", response);
        });
    }

    $scope.pathClick = function (index) {
        var fullpath = "/";

        if (index !== -1) {
            fullpath = $scope.pathlist.slice(0, index+1).toString().replace(/,/g, "/");
        }
        //fullpath = (fullpath.length !== 0) ? fullpath + "/" : fullpath;

        $http.get("/api/path/?path=" + fullpath)
            .success(function(response) {

                $scope.host = response.Host;
                $scope.pathlist = response.PathList;
                $scope.dirs = response.Dirs;
                $scope.files = response.Files;

                console.log(response);

            },
            function errorCallback(response) {
                console.log("error", response);
        });
    }

});

function getDir(dir) {
    
}