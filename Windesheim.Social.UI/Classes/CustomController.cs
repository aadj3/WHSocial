using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windesheim.Social.UI.SocialService;
using Windesheim.Social.Objects;

namespace Windesheim.Social.UI.Classes
{
    public class CustomController : Controller
    {
        private SocialServiceClient _client;

        public SocialServiceClient Client
        {
            get
            {
                if (_client == null)
                    _client = new SocialServiceClient();

                return _client;
            }
        }

        public Authentication GetSession()
        {
            var session = (Authentication)Session["WSAuth"];

            return session;
        }

        public bool ClientHasValidSession()
        {
            var session = GetSession();
            if (session != null)
                return true;

            return false;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);   
        }
    }
}