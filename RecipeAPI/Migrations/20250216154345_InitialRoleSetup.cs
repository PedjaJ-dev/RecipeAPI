using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialRoleSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContentName",
                table: "Comments",
                newName: "Content");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "ContentName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b2a08fd-9760-42f1-ad83-891d595bd15c", "AQAAAAIAAYagAAAAEGeIzGbAPpXCIsHt4b/qDutz+Z7UYc0Y60ZbFDni9ckdbo/V3g9jfa7k/jiWmeurMA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0c024dab-f3cd-40f7-80b6-6b45a18cf7c0", "AQAAAAIAAYagAAAAELY8grRICM1+fYTEvoXSzq1/xNjgFb09o5spvF1mg9f9eDTeOgACFaRVn0tzNK28xA==" });
        }
    }
}
