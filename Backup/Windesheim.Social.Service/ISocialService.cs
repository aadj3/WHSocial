using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service
{
    [ServiceContract]
    public interface ISocialService : 
        IAuthentication,
        IGroups
    {
    }
}
