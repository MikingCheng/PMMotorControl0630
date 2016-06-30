using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class InstalledMotor
    {
        public Guid InstalledMotorId { get; set; }

        public Orientation Orientation { get; set; }
        public int MotorLocationNumber { get; set; }
        public int FavorPositionFirst { get; set; }
        public int FavorPositionrSecond { get; set; }
        public int FavorPositionThird { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relationship
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
        
        public Guid? MotorInfoId { get; set; }
        public MotorInfo MotorInfo { get; set; }

        public virtual List<GroupInstalledMotor> GroupInstalledMotors { get; set; } = new List<GroupInstalledMotor>();
        #endregion
    }
}
