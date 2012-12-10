using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Windesheim.Social.Objects
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public GroupAccess AccessType { get; set; }

        [DataMember]
        public List<ExtendedProperty> ExtendedProperties { get; set; }
    }

    [DataContract]
    public class GroupExtended : Group
    {
        //[DataMember]
        //public List<User> EnrolledUsers { get; set; }

        [DataMember]
        public bool IsEnrolled { get; set; }
    }
}
