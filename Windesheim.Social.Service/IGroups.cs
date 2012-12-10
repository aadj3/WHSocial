using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service
{
    [ServiceContract]
    public interface IGroups
    {
        [OperationContract]
        int AddGroup(Authentication auth, Group group);

        [OperationContract]
        List<Group> GetGroups(Authentication auth);

        [OperationContract]
        Group GetGroup(Authentication auth, int groupId);

        [OperationContract]
        List<GroupExtended> GetGroupsExtended(Authentication auth);

        [OperationContract]
        void EnrollInGroup(Authentication auth, int groupId);

        [OperationContract]
        void PostMessage(Authentication auth, Message message, int? parentId);

        [OperationContract]
        List<Message> GetMessages(Authentication auth, int groupId);

        [OperationContract]
        void DeleteMessage(Authentication auth, int messageId);

        [OperationContract]
        List<Message> GetRelevantMessages(Authentication auth, int skip, int take);
    }
}