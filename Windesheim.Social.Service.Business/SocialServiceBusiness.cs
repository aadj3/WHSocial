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
        public SocialServiceBusiness()
        {}

        public SocialServiceBusiness(IDataLayer data)
        {
            _data = data;
        }

        private IDataLayer _data;
        private IDataLayer Data
        {
            get
            {
                if (_data == null)
                    _data = new DataLayer();
                return _data;
            }
        }

        #region [ Access to business classes ]

        private List<BusinessClass> _businessInstances = new List<BusinessClass>();

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
    }
}