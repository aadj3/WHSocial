using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windesheim.Social.Service.Data.Fake;

namespace Windesheim.Social.Service.Business.UnitTest
{
    [TestClass]
    public class BaseTestclass
    {
        private FakeDataLayer _data;
        public FakeDataLayer Data
        {
            get
            {
                if (_data == null)
                    _data = new FakeDataLayer();

                return _data;
            }
        }
    }
}
