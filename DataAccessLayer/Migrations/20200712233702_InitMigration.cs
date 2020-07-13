using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.UniqueConstraint("AK_Countries_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyManagers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyManagers_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("678133d9-8142-491b-aa8a-ddc91ff92719"), "AF", "Afghanistan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b0c85981-a94f-4ef8-84b1-65383671d2c7"), "NZ", "New Zealand" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c9a70845-993a-4997-abfd-340b58a2fe95"), "NI", "Nicaragua" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f7fb31ed-1ad8-461c-bf8a-5fb09adcd43a"), "NE", "Niger (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("46acfcbb-b11f-4ddc-80aa-d4fe105e2fc0"), "NG", "Nigeria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d807e75a-7386-4b1b-8571-80c16bf73481"), "NU", "Niue" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("125931a7-22a2-4784-9952-18f49a2c0381"), "NF", "Norfolk Island" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("152f25f1-fa60-4ba9-ac9c-64414df3cd05"), "MP", "Northern Mariana Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a200177c-8a8d-44ef-8451-800582688f62"), "NO", "Norway" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("98ef35da-2255-491b-818d-d16cd121f892"), "OM", "Oman" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4a92ebcd-481e-4478-82f6-3346f11c61e6"), "PK", "Pakistan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9fd97836-0ddd-432a-ba60-fb698e4e56c0"), "PW", "Palau" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("794741c3-ec65-4d5c-be88-713b7f9c02a8"), "PS", "Palestine, State of" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a582c2c-ba4b-44ea-8141-e4a2438ad303"), "PA", "Panama" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f79df065-936c-4aee-976d-0c93d8e76b56"), "PG", "Papua New Guinea" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bc15fd05-e52b-4472-a787-dfc5b72ca65e"), "PY", "Paraguay" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8e883530-3aa6-4ddd-b0e3-af7bf9db1cae"), "PE", "Peru" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("64453e43-8883-4880-9bcb-2a3c8677593b"), "PH", "Philippines (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("96b17ce7-ef95-47a5-83db-9fa658bd69b7"), "PN", "Pitcairn" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a3edc4d-c4ce-4c9c-aeac-717d19db1fe4"), "PL", "Poland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f9994e27-a8b5-4832-8007-eaad68f697ee"), "PT", "Portugal" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("38e4bf0a-3bd4-4d87-8a6d-7c7fc526303f"), "PR", "Puerto Rico" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("552e3aef-c8e9-4e71-a379-15cb25fad7c0"), "QA", "Qatar" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ab2ba8d6-62b3-4bc9-9575-85fb0a86e706"), "MK", "Republic of North Macedonia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("531d3094-261c-41c6-a013-b4ca0a443959"), "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("db8e77cf-a4f8-4c0c-befb-17eeded8a8c9"), "RU", "Russian Federation (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f7d9b0e8-ab47-43fe-b532-2eabbfdb7096"), "RW", "Rwanda" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fa5924f3-fd2d-478f-8f22-d087dc123f1d"), "RE", "Réunion" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("57c25c11-9371-4d80-b5a3-e6287b568b48"), "NC", "New Caledonia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7c51dbb8-1c35-4f0a-99aa-3ba198026a72"), "BL", "Saint Barthélemy" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a118fc7e-b2bc-45bc-b074-5d7441cfbae1"), "NL", "Netherlands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6ebb92a5-582c-4354-97e4-3884e15699cc"), "NR", "Nauru" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("da1a181f-e3b6-4cb5-8952-e6d1069d418d"), "LY", "Libya" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("af9e7fa5-cddc-472b-85c1-0dea267ed03c"), "LI", "Liechtenstein" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6c8d8b6b-495a-4e5b-8b80-3d618d717a4c"), "LT", "Lithuania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e26c6fcb-1044-4c09-af67-21d985311315"), "LU", "Luxembourg" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("21949767-63e5-47af-b353-97d96fdb401f"), "MO", "Macao" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fcaab421-1b7c-434f-8cd5-cf2ef4b8587d"), "MG", "Madagascar" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ed5c4e17-cbd5-4e2a-9443-3aaf1147c8f6"), "MW", "Malawi" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9123d4ba-5d9d-4c1a-b1e4-a7d67d0d20ac"), "MY", "Malaysia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bb3b0c3d-d07c-4072-a4a6-4a2e8ae96607"), "MV", "Maldives" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("bef9af8a-3640-4965-99da-621250f19215"), "ML", "Mali" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c6493c2-1750-4b81-81a5-18619555114b"), "MT", "Malta" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8a87270b-1877-4125-a909-820ecbf488a3"), "MH", "Marshall Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca377f34-c630-4f3e-b292-782d62bd3645"), "MQ", "Martinique" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("edd87c8d-b524-4a4d-a802-7581b3fe99e7"), "MR", "Mauritania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c53a1d91-3b34-423f-b80c-7547443d215c"), "MU", "Mauritius" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("58fbc319-06dd-4172-92f5-f5e6f50924ec"), "YT", "Mayotte" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("21e89832-7431-4d37-89ee-766f08b98a77"), "MX", "Mexico" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5db54ae3-78f7-4248-858e-03aa9aeec5fe"), "FM", "Micronesia (Federated States of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cef5cc95-7872-4667-bca0-496b0201f83d"), "MD", "Moldova (the Republic of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("52ce7edd-9ab2-4e2e-adfc-da066eb28fe3"), "MC", "Monaco" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("222515df-026c-4c3d-8264-c7799fe8d625"), "MN", "Mongolia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7ece59ac-25b5-407d-bf53-8664160943ec"), "ME", "Montenegro" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1311d80a-4450-4c74-be6d-414ba03e1bc9"), "MS", "Montserrat" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ecb2c42b-7bc3-493d-8757-ac1c9deea876"), "MA", "Morocco" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("81e50550-5fb9-46dc-ba92-d59501d8b11c"), "MZ", "Mozambique" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2554d2a6-ba1b-4cf3-b46e-c3e20d8d977e"), "MM", "Myanmar" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4aeaae3b-7a1e-4d3a-9dde-c98803e50870"), "NA", "Namibia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("48e10e1b-3cc2-4ae2-8241-246871a0960a"), "NP", "Nepal" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("96e50f8d-faa5-41dd-a63c-b47825b4214f"), "SH", "Saint Helena, Ascension and Tristan da Cunha" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7dc795a9-be9d-4ac3-bed9-3a41fcf6df02"), "KN", "Saint Kitts and Nevis" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("df352c43-9548-43eb-a503-9387d7fcec5a"), "LC", "Saint Lucia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2463054d-f281-400d-992d-9decf573b44a"), "TL", "Timor-Leste" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5e756224-532e-4875-a6ef-0778bbdff9e5"), "TG", "Togo" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c4a41187-995c-432a-885a-3b490a008180"), "TK", "Tokelau" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b4b40965-5ccb-42a9-8276-c79c8b0a3e5d"), "TO", "Tonga" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d853ccfa-bb19-4b96-b4e7-5a016e9cf6e6"), "TT", "Trinidad and Tobago" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b1fde521-0c90-40ce-8da0-aa0366a474d1"), "TN", "Tunisia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fef61d04-f0cc-4f75-be43-49b8f05043b9"), "TR", "Turkey" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e3df45ab-4acb-4c08-8b2a-ded35a5469a8"), "TM", "Turkmenistan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e54070fd-601a-4b55-97ef-222fa6fce9ae"), "TC", "Turks and Caicos Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("13f1aeaf-4d4b-4f40-a315-8200083be5d2"), "TV", "Tuvalu" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("02e97590-f536-4384-a96b-9ee689d861bf"), "UG", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b69d62de-1c5c-48ba-b62f-85ebbd510400"), "UA", "Ukraine" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("94003a9c-9086-4914-807d-c607faae469a"), "AE", "United Arab Emirates (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("18c17e4b-24da-4a15-b43d-b7eee54b020d"), "GB", "United Kingdom of Great Britain and Northern Ireland (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("62d204c9-be5a-47f7-b5d5-fe5cf1275853"), "UM", "United States Minor Outlying Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5daea48e-3498-4fac-9850-4cce68f20afb"), "US", "United States of America (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b173430c-8fe3-49cf-aaa0-264f3127ed89"), "UY", "Uruguay" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4c18dcaf-93f5-4ec4-ac40-f021d6042d14"), "UZ", "Uzbekistan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e78aa1cb-2add-44e4-8b65-65878c3d3fb8"), "VU", "Vanuatu" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eb5d8f03-5061-4bcc-bf95-d6eb1a92da10"), "VE", "Venezuela (Bolivarian Republic of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f4fb2ea3-914f-414d-95ce-6c3883d7b280"), "VN", "Viet Nam" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("934a7fb1-9e80-4574-b1ff-3b1f866e10e4"), "VG", "Virgin Islands (British)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9e1f3b43-774b-4215-8531-0b6a6a68cab1"), "VI", "Virgin Islands (U.S.)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("74bb6257-fd7a-4246-b880-3c1c29ad321f"), "WF", "Wallis and Futuna" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4fe5c2ba-dacd-4db9-907a-98c88cdf8553"), "EH", "Western Sahara" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("06672c7b-3843-465d-ad05-5394d949ef79"), "YE", "Yemen" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b0548b4a-43e1-455c-ad27-8531336420e1"), "ZM", "Zambia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d60c7ddc-f017-4c68-a06b-464693589c9e"), "TH", "Thailand" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dc760c31-8c72-4b2a-8469-023643606985"), "TZ", "Tanzania, United Republic of" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("28af454d-281d-4cb9-906f-f8be24eeec54"), "TJ", "Tajikistan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("81206aa5-8aef-4e02-a25f-d878b962cbc9"), "TW", "Taiwan (Province of China)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9fd89d52-b209-4810-b399-6b6c0c51f1d5"), "MF", "Saint Martin (French part)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("042ec113-03c1-431a-b499-1ced07fcfd74"), "PM", "Saint Pierre and Miquelon" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9bec736b-af40-4be2-abe7-40aebdcd15b0"), "VC", "Saint Vincent and the Grenadines" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cbf262fb-232d-43f4-bc6f-46cfb2cddca2"), "WS", "Samoa" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("be472911-c13c-4ea2-b5bf-5bd101c6b553"), "SM", "San Marino" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5b3ccdc4-cf12-47b0-aab7-40858251cff1"), "ST", "Sao Tome and Principe" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("626c0c6d-8539-4763-bbb0-cde8b053410e"), "SA", "Saudi Arabia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("71a1d15c-958b-4038-ac78-7d0532ce32ac"), "SN", "Senegal" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("615c904c-ff4b-4cdc-afa5-f7e1fc82f130"), "RS", "Serbia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7299770e-b914-4daa-a5ea-8f5ef945023b"), "SC", "Seychelles" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d82025df-e8da-478e-8e70-97d6af4cefb0"), "SL", "Sierra Leone" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca04331a-8437-4286-9e52-48619258194c"), "SG", "Singapore" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8075af6a-5dd3-4242-9250-00b89b5e0c9d"), "SX", "Sint Maarten (Dutch part)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f3a338d7-4930-4e41-b794-dbe8b0b9b8be"), "LR", "Liberia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7d227ae8-6e6a-4668-af3a-31a18f24a81b"), "SK", "Slovakia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("becd197f-243b-41a0-8519-06348f1325e0"), "SB", "Solomon Islands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("76238e86-8a1e-48f2-9f6d-865ecf69e272"), "SO", "Somalia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("129ce6eb-9003-4e60-a322-fbf076a1b121"), "ZA", "South Africa" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("403b4ccc-ed43-4add-82b2-6d46c0326111"), "GS", "South Georgia and the South Sandwich Islands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("943e1dd1-ae91-4afb-b572-7b09705e5867"), "SS", "South Sudan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cbcb8dd0-4f5b-4cad-9402-3e74321bf677"), "ES", "Spain" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a48f5b6c-e4af-43cf-8b39-e26564e91e63"), "LK", "Sri Lanka" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0fd44352-6a7e-4360-8ddd-ea3f10027413"), "SD", "Sudan (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4d260e6b-e1d5-4a85-9888-762eb28011f4"), "SR", "Suriname" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3ff872e2-93a3-47c8-a2d3-f903f73e309b"), "SJ", "Svalbard and Jan Mayen" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3b1185a4-bfd5-4ebb-b5c3-e827277f73cc"), "SE", "Sweden" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fab8d1a5-b483-4f34-b50e-5fa5a7f64b21"), "CH", "Switzerland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f873e05d-e186-42f7-9a5a-57e4dca90fc2"), "SY", "Syrian Arab Republic" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a2870433-8b34-4a66-9ee0-85d4e6f4b9fd"), "SI", "Slovenia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c40d6ea0-9847-4ad7-a0ca-b84cb82a43c3"), "ZW", "Zimbabwe" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6d434358-2413-4ef9-9e8c-eba8de2d1170"), "LS", "Lesotho" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b890954f-fe47-4c1f-9cde-0f943f38a5b5"), "LV", "Latvia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f2084da-df5b-45d8-a79b-78a70e7c0812"), "BN", "Brunei Darussalam" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b1a1acbf-df48-45f0-b728-cb3d9bd56f20"), "BG", "Bulgaria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cd699ae4-2b49-4ecb-89fd-5b7cadc62597"), "BF", "Burkina Faso" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1dd832a3-a6b1-4099-a45b-5571193e462e"), "BI", "Burundi" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("3388ef27-946e-42d9-a180-19eef915c377"), "CV", "Cabo Verde" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("618814c5-bb67-4709-a693-d63113244ddc"), "KH", "Cambodia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6b17b63c-adbb-4be4-b5f3-802012d39fd7"), "CM", "Cameroon" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("66ddf240-a8a5-44e0-8a80-7d888f21c035"), "CA", "Canada" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("34e6b0bc-b585-44a7-b833-06245ed130e5"), "KY", "Cayman Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fff9bed3-2f92-48ee-8e19-7c3a2c98a255"), "CF", "Central African Republic (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1d4694f8-aadc-4bc0-9568-06a69e7dc219"), "TD", "Chad" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8a786d7c-10a5-4c2f-b8ac-6749aea9797f"), "CL", "Chile" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c8405459-21ba-4b16-9048-87742e1d2b05"), "CN", "China" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("957662d6-002e-429d-bae1-6ac4a15425ca"), "CX", "Christmas Island" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("47068f27-9f53-4afe-9869-ca2660534d80"), "CC", "Cocos (Keeling) Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b5fec772-c49a-467e-b722-e39ec158dcdd"), "CO", "Colombia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f5c42daa-3077-43e7-9605-ae73d42e6702"), "KM", "Comoros (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a116c683-6974-4672-a5c7-32d74ffea1f7"), "CD", "Congo (the Democratic Republic of the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("73135e46-3642-4675-97eb-8b16c26673bc"), "CG", "Congo (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dc53b71c-f26c-456f-8600-cd86facca50e"), "CK", "Cook Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7f973a10-6ccf-4608-8682-acc74827608f"), "CR", "Costa Rica" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cdada79b-0cb4-4851-a854-5c6c9e6243ca"), "HR", "Croatia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("56215f97-899f-4cd0-ba27-0b63905536b3"), "CU", "Cuba" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("be3681ee-5041-4beb-8933-5919849c2449"), "CW", "Curaçao" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("47063f37-3df3-4d7c-9921-984e1a15ba02"), "CY", "Cyprus" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a56fd198-a9e7-466a-b72c-d1a8192a9755"), "CZ", "Czechia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("503eb1d7-6f09-4a4b-a6c2-452b2e212c2c"), "CI", "Côte d'Ivoire" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a47f6220-19e0-493d-b06f-ed78e613fa95"), "IO", "British Indian Ocean Territory (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8c8de5f9-7f83-41c3-812e-2257733f7595"), "DK", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ca53c73d-c726-4e4a-bde7-9054223ce021"), "BR", "Brazil" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e55a1c68-e491-4e25-8e70-32da3e7cce2a"), "BW", "Botswana" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1cfa30d5-3d4a-4893-be69-138cb2bec7e1"), "AL", "Albania" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("99afc850-9424-402e-bcb7-a98775699687"), "DZ", "Algeria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9b16b576-5f7c-4cdb-bb91-0cf5501e9bd1"), "AS", "American Samoa" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1bd7cb5a-2b43-4a81-aa23-c8f177330782"), "AD", "Andorra" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8def51aa-8c5a-4d4e-9a87-29381d54ea19"), "AO", "Angola" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f838a0b6-3653-4e34-9d72-eb788bd98615"), "AI", "Anguilla" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("31b8dcdd-6d39-4532-9352-7ed42f8c2c17"), "AQ", "Antarctica" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c842f114-b1ee-4c0d-a59d-4a7c5a3874c7"), "AG", "Antigua and Barbuda" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("739dafed-b04b-4967-b133-e6197023e616"), "AR", "Argentina" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("78034150-26cd-411b-a139-8348fe91ed82"), "AM", "Armenia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c38d077f-7b42-49e4-a5cc-7f408a2ee68d"), "AW", "Aruba" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cac03109-83a0-4cb1-ab21-240a4d702758"), "AU", "Australia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("58a79756-1bdc-4976-b91f-bf036f4dcf71"), "AT", "Austria" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e0b24d8f-8764-48db-afa7-44b424c666e9"), "AZ", "Azerbaijan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("eb9af892-29fa-4c94-9875-2a14cb9201fb"), "BS", "Bahamas (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dee14065-37b3-42dc-95bf-b7103d290619"), "BH", "Bahrain" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("82b71449-d89f-44f2-8209-d9e6a12460cd"), "BD", "Bangladesh" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6910feb5-eccb-4d8c-bd5b-24a58deea4ae"), "BB", "Barbados" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("73609d52-af40-4410-9acd-fc69bd8be4ae"), "BY", "Belarus" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2b672677-b295-4c7d-83da-e402afeb07aa"), "BE", "Belgium" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("648b0849-4dfa-4ec0-be76-31f11d85d842"), "BZ", "Belize" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("631106d0-4c42-4209-83ab-fd77e9e92ace"), "BJ", "Benin" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8eb79566-8954-4714-a752-2aca6a05b1ca"), "BM", "Bermuda" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4b068ae8-3140-4ed0-b571-c1d1facd4736"), "BT", "Bhutan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4ff7e109-4a8f-4299-b981-fd59fd1ed00e"), "BO", "Bolivia (Plurinational State of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0c3e38b1-f386-4929-a57d-1d9380f99f87"), "BQ", "Bonaire, Sint Eustatius and Saba" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("94887b89-14e5-41a7-8571-5e91e9f06c85"), "BA", "Bosnia and Herzegovina" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("7874bbae-0bb5-43a5-b902-3202b1e40e0b"), "BV", "Bouvet Island" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("45d73b21-3ca4-4eb9-9424-3f01be0f4097"), "DJ", "Djibouti" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2a13a8cd-1456-498e-8b43-2f7c207ec36f"), "DM", "Dominica" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dbb4d414-b8d3-4c46-acee-a31f55c2959d"), "DO", "Dominican Republic (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("10dc8601-73d6-416c-8302-4cd117cdb7ac"), "HT", "Haiti" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("35a089e8-d856-4263-82b9-75a0bb2bcc32"), "HM", "Heard Island and McDonald Islands" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("26ddff22-1638-4af5-8d38-120b22e34c01"), "VA", "Holy See (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("46db4030-c225-47c6-a915-5bb584c33449"), "HN", "Honduras" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("81dc6413-1cdf-4b3b-8bef-7736beda2636"), "HK", "Hong Kong" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d5e14da8-04b4-4df8-a321-62c7eb66510c"), "HU", "Hungary" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8533d0a7-22a7-40a5-a608-788c80085598"), "IS", "Iceland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("aede0efe-7a70-4133-aaf6-ebe2798e51d8"), "IN", "India" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("88f45e4b-a8fc-42b2-ae05-9bee716fafcc"), "ID", "Indonesia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8ef87f60-7753-4a78-93fd-a95ba9ba16cf"), "IR", "Iran (Islamic Republic of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("e2b9d1b5-a9ac-4fe5-8dc4-3801f2c8e723"), "IQ", "Iraq" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("48f513da-406f-4a7f-ae96-802d4bc8b192"), "IE", "Ireland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f328c652-dffe-42d5-b529-1c7ce60b9dd6"), "IM", "Isle of Man" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("2efb68c6-6aff-490b-9514-b643c2b508a1"), "IL", "Israel" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c58cac25-81d1-4251-ac79-1c2f0060a82c"), "IT", "Italy" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("56ceea4a-7bba-4d41-ab1e-e713b848e62d"), "JM", "Jamaica" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("aa9a6d47-c63b-461b-8400-b5995cfc6778"), "JP", "Japan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f5399fd-14eb-47f7-81f6-279889f1acbd"), "JE", "Jersey" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5d179a9a-f99d-4ad3-9a28-2f3b45f1bc12"), "JO", "Jordan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9a10ee4e-529b-4b44-ac5a-12e95f8ea1ce"), "KZ", "Kazakhstan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("12a43acd-7636-4e14-a69d-68dde478d59c"), "KE", "Kenya" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ccfd9ea3-318f-4309-931b-17da28da46f7"), "KI", "Kiribati" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c02894dc-f78b-4f67-9c19-311eed84da83"), "KP", "Korea (the Democratic People's Republic of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d89c993-b889-4b56-bc75-f59fb5d42317"), "KR", "Korea (the Republic of)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("a436c397-a8dd-439a-98bb-bd653a58efb7"), "KW", "Kuwait" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("162ec82e-522b-4406-bff5-7fef1ac6651f"), "KG", "Kyrgyzstan" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f11ab252-d642-4fff-a0d5-06a7b799c71d"), "LA", "Lao People's Democratic Republic (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5efa0530-0e14-4c43-9004-4bf6db252a56"), "GY", "Guyana" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("caca94cf-e65c-4b7c-b2aa-d3cc20ceb761"), "GW", "Guinea-Bissau" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1a408385-c662-42e3-a5d5-3d58c6cf8c13"), "GN", "Guinea" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("fffba9f5-8387-4468-97f1-242634497e01"), "GG", "Guernsey" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("48329656-f154-4bcd-bf6a-94787f534872"), "EC", "Ecuador" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("c3dc25e5-cd52-422c-a3ab-b227b778cfd7"), "EG", "Egypt" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("cbcfb485-11ff-4710-8cdf-f49ec5d71d2a"), "SV", "El Salvador" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8332f034-b698-432d-80df-244452119f31"), "GQ", "Equatorial Guinea" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ffddc3a3-fb49-4310-859a-411487698497"), "ER", "Eritrea" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d2719d93-4f87-42af-b1e3-72c84614e67a"), "EE", "Estonia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("773a0996-08d2-42e7-913b-d6b225f87c0d"), "SZ", "Eswatini" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8f25850b-7250-4e9b-8e2d-185907ff8912"), "ET", "Ethiopia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("f458c669-65da-439b-818a-0eddacd21893"), "FK", "Falkland Islands (the) [Malvinas]" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("4099a4fa-da1a-4827-8ca8-09e14114ad12"), "FO", "Faroe Islands (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("70b1a842-ee0f-4387-ac0e-8838b975ef00"), "FJ", "Fiji" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("82c07761-1b1c-4c5a-8c18-390ee9edf7ac"), "FI", "Finland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1c5a2cd0-c5ca-4620-8a37-1ced79d6cfa5"), "FR", "France" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("d81ef715-0ae5-4222-9ba8-30833895ccf4"), "LB", "Lebanon" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("55e2d26e-165a-47a6-8cc2-94d135e38527"), "GF", "French Guiana" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("782ed274-6373-4f86-ba0c-ac7b146d29b1"), "TF", "French Southern Territories (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5b8eca17-1c8f-406b-ae33-7a5a9ead8972"), "GA", "Gabon" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("72a79bcf-4992-468b-a54e-3f69e64f366a"), "GM", "Gambia (the)" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("5d7b2a7a-b0a1-4730-becf-7953d67be0a2"), "GE", "Georgia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("13721750-0302-4b10-93b5-a9bd82fa5bae"), "DE", "Germany" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("17a9a235-ab04-46e7-8a11-b57a66285b40"), "GH", "Ghana" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ef6b2661-f8af-4985-9028-c313939ecdc1"), "GI", "Gibraltar" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("24e88ecd-9355-4970-bad3-fe1ff7dd5181"), "GR", "Greece" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("dae75275-0f17-48c3-858f-c89aab0fbbd1"), "GL", "Greenland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("9b28f145-dbe4-4ec5-943c-b46b2ad63dc2"), "GD", "Grenada" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("0d86e208-83e9-4c6b-80cc-39338412870b"), "GP", "Guadeloupe" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("b506f40c-8c54-40c4-abbe-4cc6e41c8c33"), "GU", "Guam" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("8bc59c86-ded5-4043-ada9-087d4516784a"), "GT", "Guatemala" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("ea9f93af-a71f-4d64-a29a-860e5e338a82"), "PF", "French Polynesia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("6dcd8206-4b45-48db-acb5-e3a595676018"), "AX", "Åland Islands" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryCode",
                table: "Companies",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyManagers_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyManagers_ManagerId",
                table: "CompanyManagers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_CompanyId",
                table: "ContactInfos",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payers_CompanyId",
                table: "Payers",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyManagers");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Payers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
