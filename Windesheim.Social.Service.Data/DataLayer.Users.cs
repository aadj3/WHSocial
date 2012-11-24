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
        public long CheckOrInsertFacebookUser(FacebookUser user)
        {
            var existingUser = _data.Users.SingleOrDefault(s => s.facebookId == user.FacebookUserId);
            if (existingUser == null)
                return InsertUser(user);
            else
                return existingUser.userId;
        }

        public long InsertUser(User user)
        {
            var newuser = new Users();
            newuser.userName = user.UserName;

            //Check facebookid
            var facebookUser = user as FacebookUser;
            if (facebookUser != null)
                newuser.facebookId = facebookUser.FacebookUserId;

            _data.Users.AddObject(newuser);
            _data.SaveChanges();

            return newuser.userId;
        }

        public User GetUser(long userId)
        {
            return _data.Users.SingleOrDefault(s => s.userId == userId).AsExposableObject();
        }
	}
}
