using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentPerformance.Api.Migrations
{
    public partial class AddErrorLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TABLE [dbo].[ErrorLog] (
                   [ID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
                   [MachineName] [nvarchar](200) NULL,
                   [Logged] [datetime] NOT NULL,
                   [Level] [varchar](10) NOT NULL,
                   [Message] [nvarchar](max) NOT NULL,
                   [Logger] [nvarchar](300) NULL,
                   [Callsite] [nvarchar](300) NULL
                );
 
                GO
 
                CREATE PROCEDURE [dbo].[ErrorLog_AddEntry] (
                  @machineName nvarchar(200),
                  @logged datetime,
                  @level varchar(10),
                  @message nvarchar(max),
                  @logger nvarchar(300),
                  @callsite nvarchar(300)
                ) AS
                BEGIN
                  INSERT INTO [dbo].[ErrorLog] (
                    [MachineName],
                    [Logged],
                    [Level],
                    [Message],
                    [Logger],
                    [Callsite]
                  ) VALUES (
                    @machineName,
                    @logged,
                    @level,
                    @message,
                    @logger,
                    @callsite
                  );
                END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            DROP TABLE [dbo].[ErrorLog];
            
            GO

            DROP PROC [dbo].[ErrorLog_AddEntry];
            ");
        }
    }
}
