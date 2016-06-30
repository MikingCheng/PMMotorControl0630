using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Operator
    {
        public Guid OperatorId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public DateTime ModifiedDate { get; set; }      // alarms generated time
        public byte[] RowVersion { get; set; }

        #region relationship
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        #endregion
    }
}
