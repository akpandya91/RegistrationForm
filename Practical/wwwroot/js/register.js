$(document).ready(function () {
    $("#btn_register").click(function () {

        let name = $("#txt_fullname").val();
        let email = $("#txt_email").val();
        let password = $("#txt_password").val();
        let repassword = $("#txt_repassword").val();

        if (name == null || name == '' || name == undefined) {
            alert("Full Name is required !");
            return false;
        }
        else if (email == null || email == '' || email == undefined) {
            alert("Email is required !");
            return false;
        }
        else if (password == null || password == '' || password == undefined) {
            alert("Password is required !");
            return false;
        }
        else if (repassword != password) {
            alert("Repeat Password must be match with Password !");
            return false;
        }
        else if ($("#txt_fullname").val().length < 5)
        {
            alert("Name must be more than 5 character !");
            return false;
        }
        else if ($("#txt_password").val().length < 5) {
            alert("Password must be more than 5 character !");
            return false;
        }
        else if ($("#txt_repassword").val().length < 5) {
            alert("Repeat Password must be more than 5 character !");
            return false;
        }
        else {
            if (validateEmail(email)) {
                adddData = {
                    FullName: name,
                    Email: email,
                    Password: password
                };

                $.ajax({
                    //url: "https://localhost:7203/api/user/Register",
                    url: "https://voingtestapi.azurewebsites.net/api/user/Register",
                    type: "POST",
                    data: JSON.stringify(adddData),
                    contentType: 'application/json',
                    dataType: "JSON",
                    success: function (result) {
                        if (result.status_code != 1) {
                            alert(result.message);
                        }
                        else {
                            window.location.href = "/Home/Dashboard";
                        }
                    }
                });
            }
            else {
                alert("Email Id is not valid");
                return false;
            }
        }
    });
});

function validateEmail($email) {
    debugger;
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}