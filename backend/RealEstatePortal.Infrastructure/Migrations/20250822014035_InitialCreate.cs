using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstatePortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    CarSpots = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyImages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "City", "Description", "ListingType", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "103 Peshawar Road", 2, 2, 2, "Peshawar", "Spacious luxury apartment located in Peshawar. Ideal for families and professionals.", "Sale", 49434963m, "Luxury Apartment in Peshawar" },
                    { 2, "52 Lahore Road", 2, 4, 1, "Lahore", "Spacious family home located in Lahore. Ideal for families and professionals.", "Rent", 101202m, "Family Home in Lahore" },
                    { 3, "141 Multan Road", 1, 3, 0, "Multan", "Spacious office space located in Multan. Ideal for families and professionals.", "Sale", 54061732m, "Office Space in Multan" },
                    { 4, "103 Sialkot Road", 4, 1, 2, "Sialkot", "Spacious modern villa located in Sialkot. Ideal for families and professionals.", "Rent", 253236m, "Modern Villa in Sialkot" },
                    { 5, "161 Lahore Road", 1, 5, 1, "Lahore", "Spacious studio flat located in Lahore. Ideal for families and professionals.", "Sale", 54568624m, "Studio Flat in Lahore" },
                    { 6, "23 Quetta Road", 4, 1, 1, "Quetta", "Spacious luxury apartment located in Quetta. Ideal for families and professionals.", "Sale", 7238858m, "Luxury Apartment in Quetta" },
                    { 7, "103 Islamabad Road", 1, 1, 1, "Islamabad", "Spacious family home located in Islamabad. Ideal for families and professionals.", "Rent", 232128m, "Family Home in Islamabad" },
                    { 8, "54 Karachi Road", 1, 2, 1, "Karachi", "Spacious townhouse located in Karachi. Ideal for families and professionals.", "Sale", 58419409m, "Townhouse in Karachi" },
                    { 9, "103 Karachi Road", 4, 1, 1, "Karachi", "Spacious modern villa located in Karachi. Ideal for families and professionals.", "Rent", 170471m, "Modern Villa in Karachi" },
                    { 10, "7 Faisalabad Road", 1, 1, 1, "Faisalabad", "Spacious office space located in Faisalabad. Ideal for families and professionals.", "Sale", 6096229m, "Office Space in Faisalabad" },
                    { 11, "29 Gujranwala Road", 1, 4, 1, "Gujranwala", "Spacious commercial plot located in Gujranwala. Ideal for families and professionals.", "Rent", 140736m, "Commercial Plot in Gujranwala" },
                    { 12, "147 Faisalabad Road", 4, 2, 1, "Faisalabad", "Spacious farmhouse located in Faisalabad. Ideal for families and professionals.", "Rent", 149234m, "Farmhouse in Faisalabad" },
                    { 13, "90 Karachi Road", 1, 5, 0, "Karachi", "Spacious shop located in Karachi. Ideal for families and professionals.", "Rent", 126499m, "Shop in Karachi" },
                    { 14, "197 Rawalpindi Road", 3, 2, 1, "Rawalpindi", "Spacious luxury apartment located in Rawalpindi. Ideal for families and professionals.", "Rent", 60122m, "Luxury Apartment in Rawalpindi" },
                    { 15, "5 Quetta Road", 4, 4, 1, "Quetta", "Spacious townhouse located in Quetta. Ideal for families and professionals.", "Rent", 111974m, "Townhouse in Quetta" },
                    { 16, "118 Rawalpindi Road", 1, 2, 0, "Rawalpindi", "Spacious modern villa located in Rawalpindi. Ideal for families and professionals.", "Rent", 88615m, "Modern Villa in Rawalpindi" },
                    { 17, "150 Faisalabad Road", 2, 1, 0, "Faisalabad", "Spacious shop located in Faisalabad. Ideal for families and professionals.", "Sale", 15318434m, "Shop in Faisalabad" },
                    { 18, "169 Sialkot Road", 1, 6, 2, "Sialkot", "Spacious modern villa located in Sialkot. Ideal for families and professionals.", "Sale", 76442129m, "Modern Villa in Sialkot" },
                    { 19, "6 Islamabad Road", 2, 2, 0, "Islamabad", "Spacious penthouse located in Islamabad. Ideal for families and professionals.", "Rent", 224485m, "Penthouse in Islamabad" },
                    { 20, "59 Islamabad Road", 4, 1, 0, "Islamabad", "Spacious shop located in Islamabad. Ideal for families and professionals.", "Rent", 276848m, "Shop in Islamabad" },
                    { 21, "89 Multan Road", 2, 4, 2, "Multan", "Spacious townhouse located in Multan. Ideal for families and professionals.", "Rent", 55845m, "Townhouse in Multan" },
                    { 22, "22 Rawalpindi Road", 4, 6, 0, "Rawalpindi", "Spacious commercial plot located in Rawalpindi. Ideal for families and professionals.", "Rent", 196910m, "Commercial Plot in Rawalpindi" },
                    { 23, "25 Karachi Road", 3, 3, 1, "Karachi", "Spacious shop located in Karachi. Ideal for families and professionals.", "Sale", 66208476m, "Shop in Karachi" },
                    { 24, "188 Gujranwala Road", 3, 3, 1, "Gujranwala", "Spacious office space located in Gujranwala. Ideal for families and professionals.", "Rent", 72831m, "Office Space in Gujranwala" },
                    { 25, "177 Sialkot Road", 4, 4, 0, "Sialkot", "Spacious family home located in Sialkot. Ideal for families and professionals.", "Rent", 128794m, "Family Home in Sialkot" },
                    { 26, "84 Peshawar Road", 3, 6, 0, "Peshawar", "Spacious family home located in Peshawar. Ideal for families and professionals.", "Sale", 24423424m, "Family Home in Peshawar" },
                    { 27, "193 Sialkot Road", 2, 6, 2, "Sialkot", "Spacious townhouse located in Sialkot. Ideal for families and professionals.", "Rent", 334377m, "Townhouse in Sialkot" },
                    { 28, "161 Lahore Road", 3, 4, 0, "Lahore", "Spacious family home located in Lahore. Ideal for families and professionals.", "Rent", 227482m, "Family Home in Lahore" },
                    { 29, "40 Rawalpindi Road", 4, 4, 1, "Rawalpindi", "Spacious townhouse located in Rawalpindi. Ideal for families and professionals.", "Rent", 82143m, "Townhouse in Rawalpindi" },
                    { 30, "54 Gujranwala Road", 1, 2, 0, "Gujranwala", "Spacious modern villa located in Gujranwala. Ideal for families and professionals.", "Sale", 23227634m, "Modern Villa in Gujranwala" },
                    { 31, "71 Sialkot Road", 3, 5, 2, "Sialkot", "Spacious studio flat located in Sialkot. Ideal for families and professionals.", "Sale", 43572083m, "Studio Flat in Sialkot" },
                    { 32, "191 Sialkot Road", 3, 4, 1, "Sialkot", "Spacious luxury apartment located in Sialkot. Ideal for families and professionals.", "Sale", 84735464m, "Luxury Apartment in Sialkot" },
                    { 33, "4 Karachi Road", 4, 6, 2, "Karachi", "Spacious office space located in Karachi. Ideal for families and professionals.", "Sale", 31554236m, "Office Space in Karachi" },
                    { 34, "196 Islamabad Road", 3, 3, 1, "Islamabad", "Spacious modern villa located in Islamabad. Ideal for families and professionals.", "Rent", 313416m, "Modern Villa in Islamabad" },
                    { 35, "137 Islamabad Road", 3, 3, 0, "Islamabad", "Spacious townhouse located in Islamabad. Ideal for families and professionals.", "Rent", 25340m, "Townhouse in Islamabad" },
                    { 36, "65 Multan Road", 3, 4, 1, "Multan", "Spacious studio flat located in Multan. Ideal for families and professionals.", "Sale", 23573447m, "Studio Flat in Multan" },
                    { 37, "1 Peshawar Road", 4, 2, 1, "Peshawar", "Spacious luxury apartment located in Peshawar. Ideal for families and professionals.", "Sale", 76616474m, "Luxury Apartment in Peshawar" },
                    { 38, "36 Multan Road", 1, 4, 2, "Multan", "Spacious luxury apartment located in Multan. Ideal for families and professionals.", "Sale", 20569039m, "Luxury Apartment in Multan" },
                    { 39, "84 Peshawar Road", 2, 6, 1, "Peshawar", "Spacious penthouse located in Peshawar. Ideal for families and professionals.", "Sale", 60460139m, "Penthouse in Peshawar" },
                    { 40, "131 Faisalabad Road", 3, 4, 1, "Faisalabad", "Spacious townhouse located in Faisalabad. Ideal for families and professionals.", "Sale", 52122919m, "Townhouse in Faisalabad" },
                    { 41, "64 Gujranwala Road", 4, 4, 2, "Gujranwala", "Spacious family home located in Gujranwala. Ideal for families and professionals.", "Rent", 119307m, "Family Home in Gujranwala" },
                    { 42, "83 Multan Road", 4, 4, 0, "Multan", "Spacious commercial plot located in Multan. Ideal for families and professionals.", "Rent", 346585m, "Commercial Plot in Multan" },
                    { 43, "62 Faisalabad Road", 4, 1, 1, "Faisalabad", "Spacious farmhouse located in Faisalabad. Ideal for families and professionals.", "Sale", 39535100m, "Farmhouse in Faisalabad" },
                    { 44, "181 Faisalabad Road", 4, 2, 1, "Faisalabad", "Spacious commercial plot located in Faisalabad. Ideal for families and professionals.", "Rent", 47002m, "Commercial Plot in Faisalabad" },
                    { 45, "168 Gujranwala Road", 3, 6, 1, "Gujranwala", "Spacious family home located in Gujranwala. Ideal for families and professionals.", "Rent", 332323m, "Family Home in Gujranwala" },
                    { 46, "114 Multan Road", 3, 6, 2, "Multan", "Spacious modern villa located in Multan. Ideal for families and professionals.", "Sale", 14269739m, "Modern Villa in Multan" },
                    { 47, "5 Lahore Road", 1, 1, 1, "Lahore", "Spacious luxury apartment located in Lahore. Ideal for families and professionals.", "Sale", 36780450m, "Luxury Apartment in Lahore" },
                    { 48, "158 Islamabad Road", 3, 3, 0, "Islamabad", "Spacious office space located in Islamabad. Ideal for families and professionals.", "Rent", 291636m, "Office Space in Islamabad" },
                    { 49, "157 Islamabad Road", 1, 4, 1, "Islamabad", "Spacious modern villa located in Islamabad. Ideal for families and professionals.", "Rent", 15351m, "Modern Villa in Islamabad" },
                    { 50, "171 Multan Road", 2, 6, 1, "Multan", "Spacious shop located in Multan. Ideal for families and professionals.", "Rent", 241865m, "Shop in Multan" },
                    { 51, "186 Quetta Road", 1, 4, 2, "Quetta", "Spacious shop located in Quetta. Ideal for families and professionals.", "Rent", 286757m, "Shop in Quetta" },
                    { 52, "181 Sialkot Road", 4, 5, 1, "Sialkot", "Spacious townhouse located in Sialkot. Ideal for families and professionals.", "Sale", 87136891m, "Townhouse in Sialkot" },
                    { 53, "12 Lahore Road", 4, 4, 2, "Lahore", "Spacious office space located in Lahore. Ideal for families and professionals.", "Sale", 35631687m, "Office Space in Lahore" },
                    { 54, "176 Sialkot Road", 4, 1, 0, "Sialkot", "Spacious office space located in Sialkot. Ideal for families and professionals.", "Sale", 38112242m, "Office Space in Sialkot" },
                    { 55, "40 Multan Road", 2, 4, 0, "Multan", "Spacious modern villa located in Multan. Ideal for families and professionals.", "Rent", 200602m, "Modern Villa in Multan" },
                    { 56, "142 Quetta Road", 3, 3, 2, "Quetta", "Spacious luxury apartment located in Quetta. Ideal for families and professionals.", "Sale", 44465738m, "Luxury Apartment in Quetta" },
                    { 57, "175 Islamabad Road", 1, 4, 0, "Islamabad", "Spacious commercial plot located in Islamabad. Ideal for families and professionals.", "Rent", 222346m, "Commercial Plot in Islamabad" },
                    { 58, "174 Gujranwala Road", 2, 2, 2, "Gujranwala", "Spacious shop located in Gujranwala. Ideal for families and professionals.", "Rent", 120586m, "Shop in Gujranwala" },
                    { 59, "175 Karachi Road", 4, 5, 0, "Karachi", "Spacious commercial plot located in Karachi. Ideal for families and professionals.", "Rent", 295700m, "Commercial Plot in Karachi" },
                    { 60, "57 Lahore Road", 2, 5, 2, "Lahore", "Spacious penthouse located in Lahore. Ideal for families and professionals.", "Rent", 169001m, "Penthouse in Lahore" },
                    { 61, "94 Rawalpindi Road", 3, 3, 1, "Rawalpindi", "Spacious luxury apartment located in Rawalpindi. Ideal for families and professionals.", "Sale", 14297065m, "Luxury Apartment in Rawalpindi" },
                    { 62, "68 Peshawar Road", 4, 3, 2, "Peshawar", "Spacious penthouse located in Peshawar. Ideal for families and professionals.", "Sale", 70878741m, "Penthouse in Peshawar" },
                    { 63, "77 Islamabad Road", 1, 1, 2, "Islamabad", "Spacious commercial plot located in Islamabad. Ideal for families and professionals.", "Sale", 52062013m, "Commercial Plot in Islamabad" },
                    { 64, "95 Quetta Road", 4, 3, 0, "Quetta", "Spacious commercial plot located in Quetta. Ideal for families and professionals.", "Rent", 319926m, "Commercial Plot in Quetta" },
                    { 65, "108 Islamabad Road", 3, 2, 1, "Islamabad", "Spacious shop located in Islamabad. Ideal for families and professionals.", "Rent", 48125m, "Shop in Islamabad" },
                    { 66, "66 Faisalabad Road", 2, 2, 1, "Faisalabad", "Spacious luxury apartment located in Faisalabad. Ideal for families and professionals.", "Rent", 225877m, "Luxury Apartment in Faisalabad" },
                    { 67, "45 Peshawar Road", 1, 1, 0, "Peshawar", "Spacious luxury apartment located in Peshawar. Ideal for families and professionals.", "Sale", 46169248m, "Luxury Apartment in Peshawar" },
                    { 68, "172 Islamabad Road", 2, 1, 0, "Islamabad", "Spacious studio flat located in Islamabad. Ideal for families and professionals.", "Rent", 313419m, "Studio Flat in Islamabad" },
                    { 69, "113 Karachi Road", 4, 6, 0, "Karachi", "Spacious farmhouse located in Karachi. Ideal for families and professionals.", "Sale", 62080640m, "Farmhouse in Karachi" },
                    { 70, "54 Gujranwala Road", 2, 6, 0, "Gujranwala", "Spacious modern villa located in Gujranwala. Ideal for families and professionals.", "Rent", 56770m, "Modern Villa in Gujranwala" },
                    { 71, "16 Karachi Road", 3, 4, 1, "Karachi", "Spacious family home located in Karachi. Ideal for families and professionals.", "Sale", 18160452m, "Family Home in Karachi" },
                    { 72, "8 Multan Road", 2, 3, 1, "Multan", "Spacious office space located in Multan. Ideal for families and professionals.", "Rent", 205062m, "Office Space in Multan" },
                    { 73, "160 Gujranwala Road", 4, 6, 1, "Gujranwala", "Spacious farmhouse located in Gujranwala. Ideal for families and professionals.", "Sale", 14217328m, "Farmhouse in Gujranwala" },
                    { 74, "183 Islamabad Road", 1, 1, 0, "Islamabad", "Spacious farmhouse located in Islamabad. Ideal for families and professionals.", "Rent", 74177m, "Farmhouse in Islamabad" },
                    { 75, "83 Peshawar Road", 4, 2, 0, "Peshawar", "Spacious office space located in Peshawar. Ideal for families and professionals.", "Sale", 80167166m, "Office Space in Peshawar" },
                    { 76, "83 Quetta Road", 2, 6, 0, "Quetta", "Spacious luxury apartment located in Quetta. Ideal for families and professionals.", "Sale", 17146710m, "Luxury Apartment in Quetta" },
                    { 77, "45 Rawalpindi Road", 1, 5, 1, "Rawalpindi", "Spacious luxury apartment located in Rawalpindi. Ideal for families and professionals.", "Sale", 64329690m, "Luxury Apartment in Rawalpindi" },
                    { 78, "92 Peshawar Road", 2, 1, 0, "Peshawar", "Spacious shop located in Peshawar. Ideal for families and professionals.", "Sale", 8196958m, "Shop in Peshawar" },
                    { 79, "13 Faisalabad Road", 3, 5, 2, "Faisalabad", "Spacious shop located in Faisalabad. Ideal for families and professionals.", "Rent", 102328m, "Shop in Faisalabad" },
                    { 80, "151 Karachi Road", 2, 5, 2, "Karachi", "Spacious studio flat located in Karachi. Ideal for families and professionals.", "Sale", 40136868m, "Studio Flat in Karachi" },
                    { 81, "118 Faisalabad Road", 3, 6, 0, "Faisalabad", "Spacious office space located in Faisalabad. Ideal for families and professionals.", "Sale", 5548360m, "Office Space in Faisalabad" },
                    { 82, "95 Quetta Road", 1, 6, 1, "Quetta", "Spacious luxury apartment located in Quetta. Ideal for families and professionals.", "Rent", 264154m, "Luxury Apartment in Quetta" },
                    { 83, "148 Faisalabad Road", 4, 4, 2, "Faisalabad", "Spacious penthouse located in Faisalabad. Ideal for families and professionals.", "Rent", 17756m, "Penthouse in Faisalabad" },
                    { 84, "75 Lahore Road", 4, 4, 1, "Lahore", "Spacious penthouse located in Lahore. Ideal for families and professionals.", "Sale", 50752876m, "Penthouse in Lahore" },
                    { 85, "190 Peshawar Road", 1, 3, 1, "Peshawar", "Spacious penthouse located in Peshawar. Ideal for families and professionals.", "Sale", 79785679m, "Penthouse in Peshawar" },
                    { 86, "180 Quetta Road", 1, 3, 0, "Quetta", "Spacious farmhouse located in Quetta. Ideal for families and professionals.", "Sale", 12470603m, "Farmhouse in Quetta" },
                    { 87, "92 Sialkot Road", 4, 4, 0, "Sialkot", "Spacious shop located in Sialkot. Ideal for families and professionals.", "Rent", 346535m, "Shop in Sialkot" },
                    { 88, "155 Faisalabad Road", 3, 6, 2, "Faisalabad", "Spacious office space located in Faisalabad. Ideal for families and professionals.", "Sale", 69278981m, "Office Space in Faisalabad" },
                    { 89, "86 Karachi Road", 2, 4, 0, "Karachi", "Spacious luxury apartment located in Karachi. Ideal for families and professionals.", "Rent", 280289m, "Luxury Apartment in Karachi" },
                    { 90, "20 Lahore Road", 3, 3, 0, "Lahore", "Spacious family home located in Lahore. Ideal for families and professionals.", "Rent", 61116m, "Family Home in Lahore" },
                    { 91, "161 Karachi Road", 3, 6, 2, "Karachi", "Spacious townhouse located in Karachi. Ideal for families and professionals.", "Rent", 257026m, "Townhouse in Karachi" },
                    { 92, "19 Gujranwala Road", 4, 2, 0, "Gujranwala", "Spacious commercial plot located in Gujranwala. Ideal for families and professionals.", "Sale", 35567788m, "Commercial Plot in Gujranwala" },
                    { 93, "63 Faisalabad Road", 2, 6, 1, "Faisalabad", "Spacious modern villa located in Faisalabad. Ideal for families and professionals.", "Rent", 218576m, "Modern Villa in Faisalabad" },
                    { 94, "154 Sialkot Road", 1, 4, 0, "Sialkot", "Spacious office space located in Sialkot. Ideal for families and professionals.", "Rent", 336611m, "Office Space in Sialkot" },
                    { 95, "102 Quetta Road", 1, 6, 2, "Quetta", "Spacious townhouse located in Quetta. Ideal for families and professionals.", "Rent", 83231m, "Townhouse in Quetta" },
                    { 96, "55 Lahore Road", 3, 1, 0, "Lahore", "Spacious office space located in Lahore. Ideal for families and professionals.", "Sale", 36051023m, "Office Space in Lahore" },
                    { 97, "140 Peshawar Road", 3, 4, 0, "Peshawar", "Spacious townhouse located in Peshawar. Ideal for families and professionals.", "Sale", 61487065m, "Townhouse in Peshawar" },
                    { 98, "164 Rawalpindi Road", 3, 4, 0, "Rawalpindi", "Spacious office space located in Rawalpindi. Ideal for families and professionals.", "Sale", 45126362m, "Office Space in Rawalpindi" },
                    { 99, "37 Lahore Road", 4, 1, 0, "Lahore", "Spacious farmhouse located in Lahore. Ideal for families and professionals.", "Rent", 184724m, "Farmhouse in Lahore" },
                    { 100, "39 Gujranwala Road", 4, 3, 0, "Gujranwala", "Spacious commercial plot located in Gujranwala. Ideal for families and professionals.", "Rent", 239596m, "Commercial Plot in Gujranwala" }
                });

            migrationBuilder.InsertData(
                table: "PropertyImages",
                columns: new[] { "Id", "PropertyId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,LuxuryApartment" },
                    { 2, 2, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,FamilyHome" },
                    { 3, 3, "https://source.unsplash.com/600x400/?house,pakistan,Multan,OfficeSpace" },
                    { 4, 4, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,ModernVilla" },
                    { 5, 5, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,StudioFlat" },
                    { 6, 6, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,LuxuryApartment" },
                    { 7, 7, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,FamilyHome" },
                    { 8, 8, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,Townhouse" },
                    { 9, 9, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,ModernVilla" },
                    { 10, 10, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,OfficeSpace" },
                    { 11, 11, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,CommercialPlot" },
                    { 12, 12, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Farmhouse" },
                    { 13, 13, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,Shop" },
                    { 14, 14, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,LuxuryApartment" },
                    { 15, 15, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,Townhouse" },
                    { 16, 16, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,ModernVilla" },
                    { 17, 17, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Shop" },
                    { 18, 18, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,ModernVilla" },
                    { 19, 19, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,Penthouse" },
                    { 20, 20, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,Shop" },
                    { 21, 21, "https://source.unsplash.com/600x400/?house,pakistan,Multan,Townhouse" },
                    { 22, 22, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,CommercialPlot" },
                    { 23, 23, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,Shop" },
                    { 24, 24, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,OfficeSpace" },
                    { 25, 25, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,FamilyHome" },
                    { 26, 26, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,FamilyHome" },
                    { 27, 27, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,Townhouse" },
                    { 28, 28, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,FamilyHome" },
                    { 29, 29, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,Townhouse" },
                    { 30, 30, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,ModernVilla" },
                    { 31, 31, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,StudioFlat" },
                    { 32, 32, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,LuxuryApartment" },
                    { 33, 33, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,OfficeSpace" },
                    { 34, 34, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,ModernVilla" },
                    { 35, 35, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,Townhouse" },
                    { 36, 36, "https://source.unsplash.com/600x400/?house,pakistan,Multan,StudioFlat" },
                    { 37, 37, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,LuxuryApartment" },
                    { 38, 38, "https://source.unsplash.com/600x400/?house,pakistan,Multan,LuxuryApartment" },
                    { 39, 39, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,Penthouse" },
                    { 40, 40, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Townhouse" },
                    { 41, 41, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,FamilyHome" },
                    { 42, 42, "https://source.unsplash.com/600x400/?house,pakistan,Multan,CommercialPlot" },
                    { 43, 43, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Farmhouse" },
                    { 44, 44, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,CommercialPlot" },
                    { 45, 45, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,FamilyHome" },
                    { 46, 46, "https://source.unsplash.com/600x400/?house,pakistan,Multan,ModernVilla" },
                    { 47, 47, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,LuxuryApartment" },
                    { 48, 48, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,OfficeSpace" },
                    { 49, 49, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,ModernVilla" },
                    { 50, 50, "https://source.unsplash.com/600x400/?house,pakistan,Multan,Shop" },
                    { 51, 51, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,Shop" },
                    { 52, 52, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,Townhouse" },
                    { 53, 53, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,OfficeSpace" },
                    { 54, 54, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,OfficeSpace" },
                    { 55, 55, "https://source.unsplash.com/600x400/?house,pakistan,Multan,ModernVilla" },
                    { 56, 56, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,LuxuryApartment" },
                    { 57, 57, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,CommercialPlot" },
                    { 58, 58, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,Shop" },
                    { 59, 59, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,CommercialPlot" },
                    { 60, 60, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,Penthouse" },
                    { 61, 61, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,LuxuryApartment" },
                    { 62, 62, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,Penthouse" },
                    { 63, 63, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,CommercialPlot" },
                    { 64, 64, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,CommercialPlot" },
                    { 65, 65, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,Shop" },
                    { 66, 66, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,LuxuryApartment" },
                    { 67, 67, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,LuxuryApartment" },
                    { 68, 68, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,StudioFlat" },
                    { 69, 69, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,Farmhouse" },
                    { 70, 70, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,ModernVilla" },
                    { 71, 71, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,FamilyHome" },
                    { 72, 72, "https://source.unsplash.com/600x400/?house,pakistan,Multan,OfficeSpace" },
                    { 73, 73, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,Farmhouse" },
                    { 74, 74, "https://source.unsplash.com/600x400/?house,pakistan,Islamabad,Farmhouse" },
                    { 75, 75, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,OfficeSpace" },
                    { 76, 76, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,LuxuryApartment" },
                    { 77, 77, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,LuxuryApartment" },
                    { 78, 78, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,Shop" },
                    { 79, 79, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Shop" },
                    { 80, 80, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,StudioFlat" },
                    { 81, 81, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,OfficeSpace" },
                    { 82, 82, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,LuxuryApartment" },
                    { 83, 83, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,Penthouse" },
                    { 84, 84, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,Penthouse" },
                    { 85, 85, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,Penthouse" },
                    { 86, 86, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,Farmhouse" },
                    { 87, 87, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,Shop" },
                    { 88, 88, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,OfficeSpace" },
                    { 89, 89, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,LuxuryApartment" },
                    { 90, 90, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,FamilyHome" },
                    { 91, 91, "https://source.unsplash.com/600x400/?house,pakistan,Karachi,Townhouse" },
                    { 92, 92, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,CommercialPlot" },
                    { 93, 93, "https://source.unsplash.com/600x400/?house,pakistan,Faisalabad,ModernVilla" },
                    { 94, 94, "https://source.unsplash.com/600x400/?house,pakistan,Sialkot,OfficeSpace" },
                    { 95, 95, "https://source.unsplash.com/600x400/?house,pakistan,Quetta,Townhouse" },
                    { 96, 96, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,OfficeSpace" },
                    { 97, 97, "https://source.unsplash.com/600x400/?house,pakistan,Peshawar,Townhouse" },
                    { 98, 98, "https://source.unsplash.com/600x400/?house,pakistan,Rawalpindi,OfficeSpace" },
                    { 99, 99, "https://source.unsplash.com/600x400/?house,pakistan,Lahore,Farmhouse" },
                    { 100, 100, "https://source.unsplash.com/600x400/?house,pakistan,Gujranwala,CommercialPlot" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImages_PropertyId",
                table: "PropertyImages",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "PropertyImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
