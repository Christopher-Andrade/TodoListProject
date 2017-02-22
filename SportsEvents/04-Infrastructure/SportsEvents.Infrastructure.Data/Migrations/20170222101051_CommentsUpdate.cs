using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsEvents.Infrastructure.Data.Migrations
{
    public partial class CommentsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentParentIdentifier",
                table: "Comments",
                newName: "ParentIdentifier");

            migrationBuilder.AddColumn<int>(
                name: "CommentType",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentType",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentIdentifier",
                table: "Comments",
                newName: "CommentParentIdentifier");
        }
    }
}
