using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("0f77b12f-f92a-4952-9f69-8d080d6dc8eb"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("331e5dc4-36e9-4a83-bec9-bff6629d5645"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { new Guid("91103959-751c-4c50-8bf4-d12f0f2a4734"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("883695e5-82c5-4c70-ad7c-1ae5ea0a753c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("1760af5f-89d9-4fcd-8314-71862dc74579"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("d18cafff-321f-4845-9c20-49a122146dc2"), new Guid("0f77b12f-f92a-4952-9f69-8d080d6dc8eb"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("c341073e-6caa-4bef-a46b-a2249f347d2f"), new Guid("331e5dc4-36e9-4a83-bec9-bff6629d5645"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("6eda6309-67b0-49c1-a56d-830dabd4d5ce"), new Guid("91103959-751c-4c50-8bf4-d12f0f2a4734"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("79d9f693-0fb4-4452-90a3-bfe603371357"), new Guid("883695e5-82c5-4c70-ad7c-1ae5ea0a753c"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("9c6957a4-953c-49d7-9496-49ea153be6e6"), new Guid("1760af5f-89d9-4fcd-8314-71862dc74579"), "One of the best heavy metal albums ever", "Master Of Puppets" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
