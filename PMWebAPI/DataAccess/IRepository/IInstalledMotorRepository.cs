using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMWebAPI.DataAccess.model;

namespace PMWebAPI.DataAccess.IRepository
{
    public interface IInstalledMotorRepository
    {
        Task<IEnumerable<MInstalledMotor>> GetAllInstalledMotorAsync(Guid projectId);
        void Add(MInstalledMotor mInstallMotor, Guid locaitonId);
        void Remove(Guid locationId, int motorLocationNumber);
        void UpdateGroupName(MInstalledMotor mLocation, Guid locationId);

    }
}
