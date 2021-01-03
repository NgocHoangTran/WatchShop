$(document).ready(function ()
{
    //bắt sự kiện click của đối tượng id="create"
    $("#create").click(function () {
        if (checkNull()) {
            //lấy đối tượng id="alert" trong 1 form html
            $("#alert").removeClass("d-none");
            $("#alert").html("Error occured");
            return;
        }
        var m = $("#inputEmailAddress").val();
        if (emailIsValid(m) == false) {
            $("#alert").removeClass("d-none");
            $("#alert").html("Your email not valid");
            return;
        }
        var name = $("#inputName").val(); // .val get data intput name
        var mail = $("#inputEmailAddress").val();
        var pass = $("#inputPassword").val();
        $.ajax({ //syntax
            url: "/Admin/Admin/registerAdmin", // syntax
            data: { name: name, mail: mail, pass: pass },
            success: function (response) {
                if (response == "fail") {
                    $("#alert").removeClass("d-none");
                    $("#alert").html("Account exists");
                }
                else {
                    window.location = "https://localhost:44337/Admin/Admin/loginAdmin";
                }
            }
        });

    });

    function checkNull() {
        var name = $("#inputName").val();
        var mail = $("#inputEmailAddress").val();
        var pass = $("#inputPassword").val();
        var confpass = $("#inputConfirmPassword").val();
        if (name == "" || mail == "" || pass == "" || confpass == "" || pass != confpass) {
            return true;
        }
        return false;
    }

    function emailIsValid(email) {
        return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
    }



});
