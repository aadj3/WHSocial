using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Data.Fake
{
    public class FakeDataLayer : IDataLayer
    {
        private List<User> _users = new List<User>();
        private List<Group> _groups = new List<Group>();
        private Dictionary<Group, List<User>> _users_groups = new Dictionary<Group, List<User>>();

        public long CheckOrInsertFacebookUser(FacebookUser user)
        {
            long id = 0;
            if (_users.Any())
                id = _users.Max(s => s.UserId) + 1;
            user.UserId = id;
            _users.Add(user);

            return user.UserId;
        }

        public void EnrollInGroup(long userId, int groupId)
        {
            if (!_users_groups.Any(s => s.Key.Id == groupId))
                _users_groups.Add(_groups.Single(s => s.Id == groupId), new List<User>());

            _users_groups.Single(s => s.Key.Id == groupId).Value.Add(_users.Single(s => s.UserId == userId));
        }

        public Group GetGroup(int groupId)
        {
            return _groups.SingleOrDefault(s => s.Id == groupId);
        }

        public List<Group> GetGroups()
        {
            return _groups.Where(s => s.AccessType == GroupAccess.Open).ToList();
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
                        IsEnrolled = userId.HasValue ? _users_groups.Any(s => s.Key.Id == group.Id && s.Value.Any(d => d.UserId == userId)) : false
                    });
            }

            return result;
        }

        public Sessions GetSession(Authentication header)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long userId)
        {
            return _users.SingleOrDefault(s => s.UserId == userId);
        }

        public bool GroupExists(Group group)
        {
            if (_groups.SingleOrDefault(s => s.Name == group.Name) != null)
                return true;
            return false;
        }

        public int InsertGroup(Group group)
        {
            var id = 0;
            if (_groups.Any())
                id = _groups.Max(s => s.Id) + 1;
            group.Id = id;
            _groups.Add(group);

            return group.Id;
        }

        public long InsertUser(User user)
        {
            long id = 0;
            if (_users.Any())
                id = _users.Max(s => s.UserId) + 1;
            user.UserId = id;

            _users.Add(user);

            return user.UserId;
        }

        public bool IsEnrolledInGroup(long userId, int groupId)
        {
            if (_users_groups.Any(s => s.Key.Id == groupId && s.Value.Any(d => d.UserId == userId)))
                return true;
            return false;
        }

        public KeyValuePair<Guid, DateTime> StartSession(long userId, Guid ticket)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }


        public void InsertMessage(Message message, int? parentId)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessages(int groupId)
        {
            throw new NotImplementedException();
        }


        public Message GetMessage(int messageId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int messageId)
        {
            throw new NotImplementedException();
        }


        public List<Message> GetRelevantMessages(long userId, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
