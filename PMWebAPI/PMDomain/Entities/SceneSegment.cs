using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class SceneSegment
    {
        public Guid SceneSegmentId { get; set; }

        public int SequenceNo { get; set; }
        public string StartTime { get; set; }       //format: hhmm
        public int Volumn { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relationship
        public Guid SceneId { get; set; }
        public virtual Scene Scene { get; set; }
        #endregion
    }
}
