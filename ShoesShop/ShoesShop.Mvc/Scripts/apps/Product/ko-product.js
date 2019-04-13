var ProductListFormViewModel = function () {
    var self = this;
    self.viewListTemplate = ko.observable('product-List');
    self.viewDetailTemplate = ko.observable('product-Detail');
    self.isViewDetail = ko.observable(false);
    self.currentViewModel = ko.observable(null);

    self.productListViewModel = new ProductListViewModel(self);

};


var ProductListViewModel = function (_parent) {
    var self = this;
    var parent = _parent;
    self.products = ko.observableArray([]);

    self.init = function () {

        CommonGlobal.connectServer("Get", null, CommonEnum.API_URL.GetProduct,
            function (result) {
                self.products(result);
            });
    };

    self.ViewProduct = function (productId) {
        CommonGlobal.connectServer("Get", { productId: productId}, CommonEnum.API_URL.GetProductDetail,
            function (data) {
                parent.currentViewModel(new ProductModel(data, self));
                parent.isViewDetail(true);
            });
        
    };


    self.init();

};