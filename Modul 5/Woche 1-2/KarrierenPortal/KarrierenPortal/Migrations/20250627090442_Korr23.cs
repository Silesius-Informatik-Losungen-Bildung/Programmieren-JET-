using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarrierenPortal.Migrations
{
    /// <inheritdoc />
    public partial class Korr23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arbeitsort",
                columns: table => new
                {
                    ArbeitsortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeitsort", x => x.ArbeitsortId);
                });

            migrationBuilder.CreateTable(
                name: "Arbeitszeitmodell",
                columns: table => new
                {
                    ArbeitszeitmodellId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeitszeitmodell", x => x.ArbeitszeitmodellId);
                });

            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.BenefitId);
                });

            migrationBuilder.CreateTable(
                name: "BetriebsGroesse",
                columns: table => new
                {
                    BetriebsGroesseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetriebsGroesse", x => x.BetriebsGroesseId);
                });

            migrationBuilder.CreateTable(
                name: "BewerbungStatus",
                columns: table => new
                {
                    BewerbungStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BewerbungStatus", x => x.BewerbungStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Branche",
                columns: table => new
                {
                    BrancheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branche", x => x.BrancheId);
                });

            migrationBuilder.CreateTable(
                name: "GehaltsSpanne",
                columns: table => new
                {
                    GehaltsSpanneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GehaltsSpanne", x => x.GehaltsSpanneId);
                });

            migrationBuilder.CreateTable(
                name: "Land",
                columns: table => new
                {
                    LandCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land_1", x => x.LandCode);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Arbeitgeber",
                columns: table => new
                {
                    ArbeitgeberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BetriebsGroesseId = table.Column<int>(type: "int", nullable: false),
                    Plz = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LandCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    BrancheId = table.Column<int>(type: "int", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ansprechpartner = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Webseite = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbeitgeber", x => x.ArbeitgeberId);
                    table.ForeignKey(
                        name: "FK_Arbeitgeber_BetriebsGroesse",
                        column: x => x.BetriebsGroesseId,
                        principalTable: "BetriebsGroesse",
                        principalColumn: "BetriebsGroesseId");
                    table.ForeignKey(
                        name: "FK_Arbeitgeber_Branche",
                        column: x => x.BrancheId,
                        principalTable: "Branche",
                        principalColumn: "BrancheId");
                    table.ForeignKey(
                        name: "FK_Arbeitgeber_Land",
                        column: x => x.LandCode,
                        principalTable: "Land",
                        principalColumn: "LandCode");
                });

            migrationBuilder.CreateTable(
                name: "Bewerber",
                columns: table => new
                {
                    BewerberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Plz = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LandCode = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Geburtsdatum = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Webseite = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    ErstelltAm = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewerber", x => x.BewerberId);
                    table.ForeignKey(
                        name: "FK_Bewerber_Land",
                        column: x => x.LandCode,
                        principalTable: "Land",
                        principalColumn: "LandCode");
                });

            migrationBuilder.CreateTable(
                name: "ArbeitgeberBenefit",
                columns: table => new
                {
                    ArbeitgeberId = table.Column<int>(type: "int", nullable: false),
                    BenefitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArbeitgeberBenefit", x => new { x.ArbeitgeberId, x.BenefitId });
                    table.ForeignKey(
                        name: "FK_ArbeitgeberBenefit_Arbeitgeber",
                        column: x => x.ArbeitgeberId,
                        principalTable: "Arbeitgeber",
                        principalColumn: "ArbeitgeberId");
                    table.ForeignKey(
                        name: "FK_ArbeitgeberBenefit_Benefit",
                        column: x => x.BenefitId,
                        principalTable: "Benefit",
                        principalColumn: "BenefitId");
                });

            migrationBuilder.CreateTable(
                name: "JobAngebot",
                columns: table => new
                {
                    JobAngebotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArbeitgeberId = table.Column<int>(type: "int", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GehaltsSpanneId = table.Column<int>(type: "int", nullable: true),
                    ArbeitszeitmodellId = table.Column<int>(type: "int", nullable: true),
                    ArbeitsortId = table.Column<int>(type: "int", nullable: true),
                    Bewerbungsfrist = table.Column<DateOnly>(type: "date", nullable: true),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false),
                    ErstalltAm = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAngebot", x => x.JobAngebotId);
                    table.ForeignKey(
                        name: "FK_JobAngebot_Arbeitgeber",
                        column: x => x.ArbeitgeberId,
                        principalTable: "Arbeitgeber",
                        principalColumn: "ArbeitgeberId");
                    table.ForeignKey(
                        name: "FK_JobAngebot_Arbeitsort",
                        column: x => x.ArbeitsortId,
                        principalTable: "Arbeitsort",
                        principalColumn: "ArbeitsortId");
                    table.ForeignKey(
                        name: "FK_JobAngebot_Arbeitszeitmodell",
                        column: x => x.ArbeitszeitmodellId,
                        principalTable: "Arbeitszeitmodell",
                        principalColumn: "ArbeitszeitmodellId");
                    table.ForeignKey(
                        name: "FK_JobAngebot_GehaltsSpanne",
                        column: x => x.GehaltsSpanneId,
                        principalTable: "GehaltsSpanne",
                        principalColumn: "GehaltsSpanneId");
                });

            migrationBuilder.CreateTable(
                name: "Benachrichtigung",
                columns: table => new
                {
                    BenachrichtigungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BewerberId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benachrichtigung", x => x.BenachrichtigungId);
                    table.ForeignKey(
                        name: "FK_Benachrichtigung_Bewerber",
                        column: x => x.BewerberId,
                        principalTable: "Bewerber",
                        principalColumn: "BewerberId");
                });

            migrationBuilder.CreateTable(
                name: "BewerberSkill",
                columns: table => new
                {
                    BewerberId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => new { x.BewerberId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_BewerberSkill_Bewerber",
                        column: x => x.BewerberId,
                        principalTable: "Bewerber",
                        principalColumn: "BewerberId");
                    table.ForeignKey(
                        name: "FK_BewerberSkill_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateTable(
                name: "Lebenslauf",
                columns: table => new
                {
                    LebenslaufId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BewerberId = table.Column<int>(type: "int", nullable: false),
                    Dokument = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BewerberDokument", x => x.LebenslaufId);
                    table.ForeignKey(
                        name: "FK_Lebenslauf_Bewerber",
                        column: x => x.BewerberId,
                        principalTable: "Bewerber",
                        principalColumn: "BewerberId");
                });

            migrationBuilder.CreateTable(
                name: "Bewerbung",
                columns: table => new
                {
                    BewerbungId = table.Column<int>(type: "int", nullable: false),
                    JobAngebotId = table.Column<int>(type: "int", nullable: false),
                    BewerberId = table.Column<int>(type: "int", nullable: false),
                    Schreiben = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BewerbungStatusId = table.Column<int>(type: "int", nullable: false),
                    ErstelltAm = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bewerbung", x => x.BewerbungId);
                    table.ForeignKey(
                        name: "FK_Bewerbung_Bewerber",
                        column: x => x.BewerbungStatusId,
                        principalTable: "BewerbungStatus",
                        principalColumn: "BewerbungStatusId");
                    table.ForeignKey(
                        name: "FK_Bewerbung_Bewerber1",
                        column: x => x.BewerbungId,
                        principalTable: "Bewerber",
                        principalColumn: "BewerberId");
                    table.ForeignKey(
                        name: "FK_Bewerbung_JobAngebot",
                        column: x => x.JobAngebotId,
                        principalTable: "JobAngebot",
                        principalColumn: "JobAngebotId");
                });

            migrationBuilder.CreateTable(
                name: "JobAngebotSkill",
                columns: table => new
                {
                    JobAngebotId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1x", x => new { x.JobAngebotId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobAngebotSkill_JobAngebot",
                        column: x => x.JobAngebotId,
                        principalTable: "JobAngebot",
                        principalColumn: "JobAngebotId");
                    table.ForeignKey(
                        name: "FK_JobAngebotSkill_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitgeber_BetriebsGroesseId",
                table: "Arbeitgeber",
                column: "BetriebsGroesseId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitgeber_BrancheId",
                table: "Arbeitgeber",
                column: "BrancheId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbeitgeber_LandCode",
                table: "Arbeitgeber",
                column: "LandCode");

            migrationBuilder.CreateIndex(
                name: "IX_ArbeitgeberBenefit_BenefitId",
                table: "ArbeitgeberBenefit",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_Benachrichtigung_BewerberId",
                table: "Benachrichtigung",
                column: "BewerberId");

            migrationBuilder.CreateIndex(
                name: "IX_Bewerber_LandCode",
                table: "Bewerber",
                column: "LandCode");

            migrationBuilder.CreateIndex(
                name: "IX_BewerberSkill_SkillId",
                table: "BewerberSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Bewerbung_BewerbungStatusId",
                table: "Bewerbung",
                column: "BewerbungStatusId");

            migrationBuilder.CreateIndex(
                name: "UC_JobAngebot_Bewerbung",
                table: "Bewerbung",
                columns: new[] { "JobAngebotId", "BewerbungId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAngebot_ArbeitgeberId",
                table: "JobAngebot",
                column: "ArbeitgeberId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAngebot_ArbeitsortId",
                table: "JobAngebot",
                column: "ArbeitsortId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAngebot_ArbeitszeitmodellId",
                table: "JobAngebot",
                column: "ArbeitszeitmodellId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAngebot_GehaltsSpanneId",
                table: "JobAngebot",
                column: "GehaltsSpanneId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAngebotSkill_SkillId",
                table: "JobAngebotSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Lebenslauf",
                table: "Lebenslauf",
                column: "BewerberId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArbeitgeberBenefit");

            migrationBuilder.DropTable(
                name: "Benachrichtigung");

            migrationBuilder.DropTable(
                name: "BewerberSkill");

            migrationBuilder.DropTable(
                name: "Bewerbung");

            migrationBuilder.DropTable(
                name: "JobAngebotSkill");

            migrationBuilder.DropTable(
                name: "Lebenslauf");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "BewerbungStatus");

            migrationBuilder.DropTable(
                name: "JobAngebot");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Bewerber");

            migrationBuilder.DropTable(
                name: "Arbeitgeber");

            migrationBuilder.DropTable(
                name: "Arbeitsort");

            migrationBuilder.DropTable(
                name: "Arbeitszeitmodell");

            migrationBuilder.DropTable(
                name: "GehaltsSpanne");

            migrationBuilder.DropTable(
                name: "BetriebsGroesse");

            migrationBuilder.DropTable(
                name: "Branche");

            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
