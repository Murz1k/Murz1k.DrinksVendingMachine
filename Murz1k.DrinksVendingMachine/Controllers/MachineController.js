function play() {
    var audio = document.getElementById("audio");
    audio.play();
}

var app = angular.module("app", []);

app.controller("MachineController", function ($scope) {
    $scope.totalMoney = 0;
    $scope.lastMoney = 0;
    $scope.load = function () {
        $scope.Refresh();
    };
    $scope.giveMoney = function () {
        $scope.lastMoney = $scope.totalMoney;
        $scope.totalMoney = 0;
        alert("Ваша сдача: " + $scope.lastMoney + " руб.");
    };
    $scope.Refresh = function () {
        $.ajax({
            url: "/Home/GetAll",
            type: "post",
            dataType: "json",
            contentType: "application/json",
            success: function (beverages) {
                $scope.beverages = beverages;
                $.ajax({
                    url: "/Admin/GetAllCoins",
                    type: "post",
                    dataType: "json",
                    contentType: "application/json",
                    success: function (coins) {
                        $scope.coins = coins;
                        $scope.$applyAsync();
                    }
                });
            }
        });
    };
    $scope.buyBeverage = function (id, price) {
        $scope.totalMoney -= price;
        $.ajax({
            url: "/Home/BuyBeverage",
            data: { id: id },
            type: "post",
            dataType: "html",
            success: function()
            {
                $scope.Refresh();
            }
        });
    };
    $scope.addCoin = function (value) {
        $scope.totalMoney += value;
    };
});