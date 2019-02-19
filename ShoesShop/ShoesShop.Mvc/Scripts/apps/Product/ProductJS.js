var DeleteProduct = function (productId) {
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
                data: {productId:productId},
                success: function (result) {

                    if (result ) {
                        swalWithBootstrapButtons.fire(
                            'Deleted!',
                            'Product has been deleted.',
                            'success'
                        ).then((isConfirm) => {
                            if (isConfirm.value) {
                                $("#row_" + productId).remove();

                                //window.location = "/Product/Index";
                            }
                        });

                    }

                }

            })
            
        } else if (
            // Read more about handling dismissals
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            );
        }
    });

};

var ShowProductModal = function () {
    $('#productModal').modal("show");
}