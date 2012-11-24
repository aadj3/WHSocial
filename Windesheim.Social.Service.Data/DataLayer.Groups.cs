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
        public List<Group> GetGroups()
        {
            return _data.Groups.ToList().AsExposableObject();
        }
    }
}
