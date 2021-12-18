var saveContact = function () {
    var name = $("#txtName").val();
    var address = $("#txtAdd").val();
    var phone = $("#txtPhone").val();
    var email = $("txtEmail").val();

    var model = {
        Name: name, Address: address, Phone: phone, Email: email
    };

    $.ajax({
        url: "/Contact/SaveContact",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {
            alert("Successfully");
        }
    })
};