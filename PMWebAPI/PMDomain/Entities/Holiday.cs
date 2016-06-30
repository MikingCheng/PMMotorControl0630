using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Holiday
    {
        public Guid HolidayId { get; set; }

        public String Day { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relationship
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
    }
}
