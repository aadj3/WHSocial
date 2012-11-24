using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windesheim.Social.UI.Classes;
using Windesheim.Social.Objects;

namespace Windesheim.Social.UI.Controllers
{
    public class GroupController : CustomController
    {
        public ActionResult Index()
        {
            var session = GetSession();
            var groups = Client.GetGroups(session);
            return View(groups);
        }

    }
}
