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
    public class LocationRepository: ILocationRepository
    {
        private ShadingContext _context;

        #region constructor
        public LocationRepository() { }

        public LocationRepository(ShadingContext context)
        {
            this._context = context;
        }
        #endregion

        public async Task<IEnumerable<MLocation>> GetAllLocationAsync(Guid projectId)
        {
            var _location = await this._context.Locations
                                .Where(l => l.ProjectId == projectId)
                                .ToListAsync<Location>();

            return _location.Select(l => new MLocation
            {
                Building = l.Building,
                Floor = l.Floor,
                RoomNo=l.RoomNo,
                DeviceType=l.DeviceType,
                DeviceSerialNo=l.DeviceSerialNo,
                CommAddress =l.CommAddress,
                CommMode=l.CommMode
            });

        }
        public void Add(MLocation mLocation)
        {
            this._context.Locations.Add(new Location
            {
                LocaitonId=new Guid(),
                Building = mLocation.Building,
                Floor = mLocation.Floor,
                RoomNo = mLocation.RoomNo,
                DeviceType = mLocation.DeviceType,
                DeviceSerialNo=mLocation.DeviceSerialNo,
                CommAddress = mLocation.CommAddress,
                CommMode = mLocation.CommMode,
                ModifiedDate=DateTime.Now,
                ProjectId=mLocation.ProjectId
            });

            this._context.SaveChanges();
        }

        public void Remove(Guid projectId, Guid locationId )
        {
            var _location = this._context.Locations
                                .Where(l => l.ProjectId == projectId && l.LocaitonId == locationId)
                                .First<Location>();
            this._context.Remove(_location);

            // remove date form the event table manually
            var _event = _context.Events.Where(e => e.ProjectId == projectId);
            foreach (var e in _event)
            {
                _context.Events.Remove(e);
            }

            _context.SaveChanges();

        }

        public void UpdateGroupName(MLocation mLocation, Guid locationId)
        {
            var _location = this._context.Locations
                                      .Where(l => l.ProjectId == mLocation.ProjectId && l.LocaitonId == locationId)
                                      .First<Location>();

            _location.LocaitonId = locationId;
            _location.Building = mLocation.Building;
            _location.Floor = mLocation.Floor;
            _location.RoomNo = mLocation.RoomNo;
            _location.DeviceType = mLocation.DeviceType;
            _location.DeviceSerialNo = mLocation.DeviceSerialNo;
            _location.CommAddress = mLocation.CommAddress;
            _location.CommMode = mLocation.CommMode;
            _location.ModifiedDate = DateTime.Now;
            _location.ProjectId = mLocation.ProjectId;

            _context.Locations.Update(_location);
            _context.SaveChanges();
        }

    }
}
