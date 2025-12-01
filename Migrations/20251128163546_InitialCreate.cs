using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Romance stories focus on deep emotions, romantic tension, and the growing attraction between two characters.\nThese books draw readers into a world of longing, excitement, and heartfelt moments that often lead to a soothing reunion or a lasting love.", "romance" },
                    { 2, "Mystery stories revolve around suspense, hidden clues, and the pursuit of uncovering the truth.\nThese books keep readers engaged through tension-filled twists and revelations that build toward a satisfying conclusion.", "mystery" },
                    { 3, "Fantasy tales transport readers to magical realms filled with mythical creatures, powerful forces, and epic quests.\nThey offer immersive worlds where imagination thrives and heroes rise against extraordinary challenges.", "fantasy" },
                    { 4, "Science fiction explores futuristic technologies, advanced worlds, and the possibilities of scientific discovery.\nThese stories ignite curiosity by blending innovation with adventure and philosophical questions about humanity.", "science fiction" },
                    { 5, "Horror stories evoke fear, tension, and psychological unease through dark atmospheres and unsettling events.\nThey captivate readers with chilling twists that tap into primal emotions and hidden fears.", "horror" },
                    { 6, "Thrillers are driven by intense pacing, high stakes, and constant suspense that keeps readers on edge.\nThese books create gripping narratives filled with danger, urgency, and unexpected turns.", "thriller" },
                    { 7, "Historical fiction blends factual settings with imaginative storytelling rooted in real events or eras.\nThese novels immerse readers in rich atmospheres while offering insight into cultures and times long past.", "historical fiction" },
                    { 8, "Drama stories center on emotional conflict, personal struggles, and complex relationships among characters.\nThey provide stirring narratives that explore growth, resilience, and human connection.", "drama" },
                    { 9, "Adventure tales follow daring quests, perilous journeys, and the spirit of exploration across unknown lands.\nThey draw readers into fast-paced experiences fueled by courage, discovery, and excitement.", "adventure" },
                    { 10, "Comedy stories aim to entertain through humor, witty dialogue, and amusing situations.\nThese books lift the reader’s spirit with lighthearted moments and playful character dynamics.", "comedy" },
                    { 11, "Psychological stories delve into the complexities of the human mind, inner conflicts, and emotional depth.\nThey offer thoughtful narratives that challenge perception and explore the boundaries of consciousness.", "psychological" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Price", "PublicationYear", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "Nicholas Sparks", 1, 100000, 1996, "A deeply emotional romance about Noah and Allie, two young lovers whose relationship is torn apart by social differences. Their love endures across the years, revealing the power of memory, devotion, and second chances in a timeless story of heartfelt connection.", "The Notebook" },
                    { 2, "Jojo Moyes", 1, 150000, 2012, "A touching and transformative romance between Louisa and Will, exploring themes of hope, independence, and the meaning of living fully. Their bond grows through emotional challenges that reshape both their lives in profound and unforgettable ways.", "Me Before You" },
                    { 3, "Gillian Flynn", 2, 100000, 2012, "A psychological mystery centered on the disappearance of Amy Dunne and the growing suspicion around her husband. The story unfolds through unreliable narratives, dark secrets, and unexpected twists that keep readers guessing until the final reveal.", "Gone Girl" },
                    { 4, "Stieg Larsson", 2, 300000, 2005, "A suspenseful investigation into corruption, murder, and hidden truths as journalist Mikael Blomkvist teams up with the brilliant yet troubled hacker Lisbeth Salander. Their search exposes a chilling family mystery with far-reaching consequences.", "The Girl with the Dragon Tattoo" },
                    { 5, "J.K. Rowling", 3, 250000, 1997, "A magical adventure following Harry Potter as he discovers his true identity and enters the enchanting world of Hogwarts. Filled with wonder, friendship, danger, and destiny, this story begins an epic journey that has captivated millions worldwide.", "Harry Potter and the Sorcerer's Stone" },
                    { 6, "J.R.R. Tolkien", 3, 220000, 1937, "Bilbo Baggins is unexpectedly drawn into an epic quest with dwarves, encountering trolls, goblins, and a dragon. A classic fantasy tale blending courage, discovery, and the enchanting landscapes of Middle-earth in an unforgettable adventure.", "The Hobbit" },
                    { 7, "Frank Herbert", 4, 170000, 1965, "A sweeping sci-fi epic set on the desert planet Arrakis, where political intrigue, ecological struggle, and spiritual awakening intertwine. Paul Atreides confronts destiny, power, and survival in a world shaped by conflict and ancient prophecy.", "Dune" },
                    { 8, "Andy Weir", 4, 100000, 2011, "Astronaut Mark Watney is stranded on Mars and must rely on ingenuity, engineering, and sheer determination to survive. A gripping survival story combining science, humor, and human resilience against overwhelming odds.", "The Martian" },
                    { 9, "Stephen King", 5, 330000, 1986, "A terrifying tale of a shape-shifting entity feeding on fear in the town of Derry. A group of children face their darkest nightmares, forming bonds that stretch into adulthood as they confront an ancient evil haunting their lives.", "It" },
                    { 10, "Shirley Jackson", 5, 179000, 1959, "A chilling exploration of psychological terror as a group investigates a mysterious mansion. The house seems alive with sinister intent, blurring the line between supernatural danger and the fragile minds of its occupants.", "The Haunting of Hill House" },
                    { 11, "Dan Brown", 6, 200000, 2003, "A fast-paced thriller combining art, religion, and secret societies. Symbologist Robert Langdon unravels cryptic clues across Europe, racing against time to uncover a hidden truth that could shake the foundations of history.", "The Da Vinci Code" },
                    { 12, "Paula Hawkins", 6, 100000, 2015, "A suspenseful psychological thriller following Rachel, a troubled woman entangled in a missing-person case. As her fragmented memories collide with disturbing revelations, the truth becomes increasingly dangerous and shocking.", "The Girl on the Train" },
                    { 13, "Anthony Doerr", 7, 99000, 2014, "A beautifully written WWII story following a blind French girl and a German boy whose lives converge. Through hardship, war, and moral struggle, their journeys highlight courage, innocence, and the resilience of the human spirit.", "All the Light We Cannot See" },
                    { 14, "Markus Zusak", 7, 160000, 2005, "Narrated by Death, this story follows a young girl in Nazi Germany who finds solace in books during times of fear and loss. Her acts of reading and sharing stories bring hope to those around her despite the darkness of war.", "The Book Thief" },
                    { 15, "Khaled Hosseini", 8, 100000, 2007, "A powerful and emotional journey of two Afghan women whose lives intertwine through oppression, loss, and unexpected sisterhood. Their courage and enduring strength form a deeply moving story of sacrifice and resilience.", "A Thousand Splendid Suns" },
                    { 16, "John Green", 8, 210000, 2012, "A tender and emotional drama following Hazel and Gus—two teens facing illness while discovering love, hope, and meaning. Their story examines grief, connection, and the beauty found even in life’s most fragile moments.", "The Fault in Our Stars" },
                    { 17, "Robert Louis Stevenson", 9, 550000, 1883, "A classic adventure about young Jim Hawkins, who sets sail in search of buried treasure. Pirates, danger, and high-seas excitement shape his journey, making it one of the most iconic tales of exploration and bravery.", "Treasure Island" },
                    { 18, "Arthur Conan Doyle", 9, 480000, 1912, "An expedition led by Professor Challenger discovers a hidden plateau where dinosaurs still roam. The team faces peril, wonder, and prehistoric life in a thrilling adventure filled with danger and discovery.", "The Lost World" },
                    { 19, "Terry Pratchett & Neil Gaiman", 10, 6300000, 1990, "A comedic and imaginative story about an angel and a demon who join forces to prevent the apocalypse. Filled with quirky humor, clever satire, and memorable characters, the novel blends chaos with charm in a hilarious journey.", "Good Omens" },
                    { 20, "Douglas Adams", 10, 390000, 1979, "A wildly funny sci-fi comedy where Arthur Dent is thrust into a bizarre galactic adventure. Absurd situations, witty dialogue, and cosmic nonsense create an unforgettable journey through a chaotic universe.", "The Hitchhiker's Guide to the Galaxy" },
                    { 21, "Dennis Lehane", 11, 250000, 2003, "A tense psychological mystery in which U.S. Marshal Teddy Daniels investigates a missing patient on an isolated asylum island. As haunting clues emerge, the line between reality and illusion becomes dangerously blurred.", "Shutter Island" },
                    { 22, "Alex Michaelides", 11, 410000, 2019, "A gripping psychological drama about Alicia, a woman who stops speaking after a shocking crime. A psychotherapist becomes obsessed with discovering the reason behind her silence, uncovering hidden truths along the way.", "The Silent Patient" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
