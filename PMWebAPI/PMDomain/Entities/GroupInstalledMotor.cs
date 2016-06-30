using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class GroupInstalledMotor
    {
        public Guid GroupInstalledMotorId { get; set; }

        public Guid? InstalledMotorId { get; set; }
        public InstalledMotor InstalledMotor { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
