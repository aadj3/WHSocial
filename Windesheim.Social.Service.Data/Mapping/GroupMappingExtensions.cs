using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Data.Mapping
{
    public static class GroupMappingExtensions
    {
        #region ToExposable

        public static List<Group> AsExposableObject(this List<Groups> groups)
        {
            var result = new List<Group>();

            groups.ForEach(s => result.Add(s.AsExposableObject()));

            return result;
        }

        public static Group AsExposableObject(this Groups group)
        {
            return new Group
                {
                    AccessType = (GroupAccess)group.accessType,
                    Description = group.description,
                    Id = group.groupId,
                    Name = group.groupName
                };
        }

        #endregion

        #region ToData

        public static List<Groups> AsDataObject(this List<Group> groups)
        {
            var result = new List<Groups>();

            groups.ForEach(s => result.Add(s.AsDataObject()));

            return result;
        }

        public static Groups AsDataObject(this Group group)
        {
            return new Groups
            {
                accessType = (byte)group.AccessType,
                description = group.Description,
                groupId = group.Id,
                groupName = group.Name
            };
        }

        #endregion
    }

    public static class MessageMappingExtensions
    {
        #region ToExposable

        public static List<Message> AsExposableObject(this List<Messages> messages)
        {
            var result = new List<Message>();

            messages.ForEach(s=> result.Add(s.AsExposableObject()));

            return result;
        }

        public static Message AsExposableObject(this Messages message)
        {
            return new Message
            {
                Id = message.messageId,
                GroupId = message.Groups.groupId,
                User = new User { UserId = message.Users.userId, UserName = message.Users.userName },
                Value = message.value,
                PostDate = message.postDate,
                Children = message.Children.ToList().AsExposableObject().ToList()
            };
        }

        #endregion

        #region ToData

        public static List<Messages> AsDataObject(this List<Message> messages)
        {
            var result = new List<Messages>();

            messages.ForEach(s => result.Add(s.AsDataObject()));

            return result;
        }

        public static Messages AsDataObject(this Message message, int? parentId = null)
        {
            return new Messages
            {
                groupId = message.GroupId,
                parent = parentId,
                postDate = message.PostDate,
                userId = message.User.UserId,
                value = message.Value
            };
        }

        #endregion
    }
}
