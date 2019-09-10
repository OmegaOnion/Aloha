using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework.Migrations
{
    public partial class CommentForeignKeyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Announcements_MyAnnouncementId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MyAnnouncementId",
                table: "Comments",
                newName: "Announcement");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MyAnnouncementId",
                table: "Comments",
                newName: "IX_Comments_Announcement");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Announcements_Announcement",
                table: "Comments",
                column: "Announcement",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Announcements_Announcement",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Announcement",
                table: "Comments",
                newName: "MyAnnouncementId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_Announcement",
                table: "Comments",
                newName: "IX_Comments_MyAnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Announcements_MyAnnouncementId",
                table: "Comments",
                column: "MyAnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
