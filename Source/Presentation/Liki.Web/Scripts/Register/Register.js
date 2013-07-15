

function AddCustomer() {
    jQuery.support.cors = true;
    var customerDto = {
        Title: $('#txtTitle').val(),
        EmailAddress: $('#txtEmailAddress').val(),
        FirstName: $('#txtFirstName').val(),
        MiddleName: $('#txtMiddleName').val(),
        LastName: $('#txtLastName').val(),
        Suffix: $('#txtSuffix').val(),
        Password: $('#txtPassword').val()
    };

    $.ajax({
        url: baseUri + '/Register?callback=?',
        type: 'POST',
        data: JSON.stringify(customerDto),
        contentType: "application/json;charset=utf-8",

        success: function(result) {
            if (result == "false") {
                alert("Invalid Data, Try again.");
            } else {
                //$('#lblMessage').innerText = "Registered Successfully";
                //alert("Successfully Registered");
                //window.location = location.protocol + '//' + location.host + '/register/MainWizard';
            }
        },
        error: function(err) {
            alert("Fail : " + err.responseText);
        }
    });
}


function LoginViewModel() {
    var self = this;
    self.Registers = ko.observableArray();

    self.create = function (formElement) {

        $(formElement).validate();
        if ($(formElement).valid()) {
            jQuery.support.cors = true;
            var customerDto = {
                EmailAddress: $('#txtEmailAddressLogin').val(),
                Password: $('#txtPasswordLogin').val()
            };

            $.ajax({
                url: baseUri + '/Login?callback=?',
                type: 'POST',
                data: JSON.stringify(customerDto),
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    if (result == "") {
                        alert("Invalid UserName and Password.");
                    } else {
                        $.ajax({
                            type: 'GET',
                            data: { CustomerId: result.CustomerID, EmailAddress: result.EmailAddress },
                            url: SaveSessionurl,
                            success: function () {
                                window.location = location.protocol + '//' + location.host + '/CreditApp/Index';
                            },
                            error: function (err) {
                                alert("Fail : " + err.responseText);
                            }
                        });
                        //window.location = location.protocol + '//' + location.host + '/CreditApp/MainWizard';
                    }
                },
                error: function (err) {
                    alert("Fail : " + err.responseText);
                }
            });
        }
    };
}

function ResetControls() {
    $("#txtTitle").val("");
    $("#txtEmailAddress").val("");
    $("#txtFirstName").val("");
    $("#txtMiddleName").val("");
    $("#txtLastName").val("");
    $("#txtSuffix").val("");
    $("#txtPassword").val("");
    $("#txtEmailAddressLogin").val("");
    $("#txtPasswordLogin").val("");
}

