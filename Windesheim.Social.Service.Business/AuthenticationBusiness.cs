using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;
using Windesheim.Social.Service.Data;

namespace Windesheim.Social.Service.Business
{
    public class AuthenticationBusiness : IBusinessClass
    {
        private Data.DataLayer _data;

        public AuthenticationBusiness(DataLayer data)
        {
            this._data = data;
        }

        public Authentication Login(LoginCredentials credentials)
        {
            var result = new Authentication();

            var facebookCredentials = credentials as FacebookLoginCredentials;
            if (facebookCredentials != null)
            {
                var facebookSession = new Facebook.FacebookClient(facebookCredentials.AccessToken);

                dynamic me = facebookSession.Get("me");
                var facebookUser = new FacebookUser
                {
                    FacebookUserId = long.Parse(me["id"]),
                    UserName = me["username"]
                };

                result.UserId = _data.CheckOrInsertFacebookUser(facebookUser);
                var session = StartSession(result.UserId);
                result.Ticket = session.Key;
                result.ValidTill = session.Value;

                return result;
            }

            throw new NotImplementedException("Only facebook users are supported now");
        }

        private KeyValuePair<Guid, DateTime> StartSession(long userId)
        {
            var ticket = Guid.NewGuid();
            return _data.StartSession(userId, ticket);
        }

        public void Dispose()
        {
            if (_data != null)
                _data.Dispose();
        }
    }
}
