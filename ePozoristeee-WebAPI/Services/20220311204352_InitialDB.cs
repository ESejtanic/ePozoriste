using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePozoriste.WebAPI.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dokument",
                columns: table => new
                {
                    DokumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivDokumenta = table.Column<string>(maxLength: 40, nullable: false),
                    Sadrzaj = table.Column<byte[]>(type: "image", nullable: true),
                    FileName = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokument", x => x.DokumentID);
                });

            migrationBuilder.CreateTable(
                name: "Glumac",
                columns: table => new
                {
                    GlumacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 15, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime", nullable: false),
                    BrojUgovora = table.Column<long>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Slika = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumac", x => x.GlumacID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Telefon = table.Column<string>(maxLength: 30, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 30, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 30, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(maxLength: 20, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 30, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 30, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 30, nullable: false),
                    BrojTelefona = table.Column<string>(maxLength: 20, nullable: true),
                    BrojTokena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 15, nullable: true),
                    Kapacitet = table.Column<int>(nullable: false),
                    Klimatizacija = table.Column<bool>(nullable: false),
                    Lat = table.Column<string>(nullable: true),
                    Lng = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Sponzor",
                columns: table => new
                {
                    SponzorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    BrojTelefona = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponzor", x => x.SponzorID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "NagradnaIgra",
                columns: table => new
                {
                    NagradnaIgraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime", nullable: false),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NagradnaIgra", x => x.NagradnaIgraID);
                    table.ForeignKey(
                        name: "FK__NagradnaI__Koris__6FE99F9F",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    NovostiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Tekst = table.Column<string>(nullable: false),
                    DatumVrijemeObjave = table.Column<DateTime>(type: "datetime", nullable: false),
                    Slika = table.Column<byte[]>(type: "image", nullable: true),
                    KorisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.NovostiID);
                    table.ForeignKey(
                        name: "FK__Novosti__Korisni__7F2BE32F",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    SjedisteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Red = table.Column<int>(nullable: false),
                    Kolona = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.SjedisteID);
                    table.ForeignKey(
                        name: "FK__Sjediste__SalaID__3B75D760",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    UplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 50, nullable: false),
                    Svrha = table.Column<string>(maxLength: 200, nullable: true),
                    Iznos = table.Column<double>(nullable: false),
                    DatumUplate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SponzorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.UplataID);
                    table.ForeignKey(
                        name: "FK__Uplata__SponzorI__5441852A",
                        column: x => x.SponzorID,
                        principalTable: "Sponzor",
                        principalColumn: "SponzorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUloga",
                columns: table => new
                {
                    KorisnikUlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    UlogaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUloga", x => x.KorisnikUlogaID);
                    table.ForeignKey(
                        name: "FK__KorisnikU__Koris__656C112C",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KorisnikU__Uloga__66603565",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 40, nullable: false),
                    Opis = table.Column<string>(maxLength: 200, nullable: true),
                    Reziser = table.Column<string>(maxLength: 40, nullable: false),
                    Trajanje = table.Column<int>(nullable: false),
                    ZanrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                    table.ForeignKey(
                        name: "FK__Predstava__ZanrI__403A8C7D",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KupacNagradnaIgra",
                columns: table => new
                {
                    KupacNagradnaIgraID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NagradnaIgraID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KupacNagradnaIgra", x => x.KupacNagradnaIgraID);
                    table.ForeignKey(
                        name: "FK__KupacNagr__Kupac__73BA3083",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__KupacNagr__Nagra__72C60C4A",
                        column: x => x.NagradnaIgraID,
                        principalTable: "NagradnaIgra",
                        principalColumn: "NagradnaIgraID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifikacija",
                columns: table => new
                {
                    NotifikacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NovostiID = table.Column<int>(nullable: false),
                    DatumSlanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsProcitano = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifikacija", x => x.NotifikacijaID);
                    table.ForeignKey(
                        name: "FK__Notifikac__Novos__02084FDA",
                        column: x => x.NovostiID,
                        principalTable: "Novosti",
                        principalColumn: "NovostiID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlumacPredstava",
                columns: table => new
                {
                    GlumacPredstavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PredstavaID = table.Column<int>(nullable: false),
                    GlumacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlumacPredstava", x => x.GlumacPredstavaID);
                    table.ForeignKey(
                        name: "FK__GlumacPre__Gluma__49C3F6B7",
                        column: x => x.GlumacID,
                        principalTable: "Glumac",
                        principalColumn: "GlumacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__GlumacPre__Preds__48CFD27E",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sadrzaj = table.Column<string>(maxLength: 50, nullable: false),
                    VrijemeKreiranja = table.Column<DateTime>(type: "datetime", nullable: false),
                    Odobrena = table.Column<bool>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK__Komentar__KupacI__693CA210",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Komentar__Predst__6A30C649",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PredstavaKupac",
                columns: table => new
                {
                    PredstavaKupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ocjena = table.Column<double>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstavaKupac", x => x.PredstavaKupacID);
                    table.ForeignKey(
                        name: "FK__Predstava__Kupac__5BE2A6F2",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Predstava__Preds__5AEE82B9",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PredstavaUplata",
                columns: table => new
                {
                    PredstavaUplataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumUplate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    UplataID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstavaUplata", x => x.PredstavaUplataID);
                    table.ForeignKey(
                        name: "FK__Predstava__Preds__571DF1D5",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Predstava__Uplat__5812160E",
                        column: x => x.UplataID,
                        principalTable: "Uplata",
                        principalColumn: "UplataID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prikazivanje",
                columns: table => new
                {
                    PrikazivanjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPrikazivanja = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalaID = table.Column<int>(nullable: false),
                    PredstavaID = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prikazivanje", x => x.PrikazivanjeID);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime", nullable: false),
                    Odobrena = table.Column<bool>(nullable: false),
                    BrojRezervacije = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    PrikazivanjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Kupac__4E88ABD4",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Rezervaci__Prika__4F7CD00D",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ulaznica",
                columns: table => new
                {
                    UlaznicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PrikazivanjeID = table.Column<int>(nullable: false),
                    SjedisteID = table.Column<int>(nullable: false),
                    KupacID = table.Column<int>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: true),
                    QRKod = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaznica", x => x.UlaznicaID);
                    table.ForeignKey(
                        name: "FK__Ulaznica__KupacI__787EE5A0",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ulaznica__Prikaz__76969D2E",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ulaznica__Rezerv__797309D9",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacije",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ulaznica__Sjedis__778AC167",
                        column: x => x.SjedisteID,
                        principalTable: "Sjediste",
                        principalColumn: "SjedisteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_GlumacID",
                table: "GlumacPredstava",
                column: "GlumacID");

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_PredstavaID",
                table: "GlumacPredstava",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacID",
                table: "Komentar",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_PredstavaID",
                table: "Komentar",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_KorisnikID",
                table: "KorisnikUloga",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUloga_UlogaID",
                table: "KorisnikUloga",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_KupacID",
                table: "KupacNagradnaIgra",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_KupacNagradnaIgra_NagradnaIgraID",
                table: "KupacNagradnaIgra",
                column: "NagradnaIgraID");

            migrationBuilder.CreateIndex(
                name: "IX_NagradnaIgra_KorisnikID",
                table: "NagradnaIgra",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifikacija_NovostiID",
                table: "Notifikacija",
                column: "NovostiID");

            migrationBuilder.CreateIndex(
                name: "IX_Novosti_KorisnikID",
                table: "Novosti",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_ZanrID",
                table: "Predstava",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_KupacID",
                table: "PredstavaKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_PredstavaID",
                table: "PredstavaKupac",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaUplata_PredstavaID",
                table: "PredstavaUplata",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaUplata_UplataID",
                table: "PredstavaUplata",
                column: "UplataID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_PredstavaID",
                table: "Prikazivanje",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_SalaID",
                table: "Prikazivanje",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KupacID",
                table: "Rezervacije",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_PrikazivanjeID",
                table: "Rezervacije",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_SalaID",
                table: "Sjediste",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_KupacID",
                table: "Ulaznica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_PrikazivanjeID",
                table: "Ulaznica",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_RezervacijaID",
                table: "Ulaznica",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_SjedisteID",
                table: "Ulaznica",
                column: "SjedisteID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_SponzorID",
                table: "Uplata",
                column: "SponzorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dokument");

            migrationBuilder.DropTable(
                name: "GlumacPredstava");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "KorisnikUloga");

            migrationBuilder.DropTable(
                name: "KupacNagradnaIgra");

            migrationBuilder.DropTable(
                name: "Notifikacija");

            migrationBuilder.DropTable(
                name: "PredstavaKupac");

            migrationBuilder.DropTable(
                name: "PredstavaUplata");

            migrationBuilder.DropTable(
                name: "Ulaznica");

            migrationBuilder.DropTable(
                name: "Glumac");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "NagradnaIgra");

            migrationBuilder.DropTable(
                name: "Novosti");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Sponzor");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Prikazivanje");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Zanr");
        }
    }
}
