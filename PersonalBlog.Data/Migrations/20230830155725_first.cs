using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalBlog.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MyJob = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MyJobFA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyCvPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SQAnswer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CategoryFA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortAdress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    School = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Duraiton = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avarage = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WorkPlace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePageSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageSliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interesteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesteds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LogoText = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LogoFA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteIdentity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PercentageValue = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountFA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccountUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "BirthDate", "CreatedByName", "CreatedTime", "FirstName", "ImagePath", "IsActive", "IsDelete", "LastName", "ModifiedByName", "ModifiedTime", "MyCvPath", "MyJob", "MyJobFA" },
                values: new object[] { 1, new DateTime(2003, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 673, DateTimeKind.Local).AddTicks(5980), "Muhammet Evren", "", true, false, "Uludağ", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 673, DateTimeKind.Local).AddTicks(5988), "", "Software Developer", "<i class=\"fas fa - laptop - code\"></i>" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "EMail", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "Password", "SQAnswer", "SecurityQuestion" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 674, DateTimeKind.Local).AddTicks(5381), "Evrenuludag563@gmail.com", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 674, DateTimeKind.Local).AddTicks(5384), "80822c9ccfe0fb5bda1d9d9695071f0f", "95292c82c277311cae9da7a64ac216f3", "Anne kızlık soyadı (Küçük Harflerle)?" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryFA", "CreatedByName", "CreatedTime", "Description", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "Name" },
                values: new object[] { 1, "<i class=\"fas fa - code\"></i>", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 682, DateTimeKind.Local).AddTicks(834), "Yazılım ile ilgili güncel bilgiler içerir.", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 682, DateTimeKind.Local).AddTicks(838), "Yazılım" });

            migrationBuilder.InsertData(
                table: "ContactInfo",
                columns: new[] { "Id", "Adress", "CreatedByName", "CreatedTime", "EMail", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "PhoneNumber", "ShortAdress" },
                values: new object[] { 1, "Yeni Batı Mah. Mülk Cad. Göldelüx Konutları 1. Etap", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 680, DateTimeKind.Local).AddTicks(2437), "Evrenuludag563@gmail.com", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 680, DateTimeKind.Local).AddTicks(2442), "+905059031910", "BatıKent/Ankara" });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Avarage", "CreatedByName", "CreatedTime", "Description", "Duraiton", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "School", "Title" },
                values: new object[,]
                {
                    { 1, "...", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 675, DateTimeKind.Local).AddTicks(6125), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Exercitationem recusandae quibusdam expedita, vitae veniam aut", "Eylül 2023--Yeni Başladı", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 675, DateTimeKind.Local).AddTicks(6129), "Anadolu Üniversitesi Web Tasarımı Ve Kodlama Bölümü", "Lisans Derecesi" },
                    { 2, "81.63 ORT", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 675, DateTimeKind.Local).AddTicks(6135), "Lorem ipsum dolor sit amet consectetur adipisicing elit. Exercitationem recusandae quibusdam expedita, vitae veniam aut", "Eylül 2012--Temmuz 2016", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 675, DateTimeKind.Local).AddTicks(6135), "Türkan Halit Aykılıç Fen Lisesi-Fen Bilimleri", "Lise Mezun" }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "Description", "Duration", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "Title", "WorkPlace" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 660, DateTimeKind.Local).AddTicks(6104), "Temmuz 2023'den beridir, arkadaşlar ve çevrem için web sitesi yapıyorum. Birkaç tanesini yayına aldım.", "Haziran 2020--Devam Ediyor", true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 660, DateTimeKind.Local).AddTicks(6108), "Freelance Software Developer", "Freelance" });

            migrationBuilder.InsertData(
                table: "HomePageSliders",
                columns: new[] { "Id", "Content", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "ShortContent", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur. Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 658, DateTimeKind.Local).AddTicks(7790), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 658, DateTimeKind.Local).AddTicks(7795), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", ".NET DEVELOPER" },
                    { 2, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur. Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 658, DateTimeKind.Local).AddTicks(7803), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 658, DateTimeKind.Local).AddTicks(7804), "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır.", "WEB DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "Interesteds",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "Text" },
                values: new object[,]
                {
                    { 2, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8388), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8388), "Vizyon Filmlerini takip etmek ve izlemek, Film incelemelerini okumak, Parodileri izlemek" },
                    { 3, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8391), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8391), "Animeler ve Mangalar" },
                    { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8378), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 656, DateTimeKind.Local).AddTicks(8382), "Bilgisayar Donanımları, Bileşenleri ve Yazılımları" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "EMail", "FirstName", "IsActive", "IsDelete", "LastName", "ModifiedByName", "ModifiedTime", "Subject", "Text" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 662, DateTimeKind.Local).AddTicks(5820), "deneme@mail.com", "Mehmet", true, false, "Şevket", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 662, DateTimeKind.Local).AddTicks(5824), "deneme", "Bu bir deneme mesajıdır. Dikkate almayınız!" });

            migrationBuilder.InsertData(
                table: "SiteIdentity",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "Description", "IsActive", "IsDelete", "Keywords", "LogoFA", "LogoText", "ModifiedByName", "ModifiedTime", "Title" },
                values: new object[] { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 661, DateTimeKind.Local).AddTicks(5618), "Ben Hasan Erdal. Yazılım geliştiricisiyim. C# ve web bilgim var.", true, false, "Muhammet Evren Uludağ, Muhammet, Evren, Uludağ, Software, Developer, Engineer", "<i class=\"fab fa - hire - a - helper\"></i>", "EVREN ULUDAG", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 661, DateTimeKind.Local).AddTicks(5623), "Muhammet Evren Uludağ" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "PercentageValue", "Title" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6811), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6815), 70, "C#" },
                    { 2, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6821), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6822), 60, "ASP.NET MVC" },
                    { 3, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6824), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6824), 60, "ENTITY FRAMEWORK & LINQ" },
                    { 4, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6826), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6827), 65, "HTML & CSS" },
                    { 5, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6829), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 659, DateTimeKind.Local).AddTicks(6829), 50, "DEVEXPRESS FRAMEWORK" }
                });

            migrationBuilder.InsertData(
                table: "SocialMediaAccounts",
                columns: new[] { "Id", "Account", "AccountFA", "AccountUrl", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime" },
                values: new object[,]
                {
                    { 4, "4", "<i class=\"fab fa - github - square\"></i>", "https://github.com/EvrenUludag06", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8426), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8426) },
                    { 1, "1", "<i class=\"fab fa - Instagram - square\"></i>", "https://www.instagram.com/evrenuludag_/", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8409), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8414) },
                    { 2, "2", "<i class=\"fab fa - twitter - square\"></i>", "https://twitter.com/evrenuludag_", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8420), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8421) },
                    { 3, "3", "<i class=\"fab fa - linkedin\"></i>", "https://www.linkedin.com/in/muhammet-evren-uluda%C4%9F-263537283/", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8423), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 657, DateTimeKind.Local).AddTicks(8424) }
                });

            migrationBuilder.InsertData(
                table: "Summary",
                columns: new[] { "Id", "Content", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime" },
                values: new object[] { 1, "Merhaba siteme hoşgeldiniz. Ben Anadolu Üniversitesi'nin Web Tasarımı Ve Kodlama bölümünde okuyan aynı zamanda yazılıma gönül vermiş birisiyim. C# ve .Net alanında yoğun bir şekilde kendimi geliştiriyorum. Gelişime açık ve hızlı öğrenen birisi olduğumu düşünüyorum. Geleceğimi yazılım üzerine şekillendireceğime eminim. Bu yolda elimden geleni değil, herşeyi yapacağım. Yazılım üzerine birçok hayalim. uzun ve kısa vadeli planlarım var. Açıkcası yazılımın hayatımın her alanına yeterli ölçüde etki etmesini istiyorum. Bilgisayar, eskiden beri tutkum olan bir alan. Bilgisayardan birşeyler yazarak, bunun somut sonuçlarını görmek beni açıkcası mutlu ediyor...", "IntialCreated", new DateTime(2023, 8, 30, 18, 57, 24, 655, DateTimeKind.Local).AddTicks(3391), false, false, "IntialCreated", new DateTime(2023, 8, 30, 18, 57, 24, 655, DateTimeKind.Local).AddTicks(3534) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedByName", "CreatedTime", "IsActive", "IsDelete", "ModifiedByName", "ModifiedTime", "SeoDescription", "SeoTags", "ShortContent", "Thumbnail", "Title", "ViewsCount" },
                values: new object[] { 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 679, DateTimeKind.Local).AddTicks(3410), true, false, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 679, DateTimeKind.Local).AddTicks(3414), "C# 9.0 ve .Net 5.0 Yenilikleri", "C#, C#9, .NET5", "", "", "C# 9.0 ve .Net 5.0 Yenilikleri", 0 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CreatedByName", "CreatedTime", "FirstName", "IsActive", "IsDelete", "LastName", "ModifiedByName", "ModifiedTime", "Text" },
                values: new object[] { 1, 1, "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 681, DateTimeKind.Local).AddTicks(3012), "Muhammet Evren", true, false, "Uludağ", "InitialCreate", new DateTime(2023, 8, 30, 18, 57, 24, 681, DateTimeKind.Local).AddTicks(3016), "Bu bir deneme yorumudur. Lütfen dikkate almayınız!" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutMe");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "HomePageSliders");

            migrationBuilder.DropTable(
                name: "Interesteds");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "SiteIdentity");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMediaAccounts");

            migrationBuilder.DropTable(
                name: "Summary");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
