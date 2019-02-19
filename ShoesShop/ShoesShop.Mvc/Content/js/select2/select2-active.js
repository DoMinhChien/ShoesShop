(function ($) {
 "use strict";
 

    $(".select2_Category").select2({
        placeholder: "Select a Category",
        allowClear: true,
        ajax: {
            url: "/Category/GetCategories",
            type: "Post",
            dataType: 'json',
            delay: 150,
            data: function (params) {
               
                //matcher: matchStart(params, data);
                
            },
            processResults: function (response) {
                return {
                    results: response
                };
            },
            cache: true
        }
    });
  
    $(".select2_Supplier").select2({
        placeholder: "Select a Supplier",
        allowClear: true,
            ajax: {
                url: "/Supplier/GetSuppliers",
            type: "Post",
            dataType: 'json',
            delay: 150,
            data: function (params) {

              //  matcher: matchStart(params, data);

            },
            processResults: function (response) {
                return {
                    results: response
                };
            },
            cache: true
        }
    });
 
})(jQuery); 
