eventModule.controller("eventController", function ($scope, $http) {
    var baseLink = $("#baseLink").data("value");
    var userId = $("#userId").data("value");
    var apiLink = "http://" + baseLink + "/api/buy/items/" + userId;
   // $http.get("http://localhost:49883/api/buy/items/74e8220e-35e1-440e-8308-71820009916c")
    $http.get(apiLink)
    .success(function(response) {$scope.items = response;});
});

