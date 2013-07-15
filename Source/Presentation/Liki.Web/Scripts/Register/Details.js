
function AppViewModelDetails() {
    var self = this;
    self.Customers = ko.observableArray();
    self.CustomersEditObject = ko.observableArray();
    
    function customerViewModel(root, customer) {
        var selfCust = this;
        selfCust.CustomerID = customer.CustomerID,
        selfCust.Title = customer.Title,
        selfCust.EmailAddress = customer.EmailAddress,
        selfCust.FirstName = customer.FirstName,
        selfCust.MiddleName = customer.MiddleName,
        selfCust.LastName = customer.LastName,
        selfCust.Suffix = customer.Suffix,
        selfCust.Password = customer.Password

        selfCust.EditCustomer = function () {
            
            $("html, body").animate({ scrollTop: $(document).height() }, "slow");
            
            root.CustomersEditObject.removeAll();
            root.CustomersEditObject.push(selfCust);
        };
    }

    $.getJSON(baseUri, function (Customers) {
        $.each(Customers, function(index, Customer) {
            self.Customers.push(new customerViewModel(self, Customer));
        });
    });
};

function UpdateCustomer() {
   //var baseUri = '@ViewBag.ApiUrl';
    jQuery.support.cors = true;
    var customerDto = {
        CustomerID: $('#txtCustomerID').val(),
        Title: $('#txtTitle').val(),
        EmailAddress: $('#txtEmailAddress').val(),
        FirstName: $('#txtFirstName').val(),
        MiddleName: $('#txtMiddleName').val(),
        LastName: $('#txtLastName').val(),
        Suffix: $('#txtSuffix').val(),
        Password: $('#txtPassword').val()
    };

    $.ajax({
         url: baseUri + '/' + customerDto.CustomerID + "?callback=?",
        //url: baseUri,
        type: 'PUT',
        data: JSON.stringify(customerDto),
        contentType: "application/json;charset=utf-8",
        success: function () {
            document.location.reload();
        },
        error: function (err) {
            alert("Fail");
            alert('\n' + err + '\n');
            alert('\n' + err.toString + '\n');
        }
    });
}
