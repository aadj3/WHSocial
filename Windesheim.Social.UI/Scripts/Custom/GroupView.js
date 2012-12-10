$(function () {
    GetMessages(AppendMessages);

    InitEvents();
});

function InitEvents() {
    $("#btn_newMessage").die().live("click", function () {
        var val = $("#txt_newMessage").val();
        if (val) {
            PostMessage(val, null, function(){ $("#txt_newMessage").val(""); });
        }
    });

    $("a[id^='deleteMessage_']").die().live("click", function () {
        var id = parseFloat($(this).attr("id").replace("deleteMessage_", ""));
        DeleteMessage(id);
    });

    $("button.btn_react").die().live("click", function () {
        var val = $(this).parent().find("input.reaction").val();
        if (val) {
            var parentId = parseFloat($(this).closest("[id^=message_]").attr("id").replace("message_", ""));
            PostMessage(val, parentId, function () { $(this).parent().find("input.reaction").val(""); });
        }
    });

    $("#messages input[type='text'], #newMessage input[type='text']").die().live("keypress", function (e) {
        if (e.keyCode == 13)
            $(this).parent().find(".button").trigger("click");
    });
}

function DeleteMessage(messageId) {
    $.post("/Group/DeleteMessage", { messageId: messageId }, function (result) {
        GetMessages(AppendMessages);
    });
}

function GetMessages(callback) {
    $.post("/Group/GetMessages", { groupId: groupId }, function (result) {
        callback(result);
    }, "json");
}

function AppendMessages(messages) {
    console.log(messages);
    $("#messages").jqotesub("#tpl_message", messages);
}

function PostMessage(text, parentId, callback) {
    $.post("/Group/PostMessage",
    {
        text: text,
        groupId: groupId,
        parentId: parentId
    }, function (result) {
        if (result == "Ok")
        {
            GetMessages(AppendMessages);
            callback();
        }
    }, "json");
}