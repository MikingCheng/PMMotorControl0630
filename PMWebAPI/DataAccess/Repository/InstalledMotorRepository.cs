using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMWebAPI.DataAccess.IRepository;
using PMWebAPI.DataAccess.model;
using PMWebAPI.PMDomain.EFContext;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.DataAccess.Repository
{
    public class InstalledMotorRepository: IInstalledMotorRepository
    {
        private ShadingContext _context;

        #region constructor
        public InstalledMotorRepository() { }

        public InstalledMotorRepository(ShadingContext context)
        {
            this._context = context;
        }
        #endregion

        public async Task<IEnumerable<MInstalledMotor>> GetAllInstalledMotorAsync(Guid projectId)
        {

            var _location = await this._context.Locations
                                .Where(l => l.ProjectId == projectId)
                                .Include(l => l.InstalledMotor)
                                .ToListAsync();

            List<InstalledMotor> _installedMotor = new List<InstalledMotor>();
            return _location.Where(l=>l.InstalledMotor!=null).Select(l => new MInstalledMotor
            {
                Floor=l.Floor,
                RoomNo=l.RoomNo,
                Orientation =l.InstalledMotor.Orientation,
                MotorLocationNumber=l.InstalledMotor.MotorLocationNumber,
                CommAddress=l.CommAddress,
                DeviceSerialNo=l.DeviceSerialNo,
                FavorPositionFirst=l.InstalledMotor.FavorPositionFirst,
                FavorPositionrSecond=l.InstalledMotor.FavorPositionrSecond,
                FavorPositionThird=l.InstalledMotor.FavorPositionThird
            });
  
        }

        public void Add(MInstalledMotor mInstallMotor, Guid locaitonId)
        {
            this._context.InstalledMotors.Add(new InstalledMotor
            {
                InstalledMotorId = new Guid(),
                Orientation = mInstallMotor.Orientation,
                MotorLocationNumber = mInstallMotor.MotorLocationNumber,
                FavorPositionFirst=mInstallMotor.FavorPositionFirst,
                FavorPositionrSecond=mInstallMotor.FavorPositionrSecond,
                FavorPositionThird=mInstallMotor.FavorPositionThird,
                LocationId = locaitonId,
                ModifiedDate=DateTime.Now
            });

            this._context.SaveChanges();
        }

        public void Remove(Guid locationId, int motorLocationNumber)
        {
            var _installedMotor = this._context.InstalledMotors
                                    .Where(m => m.LocationId == locationId && m.MotorLocationNumber == motorLocationNumber)
                                    .First<InstalledMotor>();
            this._context.Remove(_installedMotor);

            // remove date form the related table
            var _location = _context.Locations.Where(l => l.LocaitonId == locationId).Single<Location>();
            _context.Locations.Remove(_location);

            _context.SaveChanges();
        }

        public void UpdateGroupName(MInstalledMotor mInstalledMotor, Guid installedMotorId)
        {
            var _installedMotor = this._context.InstalledMotors
                             .Where(g => g.InstalledMotorId == installedMotorId)
                             .First<InstalledMotor>();

            _installedMotor.Orientation = mInstalledMotor.Orientation;
            _installedMotor.MotorLocationNumber = mInstalledMotor.MotorLocationNumber;
            _installedMotor.FavorPositionFirst = mInstalledMotor.FavorPositionFirst;
            _installedMotor.FavorPositionrSecond = mInstalledMotor.FavorPositionrSecond;
            _installedMotor.FavorPositionThird = mInstalledMotor.FavorPositionThird;
            _installedMotor.ModifiedDate = DateTime.Now;

            _context.InstalledMotors.Update(_installedMotor);
            _context.SaveChanges();
        }

    }
}
