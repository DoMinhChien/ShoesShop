var HomeFormViewModel = function () {
    var self = this;

    self.viewListTemplate = ko.observable('home-List');
    self.viewDetailTemplate = ko.observable('home-Detail');
    self.isViewDetail = ko.observable(false);
    self.currentViewModel = ko.observable(null);
    
    //self.homeViewModel = new HomeViewModel(self);
    self.Products = ko.observableArray([]);
    CommonGlobal.connectServer("Get", null, CommonEnum.API_URL.GetProduct,
        function (data) {
            self.Products(data.rows);
        });

    self.sizeId = ko.observable(1);
    self.QuickView = function (productId) {
        CommonGlobal.connectServer("Get", { ProductId: productId }, CommonEnum.API_URL.GetProductDetail,
            function (data) {
                self.currentViewModel(new ProductModel(data, self));
               // e.preventDefault();
                $('.js-modal1').addClass('show-modal1');

            });
    };
};

