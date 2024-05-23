using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthDB.Migrations;

[DbContext(typeof(AppDbContext))]
[Migration("m20240524_164200_AlterUserTable")]
public class m20240524_164200_AlterUserTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Entities.Enums.RoleEnum>(name: "Role", table: "User");
    }
}
