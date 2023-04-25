using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdingJournal.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    BirdID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirdCommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirdScientificName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirdDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirdHabitat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.BirdID);
                });

            migrationBuilder.CreateTable(
                name: "BirdSightings",
                columns: table => new
                {
                    BirdSightingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirdCommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirdID = table.Column<long>(type: "bigint", nullable: true),
                    User_ID = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpottedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFemale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsJuvenile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdSightings", x => x.BirdSightingID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "BirdSightings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
