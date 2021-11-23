using System;
using Microsoft.EntityFrameworkCore.Migrations;
using SalesApp.Infrastructure.Data.Scripts;

namespace SalesApp.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_fname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    client_lname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    seller_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    seller_boss_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    seller_fname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    seller_lname = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.seller_id);
                    table.ForeignKey(
                        name: "FK__Sellers__seller___3F466844",
                        column: x => x.seller_boss_id,
                        principalTable: "Sellers",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_parent_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    order_client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_seller_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_ammount = table.Column<double>(type: "float", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__Orders__order_cl__4222D4EF",
                        column: x => x.order_client_id,
                        principalTable: "Clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Orders__order_se__4316F928",
                        column: x => x.order_seller_id,
                        principalTable: "Sellers",
                        principalColumn: "seller_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_order_client_id",
                table: "Orders",
                column: "order_client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_order_seller_id",
                table: "Orders",
                column: "order_seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_seller_boss_id",
                table: "Sellers",
                column: "seller_boss_id");

            // Executing query to create trigger
            migrationBuilder.Sql(SqlScripts.SellersTrigger);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Executing query to drop trigger
            migrationBuilder.Sql(SqlScripts.SellersTriggerDrop);

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
