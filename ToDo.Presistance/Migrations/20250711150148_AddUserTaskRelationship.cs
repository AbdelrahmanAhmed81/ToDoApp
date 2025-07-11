using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTaskRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Application",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Tasks",
                columns: new[] { "ID", "CreationDate", "DeletionDate", "DueDate", "IsDeleted", "IsDone", "LastModificationDate", "Note", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("2efc9277-e5ff-4990-a317-370ca89a9024"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "here are some notes", 3, "pay electricity bill", new Guid("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5") },
                    { new Guid("3affb6b7-7eb8-4310-9123-61a47357d1f5"), new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "call Ahmed", new Guid("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5") },
                    { new Guid("91a92362-1c2e-4149-a84a-4d4d6a23c367"), new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "prepare your passport", 2, "prepare for christmas trip", new Guid("1c48f7a0-2dbc-42d8-b31c-e53b6b2244b5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                schema: "Application",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_UserId",
                schema: "Application",
                table: "Tasks",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_UserId",
                schema: "Application",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                schema: "Application",
                table: "Tasks");

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Tasks",
                keyColumn: "ID",
                keyValue: new Guid("2efc9277-e5ff-4990-a317-370ca89a9024"));

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Tasks",
                keyColumn: "ID",
                keyValue: new Guid("3affb6b7-7eb8-4310-9123-61a47357d1f5"));

            migrationBuilder.DeleteData(
                schema: "Application",
                table: "Tasks",
                keyColumn: "ID",
                keyValue: new Guid("91a92362-1c2e-4149-a84a-4d4d6a23c367"));

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Application",
                table: "Tasks");
        }
    }
}
