using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Service.Data;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Business
{
    public class GroupBusiness : BusinessClass
    {
        public GroupBusiness(IDataLayer data)
            : base(data)
        { }

        public List<Group> GetGroups()
        {
            return _data.GetGroups().Where(s => s.AccessType == GroupAccess.Open).ToList();
        }

        public Group GetGroup(int groupId)
        {
            return _data.GetGroup(groupId);
        }

        public List<GroupExtended> GetGroupsExtended(long userId)
        {
            return _data.GetGroupsExtended(userId);
        }

        public int AddGroup(Group group)
        {
            if(!_data.GroupExists(group))
                return _data.InsertGroup(group);

            throw new InvalidOperationException(string.Format("Group with name {0} already exists", group.Name));
        }

        public void EnrollInGroup(long userId, int groupId)
        {
            if (_data.IsEnrolledInGroup(userId, groupId))
                throw new InvalidOperationException(string.Format("User {0} is already enroled in group {1}", userId, groupId));
            
            var group = _data.GetGroup(groupId);
            if (group == null)
                throw new InvalidOperationException(string.Format("Group {0} doesn't exist", groupId));
            if (group.AccessType != GroupAccess.Open)
                throw new InvalidOperationException(string.Format("Group {0} is not public", groupId));

            _data.EnrollInGroup(userId, groupId);
        }

        public void PostMessage(Message message, int? parentId)
        {
            if (!_data.IsEnrolledInGroup(message.User.UserId, message.GroupId))
                throw new InvalidOperationException(string.Format("User {0} is not enrolled in group {1}", message.User.UserId, message.GroupId));

            _data.InsertMessage(message, parentId);
        }

        public List<Message> GetMessages(long userId, int groupId)
        {
            var messages = _data.GetMessages(groupId);
            messages.ForEach(s => s.IsOwner = s.User.UserId == userId);
            return messages;
        }

        public void DeleteMessage(long userId, int messageId)
        {
            var message = _data.GetMessage(messageId);
            if (message.User.UserId != userId)
                throw new InvalidOperationException("User is not the owner of this message");

            _data.DeleteMessage(messageId);
        }

        public List<Message> GetRelevantMessages(long userId, int skip, int take)
        {
            return _data.GetRelevantMessages(userId, skip, take);
        }
    }
}
