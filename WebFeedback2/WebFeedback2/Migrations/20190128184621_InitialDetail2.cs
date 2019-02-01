using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFeedback2.Migrations
{
    public partial class InitialDetail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageDetail",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextMessage = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageDetail", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "ThemeDetail",
                columns: table => new
                {
                    ThemeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TextTheme = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeDetail", x => x.ThemeID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    UserEmail = table.Column<string>(type: "varchar(254)", nullable: false),
                    UserNumPhone = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDMessage = table.Column<int>(type: "int", nullable: false),
                    IDTheme = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageDetail");

            migrationBuilder.DropTable(
                name: "ThemeDetail");

            migrationBuilder.DropTable(
                name: "UserDetail");
        }
    }
}
