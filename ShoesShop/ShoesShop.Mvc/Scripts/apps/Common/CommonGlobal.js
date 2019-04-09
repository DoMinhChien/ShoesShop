//if (typeof (CommonGlobal)=='undefined') {
//    var CommonGlobal = {};
//}
var CommonGlobal = {
    convertDateJSToClientDateTime: function (dateJs, format) {
        if (dateJs === null) {
            return '';
        }
        if (format) {
            format = "DD-MMM-YYYY hh:mm:ss A";
        }   
        return moment(dateJs).format(format);
    },
    displayStatusInfo: function (statusId) {
        if (statusId===1) {
            return "<button type='button' class='btn custom-active-stt-btn btn-success'><span><i class='fa fa-check'></i>Active</span> </button>";
        }
    }


};