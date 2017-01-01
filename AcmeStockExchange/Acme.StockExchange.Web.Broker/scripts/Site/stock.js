var my = my || {};

my.stockButtonName = function (name) {
    $("#btnStock").html("<span class='glyphicon glyphicon-floppy-disk'></span> " + name + " stock");
}

my.focusTransaction = function () {
    $("input:text:visible:first").focus();
}

my.stock = function () {
    var self = this;

    self.Id = ko.observable();
    self.TickerSymbol = ko.observable();
    self.OfferingAmount = ko.observable();
    self.OfferingPrice = ko.observable();

    self.map = function (stockDto) {
        ko.mapping.fromJS(stockDto, null, self);
    }

    self.reset = function () {
        self.Id(null);
        self.TickerSymbol(null);
        self.OfferingAmount(null);
        self.OfferingPrice(null);
        my.stockButtonName("Add");
        my.focusTransaction();
    }
}

my.stockViewModel = (function () {
    var stock = new my.stock();
    var stocks = ko.observableArray([]);

    upsertStock = function () {
        if (!$("#frmStock").valid())
            return;

        var dataObject = ko.toJSON(stock);
        
        if (stock.Id()) {
            $.ajax({
                url: "/api/stock/",
                type: "put",
                data: dataObject,
                contentType: "application/json",
                success: function (updatedStock) {
                    updateStock(ko.mapping.fromJS(updatedStock));

                    setSuccessNoty("updated stock " + stock.TickerSymbol());
                    stock.reset();
                    my.focusTransaction();
                },
                error: function (error) {
                    setErrorNoty(error);
                }
            });
        } else {
            $.ajax({
                url: "/api/stock",
                type: "post",
                data: dataObject,
                contentType: "application/json",
                success: function (newStock) {
                    addStock(ko.mapping.fromJS(newStock));

                    setSuccessNoty("created application " + newStock.TickerSymbol);
                    stock.reset();
                    focusTransaction();
                },
                error: function (error) {
                    setErrorNoty(error);
                }
            });
        };
    };

    deleteStock = function (stock) {
        var message = "stock " + stock.TickerSymbol();
        removeConfirmation(message).then(function (isConfirmed) {
            if (isConfirmed) {
                $.ajax({
                    url: "/api/stock/" + stock.Id(),
                    type: "delete",
                    contentType: "application/json",
                    success: function () {
                        stocks.remove(stock);
                        sortStocks();
                        setSuccessNoty("deleted " + message);
                        my.focusTransaction();
                    },
                    error: function (error) {
                        setErrorNoty(error);
                    }
                });
            }
        });
    };

    editStock = function (stockDto) {
        stock.map(stockDto);
        my.stockButtonName("Update");
        my.focusTransaction();
    };

    getStocks = function () {
        $.getJSON("api/stock", function (serverStocks) {
            ko.mapping.fromJS(serverStocks, null, stocks);
            sortStocks();
        });
    };

    addStock = function (stock) {
        stocks.push(stock);
        sortStocks();
    };

    sortStocks = function () {
        stocks.sort(function (left, right) { return left.TickerSymbol === right.TickerSymbol() ? 0 : (left.TickerSymbol < right.TickerSymbol() ? -1 : 1) });
    };

    updateStock = function (stock) {
        stocks.remove(function (availableStock) { return availableStock.Id() === stock.Id() });
        stocks.push(stock);
        sortStocks();
    }

    return {
        DeleteStock: deleteStock,
        EditStock: editStock,
        GetStocks: getStocks,
        SelectedStock: stock,
        Stocks: stocks,
        UpsertStock: upsertStock
    };
})();

my.stockValidation = {
    rules: {
        iptTickerSymbol: {
            lettersOnly: true,
            required: true
        },
        iptOfferingAmount: {
            digits: true,
            greaterThan: 0,
            required: true
        },
        iptOfferingPrice: {
            greaterThan: 0,
            number: true,
            required: true
        }
    },
    messages: {
        iptTickerSymbol: {
            lettersOnly: "Ticker symbol can only have letters",
            required: "Ticker symbol is required"
        },
        iptOfferingAmount: {
            digits: "Offering amount must be an integer number",
            greaterThan: "Offering amount must be greater zero",
            required: "Offering amount is required"
        },
        iptOfferingPrice: {
            greaterThan: "Offering price must be greater zero",
            number: "Offering price must be a decimal number",
            required: "Offering price is required"
        }
    }
}

$(function () {
    $.validator.addMethod("greaterThan", function (value, element, parameter) {
        return value > parameter;
    });
    $.validator.addMethod("lettersOnly", function (value, element, parameter) {
        return value.match(new RegExp("^[a-zA-Z]+$"));
    });

    $("#frmStock").validate(my.stockValidation);

    $("#stocksTable").DataTable({
        "aoColumnDefs": [
            { "bSearchable": false, "aTargets": [0, 4] },
            { "bSortable": false, "aTargets": [0, 4] }
        ],
        "bInfo": false,
        "autoWidth": false
    });

    ko.applyBindings(my.stockViewModel);
    my.stockViewModel.GetStocks();
    my.focusTransaction();
});