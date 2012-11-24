using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Windesheim.Social.UI.Classes;

namespace Windesheim.Social.UI.Controllers
{
    public class ChannelController : CustomController
    {
        //
        // GET: /Channel/

        public ActionResult Index()
        {
            return PartialView();
        }

    }
}
