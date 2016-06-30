using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMWebAPI.PMDomain.Entity
{
    public class Scene
    {
        public Guid SceneId { get; set; }

        public String SceneName { get; set; }
        public bool Enable { get; set; }

        public DateTime ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        #region relationship
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public List<SceneSegment> SceneSegments { get; set; }
        public virtual List<Group> Groups { get; set; } = new List<Group>();
        #endregion
    }
}
