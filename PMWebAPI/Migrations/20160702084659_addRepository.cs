using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMWebAPI.Migrations
{
    public partial class addRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupInstalledMotor_Groups_GroupId",
                table: "GroupInstalledMotor");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupInstalledMotor_InstalledMotors_InstalledMotorId",
                table: "GroupInstalledMotor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupInstalledMotor",
                table: "GroupInstalledMotor");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Events",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupInstalledMotors",
                table: "GroupInstalledMotor",
                column: "GroupInstalledMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProjectId",
                table: "Events",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Projects_ProjectId",
                table: "Events",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupInstalledMotors_Groups_GroupId",
                table: "GroupInstalledMotor",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupInstalledMotors_InstalledMotors_InstalledMotorId",
                table: "GroupInstalledMotor",
                column: "InstalledMotorId",
                principalTable: "InstalledMotors",
                principalColumn: "InstalledMotorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_GroupInstalledMotor_InstalledMotorId",
                table: "GroupInstalledMotor",
                newName: "IX_GroupInstalledMotors_InstalledMotorId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupInstalledMotor_GroupId",
                table: "GroupInstalledMotor",
                newName: "IX_GroupInstalledMotors_GroupId");

            migrationBuilder.RenameTable(
                name: "GroupInstalledMotor",
                newName: "GroupInstalledMotors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Projects_ProjectId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupInstalledMotors_Groups_GroupId",
                table: "GroupInstalledMotors");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupInstalledMotors_InstalledMotors_InstalledMotorId",
                table: "GroupInstalledMotors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupInstalledMotors",
                table: "GroupInstalledMotors");

            migrationBuilder.DropIndex(
                name: "IX_Events_ProjectId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupInstalledMotor",
                table: "GroupInstalledMotors",
                column: "GroupInstalledMotorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupInstalledMotor_Groups_GroupId",
                table: "GroupInstalledMotors",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupInstalledMotor_InstalledMotors_InstalledMotorId",
                table: "GroupInstalledMotors",
                column: "InstalledMotorId",
                principalTable: "InstalledMotors",
                principalColumn: "InstalledMotorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_GroupInstalledMotors_InstalledMotorId",
                table: "GroupInstalledMotors",
                newName: "IX_GroupInstalledMotor_InstalledMotorId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupInstalledMotors_GroupId",
                table: "GroupInstalledMotors",
                newName: "IX_GroupInstalledMotor_GroupId");

            migrationBuilder.RenameTable(
                name: "GroupInstalledMotors",
                newName: "GroupInstalledMotor");
        }
    }
}
