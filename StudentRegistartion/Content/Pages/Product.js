$(document).ready(function () {
    getSpecial();
});

var getSpecial = function () {
    $.ajax({
        url: "/Product/GetList",
        method: "Post",
        /*data: JSON.stringify(model),*/
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
