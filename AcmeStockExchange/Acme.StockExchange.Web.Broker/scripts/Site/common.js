function removeConfirmation(message) {
    var defer = $.Deferred();

    $(document.createElement("div"))
        .html("<span class='glyphicon glyphicon-alert'></span> Remove " + message)
        .dialog({
            autoOpen: false,
            modal: true,
            title: "Confirmation required",
            width: 500,
            buttons: {
                "Confirm": function () {
                    defer.resolve(true);
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    defer.resolve(false);
                    $(this).dialog("close");
                }
            },
            close: function () {
                $(this).dialog('destroy').remove()
            }
        })
        .dialog("open");

    return defer.promise();
}

var layout = "topCenter";
var theme = "relax";
var timeout = 2000;
var killer = true;

function setErrorNoty(error) {
    noty({
        text: $.parseJSON(error.responseText).Message,
        layout: layout,
        theme: theme,
        type: error.status === 400 ? "warning" : "error",
        timeout: timeout,
        killer: killer
    });
}

function setSuccessNoty(notification) {
    noty({
        text: "Sucessfully " + notification,
        layout: "topCenter",
        theme: "relax",
        type: "success",
        timeout: timeout,
        killer: killer
    });
}