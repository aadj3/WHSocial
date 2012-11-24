using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;
using Windesheim.Social.Service.Data;

namespace Windesheim.Social.Service.Business
{
    public partial class SocialServiceBusiness : IDisposable
    {
        private DataLayer _data;
        private DataLayer Data
        {
            get
            {
                if (_data == null)
                    _data = new DataLayer();
                return _data;
            }
        }

        #region [ Access to business classes ]

        private List<IBusinessClass> _businessInstances = new List<IBusinessClass>();

        public AuthenticationBusiness Authentication
        {
            get
            {
                var b = _businessInstances.OfType<AuthenticationBusiness>().SingleOrDefault();

                if (b == null)
                {
                    b = new AuthenticationBusiness(Data);
                    _businessInstances.Add(b);
                }

                return _businessInstances.OfType<AuthenticationBusiness>().SingleOrDefault();
            }
        }

        public GroupBusiness Groups
        {
            get
            {
                var b = _businessInstances.OfType<GroupBusiness>().SingleOrDefault();

                if (b == null)
                {
                    b = new GroupBusiness(Data);
                    _businessInstances.Add(b);
                }

                return _businessInstances.OfType<GroupBusiness>().SingleOrDefault();
            }
        }

        #endregion

        public void Dispose()
        {
            foreach (var item in _businessInstances)
                item.Dispose();

            if (_data != null)
                _data.Dispose();
        }

        public bool UserHasAccess(Authentication auth, int groupId)
        {
            AuthenticateUser(auth);

            return true;
        }

        private void AuthenticateUser(Authentication auth)
        {
            var session = Data.GetSession(auth);
            if (session == null)
                throw new AccessViolationException("Header is not valid");
        }
    }
}