var app = angular.module("app", []);

app.controller("AdminController", function ($scope) {
    $scope.load = function () {
        $scope.Refresh();
    };
    $scope.path = "/Content/Images/";
    $scope.loadImage = function (input) {
        $scope.$applyAsync(function () {
            var photofile = input.files[0];
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById("image").src = e.target.result;
                var data = new FormData();
                data.append("file", photofile);
                $scope.file = data;
                $scope.filePath = $scope.path + photofile.name;
            };
            reader.readAsDataURL(photofile);
        });
    };
    $scope.dragOver = function (input) {
        evt.stopPropagation();
        evt.preventDefault();
        evt.dataTransfer.dropEffect = 'copy';
    };
    $scope.fileSelect = function (input) {
        $scope.$applyAsync(function () {
            input.stopPropagation();
            input.preventDefault();

            var files = input.dataTransfer.files;
            var photofile = files[0];
            var reader = new FileReader();
            reader.onload = function (e) {
                document.getElementById("image").src = e.target.result;
                var data = new FormData();
                data.append("file", photofile);
                $scope.file = data;
                $scope.filePath = $scope.path + photofile.name;
            };
            reader.readAsDataURL(photofile);

        });
    };
    $scope.SaveImage = function () {
        $scope.currentBeverage.ImagePath = $scope.filePath;
        $.ajax({
            type: "POST",
            url: '/Admin/SaveImage',
            contentType: false,
            processData: false,
            data: $scope.file
        });
    };
    $scope.Refresh = function () {
        $scope.clear();
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
    $scope.currentBeverage = {
        Id: -1,
        Title: "",
        Count: -1,
        Price: -1,
        ImagePath: ""
    };
    $scope.currentCoin = {
        Id: -1,
        Value: 0,
        Count: -1,
        IsLocked: true
    };
    $scope.addCoin = function () {
        if (confirm("Вы точно хотите добавить монету?"))
            $.ajax({
                url: "/Admin/AddCoin",
                data: { coin: $scope.currentCoin },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.editCoin = function () {
        if ($scope.currentCoin.Id < 0) {
            alert("Выберите монету.");
            return 0;
        }
        if (confirm("Вы точно хотите изменить монету?"))
            $.ajax({
                url: "/Admin/EditCoin",
                data: { id: $scope.currentCoin.Id, coin: $scope.currentCoin },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.deleteCoin = function () {
        if ($scope.currentCoin.Id < 0) {
            alert("Выберите монету.");
            return 0;
        }
        if (confirm("Вы точно хотите удалить монету?"))
            $.ajax({
                url: "/Admin/DeleteCoin",
                data: { id: $scope.currentCoin.Id },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.addBeverage = function () {
        if (confirm("Вы точно хотите добавить напиток?"))
            $scope.SaveImage();
            $.ajax({
                url: "/Admin/Add",
                data: { beverage: $scope.currentBeverage },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.editBeverage = function () {
        if ($scope.currentBeverage.Id < 0) {
            alert("Выберите напиток.");
            return 0;
        }
        if (confirm("Вы точно хотите изменить напиток?"))
            $.ajax({
                url: "/Admin/Edit",
                data: { id: $scope.currentBeverage.Id, beverage: $scope.currentBeverage },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.deleteBeverage = function () {
        if ($scope.currentBeverage.Id < 0) {
            alert("Выберите напиток.");
            return 0;
        }
        if (confirm("Вы точно хотите удалить напиток?"))
            $.ajax({
                url: "/Admin/Delete",
                data: { id: $scope.currentBeverage.Id },
                type: "post",
                dataType: "html",
                success: function () {
                    $scope.Refresh();
                }
            });
    };
    $scope.clear = function () {
        $scope.currentBeverage = {
            Id: -1,
            Title: "",
            Count: -1,
            Price: -1,
            ImagePath: ""
        };
    };
    $scope.clearCoin = function () {
        $scope.currentCoin = {
            Id: -1,
            Value: -1,
            Count: -1,
            IsLocked: true
        };
    };
    $scope.chooseBeverage = function (beverage) {
        $scope.currentBeverage = {
            Id: beverage.Id,
            Title: beverage.Title,
            Count: beverage.Count,
            Price: beverage.Price,
            ImagePath: beverage.ImagePath
        };
    };
    $scope.chooseCoin = function (coin) {
        $scope.currentCoin = {
            Id: coin.Id,
            Count: coin.Count,
            IsLocked: coin.IsLocked,
            Value: coin.Value
        };
    };
});