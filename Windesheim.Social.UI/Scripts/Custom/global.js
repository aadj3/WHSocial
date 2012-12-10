var dateformat = "dddd/mmmm/yyyy";
var datetimeformat = "dd MMMM yyyy, HH:mm:ss";

function FormatJsonDate(jsonDt) {
    var MIN_DATE = -62135578800000; // const

    var date = new Date(parseInt(jsonDt.substr(6, jsonDt.length - 8)));
    return date.toString(datetimeformat);
//    return date.toString() == new Date(MIN_DATE).toString() ? "" : (date.getMonth() + 1) + "\\" + date.getDate() + "\\" + date.getFullYear();
}