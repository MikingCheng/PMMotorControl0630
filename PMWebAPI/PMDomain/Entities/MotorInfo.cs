using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class MotorInfo
    {
        public Guid MotorInfoId { get; set; }

        public MotorDiameter Diameter { get; set; }
        public MotorTorque Torque { get; set; }
        public MotorVoltage Voltage { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relationship
        public virtual IList<InstalledMotor> InstalledMotors { get; set; } = new List<InstalledMotor>();
        #endregion
    }
}
