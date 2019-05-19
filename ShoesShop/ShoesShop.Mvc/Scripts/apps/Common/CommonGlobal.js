//if (typeof (CommonGlobal)=='undefined') {
//    var CommonGlobal = {};
//}
var CommonGlobal = {
    Ajax: function (type, param, url, callbackSuccess,isLoading) {
        $.ajax({
            type: type,
            url: url,
            beforeSend: function () {
                if (isLoading) {
                    $('#loader').show();
                }
                
            },
            data: param,
            success: function (data) {
                callbackSuccess(data);
            },
            complete: function () {
                if (isLoading) {
                    $('#loader').hide();
                }
         
            }
        });
    },
    connectServer: function (type, param, url, callbackSuccess) {
        CommonGlobal.Ajax(type, param, url, callbackSuccess,true);


    },
    connectServerBackground: function (type, param, url, callbackSuccess) {
        CommonGlobal.Ajax(type, param, url, callbackSuccess,false);
    },
    convertDateJSToClientDateTime: function (dateJs, formatMatch) {
        if (dateJs === null) {
            return '';
        }
        if (!formatMatch) {
            formatMatch = "DD-MMM-YYYY hh:mm:ss A";
        }
        
        return moment(dateJs).format(formatMatch);
        
    },
    displayStatusInfo: function (statusId) {
        if (statusId) {
            return "<button type='button' class='btn custom-active-stt-btn btn-success display-mode'><span><i class='fa fa-check'></i></span> </button>";
        }
        else {
            return "<button type='button' class='btn custom-active-stt-btn btn-default display-mode'><span><i class='fa fa-times'></i></span> </button>";
        }
    },
    showSuccessMessage: function (content, returnUrl) {
        var type = 'success';
        CommonGlobal.showSweetAlert(content, type, returnUrl);
    },
    showInfoMessage: function (content, type, returnUrl) {
        CommonGlobal.showSweetAlert(content, type, returnUrl);
    },
    swalWithBootstrapButtons: function () {
        var customeAlert = Swal.mixin({
            confirmButtonClass: 'btn btn-success ',
            cancelButtonClass: 'btn btn-danger mg-l-10',
            buttonsStyling: false
        });
        return customeAlert;
    },
    showConfirmMessage: function (type, callback) {
        const sweetAlert = CommonGlobal.swalWithBootstrapButtons();

        sweetAlert.fire({
            title: '<strong class="size-25">Are you sure?</strong>',
            text: "You won't be able to revert this!",
            type: type,
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            customClass: 'swal-wide',
            cancelButtonText: 'No, cancel!',
            //reverseButtons: true
        }).then((result) => {
            if (result.value) {
                callback();

            }
        });
    },
    showSweetAlert: function (content, type, returnUrl) {
        Swal.fire(
            {

                //position: 'top-end',
                title: content,
                type: type,
                customClass: 'swal-wide'
                //showConfirmButton: false,
                //timer: 1500
            }
        ).then((isConfirm) => {
            if (isConfirm.value) {
                window.location = returnUrl;
                // "/Product/Index"
            }
        });
    }


};