eventModule.controller("eventController", function($scope, $http) {
    var baseLink = $("#baseLink").data("value");
    var userId = $("#userId").data("value");
    var apiLink = "http://" + baseLink + "/api/buy/items/" + userId;
    $http.get(apiLink)
        .success(function (response) { $scope.items = response; });
    //0:  {
    //    itemId: 2
    //    name: "coffee bean"
    //    descrption: "good coffee bean"
    //    imageUrl: "http://www.support4change.com/blog/wp-content/uploads/2012/04/coffee-bean.jpg"
    //    holdLongLessThanDay: "01:00:00"
    //    holdLongDay: 3
    //    buyerName: null
    //    contact: null
    //    token: null
    //    holdTime: null
    //}
});