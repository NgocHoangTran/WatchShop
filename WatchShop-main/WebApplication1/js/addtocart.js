$(document).ready(function () {    
    $("#add_item").click(function () {      
        var quantity = $("#quantity option:selected").text();
        var id_pro = $("#id_pro").html();
        $.ajax({
            url: "/ProductView/AddItem",
            data: { id_pro: id_pro, quantity: quantity },
            success: function (response) {
                if (response == "success") {
                    $("#modal_body").html("Add product success");
                    $("#modal_noti").modal('show');
                }
                else if (response == "login") {
                    alert("You must login");
                    window.location = "/Home/Index";
                }
                else {
                    window.location = "/Home/Error";
                }
            }
        });
    });
});