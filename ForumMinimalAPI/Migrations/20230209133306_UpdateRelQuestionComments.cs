using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelQuestionComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.Sql(
                @"UPDATE Comments
                SET QuestionId = 1 WHERE Id = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Questions_QuestionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_QuestionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Comments");
        }
    }
}
