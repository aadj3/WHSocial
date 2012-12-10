using System;
namespace Windesheim.Social.Service.Data
{
    public interface IDataLayer : IDisposable
    {
        long CheckOrInsertFacebookUser(Windesheim.Social.Objects.FacebookUser user);
        void EnrollInGroup(long userId, int groupId);
        Windesheim.Social.Objects.Group GetGroup(int groupId);
        System.Collections.Generic.List<Windesheim.Social.Objects.Group> GetGroups();
        System.Collections.Generic.List<Windesheim.Social.Objects.GroupExtended> GetGroupsExtended(long? userId = null);
        Sessions GetSession(Windesheim.Social.Objects.Authentication header);
        Windesheim.Social.Objects.User GetUser(long userId);
        bool GroupExists(Windesheim.Social.Objects.Group group);
        int InsertGroup(Windesheim.Social.Objects.Group group);
        long InsertUser(Windesheim.Social.Objects.User user);
        bool IsEnrolledInGroup(long userId, int groupId);
        System.Collections.Generic.KeyValuePair<Guid, DateTime> StartSession(long userId, Guid ticket);
        void InsertMessage(Objects.Message message, int? parentId);
        System.Collections.Generic.List<Objects.Message> GetMessages(int groupId);
        Objects.Message GetMessage(int messageId);
        void DeleteMessage(int messageId);
        System.Collections.Generic.List<Objects.Message> GetRelevantMessages(long userId, int skip, int take);
    }
}
