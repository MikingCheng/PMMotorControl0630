using System;
using System.Collections.Generic;

namespace PMWebAPI.PMDomain.Entity
{
    public class EventMessage
    {
        public Guid EventMessageId { get; set; }

        public int MessageCode { get; set; }
        public string Message { get; set; }

        public DateTime ModifiedDate { get; set; }      // alarms generated time
        public byte[] RowVersion { get; set; }

        #region relationship
        public virtual List<Event> Events { get; set; } = new List<Event>();
        #endregion
    }
}
