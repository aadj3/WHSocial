using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Data.Mapping
{
    public static class GroupMappingExtensions
    {
        public static List<Group> AsExposableObject(this List<Groups> groups)
        {
            var result = new List<Group>();

            groups.ForEach(s => result.Add(new Group
                {
                    AccessType = (GroupAccess)s.accessType,
                    Description = s.description,
                    Id = s.groupId,
                    Name = s.groupName
                }));

            return result;
        }
    }
}
