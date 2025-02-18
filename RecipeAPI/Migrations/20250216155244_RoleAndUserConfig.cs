using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoleAndUserConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9996b69-3a27-4016-852c-23da3165904d", "AQAAAAIAAYagAAAAEEdv9H3Y6t+1AnnXlpAxjFh97mxMV2hzhHvcqCfvN5G2MttnGhvhMD3yLz9VqaqUUQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ada7d8ad-ec8e-49ef-b88c-d864bf38be79", "AQAAAAIAAYagAAAAEJgOZKFMU4lVyt6loJ2LpOqgRTVtRnPiAAtaPVrkKEKOXr6lhxDpJFap54BFQh3wpg==" });
        }
    }
}
