using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;
using Windesheim.Social.Service.Data.Mapping;

namespace Windesheim.Social.Service.Data
{
    public partial class DataLayer
    {
        public List<Group> GetGroups()
        {
            return _data.Groups.ToList().AsExposableObject();
        }

        public List<GroupExtended> GetGroupsExtended(long? userId = null)
        {
            var groups = GetGroups();
            var result = new List<GroupExtended>();
            foreach (var group in groups)
            {
                result.Add(new GroupExtended
                    {
                        AccessType = group.AccessType,
                        Description = group.Description,
                        Id = group.Id,
                        Name = group.Name,
                        IsEnrolled = userId.HasValue ? _data.Users_Groups.Any(s => s.groupId == group.Id && s.userId == userId.Value) : false
                    });
            }

            return result;
        }

        public Group GetGroup(int groupId)
        {
            return _data.Groups.SingleOrDefault(s => s.groupId == groupId).AsExposableObject();
        }

        public bool GroupExists(Group group)
        {
            if (_data.Groups.Any(s => s.groupName == group.Name))
                return true;

            return false;
        }

        public int InsertGroup(Group group)
        {
            var dataGroup = group.AsDataObject();
            _data.Groups.AddObject(dataGroup);
            _data.SaveChanges();
            
            return dataGroup.groupId;
        }

        public void EnrollInGroup(long userId, int groupId)
        {
            _data.Users_Groups.AddObject(new Users_Groups 
                {  
                    groupId = groupId, 
                    userId = userId
                });

            _data.SaveChanges();
        }

        public bool IsEnrolledInGroup(long userId, int groupId)
        {
            if (_data.Users_Groups.Any(s => s.userId == userId && s.groupId == groupId))
                return true;
            return false;
        }

        public List<Message> GetMessages(int groupId)
        {
            return  _data.Messages.Where(s => s.groupId == groupId && !s.parent.HasValue).OrderByDescending(s => s.postDate).ToList().AsExposableObject();
        }

        public Message GetMessage(int messageId)
        {
            return _data.Messages.SingleOrDefault(s => s.messageId == messageId).AsExposableObject();
        }

        public void InsertMessage(Objects.Message message, int? parentId)
        {
            _data.Messages.AddObject(message.AsDataObject(parentId));
            _data.SaveChanges();
        }

        public void DeleteMessage(int messageId)
        {
            var message = _data.Messages.Single(s => s.messageId == messageId);
            var reactions = _data.Messages.Where(s => s.parent.HasValue && s.parent.Value == message.messageId);
            foreach (var r in reactions)
                _data.DeleteObject(r);
            _data.DeleteObject(message);
            _data.SaveChanges();
        }

        public List<Message> GetRelevantMessages(long userId, int skip, int take)
        {
            var ownMessages = _data.Messages.Where(s => s.userId == userId && !s.parent.HasValue).OrderBy(s => s.Children.Max(d => d.postDate)).Skip(skip).Take(take);
            var reactions = _data.Messages.Where(s => s.userId == userId && s.parent.HasValue);
            var otherMessages = new List<Messages>();
            foreach (var r in reactions)
            {
                if (otherMessages.Count >= skip + take)
                    break;
                var parent = r.parentMessage;
                while (parent.parentMessage != null)
                    parent = parent.parentMessage;
                if (!otherMessages.Any(s => s.messageId == parent.messageId) && !ownMessages.Any(s => s.messageId == parent.messageId))
                    otherMessages.Add(parent);
            }

            var result = ownMessages.ToList().AsExposableObject();
            if (result.Count < take)
                result.AddRange(otherMessages.ToList().AsExposableObject());

            return result;
        }
    }
}
