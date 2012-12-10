using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public enum GroupAccess
    {
        [EnumMember]
        Open = 0,

        [EnumMember]
        Closed = 1,

        [EnumMember]
        Secret = 2
    }
}
