using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.DataAccess.model;

namespace PMWebAPI.DataAccess.IRepository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<MProject>> GetAllProjectsAsync(Guid projectId);
        void Add(MProject mProject);
        void Remove(Guid projectId);
        void Update(MProject mProject, Guid projectId);

    }
}
