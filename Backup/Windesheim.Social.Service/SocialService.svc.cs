using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Windesheim.Social.Common;
using Windesheim.Social.Objects;
using Windesheim.Social.Service.Business;
using System.Web.Services.Protocols;

namespace Windesheim.Social.Service
{
    public class SocialService : ISocialService
    {
        public Authentication Authentication;

        public Authentication Login(LoginCredentials credentials)
        {
            using (var business = new SocialServiceBusiness())
                return business.Authentication.Login(credentials);
        }

        public bool UserHasAccess(Authentication auth, int groupId)
        {
            using (var business = new SocialServiceBusiness())
                return business.UserHasAccess(auth, groupId);
        }

        public List<Group> GetGroups(Authentication auth)
        {
            using (var business = new SocialServiceBusiness())
                return business.Groups.GetGroups();
        }
    }
}
