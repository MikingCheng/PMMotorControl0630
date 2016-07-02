using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.DataAccess.model;

namespace PMWebAPI.DataAccess.IRepository
{
    public interface IEventRepository
    {
        void Add(MEvent mEvent);

        /// <summary>
        /// retrieve all events of project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<MEvent>> GetAllAsync(Guid projectId);
        Task<IEnumerable<MEvent>> GetAllOfLocationAsync(Guid projectId, Guid locationId);
        Task<IEnumerable<MEvent>> GetAllSpecifiedEventAsync(Guid projectId, int messageCode);

    }
}
