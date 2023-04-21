using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csi.asp.net.core.data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaboratorRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyHead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyOriginRef",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyOriginRef", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CollaboratorRoleId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: true),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partner_CollaboratorRole_CollaboratorRoleId",
                        column: x => x.CollaboratorRoleId,
                        principalTable: "CollaboratorRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partner_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partner_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Household",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", nullable: false),
                    OtherFamilyOriginRef = table.Column<string>(type: "varchar(20)", nullable: true),
                    NeighborhoodName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Block = table.Column<string>(type: "varchar(5)", nullable: false),
                    FamilyPhoneNumber = table.Column<string>(type: "varchar(9)", nullable: false),
                    ClosePlaceToHome = table.Column<string>(type: "varchar(20)", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    FamilyHeadId = table.Column<int>(type: "int", nullable: false),
                    FamilyOriginRefId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Household", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Household_FamilyHead_FamilyHeadId",
                        column: x => x.FamilyHeadId,
                        principalTable: "FamilyHead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Household_FamilyOriginRef_FamilyOriginRefId",
                        column: x => x.FamilyOriginRefId,
                        principalTable: "FamilyOriginRef",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Household_Partner_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Household_FamilyHeadId",
                table: "Household",
                column: "FamilyHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Household_FamilyOriginRefId",
                table: "Household",
                column: "FamilyOriginRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Household_PartnerId",
                table: "Household",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_CollaboratorRoleId",
                table: "Partner",
                column: "CollaboratorRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_PartnerId",
                table: "Partner",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_SiteId",
                table: "Partner",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Household");

            migrationBuilder.DropTable(
                name: "FamilyHead");

            migrationBuilder.DropTable(
                name: "FamilyOriginRef");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "CollaboratorRole");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
