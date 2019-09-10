using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coursework.Migrations
{
    public partial class CommentsFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_MyUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_MyUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "MyUserId",
                table: "Comments",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Comments",
                newName: "MyUserId");

            migrationBuilder.AlterColumn<string>(
                name: "MyUserId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
