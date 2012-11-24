using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windesheim.Social.Common;
using Windesheim.Social.Common.Extensions;
using Windesheim.Social.UI.SocialService;
using Windesheim.Social.UI.Classes;

namespace Windesheim.Social.UI.Controllers
{
    public class LoginController : CustomController
    {
        public ActionResult Index(string accessToken)
        {
            var session = GetSession();
            if (session == null && !accessToken.IsNullOrEmpty())
            {
                var auth = Client.Login(new Objects.FacebookLoginCredentials() { AccessToken = accessToken });
                Session.Add("WSAuth", auth);
            }

            return PartialView();
        }

        public ActionResult LoginWithFacebook(string accessToken)
        {
            var auth = Client.Login(new Objects.FacebookLoginCredentials() { AccessToken = accessToken });

            Session.Add("WSAuth", auth);

            return new JsonResult
            {
                Data = "Ok"
            };
        }
    }
}
