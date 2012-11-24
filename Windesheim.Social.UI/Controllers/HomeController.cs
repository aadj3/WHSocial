using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windesheim.Social.UI.Classes;

namespace Windesheim.Social.UI.Controllers
{
    public class HomeController : CustomController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if(ClientHasValidSession())
                return View();

            return View("PleaseLogin");
        }

    }
}
