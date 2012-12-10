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
        public Authentication Login(LoginCredentials credentials)
        {
            using (var business = new SocialServiceBusiness())
                return business.Authentication.Login(credentials);
        }

        public List<Group> GetGroups(Authentication auth)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.GetGroups();
            }
        }

        public Group GetGroup(Authentication auth, int groupId)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.GetGroup(groupId);
            }
        }

        public List<GroupExtended> GetGroupsExtended(Authentication auth)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.GetGroupsExtended(auth.UserId);
            }
        }

        public int AddGroup(Authentication auth, Group group)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.AddGroup(group);
            }
        }

        public void EnrollInGroup(Authentication auth, int groupId)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                business.Groups.EnrollInGroup(auth.UserId, groupId);
            }
        }

        public void PostMessage(Authentication auth, Message message, int? parentId)
        {
            using(var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                business.Groups.PostMessage(message, parentId);
            }
        }

        public List<Message> GetMessages(Authentication auth, int groupId)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.GetMessages(auth.UserId, groupId);
            }
        }


        public void DeleteMessage(Authentication auth, int messageId)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                business.Groups.DeleteMessage(auth.UserId, messageId);
            }
        }

        public List<Message> GetRelevantMessages(Authentication auth, int skip, int take)
        {
            using (var business = new SocialServiceBusiness())
            {
                business.Authentication.AuthenticateUser(auth);
                return business.Groups.GetRelevantMessages(auth.UserId, skip, take);
            }
        }
    }
}
