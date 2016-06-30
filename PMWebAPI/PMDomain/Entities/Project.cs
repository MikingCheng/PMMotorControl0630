using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Project
    {
        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string ProjectNumber { get; set; }

        public DateTime ModifiedDate { get; set; }      // alarms generated time
        public byte[] RowVersion { get; set; }

        #region relationship
        public virtual List<Location> Locations { get; set; } = new List<Location>();
        public virtual List<Scene> Scenes { get; set; } = new List<Scene>();
        public virtual List<Holiday> Holidays { get; set; } = new List<Holiday>();
        public virtual List<Group> Groups { get; set; } = new List<Group>();
        public virtual List<Operator> Operators { get; set; } = new List<Operator>();
        #endregion
    }
}
