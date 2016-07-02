using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.DataAccess.model
{
    public class MLocation
    {
        public string Building { get; set; }
        public string Floor { get; set; }
        public string RoomNo { get; set; }

        public DeviceType DeviceType { get; set; }
        public string DeviceSerialNo { get; set; }
        public CommMode CommMode { get; set; }
        public string CommAddress { get; set; }
        public string Description { get; set; }

        public Guid ProjectId { get; set; }
    }
}
