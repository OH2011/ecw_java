using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace ECWINDOW.Migrations
{
    public partial class InsertTableRows : Migration
    {
        // 文字列の前に@を付けることで\をエスケープ（\\）して書かなくてよくなる
        private const string MIGRATION_SQL_SCRIPT_FILE_NAME = @"ECWINDOW\Migrations\Scripts\InsertTableRows.sql";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, MIGRATION_SQL_SCRIPT_FILE_NAME);
            migrationBuilder.Sql(File.ReadAllText(sql));
        }
    }
}
