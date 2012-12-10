using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public class FacebookUser : User
    {
        [DataMember]
        public long FacebookUserId { get; set; }
    }
}
