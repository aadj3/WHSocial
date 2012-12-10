using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public enum GroupRole
    {
        [EnumMember]
        Member = 0,

        [EnumMember]
        Administrator = 1
    }
}
