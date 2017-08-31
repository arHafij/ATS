$("#GenCategory_GenCategoryId").change(function () {
    var genCategoryId = $("#GenCategory_GenCategoryId").val();

    if (genCategoryId == "") {
        $("#Category_CategoryId").empty();
        var optionText = "<option value=''>Select..</option>";
        $("#Category_CategoryId").append(optionText);
        return;
    }

    var jsonData = { genCategoryId: genCategoryId }
    $.ajax({
        url: "/PurchasedEntry/GetCategoryByGenCategoryId",
        type: "POST",
        data: JSON.stringify(jsonData),
        contentType: "Application/json",
        success: function (response) {
            $("#Category_CategoryId").empty();
            $.each(response,
                function (key, value) {
                    var optionText = "<option value=" + value.CategoryId + ">" + value.Name + "</option>";
                    $("#Category_CategoryId").append(optionText);
                });
        }
    });
});