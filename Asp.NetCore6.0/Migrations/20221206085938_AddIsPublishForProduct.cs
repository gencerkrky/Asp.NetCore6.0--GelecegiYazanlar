using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetCore6._0.Migrations
{
    public partial class AddIsPublishForProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublish",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublish",
                table: "Products");
        }
    }
}
