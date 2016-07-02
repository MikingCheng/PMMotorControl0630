using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMWebAPI.DataAccess.model;
using PMWebAPI.DataAccess.IRepository;
using PMWebAPI.PMDomain.EFContext;
using PMWebAPI.PMDomain.Entity;

namespace PMWebAPI.DataAccess.Repository
{
    public class GroupRepository: IGroupRepository
    {
        private ShadingContext _context;

        #region constructor
        public GroupRepository() { }

        public GroupRepository(ShadingContext context)
        {
            this._context = context;
        }
        #endregion

        public async Task<IEnumerable<MGroup>> GetAllGroupAsync(Guid projectId)
        {
            var _group = await this._context.Groups
                                            .Where(g => g.ProjectId == projectId)
                                            .ToListAsync<Group>();

            return _group.Select(g => new MGroup
            {
                GroupName = g.GroupName,
                ProjectId = projectId
            });
        }

        public void Add(MGroup mGroup)
        {
            this._context.Groups.Add(new Group
            {
                GroupId = new Guid(),
                GroupName = mGroup.GroupName,
                ModifiedDate = DateTime.Now,
                ProjectId = mGroup.ProjectId,
                SceneId = null
            });

            this._context.SaveChanges();
        }

        public void Remove(MGroup mGroup)
        {
            var _group = this._context.Groups
                                    .Where(g => g.ProjectId == mGroup.ProjectId && g.GroupName == mGroup.GroupName)
                                    .First<Group>();
            this._context.Remove(_group);

            // remove date form the related table
            var _groupMotor = _context.GroupInstalledMotors.Where(gl => gl.GroupId == _group.GroupId);
            foreach (var gl in _groupMotor)
            {
                _context.GroupInstalledMotors.Remove(gl);
            }

            _context.SaveChanges();
        }

        public void UpdateGroupName(MGroup mGroup)
        {
            var _group = this._context.Groups
                                    .Where(g => g.ProjectId == mGroup.ProjectId && g.GroupName == mGroup.GroupName)
                                    .First<Group>();
            _group.GroupName = mGroup.GroupName;

            _context.Groups.Update(_group);
            _context.SaveChanges();
        }

    }
}
