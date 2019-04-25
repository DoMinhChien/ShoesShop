﻿
var ProductModel = function (data, parent) {
    var self = this;
    self.products = ko.observableArray([]);
    self.parentViewModel = parent;
    self.Name = ko.observable(data && data.Name ? data.Name: '');
    self.Description = ko.observable(data && data.Description ? data.Description : '');
    self.ListCategory = ko.observableArray(data && data.ListCategory ? data.ListCategory : []);
    self.ListSupplier = ko.observableArray(data && data.ListCategory ? data.ListSupplier : []);
    self.Quantity = ko.observable(data && data.Quantity ? data.Quantity :0);
    self.CategoryId = ko.observable(data && data.CategoryId ? data.CategoryId  : 0);
    self.SupplierId = ko.observable(data && data.SupplierId  ?data.SupplierId : null);
    self.Id = ko.observable(data && data.Id  ? data.Id : null);
    self.StatusId = ko.observable(data && data.StatusId ? data.StatusId :1);

    self.UnitInStock = ko.observable(data && data.UnitInStock ? data.UnitInStock  : 0);
    self.UnitPrice = ko.observable(data && data.UnitPrice ? data.UnitPrice : 0);
    self.ViewCounts = ko.observable(data && data.ViewCounts ? data.ViewCounts : 0);
    self.ReturnToList = function () {
        //self.parentViewModel.searchProduct();
        self.parentViewModel.parent.isViewDetail(false);


    };
    self.ToggleSwitch = function ()
        {
        var a = 0;
        };
    self.UpdateProduct = function () {
        let url = "";
        if (self.Id()) {
            url = CommonEnum.API_URL.UpdateProduct;
            
        }
        else {
            url = CommonEnum.API_URL.InsertProduct;
        }
        var model = self.toJSON();
        CommonGlobal.connectServer("POST", { Input: model }, url,
            function (data) {
                CommonGlobal.showSuccessMessage('Test Common',  '/Product/Index');
            });


    };
    self.DeleteProduct = function (productId) {
        CommonGlobal.showConfirmMessage('warning',
            function () {
                CommonGlobal.connectServer("POST", { ProductId: productId }, CommonEnum.API_URL.DeleteProduct,
                    function (data) {
                        CommonGlobal.showSuccessMessage('Deleted', '/Product/Index');
                    });
            });

        
    };


    ProductModel.prototype.toJSON = function () {
        return {
            CategoryId: $('#dropdownCategory').val(),
            SupplierId: $('#dropdownSupplier').val(),
            Id: ko.utils.unwrapObservable(self.Id()),
            Name: ko.utils.unwrapObservable(self.Name()),
            //CategoryId: ko.utils.unwrapObservable(self.CategoryId()),
            //SupplierId: ko.utils.unwrapObservable(self.SupplierId()),
            Description: ko.utils.unwrapObservable(self.Description()),
            Quantity: ko.utils.unwrapObservable(self.Quantity()),
            UnitPrice: ko.utils.unwrapObservable(self.UnitPrice()),
            ViewCounts: ko.utils.unwrapObservable(self.ViewCounts())
        };

    };
};
