using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Service.Data;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Business
{
    public class BusinessClass : IDisposable
    {
        protected IDataLayer _data;

        public BusinessClass(IDataLayer data)
        {
            this._data = data;
        }

        public void Dispose()
        {
            if(_data != null)
            {
                _data.Dispose();
            }
        }
    }
}
