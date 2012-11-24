using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windesheim.Social.Service.Data
{
    public partial class DataLayer : IDisposable
    {
        private WindesheimSocialDatabase _data;

        public DataLayer()
        {
            _data = new WindesheimSocialDatabase();
        }

        public void Dispose()
        {
            _data.Dispose();
        }
    }
}
