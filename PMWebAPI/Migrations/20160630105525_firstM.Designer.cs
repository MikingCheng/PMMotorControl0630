using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PMWebAPI.PMDomain.EFContext;

namespace PMWebAPI.Migrations
{
    [DbContext(typeof(ShadingContext))]
    [Migration("20160630105525_firstM")]
    partial class firstM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<Guid>("EventMessageId");

                    b.Property<Guid?>("LocationId");

                    b.Property<DateTime>("ModifiedDate")
                        .IsConcurrencyToken();

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("EventId");

                    b.HasIndex("EventMessageId");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.EventMessage", b =>
                {
                    b.Property<Guid>("EventMessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("MessageCode");

                    b.Property<DateTime>("ModifiedDate")
                        .IsConcurrencyToken();

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("EventMessageId");

                    b.ToTable("EventMessages");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid>("ProjectId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<Guid?>("SceneId");

                    b.HasKey("GroupId");

                    b.HasIndex("GroupName")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.HasIndex("SceneId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.GroupInstalledMotor", b =>
                {
                    b.Property<Guid>("GroupInstalledMotorId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<Guid?>("InstalledMotorId");

                    b.HasKey("GroupInstalledMotorId");

                    b.HasIndex("GroupId");

                    b.HasIndex("InstalledMotorId");

                    b.ToTable("GroupInstalledMotor");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Holiday", b =>
                {
                    b.Property<Guid>("HolidayId");

                    b.Property<string>("Day")
                        .HasAnnotation("MaxLength", 4);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("ProjectId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("HolidayId");

                    b.HasIndex("HolidayId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.InstalledMotor", b =>
                {
                    b.Property<Guid>("InstalledMotorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FavorPositionFirst");

                    b.Property<int>("FavorPositionThird");

                    b.Property<int>("FavorPositionrSecond");

                    b.Property<Guid>("LocationId");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid?>("MotorInfoId");

                    b.Property<int>("MotorLocationNumber");

                    b.Property<int>("Orientation");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("InstalledMotorId");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("MotorInfoId");

                    b.ToTable("InstalledMotors");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Location", b =>
                {
                    b.Property<Guid>("LocaitonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("CommAddress")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<int>("CommMode");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("DeviceSerialNo")
                        .HasAnnotation("MaxLength", 16);

                    b.Property<int>("DeviceType");

                    b.Property<string>("Floor")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("ModifiedDate")
                        .IsConcurrencyToken();

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("RoomNo")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("LocaitonId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.MotorInfo", b =>
                {
                    b.Property<Guid>("MotorInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Diameter");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<int>("Torque");

                    b.Property<int>("Voltage");

                    b.HasKey("MotorInfoId");

                    b.ToTable("MotorInfoes");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Operator", b =>
                {
                    b.Property<Guid>("OperatorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Password")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<Guid>("ProjectId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("OperatorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Operators");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 60);

                    b.Property<string>("ProjectNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Scene", b =>
                {
                    b.Property<Guid>("SceneId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enable");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<Guid>("ProjectId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<string>("SceneName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("SceneId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.SceneSegment", b =>
                {
                    b.Property<Guid>("SceneSegmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken();

                    b.Property<Guid>("SceneId");

                    b.Property<int>("SequenceNo");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 4);

                    b.Property<int>("Volumn");

                    b.HasKey("SceneSegmentId");

                    b.HasIndex("SceneId");

                    b.ToTable("SceneSegments");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Event", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.EventMessage", "EventMessage")
                        .WithMany("Events")
                        .HasForeignKey("EventMessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMWebAPI.PMDomain.Entity.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Group", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Project", "Project")
                        .WithMany("Groups")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMWebAPI.PMDomain.Entity.Scene", "Scene")
                        .WithMany("Groups")
                        .HasForeignKey("SceneId");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.GroupInstalledMotor", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Group", "Group")
                        .WithMany("GroupInstalledMotors")
                        .HasForeignKey("GroupId");

                    b.HasOne("PMWebAPI.PMDomain.Entity.InstalledMotor", "InstalledMotor")
                        .WithMany("GroupInstalledMotors")
                        .HasForeignKey("InstalledMotorId");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Holiday", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Project", "Project")
                        .WithMany("Holidays")
                        .HasForeignKey("HolidayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.InstalledMotor", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Location", "Location")
                        .WithOne("InstallMotor")
                        .HasForeignKey("PMWebAPI.PMDomain.Entity.InstalledMotor", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PMWebAPI.PMDomain.Entity.MotorInfo", "MotorInfo")
                        .WithMany("InstalledMotors")
                        .HasForeignKey("MotorInfoId");
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Location", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Project", "Project")
                        .WithMany("Locations")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Operator", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Project", "Project")
                        .WithMany("Operators")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.Scene", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Project", "Project")
                        .WithMany("Scenes")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PMWebAPI.PMDomain.Entity.SceneSegment", b =>
                {
                    b.HasOne("PMWebAPI.PMDomain.Entity.Scene", "Scene")
                        .WithMany("SceneSegments")
                        .HasForeignKey("SceneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
