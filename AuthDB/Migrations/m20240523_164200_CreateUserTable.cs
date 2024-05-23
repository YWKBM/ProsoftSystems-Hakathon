using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthDB.Entities.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("m20240523_164200_CreateUserTable")]
public class m20240523_164200_CreateUserTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "User",
            columns: t => new
            {
                Id = t.Column<int>(type: "serial"),
                Login = t.Column<string>(),
                Password = t.Column<decimal>(),
            }
        ).PrimaryKey("PK-User", c => c.Id);
    }
}