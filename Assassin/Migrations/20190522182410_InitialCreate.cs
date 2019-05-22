using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assassin.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    game_id = table.Column<int>(nullable: false),
                    assassin_id = table.Column<int>(nullable: false),
                    target_id = table.Column<int>(nullable: false),
                    contract_start = table.Column<DateTime>(nullable: false),
                    contract_end = table.Column<DateTime>(nullable: false),
                    is_fulfilled = table.Column<int>(nullable: false),
                    weapon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    team_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    is_start = table.Column<int>(nullable: false),
                    is_end = table.Column<int>(nullable: false),
                    latest_kill_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    is_alive = table.Column<int>(nullable: false),
                    assassin_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    code_name = table.Column<string>(nullable: true),
                    game_id = table.Column<int>(nullable: false),
                    spoon_score = table.Column<int>(nullable: false),
                    sock_score = table.Column<int>(nullable: false),
                    phone_number = table.Column<string>(nullable: true),
                    image_url = table.Column<string>(nullable: true),
                    is_admin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
