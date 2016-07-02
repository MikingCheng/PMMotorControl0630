using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.DataAccess.model
{
    public class MInstalledMotor
    {
        public string Floor { get; set; }
        public string RoomNo { get; set; }
        public string DeviceSerialNo { get; set; }
        public string CommAddress { get; set; }
        public Orientation Orientation { get; set; }
        public int MotorLocationNumber { get; set; }
        public int FavorPositionFirst { get; set; }
        public int FavorPositionrSecond { get; set; }
        public int FavorPositionThird { get; set; }

    }
}
