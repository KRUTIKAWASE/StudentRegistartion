$(document).ready(function () {
    getList();
});

var saveProduct = function () {
    var message = "";
    $formData = new FormData();
    var image = document.getElementById('File1');;
    if (image.files.length > 0) {
        for (var i = 0; i < image.files.length; i++) {
            $formData.append('file-' + i, image.files[i]);

        }
    }
    var prodname = $("#txtName").val();
    var price = $("#txtPrice").val();
    var contact = $("#txtContact").val();
    var companyname = $("#ddlCompany").val();

    $formData.append('ProdName', prodname);
    $formData.append('Price', price);
    $formData.append('Contact', contact);
    $formData.append('CompanyName', companyname);

    $.ajax({
        url: "/Special/SaveProduct",
        method: "Post",
        data: $formData,
        /*data: JSON.stringify(model),*/
        contentType: "application/json;charset=utf-8",
        /*dataType: "json",*/
        contentType: false,
        processData: false,
        success: function (response) {
            alert("Successfully");
            ClearData();
            getList();
        }
    })
}

var ClearData = function () {
    $("#txtName").val("");
    $("#File1").val("");
    $("#txtPrice").val("");
    $("#txtContact").val("");
    $("#ddlCompany").val("");
}

var getList = function () {
    var companyname = $("#ddlCompanyName").val();
    var model = { CompanyName: companyname };

    $.ajax({
        url: "/Special/GetProductlist",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,

        success: function (response) {
            var html = "";
            $("#tblProduct tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.ID + "</td><td>" + elementValue.ProdName + "</td><td>" + elementValue.Price + "</td><td>" + elementValue.Contact + "</td><td><img src='../Content/Images/" + elementValue.Image + "'style='max-width:200px; max-heigth:200px; '/></td><td>" + elementValue.CompanyName + "</td > <td><input class='btn btn-danger' type='submit' value='Delete' onClick='deleteProduct(" + elementValue.ID + ")' /></td></tr > ";
            });
            $("#tblProduct tbody").append(html);
        }
    });
}

var familyRegistration = function (id) {
    window.location.href = "/Special/Index?Id=" + id;
}



var deleteProduct = function (id) {
    var model = { ID: id };
    $.ajax({
        url: "/Special/deleteProduct",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully....");
        }
    });
}