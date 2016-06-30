using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Location
    {
        public Guid LocaitonId { get; set; }

        public string Building { get; set; }
        public string Floor { get; set; }
        public string RoomNo { get; set; }
            
        public DeviceType DeviceType { get; set; }
        public string DeviceSerialNo { get; set; }
        public CommMode CommMode { get; set; }
        public string CommAddress { get; set; }
        public string Description { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relation
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public virtual List<Event> Events { get; set; } = new List<Event>();

        public InstalledMotor InstallMotor { get; set; }
        #endregion
    }
}
