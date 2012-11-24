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
        bool UserHasAccess(Authentication auth, int groupId);

        [OperationContract]
        List<Group> GetGroups(Authentication auth);
    }
}