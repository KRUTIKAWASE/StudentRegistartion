var SaveICard = function () {
    var name = $("#txtName").val();
    var designation = $("#txtDesig").val();
    var dob = $("#txtDob").val();
    var expired = $("#txtExpired").val();
    var photo = $("#txtPhoto").val();

    var model = { Name: name, Designation: designation, DOB: dob, Expired: expired, Photo: photo };

    $.ajax({
        url: "/ICard/saveICard",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {
            alert("Successfully");
        }
    })
};