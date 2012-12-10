using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public class Authentication
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public Guid Ticket { get; set; }

        [DataMember]
        public DateTime ValidTill { get; set; }
    }
}
