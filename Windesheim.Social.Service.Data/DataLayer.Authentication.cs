using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windesheim.Social.Objects;

namespace Windesheim.Social.Service.Data
{
	public partial class DataLayer
	{
        public KeyValuePair<Guid, DateTime> StartSession(long userId, Guid ticket)
        {
            var session = _data.Sessions.SingleOrDefault(s => s.userId == userId);
            if (session != null)
                _data.Sessions.DeleteObject(session);

            var newSession = new Sessions() { userId = userId, ticket = ticket, validTill = DateTime.Now.AddMinutes(10) };

            _data.Sessions.AddObject(newSession);

            _data.SaveChanges();

            return new KeyValuePair<Guid, DateTime>(ticket, newSession.validTill);
        }

        public Sessions GetSession(Authentication header)
        {
            if (header == null)
                return null;

            var result = _data.Sessions.SingleOrDefault(s => s.userId == header.UserId 
                && s.ticket == header.Ticket);

            if (result != null)
                if (result.validTill.ToShortDateString() != header.ValidTill.ToShortDateString())
                    result = null;

            return result;
        }
    }
}
