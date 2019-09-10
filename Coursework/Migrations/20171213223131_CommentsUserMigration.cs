using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework.Migrations
{
    public partial class CommentsUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_MyUserId",
                table: "Comments",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_MyUserId",
                table: "Comments",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_MyUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MyUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Comments");
        }
    }
}
