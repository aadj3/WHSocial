$(function () {
    GetRelevantMessages(AppendMessages);
});

function GetRelevantMessages(callback) {
    ShowLoading();
    $.post("/Home/GetRelevantMessages", null, function (result) {
        $(".loading").hide();
        callback(result);
        HideLoading();
    });
}

function ShowLoading() {
    $(".container").hide();
    $(".loading").show();
}

function HideLoading() {
    $(".container").show();
    $(".loading").hide();
}

function AppendMessages(messages) {
    $("#messages").jqotesub("#tpl_message", messages);
}

$("a[id^='deleteMessage_']").die().live("click", function () {
    var id = parseFloat($(this).attr("id").replace("deleteMessage_", ""));
    DeleteMessage(id);
});

function DeleteMessage(messageId) {
    $.post("/Group/DeleteMessage", { messageId: messageId }, function (result) {
        GetRelevantMessages(AppendMessages);
    });
}