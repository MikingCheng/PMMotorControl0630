using System;

namespace PMWebAPI.PMDomain.Entity
{
    public class Event
    {
        public Guid EventId { get; set; }

        public string Comment { get; set; }

        public DateTime ModifiedDate { get; set; }      // alarms generated time
        public byte[] RowVersion { get; set; }

        #region relationship
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid EventMessageId { get; set; }
        public EventMessage EventMessage { get; set; }

        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
        #endregion
    }
}
