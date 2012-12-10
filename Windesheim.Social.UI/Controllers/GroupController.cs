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
            var groups = Client.GetGroupsExtended(session);
            return View(groups);
        }

        public ActionResult View(int groupId)
        {
            var session = GetSession();
            var group = Client.GetGroup(session, groupId);

            return View(group);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Group group)
        {
            var session = GetSession();
            Client.AddGroup(session, group);

            return RedirectToAction("Index");
        }

        public ActionResult Enroll(int groupId)
        {
            var session = GetSession();
            Client.EnrollInGroup(session, groupId);

            return RedirectToAction("Index");
        }

        public ActionResult GetMessages(int groupId)
        {
            var session = GetSession();
            var messages = Client.GetMessages(session, groupId);

            return Json(messages, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PostMessage(string text, int groupId, int? parentId = null)
        {
            var session = GetSession();
            var message = new Message
            {
                GroupId = groupId,
                PostDate = DateTime.Now,
                User = new User { UserId = session.UserId },
                Value = text
            };
            
            Client.PostMessage(session, message, parentId);
            
            return new JsonResult
            {
                Data = "Ok",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult DeleteMessage(int messageId)
        {
            var session = GetSession();
            Client.DeleteMessage(session, messageId);

            return new JsonResult
            {
                Data = "Ok"
            };   
        }
    }
}
