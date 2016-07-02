using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PMWebAPI.DataAccess.model;

namespace PMWebAPI.DataAccess.IRepository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<MLocation>> GetAllLocationAsync(Guid projectId);
        void Add(MLocation mLocation);
        void Remove(Guid projectId, Guid locationId);
        void UpdateGroupName(MLocation mLocation, Guid locationId);

    }
}
