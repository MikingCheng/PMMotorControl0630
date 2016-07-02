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
    public class ProjectRepository: IProjectRepository
    {
        private ShadingContext _context;

        #region constructor
        public ProjectRepository() { }

        public ProjectRepository(ShadingContext context)
        {
            this._context = context;
        }
        #endregion

        public async Task<IEnumerable<MProject>> GetAllProjectsAsync(Guid projectId)
        {
            var _project = await this._context.Projects
                                .Where(g => g.ProjectId == projectId)
                                .ToListAsync<Project>();

            return _project.Select(p => new MProject
            {
                ProjectName = p.ProjectName,
                ProjectNumber = p.ProjectNumber
            });
        }

        public void Add(MProject mProject)
        {
            this._context.Projects.Add(new Project
            {
                ProjectId = new Guid(),
                ProjectName = mProject.ProjectName,
                ProjectNumber=mProject.ProjectNumber,
                ModifiedDate = DateTime.Now,
            });

            this._context.SaveChanges();
        }

        public void Remove(Guid projectId)
        {
            var _project = this._context.Projects
                        .Where(p => p.ProjectId == projectId)
                        .First<Project>();
            this._context.Remove(_project);

            //// remove date form the related table
            //var _groupMotor = _context.GroupInstalledMotors.Where(gl => gl.GroupId == _group.GroupId);
            //foreach (var gl in _groupMotor)
            //{
            //    _context.GroupInstalledMotors.Remove(gl);
            //}

            _context.SaveChanges();

        }

        public void Update(MProject mProject, Guid projectId)
        {
            var _project = this._context.Projects
                        .Where(p => p.ProjectId ==projectId )
                        .First<Project>();
            _project.ProjectName = mProject.ProjectName;
            _project.ProjectNumber = mProject.ProjectNumber;

            _context.Projects.Update(_project);
            _context.SaveChanges();
        }

    }
}
