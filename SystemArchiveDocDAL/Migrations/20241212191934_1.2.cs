using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemArchiveDocDAL.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatusEnumerable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatusEnumerable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTaskTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTaskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentEvents_DocumentOperations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "DocumentOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: true),
                    Result = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CountryIsoCode = table.Column<string>(type: "text", nullable: true),
                    FederalDistrict = table.Column<string>(type: "text", nullable: true),
                    RegionFiasId = table.Column<string>(type: "text", nullable: true),
                    RegionKadrId = table.Column<string>(type: "text", nullable: true),
                    RegionIsoCode = table.Column<string>(type: "text", nullable: true),
                    RegionWitType = table.Column<string>(type: "text", nullable: true),
                    RegionType = table.Column<string>(type: "text", nullable: true),
                    RegionTypeFull = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    AreaFiasId = table.Column<string>(type: "text", nullable: true),
                    AreaKladrId = table.Column<string>(type: "text", nullable: true),
                    AreaWithType = table.Column<string>(type: "text", nullable: true),
                    AreaType = table.Column<string>(type: "text", nullable: true),
                    AreaTypeFull = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    SubAreaFiasId = table.Column<string>(type: "text", nullable: true),
                    SubAreaKladrId = table.Column<string>(type: "text", nullable: true),
                    SubAreaWithType = table.Column<string>(type: "text", nullable: true),
                    SubAreaType = table.Column<string>(type: "text", nullable: true),
                    SubAreaTypeFull = table.Column<string>(type: "text", nullable: true),
                    SubArea = table.Column<string>(type: "text", nullable: true),
                    CityFiasId = table.Column<string>(type: "text", nullable: true),
                    CityKladrId = table.Column<string>(type: "text", nullable: true),
                    CityWithType = table.Column<string>(type: "text", nullable: true),
                    CitygType = table.Column<string>(type: "text", nullable: true),
                    CityTypeFull = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CityArea = table.Column<string>(type: "text", nullable: true),
                    CityDistrictFiasId = table.Column<string>(type: "text", nullable: true),
                    CityDistrictKladrId = table.Column<string>(type: "text", nullable: true),
                    CityDistrictWithType = table.Column<string>(type: "text", nullable: true),
                    CityDistrictType = table.Column<string>(type: "text", nullable: true),
                    CityDistrictTypeFull = table.Column<string>(type: "text", nullable: true),
                    CityDistrict = table.Column<string>(type: "text", nullable: true),
                    SettlementFiasId = table.Column<string>(type: "text", nullable: true),
                    SettlementKladrId = table.Column<string>(type: "text", nullable: true),
                    settlementWithType = table.Column<string>(type: "text", nullable: true),
                    SettlementType = table.Column<string>(type: "text", nullable: true),
                    SettlementTypeFull = table.Column<string>(type: "text", nullable: true),
                    Settlement = table.Column<string>(type: "text", nullable: true),
                    StreetFiasId = table.Column<string>(type: "text", nullable: true),
                    StreetKladrId = table.Column<string>(type: "text", nullable: true),
                    StreetWithType = table.Column<string>(type: "text", nullable: true),
                    StreetType = table.Column<string>(type: "text", nullable: true),
                    StreetTypeFull = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    HouseFiasId = table.Column<string>(type: "text", nullable: true),
                    HouseKladrId = table.Column<string>(type: "text", nullable: true),
                    HouseCadnum = table.Column<string>(type: "text", nullable: true),
                    HouseWithType = table.Column<string>(type: "text", nullable: true),
                    HouseType = table.Column<string>(type: "text", nullable: true),
                    HouseTypeFull = table.Column<string>(type: "text", nullable: true),
                    House = table.Column<string>(type: "text", nullable: true),
                    BlockType = table.Column<string>(type: "text", nullable: true),
                    BlockTypeFull = table.Column<string>(type: "text", nullable: true),
                    Block = table.Column<string>(type: "text", nullable: true),
                    Entrance = table.Column<string>(type: "text", nullable: true),
                    Floor = table.Column<string>(type: "text", nullable: true),
                    FlatFiasId = table.Column<string>(type: "text", nullable: true),
                    FlatCadnum = table.Column<string>(type: "text", nullable: true),
                    FlatType = table.Column<string>(type: "text", nullable: true),
                    FlatTypeFull = table.Column<string>(type: "text", nullable: true),
                    Flat = table.Column<string>(type: "text", nullable: true),
                    SteadFiasId = table.Column<string>(type: "text", nullable: true),
                    SteadKladrId = table.Column<string>(type: "text", nullable: true),
                    SteadType = table.Column<string>(type: "text", nullable: true),
                    SteadTypeFull = table.Column<string>(type: "text", nullable: true),
                    Stead = table.Column<string>(type: "text", nullable: true),
                    FlatArea = table.Column<string>(type: "text", nullable: true),
                    SquareMeterPrice = table.Column<string>(type: "text", nullable: true),
                    FlatPrice = table.Column<string>(type: "text", nullable: true),
                    PostalBox = table.Column<string>(type: "text", nullable: true),
                    FiasId = table.Column<string>(type: "text", nullable: true),
                    FiasCode = table.Column<string>(type: "text", nullable: true),
                    FiasLevel = table.Column<string>(type: "text", nullable: true),
                    FiasActuality_state = table.Column<string>(type: "text", nullable: true),
                    KladrId = table.Column<string>(type: "text", nullable: true),
                    GeonameId = table.Column<string>(type: "text", nullable: true),
                    CapitalMarker = table.Column<string>(type: "text", nullable: true),
                    Okato = table.Column<string>(type: "text", nullable: true),
                    Oktmo = table.Column<string>(type: "text", nullable: true),
                    TaxOffice = table.Column<string>(type: "text", nullable: true),
                    TaxOfficeLegal = table.Column<string>(type: "text", nullable: true),
                    Timezone = table.Column<string>(type: "text", nullable: true),
                    GeoLat = table.Column<string>(type: "text", nullable: true),
                    GeoLon = table.Column<string>(type: "text", nullable: true),
                    BeltwayHit = table.Column<string>(type: "text", nullable: true),
                    BeltwayDistance = table.Column<string>(type: "text", nullable: true),
                    Gc_geo = table.Column<string>(type: "text", nullable: true),
                    GcComplete = table.Column<string>(type: "text", nullable: true),
                    GcHouse = table.Column<string>(type: "text", nullable: true),
                    Gc = table.Column<string>(type: "text", nullable: true),
                    UnparsedParts = table.Column<string>(type: "text", nullable: true),
                    HistoryValues = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_DocumentStatusEnumerable_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DocumentStatusEnumerable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemArchiveObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemArchiveObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemArchiveObject_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemArchiveObject_DocumentStatusEnumerable_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DocumentStatusEnumerable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SystemArchiveObject_ObjectTypes_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalTable: "ObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Extention = table.Column<int>(type: "integer", nullable: false),
                    TaskTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveObjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentStatusEnumerable_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DocumentStatusEnumerable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "DocumentTaskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_SystemArchiveObject_ArchiveObjectId",
                        column: x => x.ArchiveObjectId,
                        principalTable: "SystemArchiveObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StatusId",
                table: "Addresses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentEvents_OperationId",
                table: "DocumentEvents",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ArchiveObjectId",
                table: "Documents",
                column: "ArchiveObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_StatusId",
                table: "Documents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TaskTypeId",
                table: "Documents",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemArchiveObject_AddressId",
                table: "SystemArchiveObject",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemArchiveObject_ObjectTypeId",
                table: "SystemArchiveObject",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemArchiveObject_StatusId",
                table: "SystemArchiveObject",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentEvents");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentOperations");

            migrationBuilder.DropTable(
                name: "DocumentTaskTypes");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "SystemArchiveObject");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ObjectTypes");

            migrationBuilder.DropTable(
                name: "DocumentStatusEnumerable");
        }
    }
}
