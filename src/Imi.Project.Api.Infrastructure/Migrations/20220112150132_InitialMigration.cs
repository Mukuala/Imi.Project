using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Biography = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    EmbeddedTrailerUrl = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    AverageRating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorites_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watchlists_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Watchlists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "DateOfBirth", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer Jenny (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal, and the United States. Bale acknowledges the constant change was one of the influences on his career choice.", new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Christian_Bale.jpg", "Christian Bale" },
                    { 21, "Orlando Jonathan Blanchard Copeland Bloom was born on January 13, 1977 in Canterbury, Kent, England. His mother, Sonia Constance Josephine Bloom (née Copeland), was born in Kolkata, India, to an English family then-resident there. The man he first knew as his father, Harry Bloom, was a legendary political activist who fought for civil rights in South Africa. But Harry died of a stroke when Orlando was only four years old. After that, Orlando and his older sister, Samantha Bloom, were raised by their mother and family friend, Colin Stone. When Orlando was 13, Sonia revealed to him that Colin is actually the biological father of Orlando and his sister; the two were conceived after an agreement by his parents, since Harry, who suffered a stroke in 1975, was unable to have children.", new DateTime(1977, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Orlando_Bloom.jpg", "Orlando Bloom" },
                    { 20, "Johnny Depp is perhaps one of the most versatile actors of his day and age in Hollywood. He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer. Depp was raised in Florida. He dropped out of school when he was 15, and fronted a series of music-garage bands, including one named 'The Kids'. When he married Lori Anne Allison (Lori A. Depp) he took a job as a ballpoint-pen salesman to support himself and his wife. A visit to Los Angeles, California, with his wife, however, happened to be a blessing in disguise, when he met up with actor Nicolas Cage, who advised him to turn to acting, which culminated in Depp's film debut in the low-budget horror film, A Nightmare on Elm Street (1984), where he played a teenager who falls prey to dream-stalking demon Freddy Krueger.", new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Johnny_Depp.jpg", "Johnny Depp" },
                    { 19, "Megan Denise Fox was born on May 16, 1986 in Oak Ridge, Tennessee and raised in Rockwood, Tennessee to Gloria Darlene Tonachio (née Cisson), a real estate manager and Franklin Thomas Fox, a parole officer. She began her drama and dance training at age 5 and at age 10, she moved to Port St. Lucie, Florida where she continued her training and finished school. Megan began acting and modeling at age 13 after winning several awards at the 1999 American Modeling and Talent Convention in Hilton Head, South Carolina. At age 17, she tested out of school using correspondence and eventually moved to Los Angeles, California. Megan made her film debut as Brianna Wallace in the Mary-Kate Olsen and Ashley Olsen film, Holiday in the Sun (2001). Her best known roles are as Sam Witwicky's love interest, Mikaela Banes in Transformers (2007) and Transformers: Revenge of the Fallen (2009), and as April O'Neil in the film reboot Teenage Mutant Ninja Turtles (2014) and its sequel Teenage Mutant Ninja Turtles: Out of the Shadows (2016).", new DateTime(1986, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Megan_Fox.jpg", "Megan Fox" },
                    { 18, "Shia Saide LaBeouf was born in Los Angeles, California, to Shayna (Saide) and Jeffrey Craig LaBeouf, and is an only child. His mother is from an Ashkenazi Jewish family, while his father has Cajun (French) ancestry. His parents are divorced. He started his career by doing stand-up comedy around places in his neighborhood, such as coffee clubs. One day, he saw a friend of his acting on Dr. Quinn, Medicine Woman (1993), and wanted to become an actor. Shia and his mother talked it over, and the next day, he started looking for an agent. He searched in the yellow pages, called one up, and did a stand-up routine in front of him. They liked him and signed him, and then he started auditioning. He is well known for playing Louis Stevens on the popular Disney Channel series Even Stevens (2000) and has won a Daytime Emmy Award for his performance. His best known role is as Sam Witwicky, the main protagonist of the first three installments of the Transformers series: Transformers (2007), Transformers: Revenge of the Fallen (2009) and Transformers: Dark of the Moon (2011).", new DateTime(1986, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Shia_LaBeouf.jpg", "Shia LaBeouf" },
                    { 17, "Margot Elise Robbie was born on July 2, 1990 in Dalby, Queensland, Australia to Scottish parents. Her mother, Sarie Kessler, is a physiotherapist, and her father, is Doug Robbie. She comes from a family of four children, having two brothers and one sister. She graduated from Somerset College in Mudgeeraba, Queensland, Australia, a suburb in the Gold Coast hinterland of South East Queensland, where she and her siblings were raised by their mother and spent much of her time at the farm belonging to her grandparents. In her late teens, she moved to Melbourne, Victoria, Australia to pursue an acting career.", new DateTime(1990, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Margot_Robbie.jpg", "Margot Robbie" },
                    { 16, "With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959. His first dramatic arts exposure was on the stage including appearing in an all-African American production of the exuberant musical Hello, Dolly!.", new DateTime(1937, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Morgan_Freeman.jpg", "Morgan Freeman" },
                    { 15, "Thomas William Hiddleston was born in Westminster, London, to English-born Diana Patricia (Servaes) and Scottish-born James Norman Hiddleston. His mother is a former stage manager, and his father, a scientist, was the managing director of a pharmaceutical company. He started off at the preparatory school, The Dragon School in Oxford, and by the time he was 13, he boarded at Eton College, at the same time that his parents were going through a divorce. He continued on to the University of Cambridge, where he earned a double first in Classics. He continued to study acting at the Royal Academy of Dramatic Art, from which he graduated in 2005.", new DateTime(1981, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Tom_Hiddleston.jpg", "Tom Hiddleston" },
                    { 14, "Award-winning actor Mark Ruffalo was born on November 22, 1967, in Kenosha, Wisconsin, of humble means to father Frank Lawrence Ruffalo, a construction painter and Marie Rose (Hebert), a stylist and hairdresser; his father's ancestry is Italian and his mother is of half French-Canadian and half Italian descent. Mark moved with his family to Virginia Beach, Virginia, where he lived out most of his teenage years. Following high school, Mark moved with his family to San Diego and soon migrated north, eventually settling in Los Angeles.", new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Mark_Ruffalo.jpg", "Mark Ruffalo" },
                    { 13, "Christopher Hemsworth was born on August 11, 1983 in Melbourne, Victoria, Australia to Leonie Hemsworth (née van Os), an English teacher & Craig Hemsworth, a social-services counselor. His brothers are actors, Liam Hemsworth & Luke Hemsworth; he is of Dutch (from his immigrant maternal grandfather), Irish, English, Scottish, and German ancestry. His uncle, by marriage, was Rod Ansell, the bushman who inspired the comedy film Crocodile Dundee (1986).", new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Chris_Hemsworth.jpg", "Chris Hemsworth" },
                    { 22, "Keira Christina Knightley was born March 26, 1985 in the South West Greater London suburb of Richmond. She is the daughter of actor Will Knightley and actress turned playwright Sharman Macdonald. An older brother, Caleb Knightley, was born in 1979. Her father is English, while her Scottish-born mother is of Scottish and Welsh origin. Brought up immersed in the acting profession from both sides - writing and performing - it is little wonder that the young Keira asked for her own agent at the age of three. She was granted one at the age of six and performed in her first TV role as Little Girl in Screen One: Royal Celebration (1993), aged seven.", new DateTime(1985, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Keira_Knightley.jpg", "Keira Knightley" },
                    { 12, "Christopher Robert Evans began his acting career in typical fashion: performing in school productions and community theatre. He was born in Boston, Massachusetts, the son of Lisa (Capuano), who worked at the Concord Youth Theatre, and G. Robert Evans III, a dentist. His uncle is former U.S. Representative Mike Capuano. Chris's father is of half German and half Welsh/English/Scottish ancestry, while Chris's mother is of half Italian and half Irish descent. He has an older sister, Carly Evans, and two younger siblings, a brother named Scott Evans, who is also an actor, and a sister named Shana Evans. The family moved to suburban Sudbury when he was 11 years-old. Bitten by the acting bug in the first grade because his older sister, Carly, started performing, Evans followed suit and began appearing in school plays. While at Lincoln-Sudbury Regional High School, his drama teacher cited his performance as Leontes in The Winter's Tale as exemplary of his skill. After more plays and regional theatre, he moved to New York and attended the Lee Strasberg Theatre Institute.", new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Chris_Evans.jpg", "Chris Evans" },
                    { 10, "As the highest-paid actress in the world in 2015 and 2016, and with her films grossing over $5.5 billion worldwide, Jennifer Lawrence is often cited as the most successful actress of her generation. She is also thus far the only person born in the 1990s to have won an acting Oscar. Jennifer Shrader Lawrence was born August 15, 1990, in Louisville, Kentucky, to Karen (Koch), who manages a children's camp, and Gary Lawrence, who works in construction. She has two older brothers, Ben and Blaine, and has English, German, Irish, and Scottish ancestry.", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Jennifer_Lawrence.jpg", "Jennifer Lawrence" },
                    { 9, "McAvoy was born on 21 April 1979 in Glasgow, Scotland, to James, a bus driver, and Elizabeth (née Johnstone), a nurse. He was raised on a housing estate in Drumchapel, Glasgow by his maternal grandparents (James, a butcher, and Mary), after his parents divorced when James was 11. He went to St Thomas Aquinas Secondary in Jordanhill, Glasgow, where he did well enough and started 'a little school band with a couple of mates'.", new DateTime(1979, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/James_McAvoy.jpg", "James McAvoy" },
                    { 8, "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard: With a Vengeance (1995), Unbreakable (2000), Shaft (2000), The 51st State (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe.Samuel Leroy Jackson was born in Washington, D.C., to Elizabeth (Montgomery) and Roy Henry Jackson. He was raised by his mother, a factory worker, and his grandparents. At Morehouse College, Jackson was active in the black student movement. In the seventies, he joined the Negro Ensemble Company (together with Morgan Freeman). In the eighties, he became well-known after three movies made by Spike Lee: Do the Right Thing(1989), Mo' Better Blues (1990) and Jungle Fever (1991). He achieved prominence and critical acclaim in the early 1990s with films such as Patriot Games (1992), Amos & Andrew (1993), True Romance (1993), Jurassic Park (1993), and his collaborations with director Quentin Tarantino, including Pulp Fiction (1994), Jackie Brown (1997), and later Django Unchained (2012). Going from supporting player to leading man, his performance in Pulp Fiction (1994) gave him an Oscar nomination for his character Jules Winnfield, and he received a Silver Berlin Bear for his part as Ordell Robbi in Jackie Brown (1997). Jackson usually played bad guys and drug addicts before becoming an action hero.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Samuel_L._Jackson.jpg", "Samuel L. Jackson" },
                    { 7, "Michael Fassbender is an Irish actor who was born in Heidelberg, Germany, to a German father, Josef, and an Irish mother, Adele (originally from Larne, County Antrim, in Northern Ireland). Michael was raised in the town of Killarney, Co. Kerry, in south-west Ireland, where his family moved to when he was two years old. His parents ran a restaurant (his father is a chef).Fassbender is based in London, England, and became known in the U.S. after his role in the Quentin Tarantino's Inglourious Basterds (2009). In 2011, Fassbender debuted as the Marvel antihero Magneto in the prequel X-Men: First Class (2011); he would go on to share the role with Ian McKellen in X-Men: Days of Future Past (2014). Also in 2011, Fassbender's performance as a sex addict in Shame (2011) received critical acclaim. He won the Volpi Cup for Best Actor at the Venice Film Festival and was nominated for Golden Globe and BAFTA Awards.In 2013, his role as slave owner Edwin Epps in slavery epic 12 Years a Slave(2013) was similarly praised, earning him his first Oscar nomination, for Best Supporting Actor.", new DateTime(1977, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Michael_Fassbender.jpg", "Michael Fassbender" },
                    { 6, @"An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winner Brad Pitt's most widely recognized role may be Tyler Durden in Fight Club (1999). However, his portrayals of Billy Beane in Moneyball (2011), and Rusty Ryan in the remake of Ocean's Eleven (2001) and its sequels, also loom large in his filmography.

                Pitt was born William Bradley Pitt on December 18th, 1963, in Shawnee, Oklahoma, and was raised in Springfield, Missouri. He is the son of Jane Etta (Hillhouse), a school counselor, and William Alvin Pitt, a truck company manager. He has a younger brother, Douglas (Doug) Pitt, and a younger sister, Julie Neal Pitt. At Kickapoo High School, Pitt was involved in sports, debating, student government and school musicals. Pitt attended the University of Missouri, where he majored in journalism with a focus on advertising. He occasionally acted in fraternity shows. He left college two credits short of graduating to move to California. Before he became successful at acting, Pitt supported himself by driving strippers in limos, moving refrigerators and dressing as a giant chicken while working for el Pollo Loco.", new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Brad_Pitt.jpg", "Brad Pitt" },
                    { 5, @"Scarlett Ingrid Johansson was born on November 22, 1984 in Manhattan, New York City, New York. Her mother, Melanie Sloan is from a Jewish family from the Bronx and her father, Karsten Johansson is a Danish-born architect from Copenhagen. She has a sister, Vanessa Johansson, who is also an actress, a brother, Adrian, a twin brother, Hunter Johansson, born three minutes after her, and a paternal half-brother, Christian. Her grandfather was writer Ejner Johansson.

                Johansson began acting during childhood, after her mother started taking her to auditions. She made her professional acting debut at the age of eight in the off-Broadway production of Sophistry with Ethan Hawke, at New York's Playwrights Horizons. She would audition for commercials but took rejection so hard her mother began limiting her to film tryouts. She made her film debut at the age of nine, as John Ritter's character's daughter in the fantasy comedy North (1994). Following minor roles in Just Cause (1995), as the daughter of Sean Connery and Kate Capshaw's character, and If Lucy Fell (1996), she played the role of Amanda in Manny & Lo (1996). Her performance in Manny & Lo garnered a nomination for the Independent Spirit Award for Best Lead Female, and positive reviews.", new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Scarlett_Johansson.jpg", "Scarlett Johansson" },
                    { 4, "Hugh Michael Jackman is an Australian actor, singer, multi-instrumentalist, dancer and producer. Jackman has won international recognition for his roles in major films, notably as superhero, period, and romance characters. He is best known for his long-running role as Wolverine in the X-Men film series, as well as for his lead roles in the romantic-comedy fantasy Kate & Leopold (2001), the action-horror film Van Helsing (2004), the drama The Prestige and The Fountain (2006), the epic historical romantic drama Australia (2008), the film version of Les Misérables (2012), and the thriller Prisoners (2013). His work in Les Misérables earned him his first Academy Award nomination for Best Actor and his first Golden Globe Award for Best Actor - Motion Picture Musical or Comedy in 2013. In Broadway theatre, Jackman won a Tony Award for his role in The Boy from Oz. A four-time host of the Tony Awards themselves, he won an Emmy Award for one of these appearances. Jackman also hosted the 81st Academy Awards on 22 February 2009.", new DateTime(1968, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Hugh_Jackman.jpg", "Hugh Jackman" },
                    { 3, @"Leonardo Wilhelm DiCaprio was born November 11, 1974 in Los Angeles, California, the only child of Irmelin DiCaprio (née Indenbirken) and former comic book artist George DiCaprio. His father is of Italian and German descent, and his mother, who is German-born, is of German and Russian ancestry. His middle name, Wilhelm, was his maternal grandfather's first name. Leonardo's father had achieved minor status as an artist and distributor of cult comic book titles, and was even depicted in several issues of American Splendor, the cult semi-autobiographical comic book series by the late 'Harvey Pekar', a friend of George's. Leonardo's performance skills became obvious to his parents early on, and after signing him up with a talent agent who wanted Leonardo to perform under the stage name Lenny Williams, DiCaprio began appearing on a number of television commercials and educational programs.

                Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s, as the hunky lead actor in movies such as Romeo + Juliet (1996) and Titanic (1997), to then become a leading man in Hollywood blockbusters, made by internationally renowned directors such as Martin Scorsese and Christopher Nolan.", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Leonardo_DiCaprio.jpg", "Leonardo DiCaprio" },
                    { 2, @"Edward Thomas Hardy was born on September 15, 1977 in Hammersmith, London; his mother, Elizabeth Anne (Barrett), is an artist and painter, and his father, Chips Hardy, is a writer. He is of English and Irish descent. Hardy was brought up in East Sheen, London, and first studied at Reed's School. His education continued at Tower House School, then at Richmond Drama School, and subsequently at the Drama Centre London, along with fellow Oscar nominee Michael Fassbender. After winning a modeling competition at age 21, he had a brief contract with the agency Models One.

                Tom spent his teens and early twenties battling delinquency, alcoholism and drug addiction; after completing his work on Star Trek: Nemesis(2002), he sought treatment and has also admitted that his battles with addiction ended his five - year marriage to Sarah Ward. Returning to work in 2003, Hardy was awarded the Evening Standard Most Promising Newcomer Award for his theatre performances in the productions of In Arabia, We'd All Be Kings and Blood.In 2003, Tom also co - starred in the play The Modernists with Paul Popplewell, Jesse Spencer and Orlando Wells.", new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Tom_Hardy.jpg", "Tom Hardy" },
                    { 11, "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business. Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry. Robert and his sister, Allyson Downey, were immersed in film and the performing arts from a very young age, leading Downey Jr. to study at the Stagedoor Manor Performing Arts Training Center in upstate New York, before moving to California with his father following his parents' 1978 divorce. In 1982, he dropped out of Santa Monica High School to pursue acting full time. Downey Sr., himself a drug addict, exposed his son to drugs at a very early age, and Downey Jr. would go on to struggle with abuse for decades.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Robert_Downey_Jr.jpg", "Robert Downey Jr." }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "C11D2B23-5AB0-48B2-BE9E-C7E082ECF755", "77aa5b61-72d2-4aab-942d-397dbc51b9fd", "Admin", "ADMIN" },
                    { "53a61ad7-806c-4107-b051-574846f37501", "383fa921-6c98-43a6-82a5-f2b2078285ce", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Birthday", "FirstName", "Image", "LastName" },
                values: new object[,]
                {
                    { "d07a98ed-d98b-48b1-8fe6-5947359f936d", 0, "ce521983-c061-4bb1-b196-bfdcfdef8fa5", "ApplicationUser", "dmcelwee2@surveymonkey.com", true, false, null, "DMCELWEE2@SURVEYMONKEY.COM", "DMCELWEE2", "AQAAAAEAACcQAAAAEM2aBZC1CKNe9avlfNGdTUgco+iS5/Z68Cg9aJbLsYhAuLIEOVDgAQYp7BC4Dx7XIg==", null, false, "97289fc0-f24c-481e-a92a-5637a44121ac", false, "dmcelwee2", new DateTime(1993, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dougy", "https://robohash.org/nonquiaipsa.png?size=200x200&set=set1", "McElwee" },
                    { "919402ab-ceb9-4475-a7c3-ca0419c373a2", 0, "58da700d-8f3e-424a-b7e1-3cbcb56c769b", "ApplicationUser", "nvasechkino@vistaprint.com", true, false, null, "NVASECHKINO@VISTAPRINT.COM", "NVASECHKINO", "AQAAAAEAACcQAAAAELyfFQ+Hexd7euXykFLq7cb8ZymfqxTO9WRm978OJKLYCFAaOgBh04OWMiFEzh5hEg==", null, false, "fbfecead-abb9-4797-a892-bd781ca43d3c", false, "nvasechkino", new DateTime(1990, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nilson", "https://robohash.org/rationecumquequis.png?size=200x200&set=set1", "Vasechkin" },
                    { "db62733c-5c91-4fee-ba45-f69c0559edce", 0, "7b930b9d-8ba2-476a-8e6c-293d32635f8e", "ApplicationUser", "btubbp@purevolume.com", true, false, null, "BTUBBP@PUREVOLUME.COM", "BTUBBP", "AQAAAAEAACcQAAAAEBvmpMs2aELzi5hDJr0TycNtZqkBM1lKaIG3VrDXlHf+NXuyntReerOiVQcgXwD/3g==", null, false, "52b7b81a-e564-4c64-96c0-2d334ed53b4f", false, "btubbp", new DateTime(2014, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boothe", "https://robohash.org/fugitanimidolorem.png?size=200x200&set=set1", "Tubb" },
                    { "1cde7869-3a95-492f-b208-06091017990b", 0, "147c7c8b-3451-48b7-961d-93585a745dd9", "ApplicationUser", "abrawnq@people.com.cn", true, false, null, "ABRAWNQ@PEOPLE.COM.CN", "ABRAWNQ", "AQAAAAEAACcQAAAAEBn/4xMVHq/7v6PXOprmsHJEVCbfjvMafD239LJNT18EDgiHt7F57s57KkUeFa7THA==", null, false, "c2e64b73-38c2-43a5-afd9-265a381037a6", false, "abrawnq", new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allegra", "https://robohash.org/maximerationeet.png?size=200x200&set=set1", "Brawn" },
                    { "9b890576-aa15-4462-b71d-6242a310b95a", 0, "c7027b38-404c-4551-a72e-d1225648439e", "ApplicationUser", "corteaur@marriott.com", true, false, null, "CORTEAUR@MARRIOTT.COM", "CORTEAUR", "AQAAAAEAACcQAAAAEDVaBl3O1HQ/y89bU2Fgy+arFuCKhqUgTm+FEV4JMapGeriTdw/NVQDGZ/ElbRmJAA==", null, false, "dab35729-0c1d-4a03-800e-a5138008a624", false, "corteaur", new DateTime(1974, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cornelle", "https://robohash.org/reprehenderitquaeratomnis.png?size=200x200&set=set1", "Orteau" },
                    { "5243cce1-d4a5-4e5b-a019-0810474caa2d", 0, "f98a1f03-9d29-4ad0-8099-9f4d0620fdfa", "ApplicationUser", "bnichollss@harvard.edu", true, false, null, "BNICHOLLSS@HARVARD.EDU", "BNICHOLLSS", "AQAAAAEAACcQAAAAEBjUj5dMrNpZgHZ/A7OSlGVCZrdWSDHgEHhxoc8/pulTnrKr1iQQ7Mx+fJ2P4Bhjjw==", null, false, "2f9b943b-b0cf-4ad2-b957-216f92f59f78", false, "bnichollss", new DateTime(1993, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bell", "https://robohash.org/quasincidunttemporibus.png?size=200x200&set=set1", "Nicholls" },
                    { "b6da71c1-a50d-44c3-abea-54def1d6a293", 0, "12ec3ea2-d4f5-4318-b62c-62a9ec1a6078", "ApplicationUser", "jpittett@fotki.com", true, false, null, "JPITTETT@FOTKI.COM", "JPITTETT", "AQAAAAEAACcQAAAAED6WG4P2UHnRCAvoY78dnLplszD4kwV/qc4wRtqCgpDrhPzhB0YWH0V9Q4PTzs7xUQ==", null, false, "d56fd717-88b5-422c-a467-b184edbf2156", false, "jpittett", new DateTime(2001, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasun", "https://robohash.org/delectusdoloribusoccaecati.png?size=200x200&set=set1", "Pittet" },
                    { "373e0ebe-edf7-456f-87ab-9083a98cec16", 0, "71b5e444-97ee-4391-a39f-cbf4989c41ee", "ApplicationUser", "cstainesu@uol.com.br", true, false, null, "CSTAINESU@UOL.COM.BR", "CSTAINESU", "AQAAAAEAACcQAAAAEGd0XAPPuOBQ1dNX/9Tmmo/XJfgxyqw4yj1P2uCyfbt6AS2GN0E7VI4UTpgpsfTJbw==", null, false, "f4d488d8-44b0-46d0-ba15-b1fbf1ef4ea5", false, "cstainesu", new DateTime(1985, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cecilla", "https://robohash.org/occaecatiestvoluptates.png?size=200x200&set=set1", "Staines" },
                    { "8998b136-ce57-4ce1-a245-264750d6d5a9", 0, "7e864dd6-3259-47c9-9679-6eae6b981847", "ApplicationUser", "gpapen0@t-online.de", true, false, null, "GPAPEN0@T-ONLINE.DE", "GPAPEN0", "AQAAAAEAACcQAAAAEHh62E+N5nw5qKeKr3eJsGAyp4cSESMQVglwpIKepqKkT/WfILmxpRTLbZ2KuwaY3w==", null, false, "6646b34c-bb46-416c-8264-24fec5e57dcb", false, "gpapen0", new DateTime(1994, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gwyneth", "https://robohash.org/atnulladolor.png?size=200x200&set=set1", "Papen" },
                    { "0169ee2e-ac62-420a-81b1-5e2107c5229c", 0, "51579b95-6491-4e71-94aa-77f4db4cb5a2", "ApplicationUser", "dfallenw@cbc.ca", true, false, null, "DFALLENW@CBC.CA", "DFALLENW", "AQAAAAEAACcQAAAAEBgTK837BkgrRMRo0wsCF8TiC8SjI1uVVahod8ZoCh3BGMTP2DTIfokjH1U7ksd/MQ==", null, false, "f28d0cf7-e2e7-4615-93d7-77349db89051", false, "dfallenw", new DateTime(1997, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Del", "https://robohash.org/excepturieumvitae.png?size=200x200&set=set1", "Fallen" },
                    { "fe2dcf3f-c8f9-413f-b728-b8268e4ff250", 0, "0d88c38c-47ec-4a7c-8152-e21aecc525b5", "ApplicationUser", "dfieldsendx@live.com", true, false, null, "DFIELDSENDX@LIVE.COM", "DFIELDSENDX", "AQAAAAEAACcQAAAAENHRpoZ6A+LsgL8oxTUQA8vUEu4ncXf2jbzFVlURpENRDss19TRsZgwXXgUkV+rjdA==", null, false, "27956e68-9e3f-4d27-9e1c-0760182430dc", false, "dfieldsendx", new DateTime(2003, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danya", "https://robohash.org/adipiscicorruptiquo.png?size=200x200&set=set1", "Fieldsend" },
                    { "bb7bcba3-c15b-4948-9ed7-e2b03b6a56e3", 0, "c5046186-66b5-437c-8bf4-ab8e9488ef8d", "ApplicationUser", "hmatyuginy@google.ca", true, false, null, "HMATYUGINY@GOOGLE.CA", "HMATYUGINY", "AQAAAAEAACcQAAAAEPnO9zqt/keJV9Yw5s4RkyBfsd/+hJc6ey4MLASYEBqk0eykS8iht8VWbbSCPh7JuQ==", null, false, "d3ab686d-7152-4f73-9926-28986892c2e5", false, "hmatyuginy", new DateTime(1985, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hilliard", "https://robohash.org/doloreumearum.png?size=200x200&set=set1", "Matyugin" },
                    { "c12d37b9-6bf6-40f4-a690-ee4b86a8c18a", 0, "8cab2180-f53c-4e43-8599-e9316733b2a4", "ApplicationUser", "pgreenhillz@wisc.edu", true, false, null, "PGREENHILLZ@WISC.EDU", "PGREENHILLZ", "AQAAAAEAACcQAAAAEASq6hOuD4foXbjRjYoOkSoqRLD0CHc7/iq60Qm7Qpg68+iiUdll+3gSTtzXBOk4bA==", null, false, "3fb1c9d8-49e9-4d7e-9bb1-52282c965376", false, "pgreenhillz", new DateTime(1995, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pieter", "https://robohash.org/estenimsoluta.png?size=200x200&set=set1", "Greenhill" },
                    { "69465360-555b-4a6e-a353-e92ffb1679a7", 0, "ce5198eb-bb91-47a2-b7e0-202c4c14a62c", "ApplicationUser", "rcrudgington10@sciencedirect.com", true, false, null, "RCRUDGINGTON10@SCIENCEDIRECT.COM", "RCRUDGINGTON10", "AQAAAAEAACcQAAAAEEiFN6OK0jsNWw0I8tzWcc9XxKK1/+TNYEFCoYwIqTC5mbl71/lcVdd1m5WltWNXyA==", null, false, "3463ec59-61c8-4025-af20-aa8f0c0e2595", false, "rcrudgington10", new DateTime(2011, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosella", "https://robohash.org/etquoest.png?size=200x200&set=set1", "Crudgington" },
                    { "06fc4b3c-070b-4cd4-bd21-37e2a799b973", 0, "230f7dbb-ec10-43b9-adb6-acd62c8d4141", "ApplicationUser", "dchase11@mlb.com", true, false, null, "DCHASE11@MLB.COM", "DCHASE11", "AQAAAAEAACcQAAAAEI7GhiJ5f0TdIEfY6jE7ODy3/dPl9lQAJzBSIEnKfAPCjiFQ3MBmc4eHYM/wU5fn8Q==", null, false, "6582ae1f-41cc-4575-b654-72b0609d044d", false, "dchase11", new DateTime(1990, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dahlia", "https://robohash.org/minuspariaturvoluptatem.png?size=200x200&set=set1", "Chase" },
                    { "6cbfdcc5-f065-4b36-947e-6e383be9fa96", 0, "5def32e4-c800-4ef0-b59b-11e2ac6ca990", "ApplicationUser", "sblakeston12@alibaba.com", true, false, null, "SBLAKESTON12@ALIBABA.COM", "SBLAKESTON12", "AQAAAAEAACcQAAAAEF2p/l5BFF7Y9oJenDT8w/marNTuayjL3M0RRibOguuBUrwljE0Tx+36W1zoiX0tJQ==", null, false, "0e857092-510c-42c5-81cc-e3a2646b8e0a", false, "sblakeston12", new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siana", "https://robohash.org/autofficiavoluptatem.png?size=200x200&set=set1", "Blakeston" },
                    { "f8e204c0-5642-481f-995d-cab4cb457e1f", 0, "853da035-c2b8-4334-80d3-d5df6f12069c", "ApplicationUser", "sfriskey13@xrea.com", true, false, null, "SFRISKEY13@XREA.COM", "SFRISKEY13", "AQAAAAEAACcQAAAAEOT69qhYMG/Q2OKz7GdW2m1tFnUhqoPzQNrh6mD0dw3d9bD3MOSmzlAM/emqO8TP4w==", null, false, "edaf9ac9-249f-490a-aea8-67c54485886e", false, "sfriskey13", new DateTime(1999, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shae", "https://robohash.org/areprehenderitrepudiandae.png?size=200x200&set=set1", "Friskey" },
                    { "8d8c5811-068d-4422-9ca3-0b73db5db489", 0, "8b7c0af6-f1fe-41e3-bf04-8aac1d7c5caf", "ApplicationUser", "dtorbet1@weather.com", true, false, null, "DTORBET1@WEATHER.COM", "DTORBET1", "AQAAAAEAACcQAAAAEFUtmvFQltsIzoM8f2FzR7nIeuw124k1+kihmdGTBoaOqq9CHZ0FCIMAlqr59tNitA==", null, false, "879b7453-5ff4-4dc7-bd57-c91df510bc8c", false, "dtorbet1", new DateTime(1998, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dalis", "https://robohash.org/perferendisatveniam.png?size=200x200&set=set1", "Torbet" },
                    { "8d6c24d1-5e29-49a5-957a-852a72f2dc27", 0, "59ab2b01-cd1d-455b-8162-9d82a86cc08a", "ApplicationUser", "henochn@ow.ly", true, false, null, "HENOCHN@OW.LY", "HENOCHN", "AQAAAAEAACcQAAAAEFwoJS0HDtOx08ov+2SHJohjS5NpeEp3vAVUGVlUEc9Eb8m8XEbQtm7SOJSAFKnkDw==", null, false, "52615d4f-5a1e-41f6-ba92-2340685e1df7", false, "henochn", new DateTime(1953, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamnet", "https://robohash.org/sedautnatus.png?size=200x200&set=set1", "Enoch" },
                    { "b1122532-ab1e-4dea-b349-6ad129e86932", 0, "89f01d93-f25a-4e99-89d8-81720e9f881e", "ApplicationUser", "rbraunterm@amazon.co.jp", true, false, null, "RBRAUNTERM@AMAZON.CO.JP", "RBRAUNTERM", "AQAAAAEAACcQAAAAEBzxjLXPiFt0hw3CsFyu/EDXXPTzzx8OCvuxlCHsMiynlu6Jv95xIO+1gPgoSTYfwQ==", null, false, "253fc845-c745-4fab-8006-f49b17921700", false, "rbraunterm", new DateTime(2002, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rice", "https://robohash.org/quasicorporislaudantium.png?size=200x200&set=set1", "Braunter" },
                    { "efa3ba3d-7e04-40c4-b869-bcedc77371b0", 0, "e13802eb-da06-4357-afd2-7a1ca0c2b3c9", "ApplicationUser", "dpitwayv@acquirethisname.com", true, false, null, "DPITWAYV@ACQUIRETHISNAME.COM", "DPITWAYV", "AQAAAAEAACcQAAAAEPZCuxRIy4WU7JCf55GKbAIwpE9WdQobvXAO5opA/cNg2Ir4GlEaahQj/QipCc/cow==", null, false, "5dc557e8-9fc1-40b7-91d3-f41d66a8b24c", false, "dpitwayv", new DateTime(2000, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Derk", "https://robohash.org/etquasiveniam.png?size=200x200&set=set1", "Pitway" },
                    { "486eb8b1-0fd0-4010-9ddd-2d102e279d18", 0, "01b463af-4f03-45be-a70e-81ee885d6e43", "ApplicationUser", "jmcdonoghk@blogger.com", true, false, null, "JMCDONOGHK@BLOGGER.COM", "JMCDONOGHK", "AQAAAAEAACcQAAAAEB2ntg6qBphBZsLTdkHlffimj5uAghD8cDDf0m1M9qUq70EVjS9iocNbYkFDk+Uaug==", null, false, "6956bbef-fd08-4df2-8e11-8be6b132edc1", false, "jmcdonoghk", new DateTime(1987, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jannelle", "https://robohash.org/utperspiciatisut.png?size=200x200&set=set1", "McDonogh" },
                    { "f617a491-c12c-4352-a1d6-dc4484876f18", 0, "8986a82a-3437-4069-86a5-dda0f6b52e8a", "ApplicationUser", "vsydney3@spiegel.de", true, false, null, "VSYDNEY3@SPIEGEL.DE", "VSYDNEY3", "AQAAAAEAACcQAAAAENjQmyqpj+K1r7pxyburMIE4c5P+71eFVpi6sR95Nk05mrJZtSnJMtt9vbkTikpdsA==", null, false, "eb75685b-5dac-4a2c-b6f1-1478f1eada8a", false, "vsydney3", new DateTime(1964, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vally", "https://robohash.org/consequaturinciduntquaerat.png?size=200x200&set=set1", "Sydney" },
                    { "9110e2cd-ddd4-472c-98bf-6b667321426d", 0, "22fc3727-edd5-4b9d-984f-35e4f69fd344", "ApplicationUser", "showenl@spiegel.de", true, false, null, "SHOWENL@SPIEGEL.DE", "SHOWENL", "AQAAAAEAACcQAAAAEBE5AWX4RX+Xq7AaGeFp6ZytmfUKDa51rG6wtjfgFOqS/8Z0UmRQhXm0B3iCamrSAA==", null, false, "c82ebef3-7009-4742-857a-f47a599de7ab", false, "showenl", new DateTime(1954, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siward", "https://robohash.org/eosconsequaturautem.png?size=200x200&set=set1", "Howen" },
                    { "3a98651d-c672-4b2f-ba1a-2d91609630d1", 0, "e68cc6c7-0d44-499c-a286-f491cd839746", "ApplicationUser", "bstryde4@yahoo.co.jp", true, false, null, "BSTRYDE4@YAHOO.CO.JP", "BSTRYDE4", "AQAAAAEAACcQAAAAEMQlqfvDRcg7VJhHD4W781JS7RQfqg0up2p0Smhb6g4bglPPtVKHGia2eLbE+7J+4A==", null, false, "e5c5249e-725e-4ea5-a272-dcc81b8c04ef", false, "bstryde4", new DateTime(2013, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bastien", "https://robohash.org/laudantiumestdeserunt.png?size=200x200&set=set1", "Stryde" },
                    { "5c69ae15-a4ad-4e0e-9466-46372339e4b0", 0, "a90d5e53-2d1e-450a-a835-bac7a09f7640", "ApplicationUser", "vkillingback5@bing.com", true, false, null, "VKILLINGBACK5@BING.COM", "VKILLINGBACK5", "AQAAAAEAACcQAAAAEGWtso+KwW+/glNUbOvhTABo6EsZI37d2e4ASaWhvwvrTUn/m0aWN78Q9ZaK8n3qhg==", null, false, "72f92fe3-769d-4517-ac81-eb8f43a39d6d", false, "vkillingback5", new DateTime(2016, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Violetta", "https://robohash.org/expeditaveritatisconsectetur.png?size=200x200&set=set1", "Killingback" },
                    { "7bf6c2cd-0f1e-42da-b8a3-4f6c2d86b6f2", 0, "251f5acb-676c-4def-a7c0-a17e7a225ced", "ApplicationUser", "lserrier6@xinhuanet.com", true, false, null, "LSERRIER6@XINHUANET.COM", "LSERRIER6", "AQAAAAEAACcQAAAAEFnMatKckqLDoJqATxEFM5HX0oVl+RujLiHDJcjMPnELDBYfvzID1PGWjw1amZZ+oQ==", null, false, "3808480f-c985-4e85-9b03-5b3cab0a881b", false, "lserrier6", new DateTime(1998, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loria", "https://robohash.org/quibusdamdoloremqueet.png?size=200x200&set=set1", "Serrier" },
                    { "bd24214f-91d0-4ed4-8dcf-f8d75ff64cab", 0, "e0b98c75-66ad-4913-831b-8313ceda97ae", "ApplicationUser", "rreihm7@1688.com", true, false, null, "RREIHM7@1688.COM", "RREIHM7", "AQAAAAEAACcQAAAAEGEFei3iYSfW7+PgPaHtl8L09TjOOMjZYRRDkGmgzUsgxCzeiGwTrxjXohZqFoaG0w==", null, false, "8524f3ce-0d9a-4d7c-8e95-02b89286eded", false, "rreihm7", new DateTime(1996, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard", "https://robohash.org/enimquoet.png?size=200x200&set=set1", "Reihm" },
                    { "32f6f64a-22f9-42a5-a218-26f7203436cd", 0, "26f7f216-d607-48e2-bdc4-d5d11a62f094", "ApplicationUser", "cmatveiko9@youtube.com", true, false, null, "CMATVEIKO9@YOUTUBE.COM", "CMATVEIKO9", "AQAAAAEAACcQAAAAEHUkiIC5d3NxuPp4vwsXS3MiA6rczwzrxjdPtt/CI12HrlAq6ZxN5sJrhWZzqbTCwA==", null, false, "a6535a56-0f41-41cb-bd6d-35f59308e2d4", false, "cmatveiko9", new DateTime(1976, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "https://robohash.org/autemconsecteturlaudantium.png?size=200x200&set=set1", "Matveiko" },
                    { "ad9d1515-d2ac-416f-9415-6dae316339b4", 0, "3d6d1603-1c56-4798-bba1-709a78e65fe3", "ApplicationUser", "sbemrosea@prweb.com", true, false, null, "SBEMROSEA@PRWEB.COM", "SBEMROSEA", "AQAAAAEAACcQAAAAELDFrTvjbbqIhTqL11srffmeoukSq/8KhazUtlPOkc2ma4ZfS2oNg+dlJ0oUscRfFQ==", null, false, "061baa7f-5aa2-4119-84c0-5de4df2b9d8a", false, "sbemrosea", new DateTime(2012, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shane", "https://robohash.org/remrepellatcupiditate.png?size=200x200&set=set1", "Bemrose" },
                    { "f17e9da9-50f4-4148-b4f9-d3d634f04341", 0, "ba9bb7b0-13ab-4700-a298-beb56e35ac99", "ApplicationUser", "aoneill8@comcast.net", true, false, null, "AONEILL8@COMCAST.NET", "AONEILL8", "AQAAAAEAACcQAAAAEB61LYL/CpJDvSzmweBErLVfesFZF1swtRcxGmrgIGh3TCVC5Ulg9nvrixP9HiTUBA==", null, false, "7c124fd9-dc52-48bc-8b8b-0cb247c1c73e", false, "aoneill8", new DateTime(1952, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alyse", "https://robohash.org/quisquamoccaecatiautem.png?size=200x200&set=set1", "Oneill" },
                    { "8cbd8b6f-0dd5-4f67-ad0d-16c5ae77b5fe", 0, "278e2c94-7ddc-467f-b6e4-b2ebd3df81b5", "ApplicationUser", "nbollinsc@flavors.me", true, false, null, "NBOLLINSC@FLAVORS.ME", "NBOLLINSC", "AQAAAAEAACcQAAAAELOpnvefejsVXlOYqPsVtVp+hM/t9zHxaJxqkBA1tbCHdDq4ylHA0F8c8av2h1xUWw==", null, false, "097aa684-c22f-4795-b281-801df678802a", false, "nbollinsc", new DateTime(1964, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Newton", "https://robohash.org/consequunturestcupiditate.png?size=200x200&set=set1", "Bollins" },
                    { "d3b54d21-adfd-4ae7-8e4e-58e7e67e6286", 0, "6c95d4f0-242a-4fea-9311-e8eafdb582dc", "ApplicationUser", "amacd@skype.com", true, false, null, "AMACD@SKYPE.COM", "AMACD", "AQAAAAEAACcQAAAAEKooi6URf2pYjLTg6HEK/p+DUaYg/KZQL8lfYXY7BBU0uxNrEGvF8GdSGuxhWc+7yQ==", null, false, "d66d841f-ff9c-415d-bd25-e8693027626f", false, "amacd", new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agatha", "https://robohash.org/voluptatemtemporeveritatis.png?size=200x200&set=set1", "Mac" },
                    { "9b46aa5a-fec8-4e87-9b91-4ceabd656d4c", 0, "31fdf652-e9b7-431e-91d5-04873df8c9d0", "ApplicationUser", "fderre@posterous.com", true, false, null, "FDERRE@POSTEROUS.COM", "FDERRE", "AQAAAAEAACcQAAAAEKfhPSc1bxOZJ1v6TD3WFmQJH3cfY4FcMd+TXjURLWqDVhIfR9fCNPKTbMKgFXvg9Q==", null, false, "1eff1a1b-032d-42df-8c7e-6f263d85db6e", false, "fderre", new DateTime(1967, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fawn", "https://robohash.org/quiaquoet.png?size=200x200&set=set1", "Derr" },
                    { "ee8c7b7b-67b3-49cf-b382-7dacc6fa8285", 0, "4268c39c-f3b6-4316-aa87-48d79817cdcf", "ApplicationUser", "bbodleighf@blogger.com", true, false, null, "BBODLEIGHF@BLOGGER.COM", "BBODLEIGHF", "AQAAAAEAACcQAAAAEAmRaFay5PInBXQxkJXOb76FTYj4OffPOS0EQoGblyr3rKr33RhuOIibEm9B+zUX/Q==", null, false, "7a2f864a-d267-4f61-93f8-d4fe05c4ec78", false, "bbodleighf", new DateTime(1970, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brittaney", "https://robohash.org/accusantiumexplicabofugit.png?size=200x200&set=set1", "Bodleigh" },
                    { "11b823e7-441e-4649-bbd4-8a81c70551e0", 0, "11c468d1-8279-41ce-a691-aa1a7f6348f6", "ApplicationUser", "esawdayg@nature.com", true, false, null, "ESAWDAYG@NATURE.COM", "ESAWDAYG", "AQAAAAEAACcQAAAAEImdTx/qZ+IXgPXB8ElDQ68HEDWp5mFTd6SwBLWaLOaW+mZeUv32BU6sZ4JetFzK2w==", null, false, "b0cf3eeb-46dc-4e26-ac2e-9b8b0d0dc89f", false, "esawdayg", new DateTime(1957, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eartha", "https://robohash.org/quisquamquosquo.png?size=200x200&set=set1", "Sawday" },
                    { "f673974f-004e-4b7b-998e-d998f233df09", 0, "0dd78470-e33e-4d88-9ab1-7d1b97c2dc37", "ApplicationUser", "avedekhinh@soundcloud.com", true, false, null, "AVEDEKHINH@SOUNDCLOUD.COM", "AVEDEKHINH", "AQAAAAEAACcQAAAAELMkHt8teLf6EA4tIpj8L0kF0QotHBLPJ7IwOLFBBh2GG2hcS87fTDnRUPBrT4xDDQ==", null, false, "88b58406-a648-4297-9ea6-1e61207101c4", false, "avedekhinh", new DateTime(2018, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alysia", "https://robohash.org/consequaturnonaperiam.png?size=200x200&set=set1", "Vedekhin" },
                    { "191768fe-daf3-4854-9ac7-0c9066d564f6", 0, "9e319c79-5022-48c8-a18b-83e08fa07e43", "ApplicationUser", "tandreiai@360.cn", true, false, null, "TANDREIAI@360.CN", "TANDREIAI", "AQAAAAEAACcQAAAAEJ9fKCnfQp01T32WFTwc3ltIDK/Sp9YB8sfp4GOJPXS1QB7ftyS+u/GxaRqY3Hau9w==", null, false, "46fc1b01-8693-4c85-8ab1-1841cf6a4015", false, "tandreiai", new DateTime(1980, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travers", "https://robohash.org/similiquevelitaque.png?size=200x200&set=set1", "Andreia" },
                    { "a35f9512-7b70-4dc4-91ad-ff3bab79c9c5", 0, "625c5db0-48fd-4e0f-aecf-d85a8a03f0ae", "ApplicationUser", "glarcombej@nytimes.com", true, false, null, "GLARCOMBEJ@NYTIMES.COM", "GLARCOMBEJ", "AQAAAAEAACcQAAAAEM6cRVsWKaqrzacng+1R+QvYS48a/Gn8cB3kIiBAwPrXmrozZa96FiIoaAV/KkhcdA==", null, false, "6e10b709-1da1-42d1-b5fc-5a15d227b33a", false, "glarcombej", new DateTime(1966, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garvin", "https://robohash.org/quiillumvoluptate.png?size=200x200&set=set1", "Larcombe" },
                    { "6d5a0ee9-b73a-4ad6-b06d-168b65f112ce", 0, "07a06fe7-3f9e-480d-8ebc-0bc77f6231ef", "ApplicationUser", "acrannyb@rambler.ru", true, false, null, "ACRANNYB@RAMBLER.RU", "ACRANNYB", "AQAAAAEAACcQAAAAEHj8ZMtv4jU/deDcm1lteQsVecNpDlM6d0+4bf/9C3iBs4V/9B7s6fR9uwJk0MuJpg==", null, false, "9daff011-b99e-408d-9d3b-072f9616b01a", false, "acrannyb", new DateTime(1962, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ardenia", "https://robohash.org/consecteturfugitest.png?size=200x200&set=set1", "Cranny" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "Comedy" },
                    { 14, "History" },
                    { 13, "Romance" },
                    { 12, "Biography" },
                    { 11, "Thriller" },
                    { 9, "War" },
                    { 4, "Drama" },
                    { 7, "Western" },
                    { 6, "Sci-Fi" },
                    { 5, "Mystery" },
                    { 3, "Crime" },
                    { 2, "Adventure" },
                    { 1, "Action" },
                    { 8, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Duration", "EmbeddedTrailerUrl", "Image", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 19, 7.5999999999999996, "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.", 161, "https://www.youtube.com/embed/ELeMaP8EPAA", "/Images/MovieImg/Once_Upon_a_Time_in_Hollywood.jpg", "Once Upon a Time... in Hollywood", new DateTime(2019, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 8.0, "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.", 156, "https://www.youtube.com/embed/LoebZZ8K5N0", "/Images/MovieImg/The_Revenant.jpg", "The Revenant", new DateTime(2015, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 7.2000000000000002, "A writer and wall street trader, Nick, finds himself drawn to the past and lifestyle of his millionaire neighbor, Jay Gatsby.", 143, "https://www.youtube.com/embed/sN183rJltNM", "/Images/MovieImg/The_Great_Gatsby.jpg", "The Great Gatsby", new DateTime(2013, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 8.1999999999999993, "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.", 138, "https://www.youtube.com/embed/5iaYLCiq5RM", "/Images/MovieImg/Shutter_Island.jpg", "Shutter Island", new DateTime(2010, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 7.2999999999999998, "An adaptation of Homer's great epic, the film follows the assault on Troy by the united Greek forces and chronicles the fates of the men involved.", 163, "https://www.youtube.com/embed/znTLzRJimeY", "/Images/MovieImg/Troy.jpg", "Troy", new DateTime(2004, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 6.0, "Sam Witwicky leaves the Autobots behind for a normal life. But when his mind is filled with cryptic symbols, the Decepticons target him and he is dragged back into the Transformers' war.", 149, "https://www.youtube.com/embed/fnXzKwUgDhg", "/Images/MovieImg/Transformers_Revenge_of_the_Fallen.jpg", "Transformers: Revenge of the Fallen", new DateTime(2009, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 7.0, "An ancient struggle between two Cybertronian races, the heroic Autobots and the evil Decepticons, comes to Earth, with a clue to the ultimate power held by a teenager.", 144, "https://www.youtube.com/embed/dxQxgAfNzyE", "/Images/MovieImg/Transformers.jpg", "Transformers", new DateTime(2007, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 8.1999999999999993, "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", 180, "https://www.youtube.com/embed/iszwuX1AK6A", "/Images/MovieImg/The_Wolf_of_Wall_Street.jpg", "The Wolf of Wall Street", new DateTime(2013, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 6.2000000000000002, "The Autobots learn of a Cybertronian spacecraft hidden on the moon, and race against the Decepticons to reach it and to learn its secrets.", 154, "https://www.youtube.com/embed/bTIrEZM-cFE", "/Images/MovieImg/Transformers_Dark_of_the_Moon.jpg", "Transformers: Dark of the Moon", new DateTime(2011, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 8.0, "Blacksmith Will Turner teams up with eccentric pirate Captain Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.", 143, "https://www.youtube.com/embed/-9HT0l9HV4", "/Images/MovieImg/Pirates_of_the_Caribbean_The_Curse_of_the_Black_Pearl.jpg", "Pirates of the Caribbean: The Curse of the Black Pearl", new DateTime(2003, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 7.2999999999999998, "Jack Sparrow races to recover the heart of Davy Jones to avoid enslaving his soul to Jones' service, as other friends and foes seek the heart for their own agenda as well.", 151, "https://www.youtube.com/embed/ozk0-RHXtFw", "/Images/MovieImg/Pirates_of_the_Caribbean_Dead_Man's_Chest.jpg", "Pirates of the Caribbean: Dead Man's Chest", new DateTime(2006, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 7.0999999999999996, "Captain Barbossa, Will Turner and Elizabeth Swann must sail off the edge of the map, navigate treachery and betrayal, find Jack Sparrow, and make their final alliances for one last decisive battle.", 169, "https://www.youtube.com/embed/0op_XllRaAw", "/Images/MovieImg/Pirates_of_the_Caribbean_At_World's_End.jpg", "Pirates of the Caribbean: At World's End", new DateTime(2007, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 7.5999999999999996, "A grizzled tank commander makes tough decisions as he and his crew fight their way across Germany in April, 1945.", 134, "https://www.youtube.com/embed/DNHuK1rteF4", "/Images/MovieImg/Fury.jpg", "Fury", new DateTime(2014, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 8.8000000000000007, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", 148, "https://www.youtube.com/embed/YoHD9XEInc0", "/Images/MovieImg/Inception.jpg", "Inception", new DateTime(2010, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 7.7999999999999998, "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.", 147, "https://www.youtube.com/embed/dKrVegVI0Us", "/Images/MovieImg/Captain_America_Civil_War.jpg", "Captain America: Civil War", new DateTime(2016, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 7.2000000000000002, "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money.", 115, "https://www.youtube.com/embed/KzJNYYkkhzc", "/Images/MovieImg/Now_You_See_Me.jpg", "Now You See Me", new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8.4000000000000004, "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", 181, "https://www.youtube.com/embed/TcMBFSGVi1c", "/Images/MovieImg/Avengers_Endgame.jpg", "Avengers: Endgame", new DateTime(2019, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 8.4000000000000004, "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", 149, "https://www.youtube.com/embed/6ZfuNTqbHE8", "/Images/MovieImg/Avengers_Infinity_War.jpg", "Avengers: Infinity War", new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 7.2999999999999998, "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", 141, "https://www.youtube.com/embed/tmeOjFno6Do", "/Images/MovieImg/Avengers_Age_of_Ultron.jpg", "Avengers: Age of Ultron", new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 8.0, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", 143, "https://www.youtube.com/embed/eOrNdBpGMv8", "/Images/MovieImg/The_Avengers.jpg", "The Avengers", new DateTime(2012, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 5.7000000000000002, "Jean Grey begins to develop incredible powers that corrupt and turn her into a Dark Phoenix, causing the X-Men to decide if her life is worth more than all of humanity.", 113, "https://www.youtube.com/embed/1-q8C_c-nlM", "/Images/MovieImg/X-Men_Dark_Phoenix.jpg", "X-Men: Dark Phoenix", new DateTime(2019, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6.9000000000000004, "In the 1980s the X-Men must defeat an ancient all-powerful mutant, En Sabah Nur, who intends to thrive through bringing destruction to the world.", 144, "https://www.youtube.com/embed/COvnHv42T-A", "/Images/MovieImg/X-Men_Apocalypse.jpg", "X-Men: Apocalypse", new DateTime(2016, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7.7000000000000002, "In the 1960s, superpowered humans Charles Xavier and Erik Lensherr work together to find others like them, but Erik's vengeful pursuit of an ambitious mutant who ruined his life causes a schism to divide them.", 131, "https://www.youtube.com/embed/zp4rIZnQobE", "/Images/MovieImg/X-Men_First_Class.jpg", "X-Men: First Class", new DateTime(2011, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 8.3000000000000007, "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.", 153, "https://www.youtube.com/embed/KnrRy6kSFF0", "/Images/MovieImg/Inglourious_Basterds.jpg", "Inglourious Basterds", new DateTime(2009, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 8.4000000000000004, "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation-owner in Mississippi.", 165, "https://www.youtube.com/embed/0fUCuvNlOCg", "/Images/MovieImg/Django_Unchained.jpg", "Django Unchained", new DateTime(2012, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 8.5, "After a tragic accident, two stage magicians in 1890s London engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", 130, "https://www.youtube.com/embed/ObGVA1WOqyE", "/Images/MovieImg/The_Prestige.jpg", "The Prestige", new DateTime(2006, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 8.4000000000000004, "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.", 164, "https://www.youtube.com/embed/g8evyE9TuYk", "/Images/MovieImg/The_Dark_Knight_Rises.jpg", "The Dark Knight Rises", new DateTime(2012, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 9.0, "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes", 152, "https://www.youtube.com/embed/TQfATDZY5Y4", "/Images/MovieImg/The_Dark_Knight.jpg", "The Dark Knight", new DateTime(2008, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6.5, "The Four Horsemen resurface, and are forcibly recruited by a tech genius to pull off their most impossible heist yet.", 129, "https://www.youtube.com/embed/4I8rVcSQbic", "/Images/MovieImg/Now_You_See_Me_2.jpg", "Now You See Me 2", new DateTime(2016, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 8.1999999999999993, "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.", 140, "https://www.youtube.com/embed/qHhHIbNuok8", "/Images/MovieImg/Batman_Begins.jpg", "Batman Begins", new DateTime(2005, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "bd24214f-91d0-4ed4-8dcf-f8d75ff64cab", "53a61ad7-806c-4107-b051-574846f37501" },
                    { "f8e204c0-5642-481f-995d-cab4cb457e1f", "C11D2B23-5AB0-48B2-BE9E-C7E082ECF755" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "Id", "ApplicationUserId", "MovieId" },
                values: new object[,]
                {
                    { 12, "f617a491-c12c-4352-a1d6-dc4484876f18", 9 },
                    { 38, "f617a491-c12c-4352-a1d6-dc4484876f18", 9 },
                    { 42, "f617a491-c12c-4352-a1d6-dc4484876f18", 10 },
                    { 7, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 11 },
                    { 14, "f617a491-c12c-4352-a1d6-dc4484876f18", 11 },
                    { 30, "f617a491-c12c-4352-a1d6-dc4484876f18", 11 },
                    { 5, "8d8c5811-068d-4422-9ca3-0b73db5db489", 12 },
                    { 11, "f617a491-c12c-4352-a1d6-dc4484876f18", 12 },
                    { 25, "f617a491-c12c-4352-a1d6-dc4484876f18", 12 },
                    { 33, "f617a491-c12c-4352-a1d6-dc4484876f18", 13 },
                    { 36, "f617a491-c12c-4352-a1d6-dc4484876f18", 14 },
                    { 4, "8d8c5811-068d-4422-9ca3-0b73db5db489", 15 },
                    { 22, "f617a491-c12c-4352-a1d6-dc4484876f18", 15 },
                    { 16, "f617a491-c12c-4352-a1d6-dc4484876f18", 16 },
                    { 17, "f617a491-c12c-4352-a1d6-dc4484876f18", 17 },
                    { 28, "f617a491-c12c-4352-a1d6-dc4484876f18", 17 },
                    { 8, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 30 },
                    { 40, "f617a491-c12c-4352-a1d6-dc4484876f18", 29 },
                    { 15, "f617a491-c12c-4352-a1d6-dc4484876f18", 26 },
                    { 23, "f617a491-c12c-4352-a1d6-dc4484876f18", 25 },
                    { 37, "f617a491-c12c-4352-a1d6-dc4484876f18", 24 },
                    { 34, "f617a491-c12c-4352-a1d6-dc4484876f18", 23 },
                    { 9, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 8 },
                    { 26, "f617a491-c12c-4352-a1d6-dc4484876f18", 22 },
                    { 41, "f617a491-c12c-4352-a1d6-dc4484876f18", 20 },
                    { 39, "f617a491-c12c-4352-a1d6-dc4484876f18", 19 },
                    { 13, "f617a491-c12c-4352-a1d6-dc4484876f18", 19 },
                    { 10, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 19 },
                    { 18, "f617a491-c12c-4352-a1d6-dc4484876f18", 18 },
                    { 31, "f617a491-c12c-4352-a1d6-dc4484876f18", 17 },
                    { 6, "8d8c5811-068d-4422-9ca3-0b73db5db489", 22 },
                    { 27, "f617a491-c12c-4352-a1d6-dc4484876f18", 7 },
                    { 1, "8998b136-ce57-4ce1-a245-264750d6d5a9", 1 },
                    { 24, "f617a491-c12c-4352-a1d6-dc4484876f18", 2 },
                    { 32, "f617a491-c12c-4352-a1d6-dc4484876f18", 3 },
                    { 21, "f617a491-c12c-4352-a1d6-dc4484876f18", 5 },
                    { 2, "8998b136-ce57-4ce1-a245-264750d6d5a9", 3 },
                    { 35, "f617a491-c12c-4352-a1d6-dc4484876f18", 4 },
                    { 19, "f617a491-c12c-4352-a1d6-dc4484876f18", 4 },
                    { 20, "f617a491-c12c-4352-a1d6-dc4484876f18", 5 },
                    { 29, "f617a491-c12c-4352-a1d6-dc4484876f18", 1 },
                    { 3, "8d8c5811-068d-4422-9ca3-0b73db5db489", 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "MovieId", "ActorId" },
                values: new object[,]
                {
                    { 13, 15 },
                    { 14, 12 },
                    { 4, 1 },
                    { 14, 5 },
                    { 25, 18 },
                    { 22, 3 },
                    { 25, 19 },
                    { 11, 15 },
                    { 11, 14 },
                    { 11, 13 },
                    { 11, 12 },
                    { 11, 11 },
                    { 11, 8 },
                    { 11, 5 },
                    { 4, 4 },
                    { 4, 5 },
                    { 3, 1 },
                    { 16, 14 },
                    { 14, 11 },
                    { 22, 14 },
                    { 12, 5 },
                    { 12, 8 },
                    { 23, 6 },
                    { 13, 14 },
                    { 13, 13 },
                    { 3, 2 },
                    { 13, 12 },
                    { 13, 11 },
                    { 13, 8 },
                    { 13, 5 },
                    { 23, 21 },
                    { 15, 14 },
                    { 24, 6 },
                    { 24, 18 },
                    { 21, 3 },
                    { 12, 15 },
                    { 12, 14 },
                    { 16, 16 },
                    { 12, 12 },
                    { 12, 11 },
                    { 15, 16 },
                    { 12, 13 },
                    { 5, 3 },
                    { 10, 15 },
                    { 8, 7 },
                    { 1, 1 },
                    { 29, 20 },
                    { 29, 21 },
                    { 29, 22 },
                    { 19, 17 },
                    { 7, 10 },
                    { 7, 9 },
                    { 7, 7 },
                    { 19, 6 },
                    { 19, 3 },
                    { 30, 20 },
                    { 30, 21 },
                    { 6, 7 },
                    { 6, 6 },
                    { 30, 22 },
                    { 18, 3 },
                    { 18, 17 },
                    { 5, 8 },
                    { 26, 18 },
                    { 8, 10 },
                    { 8, 9 },
                    { 17, 2 },
                    { 10, 14 },
                    { 10, 13 },
                    { 10, 12 },
                    { 10, 11 },
                    { 10, 8 },
                    { 10, 5 },
                    { 26, 19 },
                    { 20, 2 },
                    { 20, 3 },
                    { 17, 3 },
                    { 2, 1 },
                    { 9, 10 },
                    { 9, 9 },
                    { 9, 7 },
                    { 28, 20 },
                    { 28, 21 },
                    { 28, 22 },
                    { 27, 18 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" },
                values: new object[,]
                {
                    { 20, 2 },
                    { 20, 4 },
                    { 19, 10 },
                    { 21, 4 },
                    { 2, 1 },
                    { 19, 4 },
                    { 20, 1 },
                    { 1, 2 },
                    { 22, 5 },
                    { 30, 8 },
                    { 30, 2 },
                    { 30, 1 },
                    { 29, 8 },
                    { 29, 2 },
                    { 29, 1 },
                    { 28, 8 },
                    { 28, 2 },
                    { 28, 1 },
                    { 27, 6 },
                    { 27, 2 },
                    { 27, 1 },
                    { 21, 13 },
                    { 26, 6 },
                    { 26, 1 },
                    { 1, 1 },
                    { 25, 6 },
                    { 25, 2 },
                    { 25, 1 },
                    { 2, 3 },
                    { 24, 9 },
                    { 24, 4 },
                    { 24, 1 },
                    { 23, 14 },
                    { 23, 4 },
                    { 22, 11 },
                    { 26, 2 },
                    { 2, 4 },
                    { 15, 11 },
                    { 11, 6 },
                    { 12, 2 },
                    { 12, 1 },
                    { 18, 12 },
                    { 11, 2 },
                    { 11, 1 },
                    { 4, 4 },
                    { 10, 6 },
                    { 10, 2 },
                    { 10, 1 },
                    { 4, 5 },
                    { 9, 6 },
                    { 9, 2 },
                    { 9, 1 },
                    { 4, 6 },
                    { 8, 6 },
                    { 8, 2 },
                    { 8, 1 },
                    { 7, 6 },
                    { 7, 2 },
                    { 7, 1 },
                    { 6, 9 },
                    { 6, 4 },
                    { 6, 2 },
                    { 5, 7 },
                    { 5, 4 },
                    { 12, 6 },
                    { 13, 1 },
                    { 13, 2 },
                    { 16, 1 },
                    { 17, 1 },
                    { 17, 2 },
                    { 16, 10 },
                    { 14, 6 },
                    { 14, 2 },
                    { 17, 6 },
                    { 3, 1 },
                    { 14, 1 },
                    { 15, 5 },
                    { 18, 3 },
                    { 18, 10 },
                    { 13, 4 },
                    { 16, 2 },
                    { 3, 3 },
                    { 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "Watchlists",
                columns: new[] { "Id", "ApplicationUserId", "MovieId" },
                values: new object[,]
                {
                    { 34, "f617a491-c12c-4352-a1d6-dc4484876f18", 4 },
                    { 19, "f617a491-c12c-4352-a1d6-dc4484876f18", 19 },
                    { 28, "f617a491-c12c-4352-a1d6-dc4484876f18", 28 },
                    { 16, "f617a491-c12c-4352-a1d6-dc4484876f18", 16 },
                    { 37, "f617a491-c12c-4352-a1d6-dc4484876f18", 7 },
                    { 7, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 7 },
                    { 6, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 6 },
                    { 36, "f617a491-c12c-4352-a1d6-dc4484876f18", 6 },
                    { 29, "f617a491-c12c-4352-a1d6-dc4484876f18", 29 },
                    { 17, "f617a491-c12c-4352-a1d6-dc4484876f18", 17 },
                    { 2, "8d8c5811-068d-4422-9ca3-0b73db5db489", 2 },
                    { 35, "f617a491-c12c-4352-a1d6-dc4484876f18", 5 },
                    { 5, "8d8c5811-068d-4422-9ca3-0b73db5db489", 5 },
                    { 30, "f617a491-c12c-4352-a1d6-dc4484876f18", 30 },
                    { 32, "f617a491-c12c-4352-a1d6-dc4484876f18", 2 },
                    { 8, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 8 },
                    { 31, "f617a491-c12c-4352-a1d6-dc4484876f18", 1 },
                    { 27, "f617a491-c12c-4352-a1d6-dc4484876f18", 27 },
                    { 3, "8d8c5811-068d-4422-9ca3-0b73db5db489", 3 },
                    { 33, "f617a491-c12c-4352-a1d6-dc4484876f18", 3 },
                    { 12, "f617a491-c12c-4352-a1d6-dc4484876f18", 12 },
                    { 23, "f617a491-c12c-4352-a1d6-dc4484876f18", 23 },
                    { 1, "8998b136-ce57-4ce1-a245-264750d6d5a9", 1 },
                    { 13, "f617a491-c12c-4352-a1d6-dc4484876f18", 13 },
                    { 40, "f617a491-c12c-4352-a1d6-dc4484876f18", 11 },
                    { 11, "f617a491-c12c-4352-a1d6-dc4484876f18", 11 },
                    { 24, "f617a491-c12c-4352-a1d6-dc4484876f18", 24 },
                    { 41, "f617a491-c12c-4352-a1d6-dc4484876f18", 21 },
                    { 21, "f617a491-c12c-4352-a1d6-dc4484876f18", 21 },
                    { 10, "f617a491-c12c-4352-a1d6-dc4484876f18", 10 },
                    { 14, "f617a491-c12c-4352-a1d6-dc4484876f18", 14 },
                    { 25, "f617a491-c12c-4352-a1d6-dc4484876f18", 25 },
                    { 20, "f617a491-c12c-4352-a1d6-dc4484876f18", 20 },
                    { 39, "f617a491-c12c-4352-a1d6-dc4484876f18", 9 },
                    { 9, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 9 },
                    { 26, "f617a491-c12c-4352-a1d6-dc4484876f18", 26 },
                    { 15, "f617a491-c12c-4352-a1d6-dc4484876f18", 15 },
                    { 22, "f617a491-c12c-4352-a1d6-dc4484876f18", 22 },
                    { 4, "8d8c5811-068d-4422-9ca3-0b73db5db489", 4 },
                    { 38, "f617a491-c12c-4352-a1d6-dc4484876f18", 8 },
                    { 18, "f617a491-c12c-4352-a1d6-dc4484876f18", 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ApplicationUserId",
                table: "Favorites",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_MovieId",
                table: "Favorites",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_ApplicationUserId",
                table: "Watchlists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlists_MovieId",
                table: "Watchlists",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Watchlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
