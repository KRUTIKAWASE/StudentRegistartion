$(document).ready(function () {
    getList();
});

var saveRegister = function () {
    var studname = $("#txtName").val();
    var email = $("#txtEmail").val();
    var mobileno = $("#txtPhone").val();
    var address = $("#txtAdd").val();
    var state = $("#txtState").val();
    var password = $("#txtPass").val();

    var model = { StudName: studname, Email: email, MobileNo: mobileno, Address: address, State: state, Password: password };

    $.ajax({
        url: "/Regis/SaveRegis",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (reponse) {
            alert("Successfully");
            ClearData();
            getList();
        }
    });
}

var ClearData = function () {
    $("#txtName").val("");
    $("#txtEmail").val("");
    $("#txtPhone").val("");
    $("#txtAdd").val("");
    $("#txtState").val("");
    $("#txtPass").val("");
}

var getList = function () {
    $.ajax({
        url: "/Regis/GetRegisModel",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: true,
        success: function (response) {
            var html = "";
            $("#tblRegistration tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.StudeID + "</td><td>" + elementValue.StudName + "</td><td>" + elementValue.Email + "</td><td>" + elementValue.MobileNo + "</td><td>" + elementValue.Address + "</td><td>" + elementValue.State + "</td><td>" + elementValue.Password + "</td></tr>";
            });
            $("#tblRegistration tbody").append(html);
            debugger;
            $("#tblRegistration").DataTable();
        }
    });
}

var deleteRegister = function (id) {
    var model = { StudeID: id };
    $.ajax({
        url: "/Regis/deleteRegister",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully...");
        }
    });
}

//var Editdata = function (id) {
//    var model = { ID: id };
//    alert("Record Edit Successfully ....");
//    $.ajax({
//        url: "/Regis/GetEditData ",
//        method: "post",
//        data: JSON.stringify(model),
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        async: false,
//        success: function (response) {
//            $("#lblid").val(response.model.ID);
//            $("#txtName").val(response.model.StudName);
//            $("#txtEmail").val(response.model.Email);
//            $("#txtPhone").val(response.model.MobileNo);
//            $("#txtAdd").val(response.model.Address);
//            $("#txtState").val(response.model.State);
//            $("#txtPass").val(response.model.Password);
//        }
//    });
//}