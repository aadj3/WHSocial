using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Service.Data;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Business
{
    public class GroupBusiness : IBusinessClass
    {
        private Data.DataLayer _data;

        public GroupBusiness(DataLayer data)
        {
            this._data = data;
        }

        public List<Group> GetGroups()
        {
            var result = _data.GetGroups();

            return result;
        }

        public void Dispose()
        {
            
        }
    }
}
