var ProductListFormViewModel = function () {
    var self = this;
    self.viewListTemplate = ko.observable('product-List');
    self.viewDetailTemplate = ko.observable('product-Detail');
    self.isViewDetail = ko.observable(false);
    self.currentViewModel = ko.observable(null);

    self.productListViewModel = new ProductListViewModel(self);

};


var ProductListViewModel = function (parent) {
    var self = this;
    self.parent = parent;
    self.products = ko.observableArray([]);

    self.init = function () {
        $.ajax({
            type: "Get",
            url: CommonEnum.API_URL.GetProduct,
            //beforeSend: function () {
            //    $('#loader').show();
            //},
            // data: { Input: Input },
            success: function (result) {
                self.products(result);

            },
            complete: function () {
                $('#loader').hide();
            }
        });
    };
    self.ViewProduct = function (productId) {
        self.parent.isViewDetail(true);
    };


    self.init();

};