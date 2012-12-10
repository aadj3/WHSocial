using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int GroupId { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public List<Message> Children { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public DateTime PostDate { get; set; }

        [DataMember]
        public bool IsOwner { get; set; }
    }
}
