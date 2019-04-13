
var ProductModel = function (data, parent) {
    var self = this;
    self.products = ko.observableArray([]);
    self.parentViewModel = parent;
    self.Name = ko.observable(data.Name || '');
    self.Description = ko.observable(data.Description || '');
    self.ListCategory = ko.observableArray(data.ListCategory || []);
    self.ListSupplier = ko.observableArray(data.ListSupplier || []);
    self.Quantity = ko.observable(data.Quantity || 0);
    self.CategoryId = ko.observable(data.CategoryId || 0);
    self.Id = ko.observable(data.Id || null);
    self.StatusId = ko.observable(data.StatusId || 0);
    self.SupplierId = ko.observable(data.SupplierId || null);
    self.UnitInStock = ko.observable(data.UnitInStock || 0);
    self.UnitPrice = ko.observable(data.UnitPrice || 0);
    self.ViewCounts = ko.observable(data.ViewCounts || 0);
   
    self.SaveProduct = function () {
        var model = self.toJSON();
        CommonGlobal.connectServer("POST", { Input: model }, CommonEnum.API_URL.UpdateProduct,
            function (data) {
                Swal.fire(
                    'Sucessfully!', '',
                    'success'
                ).then((isConfirm) => {
                    if (isConfirm.value) {
                        window.location = "/Product/Index";
                    }
                });
            });


    };

    self.DeleteProduct = function (productId) {
        const swalWithBootstrapButtons = Swal.mixin({
            confirmButtonClass: 'btn btn-success btn-mg-10',
            cancelButtonClass: 'btn btn-danger',
            buttonsStyling: false
        });

        swalWithBootstrapButtons.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "Post",
                    url: "/Product/DeleteProduct",
                    data: { productId: productId },
                    success: function (result) {

                        if (result) {
                            swalWithBootstrapButtons.fire(
                                'Deleted!',
                                'Product has been deleted.',
                                'success'
                            ).then((isConfirm) => {
                                if (isConfirm.value) {
                                    //$("#row_" + productId).remove();

                                    window.location = "/Product/Index";
                                }
                            });

                        }

                    }

                });

            }
        });

  
    };

    ProductModel.prototype.toJSON = function () {
        return {
            Name: $('#txtName').val(),
            CategoryId: $('#dropdownCategory').val(),
            SupplierId: $('#dropdownSupplier').val(),
            Description: $('#txtDescription').val(),
            Quantity: $('#txtQuantity').val(),
            UnitPrice: $('#txtPrice').val(),
            Id: ko.utils.unwrapObservable(self.Id())
        };

    };
};


//};
//var InsertProduct = function () {
//    var Input = GetFormData();
//    $.ajax({
//        type: "Post",
//        url: "/Product/InsertProduct",
//        data: { Input: Input },
//        success: function (result) {

//            if (result) {
//                Swal.fire(
//                    'Sucessfully!','',
//                    'success'
//                ).then((isConfirm) => {
//                    if (isConfirm.value) {
//                        window.location = "/Product/Index";
//                    }
//                });

//            }

//        }

//    });
//};
//var ShowProductModal = function () {
//    $('#productModal').modal("show");
//};

//function GetFormData(Id) {
//    var model = {};
//    model.Name = $('#txtName').val();
//    model.CategoryId = $('#dropdownCategory').val();
//    model.SupplierId = $('#dropdownSupplier').val();
//    model.Description = $('#txtDescription').val();
//    model.Quantity = $('#txtQuantity').val();
//    model.UnitPrice = $('#txtPrice').val();
//    model.Id = Id;
//    return model;
//}
//var UpdateProduct = function (ProductId) {
//    var Input = GetFormData(ProductId);

//    $.ajax({
//        type: "Post",
//        url: "/Product/UpdateProduct",
//        data: { Input: Input },
//        success: function (result) {

//            if (result) {
//                Swal.fire(
//                    'Sucessfully!', '',
//                    'success'
//                ).then((isConfirm) => {
//                    if (isConfirm.value) {
//                        window.location = "/Product/Index";
//                    }
//                });

//            }

//        }

//    });
//}