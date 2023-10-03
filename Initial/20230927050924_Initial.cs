using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace IS220_WebApplication.Initial
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    id = table.Column<uint>(name: " id", type: "int(10) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    lastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValueSql: "'NULL'"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, defaultValueSql: "'NULL'"),
                    birth = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "'NULL'"),
                    role = table.Column<sbyte>(type: "tinyint(4)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "'current_timestamp()'"),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "'NULL'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.email);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true, defaultValueSql: "'NULL'"),
                    price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, nullable: false),
                    releaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    imgPath = table.Column<string>(type: "tinytext", nullable: true, defaultValueSql: "'NULL'"),
                    publisherID = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    developerID = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    downloadLink = table.Column<string>(type: "tinytext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_Game_Developer",
                        column: x => x.developerID,
                        principalTable: "developer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Publisher",
                        column: x => x.publisherID,
                        principalTable: "publisher",
                        principalColumn: " id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "game_category",
                columns: table => new
                {
                    categoryID = table.Column<uint>(type: "int(10) unsigned", nullable: false),
                    gameID = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GameCategory_Category",
                        column: x => x.categoryID,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategory_Game",
                        column: x => x.gameID,
                        principalTable: "game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "game_owned",
                columns: table => new
                {
                    userEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    gameID = table.Column<uint>(type: "int(10) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GameOwner_Game",
                        column: x => x.gameID,
                        principalTable: "game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameOwner_User",
                        column: x => x.userEmail,
                        principalTable: "user",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_Game_Developer",
                table: "game",
                column: "developerID");

            migrationBuilder.CreateIndex(
                name: "FK_Game_Publisher",
                table: "game",
                column: "publisherID");

            migrationBuilder.CreateIndex(
                name: "FK_GameCategory_Category",
                table: "game_category",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "FK_GameCategory_Game",
                table: "game_category",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "FK_GameOwner_Game",
                table: "game_owned",
                column: "gameID");

            migrationBuilder.CreateIndex(
                name: "FK_GameOwner_User",
                table: "game_owned",
                column: "userEmail");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_category");

            migrationBuilder.DropTable(
                name: "game_owned");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropTable(
                name: "publisher");
        }
    }
}
