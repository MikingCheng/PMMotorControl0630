using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.DataAccess.model;

namespace PMWebAPI.DataAccess.IRepository
{
    public  interface IGroupRepository
    {
        Task<IEnumerable<MGroup>> GetAllGroupAsync(Guid projectId);
        void Add(MGroup mGroup);
        void Remove(MGroup mGroup);
        void UpdateGroupName(MGroup mGroup);
    }
}
