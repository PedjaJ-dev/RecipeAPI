using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7730cac3-f44b-4863-897e-330402d9d179", "AQAAAAIAAYagAAAAEJ1+D07d4MiaaVWyizUJJEdea848O1L0LnkfQn4m504279XE0P9fiw0cN+vsyHKKWA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3a39f165-749f-4c3e-9caf-46e3e1774ae4", "AQAAAAIAAYagAAAAEL5i7OZkIiUpM899LvDy8gtCDEXcjXF7sfVZj5EKW7nJv4oqH4DlAzEQATIokEBbjQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34afb19f-9bdf-4a46-872d-718b2c593ae9", "AQAAAAIAAYagAAAAEPBag8sOx8Vtjozw6c/jdGKfgP4q8aSqe9/bMpXRw1QeK3gYW7WVrlRm4DmjOMj7TA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ce1a2ad-a4b5-4bdd-b3c1-6ab0d8387743", "AQAAAAIAAYagAAAAEC6+9Ldccbe4d2VMkxiKxQ9LeyBjbnv8+g8ud4w0oZPn0jffd3+RWf2akSQEVafjJw==" });
        }
    }
}
