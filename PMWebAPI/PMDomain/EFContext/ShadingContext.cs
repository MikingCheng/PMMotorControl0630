using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMWebAPI.PMDomain.Entity;


namespace PMWebAPI.PMDomain.EFContext
{
    public class ShadingContext: DbContext
    {
        public ShadingContext(DbContextOptions<ShadingContext> options) : base(options) { }

        public DbSet<Event> Events { get; set;}
        public DbSet<EventMessage> EventMessages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<InstalledMotor> InstalledMotors { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MotorInfo> MotorInfoes { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<SceneSegment> SceneSegments { get; set; }
        public DbSet<GroupInstalledMotor> GroupInstalledMotors { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=DpTest;Initial Catalog=FlugDbE2E;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //            new AlarmMessageConfiguration(modelBuilder.Entity<AlarmMessage>());
            new ConfigEvent(modelBuilder.Entity<Event>());
            new ConfigEventMessage(modelBuilder.Entity<EventMessage>());
            new ConfigGroup(modelBuilder.Entity<Group>());
            new ConfigInstalledMotor(modelBuilder.Entity<InstalledMotor>());
            new ConfigHoliday(modelBuilder.Entity<Holiday>());
            new ConfigGroupInstalledMotor(modelBuilder.Entity<GroupInstalledMotor>());
            new ConfigLocation(modelBuilder.Entity<Location>());
            new ConfigMotorInfo(modelBuilder.Entity<MotorInfo>());
            new ConfigOperator(modelBuilder.Entity<Operator>());
            new ConfigProject(modelBuilder.Entity<Project>());
            new ConfigScene(modelBuilder.Entity<Scene>());
            new ConfigSceneSegment(modelBuilder.Entity<SceneSegment>());
        }
    }
}
