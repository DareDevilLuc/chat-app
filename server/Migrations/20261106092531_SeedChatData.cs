using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class SeedChatData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "CreatedAt" },
                values: new object[] { 1, "2026-10-30T18:00:00Z" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "You" },
                    { 2, "Bryan" },
                    { 3, "Alex" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "Content", "CreatedAt", "SenderId" },
                values: new object[,]
                {
                    { 1, 1, "Hey, you coming to the thing tonight?", new DateTime(2026, 10, 31, 2, 30, 0, 0, DateTimeKind.Local), 2 },
                    { 2, 1, "Yeah! What time are we meeting?", new DateTime(2026, 10, 31, 2, 32, 0, 0, DateTimeKind.Local), 1 },
                    { 3, 1, "Around 7:30 PM. We're meeting at the usual spot.", new DateTime(2026, 10, 31, 2, 33, 0, 0, DateTimeKind.Local), 2 },
                    { 4, 1, "Got it. I'll be there!", new DateTime(2026, 10, 31, 2, 35, 0, 0, DateTimeKind.Local), 1 },
                    { 5, 1, "Don't forget to bring the documents tomorrow.", new DateTime(2026, 10, 31, 2, 40, 0, 0, DateTimeKind.Local), 3 },
                    { 6, 1, "Thanks for reminding me. I almost forgot 😂", new DateTime(2026, 10, 31, 2, 42, 0, 0, DateTimeKind.Local), 1 },
                    { 7, 1, "Also, did you finish the project?", new DateTime(2026, 10, 31, 2, 45, 0, 0, DateTimeKind.Local), 2 },
                    { 8, 1, "Almost done. Just fixing a few bugs.", new DateTime(2026, 10, 31, 2, 47, 0, 0, DateTimeKind.Local), 1 },
                    { 9, 1, "Nice! Let me know when it's ready.", new DateTime(2026, 10, 31, 2, 50, 0, 0, DateTimeKind.Local), 2 },
                    { 10, 1, "Will do. See you later!", new DateTime(2026, 10, 31, 2, 52, 0, 0, DateTimeKind.Local), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
