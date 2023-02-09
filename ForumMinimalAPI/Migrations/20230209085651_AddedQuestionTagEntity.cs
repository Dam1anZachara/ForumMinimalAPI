using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumMinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuestionTagEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Questions_QuestionsId",
                table: "QuestionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Tags_TagsId",
                table: "QuestionTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "QuestionTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "QuestionTag",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTag_TagsId",
                table: "QuestionTag",
                newName: "IX_QuestionTag_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Tags_TagId",
                table: "QuestionTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Questions_QuestionId",
                table: "QuestionTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTag_Tags_TagId",
                table: "QuestionTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "QuestionTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "QuestionTag",
                newName: "QuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionTag_TagId",
                table: "QuestionTag",
                newName: "IX_QuestionTag_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Questions_QuestionsId",
                table: "QuestionTag",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTag_Tags_TagsId",
                table: "QuestionTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
