  // Additional JS functions here
window.fbAsyncInit = function () {
    FB.init({
        appId: '417311178336726', // App ID
        channelUrl: 'http://localhost:2851/Channel', // Channel File
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        oauth: true,
        xfbml: true  // parse XFBML
    });

    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            LoggedIn(response.authResponse.accessToken);
        } else if (response.status === 'not_authorized') {
            login();
        } else {
            login();
        }
    });

};

  // Load the SDK Asynchronously
  (function(d){
     var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement('script'); js.id = id; js.async = true;
     js.src = "//connect.facebook.net/en_US/all.js";
     ref.parentNode.insertBefore(js, ref);
   }(document));
    
  function login() {
      $("#login_loading").show();
    FB.login(function (response) {
        if (response.authResponse) {
            LoginAtServer(response.authResponse.accessToken, LoggedIn);
        } else {
            // cancelled
        }
        $("#login_loading").hide();
    });
}

function LoggedIn(accessToken) {
    FB.api('/me', function (fbresponse) {
        $.post("/Login/Index", { accessToken: accessToken }, function (response) {
            $("#header-right").jqotesub("#logOutTemplate", fbresponse);
        });
    }, { scope: 'email,user_likes' });
}

function LoginAtServer(accessToken, callback) {
    $.post("/Login/LoginWithFacebook", { accessToken: accessToken }, function () {
        callback();
    });
}

$(function () {
    $("#btn_logOut").live("click", function () {
        FB.logout(function (response) {
        });
    });
});