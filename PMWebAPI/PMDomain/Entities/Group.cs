using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Group
    {
        public Guid GroupId { get; set; }

        public string GroupName { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region  relationship
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid? SceneId { get; set; }
        public Scene Scene { get; set; }

        public virtual List<GroupInstalledMotor> GroupInstalledMotors { get; set; } = new List<GroupInstalledMotor>();
        #endregion
    }
}
