using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMWebAPI.Migrations
{
    public partial class firstM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventMessages",
                columns: table => new
                {
                    EventMessageId = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(maxLength: 100, nullable: true),
                    MessageCode = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMessages", x => x.EventMessageId);
                });

            migrationBuilder.CreateTable(
                name: "MotorInfoes",
                columns: table => new
                {
                    MotorInfoId = table.Column<Guid>(nullable: false),
                    Diameter = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Torque = table.Column<int>(nullable: false),
                    Voltage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorInfoes", x => x.MotorInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectName = table.Column<string>(maxLength: 60, nullable: false),
                    ProjectNumber = table.Column<string>(maxLength: 20, nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<Guid>(nullable: false),
                    Day = table.Column<string>(maxLength: 4, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                    table.ForeignKey(
                        name: "FK_Holidays_Projects_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocaitonId = table.Column<Guid>(nullable: false),
                    Building = table.Column<string>(maxLength: 80, nullable: false),
                    CommAddress = table.Column<string>(maxLength: 40, nullable: true),
                    CommMode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceSerialNo = table.Column<string>(maxLength: 16, nullable: true),
                    DeviceType = table.Column<int>(nullable: false),
                    Floor = table.Column<string>(maxLength: 20, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    RoomNo = table.Column<string>(maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocaitonId);
                    table.ForeignKey(
                        name: "FK_Locations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                    table.ForeignKey(
                        name: "FK_Operators_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    SceneId = table.Column<Guid>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    SceneName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.SceneId);
                    table.ForeignKey(
                        name: "FK_Scenes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    EventMessageId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_EventMessages_EventMessageId",
                        column: x => x.EventMessageId,
                        principalTable: "EventMessages",
                        principalColumn: "EventMessageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocaitonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstalledMotors",
                columns: table => new
                {
                    InstalledMotorId = table.Column<Guid>(nullable: false),
                    FavorPositionFirst = table.Column<int>(nullable: false),
                    FavorPositionThird = table.Column<int>(nullable: false),
                    FavorPositionrSecond = table.Column<int>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    MotorInfoId = table.Column<Guid>(nullable: true),
                    MotorLocationNumber = table.Column<int>(nullable: false),
                    Orientation = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalledMotors", x => x.InstalledMotorId);
                    table.ForeignKey(
                        name: "FK_InstalledMotors_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocaitonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstalledMotors_MotorInfoes_MotorInfoId",
                        column: x => x.MotorInfoId,
                        principalTable: "MotorInfoes",
                        principalColumn: "MotorInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    SceneId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "SceneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SceneSegments",
                columns: table => new
                {
                    SceneSegmentId = table.Column<Guid>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    SceneId = table.Column<Guid>(nullable: false),
                    SequenceNo = table.Column<int>(nullable: false),
                    StartTime = table.Column<string>(maxLength: 4, nullable: false),
                    Volumn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneSegments", x => x.SceneSegmentId);
                    table.ForeignKey(
                        name: "FK_SceneSegments_Scenes_SceneId",
                        column: x => x.SceneId,
                        principalTable: "Scenes",
                        principalColumn: "SceneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupInstalledMotor",
                columns: table => new
                {
                    GroupInstalledMotorId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: true),
                    InstalledMotorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupInstalledMotor", x => x.GroupInstalledMotorId);
                    table.ForeignKey(
                        name: "FK_GroupInstalledMotor_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupInstalledMotor_InstalledMotors_InstalledMotorId",
                        column: x => x.InstalledMotorId,
                        principalTable: "InstalledMotors",
                        principalColumn: "InstalledMotorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventMessageId",
                table: "Events",
                column: "EventMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LocationId",
                table: "Events",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupName",
                table: "Groups",
                column: "GroupName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ProjectId",
                table: "Groups",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SceneId",
                table: "Groups",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupInstalledMotor_GroupId",
                table: "GroupInstalledMotor",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupInstalledMotor_InstalledMotorId",
                table: "GroupInstalledMotor",
                column: "InstalledMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_HolidayId",
                table: "Holidays",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_InstalledMotors_LocationId",
                table: "InstalledMotors",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstalledMotors_MotorInfoId",
                table: "InstalledMotors",
                column: "MotorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProjectId",
                table: "Locations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_ProjectId",
                table: "Operators",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Scenes_ProjectId",
                table: "Scenes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneSegments_SceneId",
                table: "SceneSegments",
                column: "SceneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GroupInstalledMotor");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "SceneSegments");

            migrationBuilder.DropTable(
                name: "EventMessages");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "InstalledMotors");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MotorInfoes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
