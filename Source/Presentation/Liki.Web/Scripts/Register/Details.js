
function AppViewModelDetails() {
    var self = this;
    self.Users = ko.observableArray();
    self.UsersEditObject = ko.observableArray();
    
    function UserViewModel(root, User) {
        var selfCust = this;
        selfCust.UserID = User.UserID,
        selfCust.Title = User.Title,
        selfCust.EmailAddress = User.EmailAddress,
        selfCust.FirstName = User.FirstName,
        selfCust.MiddleName = User.MiddleName,
        selfCust.LastName = User.LastName,
        selfCust.Suffix = User.Suffix,
        selfCust.Password = User.Password

        selfCust.EditUser = function () {
            
            $("html, body").animate({ scrollTop: $(document).height() }, "slow");
            
            root.UsersEditObject.removeAll();
            root.UsersEditObject.push(selfCust);
        };
    }

    $.getJSON(baseUri, function (Users) {
        $.each(Users, function(index, User) {
            self.Users.push(new UserViewModel(self, User));
        });
    });
};

function UpdateUser() {
   //var baseUri = '@ViewBag.ApiUrl';
    jQuery.support.cors = true;
    var UserDto = {
        UserID: $('#txtUserID').val(),
        Title: $('#txtTitle').val(),
        EmailAddress: $('#txtEmailAddress').val(),
        FirstName: $('#txtFirstName').val(),
        MiddleName: $('#txtMiddleName').val(),
        LastName: $('#txtLastName').val(),
        Suffix: $('#txtSuffix').val(),
        Password: $('#txtPassword').val()
    };

    $.ajax({
         url: baseUri + '/' + UserDto.UserID + "?callback=?",
        //url: baseUri,
        type: 'PUT',
        data: JSON.stringify(UserDto),
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
