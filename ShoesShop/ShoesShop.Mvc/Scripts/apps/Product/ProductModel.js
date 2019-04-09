var ProcductViewModel = function () {
    var self = this;

    self.Id = ko.observable();

    self.IsViewDetail = ko.observable(false);

    self.ViewProduct = function (productId) {
        self.IsViewDetail(true);
    };
   
    self.productModel = ko.observable(new ProductModel(self));
    self.ReturnToList = function () {
        self.IsViewDetail(false);
    };
};

var ProductModel = function (parent) {
    self.products = ko.observableArray([]);
    self.parentViewModel = parent;
    self.init = function () {
        $.ajax({
            type: "Get",
            url: "/Product/GetProducts",
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
    self.init();
};

//var DeleteProduct = function (productId) {
//    const swalWithBootstrapButtons = Swal.mixin({
//        confirmButtonClass: 'btn btn-success btn-mg-10',
//        cancelButtonClass: 'btn btn-danger',
//        buttonsStyling: false
//    });

//    swalWithBootstrapButtons.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        type: 'warning',
//        showCancelButton: true,
//        confirmButtonText: 'Yes, delete it!',
//        cancelButtonText: 'No, cancel!',
//        reverseButtons: true
//    }).then((result) => {
//        if (result.value) {
//            $.ajax({  
//                type: "Post",
//                url: "/Product/DeleteProduct",
//                data: { productId: productId },
//                success: function (result) {

//                    if (result) {
//                        swalWithBootstrapButtons.fire(
//                            'Deleted!',
//                            'Product has been deleted.',
//                            'success'
//                        ).then((isConfirm) => {
//                            if (isConfirm.value) {
//                                $("#row_" + productId).remove();

//                                //window.location = "/Product/Index";
//                            }
//                        });

//                    }

//                }

//            });

//        } 
//    });

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
//};