using LibraryApi.Entities;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.DbContexts
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
          : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category("romance")
                 {
                     Id = 1,
                     Description = "Romance stories focus on deep emotions, romantic tension, and the growing attraction between two characters.\nThese books draw readers into a world of longing, excitement, and heartfelt moments that often lead to a soothing reunion or a lasting love."


                 },
                 new Category("mystery")
                 {
                     Id = 2,
                     Description = "Mystery stories revolve around suspense, hidden clues, and the pursuit of uncovering the truth.\nThese books keep readers engaged through tension-filled twists and revelations that build toward a satisfying conclusion."

                 },

                new Category("fantasy")
                {
                    Id = 3,
                    Description = "Fantasy tales transport readers to magical realms filled with mythical creatures, powerful forces, and epic quests.\nThey offer immersive worlds where imagination thrives and heroes rise against extraordinary challenges."

                },

                new Category("science fiction")
                {
                    Id = 4,
                    Description = "Science fiction explores futuristic technologies, advanced worlds, and the possibilities of scientific discovery.\nThese stories ignite curiosity by blending innovation with adventure and philosophical questions about humanity."

                },

                new Category("horror")
                {
                    Id = 5,
                    Description = "Horror stories evoke fear, tension, and psychological unease through dark atmospheres and unsettling events.\nThey captivate readers with chilling twists that tap into primal emotions and hidden fears."

                },

                new Category("thriller")
                {
                    Id = 6,
                    Description = "Thrillers are driven by intense pacing, high stakes, and constant suspense that keeps readers on edge.\nThese books create gripping narratives filled with danger, urgency, and unexpected turns."

                },

                new Category("historical fiction")
                {
                    Id = 7,
                    Description = "Historical fiction blends factual settings with imaginative storytelling rooted in real events or eras.\nThese novels immerse readers in rich atmospheres while offering insight into cultures and times long past."

                },

                new Category("drama")
                {
                    Id = 8,
                    Description = "Drama stories center on emotional conflict, personal struggles, and complex relationships among characters.\nThey provide stirring narratives that explore growth, resilience, and human connection."

                },

                new Category("adventure")
                {
                    Id = 9,
                    Description = "Adventure tales follow daring quests, perilous journeys, and the spirit of exploration across unknown lands.\nThey draw readers into fast-paced experiences fueled by courage, discovery, and excitement."

                },

                new Category("comedy")
                {
                    Id = 10,
                    Description = "Comedy stories aim to entertain through humor, witty dialogue, and amusing situations.\nThese books lift the reader’s spirit with lighthearted moments and playful character dynamics."

                },

                new Category("psychological")
                {
                    Id = 11,
                    Description = "Psychological stories delve into the complexities of the human mind, inner conflicts, and emotional depth.\nThey offer thoughtful narratives that challenge perception and explore the boundaries of consciousness."
                }
                );

            modelBuilder.Entity<Book>().HasData(
                // Romance - CategoryId = 1
                new Book("The Notebook", "Nicholas Sparks")
                {
                    Id = 1,
                    Summary = "A deeply emotional romance about Noah and Allie, two young lovers whose relationship is torn apart by social differences. Their love endures across the years, revealing the power of memory, devotion, and second chances in a timeless story of heartfelt connection.",
                    PublicationYear = 1996,
                    CategoryId = 1,
                    Price = 100000
                    
                },

                new Book("Me Before You", "Jojo Moyes")
                {
                    Id = 2,
                    Summary = "A touching and transformative romance between Louisa and Will, exploring themes of hope, independence, and the meaning of living fully. Their bond grows through emotional challenges that reshape both their lives in profound and unforgettable ways.",
                    PublicationYear = 2012,
                    CategoryId = 1,
                    Price = 150000
                },


                // Mystery - CategoryId = 2
                new Book("Gone Girl", "Gillian Flynn")
                {
                    Id = 3,
                    Summary = "A psychological mystery centered on the disappearance of Amy Dunne and the growing suspicion around her husband. The story unfolds through unreliable narratives, dark secrets, and unexpected twists that keep readers guessing until the final reveal.",
                    PublicationYear = 2012,
                    CategoryId = 2,
                    Price = 100000
                },

                new Book("The Girl with the Dragon Tattoo", "Stieg Larsson")
                {
                    Id = 4,
                    Summary = "A suspenseful investigation into corruption, murder, and hidden truths as journalist Mikael Blomkvist teams up with the brilliant yet troubled hacker Lisbeth Salander. Their search exposes a chilling family mystery with far-reaching consequences.",
                    PublicationYear = 2005,
                    CategoryId = 2,
                    Price = 300000
                },


                // Fantasy - CategoryId = 3
                new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling")
                {
                    Id = 5,
                    Summary = "A magical adventure following Harry Potter as he discovers his true identity and enters the enchanting world of Hogwarts. Filled with wonder, friendship, danger, and destiny, this story begins an epic journey that has captivated millions worldwide.",
                    PublicationYear = 1997,
                    CategoryId = 3,
                    Price = 250000
                },

                new Book("The Hobbit", "J.R.R. Tolkien")
                {
                    Id = 6,
                    Summary = "Bilbo Baggins is unexpectedly drawn into an epic quest with dwarves, encountering trolls, goblins, and a dragon. A classic fantasy tale blending courage, discovery, and the enchanting landscapes of Middle-earth in an unforgettable adventure.",
                    PublicationYear = 1937,
                    CategoryId = 3,
                    Price = 220000
                },


                // Science Fiction - CategoryId = 4
                new Book("Dune", "Frank Herbert")
                {
                    Id = 7,
                    Summary = "A sweeping sci-fi epic set on the desert planet Arrakis, where political intrigue, ecological struggle, and spiritual awakening intertwine. Paul Atreides confronts destiny, power, and survival in a world shaped by conflict and ancient prophecy.",
                    PublicationYear = 1965,
                    CategoryId = 4,
                    Price = 170000
                },

                new Book("The Martian", "Andy Weir")
                {
                    Id = 8,
                    Summary = "Astronaut Mark Watney is stranded on Mars and must rely on ingenuity, engineering, and sheer determination to survive. A gripping survival story combining science, humor, and human resilience against overwhelming odds.",
                    PublicationYear = 2011,
                    CategoryId = 4,
                    Price = 100000

                },


                // Horror - CategoryId = 5
                new Book("It", "Stephen King")
                {
                    Id = 9,
                    Summary = "A terrifying tale of a shape-shifting entity feeding on fear in the town of Derry. A group of children face their darkest nightmares, forming bonds that stretch into adulthood as they confront an ancient evil haunting their lives.",
                    PublicationYear = 1986,
                    CategoryId = 5,
                    Price = 330000
                },

                new Book("The Haunting of Hill House", "Shirley Jackson")
                {
                    Id = 10,
                    Summary = "A chilling exploration of psychological terror as a group investigates a mysterious mansion. The house seems alive with sinister intent, blurring the line between supernatural danger and the fragile minds of its occupants.",
                    PublicationYear = 1959,
                    CategoryId = 5,
                    Price = 179000
                },


                // Thriller - CategoryId = 6
                new Book("The Da Vinci Code", "Dan Brown")
                {
                    Id = 11,
                    Summary = "A fast-paced thriller combining art, religion, and secret societies. Symbologist Robert Langdon unravels cryptic clues across Europe, racing against time to uncover a hidden truth that could shake the foundations of history.",
                    PublicationYear = 2003,
                    CategoryId = 6,
                    Price = 200000
                },

                new Book("The Girl on the Train", "Paula Hawkins")
                {
                    Id = 12,
                    Summary = "A suspenseful psychological thriller following Rachel, a troubled woman entangled in a missing-person case. As her fragmented memories collide with disturbing revelations, the truth becomes increasingly dangerous and shocking.",
                    PublicationYear = 2015,
                    CategoryId = 6,
                    Price = 100000
                },
                // Historical Fiction - CategoryId = 7
                new Book("All the Light We Cannot See", "Anthony Doerr")
                {
                    Id = 13,
                    Summary = "A beautifully written WWII story following a blind French girl and a German boy whose lives converge. Through hardship, war, and moral struggle, their journeys highlight courage, innocence, and the resilience of the human spirit.",
                    PublicationYear = 2014,
                    CategoryId = 7,
                    Price = 99000
                },

                new Book("The Book Thief", "Markus Zusak")
                {
                    Id = 14,
                    Summary = "Narrated by Death, this story follows a young girl in Nazi Germany who finds solace in books during times of fear and loss. Her acts of reading and sharing stories bring hope to those around her despite the darkness of war.",
                    PublicationYear = 2005,
                    CategoryId = 7,
                    Price = 160000
                },


                // Drama - CategoryId = 8
                new Book("A Thousand Splendid Suns", "Khaled Hosseini")
                {
                    Id = 15,
                    Summary = "A powerful and emotional journey of two Afghan women whose lives intertwine through oppression, loss, and unexpected sisterhood. Their courage and enduring strength form a deeply moving story of sacrifice and resilience.",
                    PublicationYear = 2007,
                    CategoryId = 8,
                    Price = 100000
                },

                new Book("The Fault in Our Stars", "John Green")
                {
                    Id = 16,
                    Summary = "A tender and emotional drama following Hazel and Gus—two teens facing illness while discovering love, hope, and meaning. Their story examines grief, connection, and the beauty found even in life’s most fragile moments.",
                    PublicationYear = 2012,
                    CategoryId = 8,
                    Price = 210000
                },


                // Adventure - CategoryId = 9
                new Book("Treasure Island", "Robert Louis Stevenson")
                {
                    Id = 17,
                    Summary = "A classic adventure about young Jim Hawkins, who sets sail in search of buried treasure. Pirates, danger, and high-seas excitement shape his journey, making it one of the most iconic tales of exploration and bravery.",
                    PublicationYear = 1883,
                    CategoryId = 9,
                    Price = 550000
                },

                new Book("The Lost World", "Arthur Conan Doyle")
                {
                    Id = 18,
                    Summary = "An expedition led by Professor Challenger discovers a hidden plateau where dinosaurs still roam. The team faces peril, wonder, and prehistoric life in a thrilling adventure filled with danger and discovery.",
                    PublicationYear = 1912,
                    CategoryId = 9,
                    Price = 480000
                },


                // Comedy - CategoryId = 10
                new Book("Good Omens", "Terry Pratchett & Neil Gaiman")
                {
                    Id = 19,
                    Summary = "A comedic and imaginative story about an angel and a demon who join forces to prevent the apocalypse. Filled with quirky humor, clever satire, and memorable characters, the novel blends chaos with charm in a hilarious journey.",
                    PublicationYear = 1990,
                    CategoryId = 10,
                    Price = 6300000
                },

                new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams")
                {
                    Id = 20,
                    Summary = "A wildly funny sci-fi comedy where Arthur Dent is thrust into a bizarre galactic adventure. Absurd situations, witty dialogue, and cosmic nonsense create an unforgettable journey through a chaotic universe.",
                    PublicationYear = 1979,
                    CategoryId = 10,
                    Price = 390000
                },


                // Psychological - CategoryId = 11
                new Book("Shutter Island", "Dennis Lehane")
                {
                    Id = 21,
                    Summary = "A tense psychological mystery in which U.S. Marshal Teddy Daniels investigates a missing patient on an isolated asylum island. As haunting clues emerge, the line between reality and illusion becomes dangerously blurred.",
                    PublicationYear = 2003,
                    CategoryId = 11,
                    Price = 250000
                },

                new Book("The Silent Patient", "Alex Michaelides")
                {
                    Id = 22,
                    Summary = "A gripping psychological drama about Alicia, a woman who stops speaking after a shocking crime. A psychotherapist becomes obsessed with discovering the reason behind her silence, uncovering hidden truths along the way.",
                    PublicationYear = 2019,
                    CategoryId = 11,
                    Price = 410000
                }
                );

            modelBuilder.Entity<Order>().HasMany(o=> o.Items).WithOne(i => i.Order).
                HasForeignKey(i => i.OrderId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
