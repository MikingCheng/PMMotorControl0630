using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.DataAccess.model
{
    public class MEvent
    {
        public int MessageCode { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? LocationId { get; set; }
        public string Comment { get; set; }
    }
}
