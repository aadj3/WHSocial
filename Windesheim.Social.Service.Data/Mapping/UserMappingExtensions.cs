using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Data.Mapping
{
    public static class UserMappingExtensions
    {
        public static User AsExposableObject(this Users user)
        {
            if (user.facebookId.HasValue)
                return new FacebookUser
                {
                    UserId = user.userId,
                    FacebookUserId = user.facebookId.Value,
                    UserName = user.userName
                };
            else
                return new User
                {
                    UserId = user.userId,
                    UserName = user.userName
                };
        }
    }
}
