using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentPost");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId1",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId1",
                table: "Comments",
                column: "PostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId1",
                table: "Comments",
                column: "PostId1",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId1",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "CommentPost",
                columns: table => new
                {
                    CommentsCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostForId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPost", x => new { x.CommentsCommentId, x.PostForId });
                    table.ForeignKey(
                        name: "FK_CommentPost_Comments_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentPost_Posts_PostForId",
                        column: x => x.PostForId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPost_PostForId",
                table: "CommentPost",
                column: "PostForId");
        }
    }
}
