using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace Windesheim.Social.Objects
{
    public class Authentication
    {
        public long UserId { get; set; }
        public Guid Ticket { get; set; }
        public DateTime ValidTill { get; set; }
    }
}
