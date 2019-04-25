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
    self.parent = _parent;
    self.products = ko.observableArray([]);
    var ListCategory = [];
    var ListSupplier = [];
    self.init = function () {
        _getProducts();
    };

    function _getProducts() {

        CommonGlobal.connectServer("Get", null, CommonEnum.API_URL.GetProduct,
            function (result) {
                self.products(result.model);
                ListCategory = result.ListCategory;
                ListSupplier = result.ListSupplier;
            });
    };
    self.searchProduct = function () {
        _getProducts();
    };
    self.ViewProduct = function (productId) {
        CommonGlobal.connectServer("Get", { ProductId: productId }, CommonEnum.API_URL.GetProductDetail,
            function (data) {
                self.parent.currentViewModel(new ProductModel(data, self));
                self.parent.isViewDetail(true);
            });

    };
    
    self.InsertProduct = function () {
        var model = new ProductModel({
            ListCategory: ListCategory,
            ListSupplier: ListSupplier,
            ViewCounts:0
        }, self);
        self.parent.currentViewModel(model);
        self.parent.isViewDetail(true);
    };
    self.init();

};