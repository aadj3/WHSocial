using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
