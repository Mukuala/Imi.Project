﻿using System;
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
                    Id = table.Column<long>(nullable: false)
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
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
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
                    Id = table.Column<long>(nullable: false)
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
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(nullable: false),
                    ActorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => x.Id);
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
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(nullable: false),
                    GenreId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.Id);
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
                name: "Watchlist",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watchlist_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Watchlist_Movies_MovieId",
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
                    { 1L, "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer Jenny (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal, and the United States. Bale acknowledges the constant change was one of the influences on his career choice.", new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Christian_Bale.jpg", "Christian Bale" },
                    { 22L, "Keira Christina Knightley was born March 26, 1985 in the South West Greater London suburb of Richmond. She is the daughter of actor Will Knightley and actress turned playwright Sharman Macdonald. An older brother, Caleb Knightley, was born in 1979. Her father is English, while her Scottish-born mother is of Scottish and Welsh origin. Brought up immersed in the acting profession from both sides - writing and performing - it is little wonder that the young Keira asked for her own agent at the age of three. She was granted one at the age of six and performed in her first TV role as Little Girl in Screen One: Royal Celebration (1993), aged seven.", new DateTime(1985, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Keira_Knightley.jpg", "Keira Knightley" },
                    { 20L, "Johnny Depp is perhaps one of the most versatile actors of his day and age in Hollywood. He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer. Depp was raised in Florida. He dropped out of school when he was 15, and fronted a series of music-garage bands, including one named 'The Kids'. When he married Lori Anne Allison (Lori A. Depp) he took a job as a ballpoint-pen salesman to support himself and his wife. A visit to Los Angeles, California, with his wife, however, happened to be a blessing in disguise, when he met up with actor Nicolas Cage, who advised him to turn to acting, which culminated in Depp's film debut in the low-budget horror film, A Nightmare on Elm Street (1984), where he played a teenager who falls prey to dream-stalking demon Freddy Krueger.", new DateTime(1963, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Johnny_Depp.jpg", "Johnny Depp" },
                    { 19L, "Megan Denise Fox was born on May 16, 1986 in Oak Ridge, Tennessee and raised in Rockwood, Tennessee to Gloria Darlene Tonachio (née Cisson), a real estate manager and Franklin Thomas Fox, a parole officer. She began her drama and dance training at age 5 and at age 10, she moved to Port St. Lucie, Florida where she continued her training and finished school. Megan began acting and modeling at age 13 after winning several awards at the 1999 American Modeling and Talent Convention in Hilton Head, South Carolina. At age 17, she tested out of school using correspondence and eventually moved to Los Angeles, California. Megan made her film debut as Brianna Wallace in the Mary-Kate Olsen and Ashley Olsen film, Holiday in the Sun (2001). Her best known roles are as Sam Witwicky's love interest, Mikaela Banes in Transformers (2007) and Transformers: Revenge of the Fallen (2009), and as April O'Neil in the film reboot Teenage Mutant Ninja Turtles (2014) and its sequel Teenage Mutant Ninja Turtles: Out of the Shadows (2016).", new DateTime(1986, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Megan_Fox.jpg", "Megan Fox" },
                    { 18L, "Shia Saide LaBeouf was born in Los Angeles, California, to Shayna (Saide) and Jeffrey Craig LaBeouf, and is an only child. His mother is from an Ashkenazi Jewish family, while his father has Cajun (French) ancestry. His parents are divorced. He started his career by doing stand-up comedy around places in his neighborhood, such as coffee clubs. One day, he saw a friend of his acting on Dr. Quinn, Medicine Woman (1993), and wanted to become an actor. Shia and his mother talked it over, and the next day, he started looking for an agent. He searched in the yellow pages, called one up, and did a stand-up routine in front of him. They liked him and signed him, and then he started auditioning. He is well known for playing Louis Stevens on the popular Disney Channel series Even Stevens (2000) and has won a Daytime Emmy Award for his performance. His best known role is as Sam Witwicky, the main protagonist of the first three installments of the Transformers series: Transformers (2007), Transformers: Revenge of the Fallen (2009) and Transformers: Dark of the Moon (2011).", new DateTime(1986, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Shia_LaBeouf.jpg", "Shia LaBeouf" },
                    { 17L, "Margot Elise Robbie was born on July 2, 1990 in Dalby, Queensland, Australia to Scottish parents. Her mother, Sarie Kessler, is a physiotherapist, and her father, is Doug Robbie. She comes from a family of four children, having two brothers and one sister. She graduated from Somerset College in Mudgeeraba, Queensland, Australia, a suburb in the Gold Coast hinterland of South East Queensland, where she and her siblings were raised by their mother and spent much of her time at the farm belonging to her grandparents. In her late teens, she moved to Melbourne, Victoria, Australia to pursue an acting career.", new DateTime(1990, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Margot_Robbie.jpg", "Margot Robbie" },
                    { 16L, "With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959. His first dramatic arts exposure was on the stage including appearing in an all-African American production of the exuberant musical Hello, Dolly!.", new DateTime(1937, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Morgan_Freeman.jpg", "Morgan Freeman" },
                    { 15L, "Thomas William Hiddleston was born in Westminster, London, to English-born Diana Patricia (Servaes) and Scottish-born James Norman Hiddleston. His mother is a former stage manager, and his father, a scientist, was the managing director of a pharmaceutical company. He started off at the preparatory school, The Dragon School in Oxford, and by the time he was 13, he boarded at Eton College, at the same time that his parents were going through a divorce. He continued on to the University of Cambridge, where he earned a double first in Classics. He continued to study acting at the Royal Academy of Dramatic Art, from which he graduated in 2005.", new DateTime(1981, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Tom_Hiddleston.jpg", "Tom Hiddleston" },
                    { 14L, "Award-winning actor Mark Ruffalo was born on November 22, 1967, in Kenosha, Wisconsin, of humble means to father Frank Lawrence Ruffalo, a construction painter and Marie Rose (Hebert), a stylist and hairdresser; his father's ancestry is Italian and his mother is of half French-Canadian and half Italian descent. Mark moved with his family to Virginia Beach, Virginia, where he lived out most of his teenage years. Following high school, Mark moved with his family to San Diego and soon migrated north, eventually settling in Los Angeles.", new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Mark_Ruffalo.jpg", "Mark Ruffalo" },
                    { 13L, "Christopher Hemsworth was born on August 11, 1983 in Melbourne, Victoria, Australia to Leonie Hemsworth (née van Os), an English teacher & Craig Hemsworth, a social-services counselor. His brothers are actors, Liam Hemsworth & Luke Hemsworth; he is of Dutch (from his immigrant maternal grandfather), Irish, English, Scottish, and German ancestry. His uncle, by marriage, was Rod Ansell, the bushman who inspired the comedy film Crocodile Dundee (1986).", new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Chris_Hemsworth.jpg", "Chris Hemsworth" },
                    { 12L, "Christopher Robert Evans began his acting career in typical fashion: performing in school productions and community theatre. He was born in Boston, Massachusetts, the son of Lisa (Capuano), who worked at the Concord Youth Theatre, and G. Robert Evans III, a dentist. His uncle is former U.S. Representative Mike Capuano. Chris's father is of half German and half Welsh/English/Scottish ancestry, while Chris's mother is of half Italian and half Irish descent. He has an older sister, Carly Evans, and two younger siblings, a brother named Scott Evans, who is also an actor, and a sister named Shana Evans. The family moved to suburban Sudbury when he was 11 years-old. Bitten by the acting bug in the first grade because his older sister, Carly, started performing, Evans followed suit and began appearing in school plays. While at Lincoln-Sudbury Regional High School, his drama teacher cited his performance as Leontes in The Winter's Tale as exemplary of his skill. After more plays and regional theatre, he moved to New York and attended the Lee Strasberg Theatre Institute.", new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Chris_Evans.jpg", "Chris Evans" },
                    { 21L, "Orlando Jonathan Blanchard Copeland Bloom was born on January 13, 1977 in Canterbury, Kent, England. His mother, Sonia Constance Josephine Bloom (née Copeland), was born in Kolkata, India, to an English family then-resident there. The man he first knew as his father, Harry Bloom, was a legendary political activist who fought for civil rights in South Africa. But Harry died of a stroke when Orlando was only four years old. After that, Orlando and his older sister, Samantha Bloom, were raised by their mother and family friend, Colin Stone. When Orlando was 13, Sonia revealed to him that Colin is actually the biological father of Orlando and his sister; the two were conceived after an agreement by his parents, since Harry, who suffered a stroke in 1975, was unable to have children.", new DateTime(1977, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Orlando_Bloom.jpg", "Orlando Bloom" },
                    { 10L, "As the highest-paid actress in the world in 2015 and 2016, and with her films grossing over $5.5 billion worldwide, Jennifer Lawrence is often cited as the most successful actress of her generation. She is also thus far the only person born in the 1990s to have won an acting Oscar. Jennifer Shrader Lawrence was born August 15, 1990, in Louisville, Kentucky, to Karen (Koch), who manages a children's camp, and Gary Lawrence, who works in construction. She has two older brothers, Ben and Blaine, and has English, German, Irish, and Scottish ancestry.", new DateTime(1990, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Jennifer_Lawrence.jpg", "Jennifer Lawrence" },
                    { 9L, "McAvoy was born on 21 April 1979 in Glasgow, Scotland, to James, a bus driver, and Elizabeth (née Johnstone), a nurse. He was raised on a housing estate in Drumchapel, Glasgow by his maternal grandparents (James, a butcher, and Mary), after his parents divorced when James was 11. He went to St Thomas Aquinas Secondary in Jordanhill, Glasgow, where he did well enough and started 'a little school band with a couple of mates'.", new DateTime(1979, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/James_McAvoy.jpg", "James McAvoy" },
                    { 8L, "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard: With a Vengeance (1995), Unbreakable (2000), Shaft (2000), The 51st State (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe.Samuel Leroy Jackson was born in Washington, D.C., to Elizabeth (Montgomery) and Roy Henry Jackson. He was raised by his mother, a factory worker, and his grandparents. At Morehouse College, Jackson was active in the black student movement. In the seventies, he joined the Negro Ensemble Company (together with Morgan Freeman). In the eighties, he became well-known after three movies made by Spike Lee: Do the Right Thing(1989), Mo' Better Blues (1990) and Jungle Fever (1991). He achieved prominence and critical acclaim in the early 1990s with films such as Patriot Games (1992), Amos & Andrew (1993), True Romance (1993), Jurassic Park (1993), and his collaborations with director Quentin Tarantino, including Pulp Fiction (1994), Jackie Brown (1997), and later Django Unchained (2012). Going from supporting player to leading man, his performance in Pulp Fiction (1994) gave him an Oscar nomination for his character Jules Winnfield, and he received a Silver Berlin Bear for his part as Ordell Robbi in Jackie Brown (1997). Jackson usually played bad guys and drug addicts before becoming an action hero.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Samuel_L._Jackson.jpg", "Samuel L. Jackson" },
                    { 7L, "Michael Fassbender is an Irish actor who was born in Heidelberg, Germany, to a German father, Josef, and an Irish mother, Adele (originally from Larne, County Antrim, in Northern Ireland). Michael was raised in the town of Killarney, Co. Kerry, in south-west Ireland, where his family moved to when he was two years old. His parents ran a restaurant (his father is a chef).Fassbender is based in London, England, and became known in the U.S. after his role in the Quentin Tarantino's Inglourious Basterds (2009). In 2011, Fassbender debuted as the Marvel antihero Magneto in the prequel X-Men: First Class (2011); he would go on to share the role with Ian McKellen in X-Men: Days of Future Past (2014). Also in 2011, Fassbender's performance as a sex addict in Shame (2011) received critical acclaim. He won the Volpi Cup for Best Actor at the Venice Film Festival and was nominated for Golden Globe and BAFTA Awards.In 2013, his role as slave owner Edwin Epps in slavery epic 12 Years a Slave(2013) was similarly praised, earning him his first Oscar nomination, for Best Supporting Actor.", new DateTime(1977, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Michael_Fassbender.jpg", "Michael Fassbender" },
                    { 6L, @"An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winner Brad Pitt's most widely recognized role may be Tyler Durden in Fight Club (1999). However, his portrayals of Billy Beane in Moneyball (2011), and Rusty Ryan in the remake of Ocean's Eleven (2001) and its sequels, also loom large in his filmography.

                Pitt was born William Bradley Pitt on December 18th, 1963, in Shawnee, Oklahoma, and was raised in Springfield, Missouri. He is the son of Jane Etta (Hillhouse), a school counselor, and William Alvin Pitt, a truck company manager. He has a younger brother, Douglas (Doug) Pitt, and a younger sister, Julie Neal Pitt. At Kickapoo High School, Pitt was involved in sports, debating, student government and school musicals. Pitt attended the University of Missouri, where he majored in journalism with a focus on advertising. He occasionally acted in fraternity shows. He left college two credits short of graduating to move to California. Before he became successful at acting, Pitt supported himself by driving strippers in limos, moving refrigerators and dressing as a giant chicken while working for el Pollo Loco.", new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Brad_Pitt.jpg", "Brad Pitt" },
                    { 5L, @"Scarlett Ingrid Johansson was born on November 22, 1984 in Manhattan, New York City, New York. Her mother, Melanie Sloan is from a Jewish family from the Bronx and her father, Karsten Johansson is a Danish-born architect from Copenhagen. She has a sister, Vanessa Johansson, who is also an actress, a brother, Adrian, a twin brother, Hunter Johansson, born three minutes after her, and a paternal half-brother, Christian. Her grandfather was writer Ejner Johansson.

                Johansson began acting during childhood, after her mother started taking her to auditions. She made her professional acting debut at the age of eight in the off-Broadway production of Sophistry with Ethan Hawke, at New York's Playwrights Horizons. She would audition for commercials but took rejection so hard her mother began limiting her to film tryouts. She made her film debut at the age of nine, as John Ritter's character's daughter in the fantasy comedy North (1994). Following minor roles in Just Cause (1995), as the daughter of Sean Connery and Kate Capshaw's character, and If Lucy Fell (1996), she played the role of Amanda in Manny & Lo (1996). Her performance in Manny & Lo garnered a nomination for the Independent Spirit Award for Best Lead Female, and positive reviews.", new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Scarlett_Johansson.jpg", "Scarlett Johansson" },
                    { 4L, "Hugh Michael Jackman is an Australian actor, singer, multi-instrumentalist, dancer and producer. Jackman has won international recognition for his roles in major films, notably as superhero, period, and romance characters. He is best known for his long-running role as Wolverine in the X-Men film series, as well as for his lead roles in the romantic-comedy fantasy Kate & Leopold (2001), the action-horror film Van Helsing (2004), the drama The Prestige and The Fountain (2006), the epic historical romantic drama Australia (2008), the film version of Les Misérables (2012), and the thriller Prisoners (2013). His work in Les Misérables earned him his first Academy Award nomination for Best Actor and his first Golden Globe Award for Best Actor - Motion Picture Musical or Comedy in 2013. In Broadway theatre, Jackman won a Tony Award for his role in The Boy from Oz. A four-time host of the Tony Awards themselves, he won an Emmy Award for one of these appearances. Jackman also hosted the 81st Academy Awards on 22 February 2009.", new DateTime(1968, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Hugh_Jackman.jpg", "Hugh Jackman" },
                    { 3L, @"Leonardo Wilhelm DiCaprio was born November 11, 1974 in Los Angeles, California, the only child of Irmelin DiCaprio (née Indenbirken) and former comic book artist George DiCaprio. His father is of Italian and German descent, and his mother, who is German-born, is of German and Russian ancestry. His middle name, Wilhelm, was his maternal grandfather's first name. Leonardo's father had achieved minor status as an artist and distributor of cult comic book titles, and was even depicted in several issues of American Splendor, the cult semi-autobiographical comic book series by the late 'Harvey Pekar', a friend of George's. Leonardo's performance skills became obvious to his parents early on, and after signing him up with a talent agent who wanted Leonardo to perform under the stage name Lenny Williams, DiCaprio began appearing on a number of television commercials and educational programs.

                Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s, as the hunky lead actor in movies such as Romeo + Juliet (1996) and Titanic (1997), to then become a leading man in Hollywood blockbusters, made by internationally renowned directors such as Martin Scorsese and Christopher Nolan.", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Leonardo_DiCaprio.jpg", "Leonardo DiCaprio" },
                    { 2L, @"Edward Thomas Hardy was born on September 15, 1977 in Hammersmith, London; his mother, Elizabeth Anne (Barrett), is an artist and painter, and his father, Chips Hardy, is a writer. He is of English and Irish descent. Hardy was brought up in East Sheen, London, and first studied at Reed's School. His education continued at Tower House School, then at Richmond Drama School, and subsequently at the Drama Centre London, along with fellow Oscar nominee Michael Fassbender. After winning a modeling competition at age 21, he had a brief contract with the agency Models One.

                Tom spent his teens and early twenties battling delinquency, alcoholism and drug addiction; after completing his work on Star Trek: Nemesis(2002), he sought treatment and has also admitted that his battles with addiction ended his five - year marriage to Sarah Ward. Returning to work in 2003, Hardy was awarded the Evening Standard Most Promising Newcomer Award for his theatre performances in the productions of In Arabia, We'd All Be Kings and Blood.In 2003, Tom also co - starred in the play The Modernists with Paul Popplewell, Jesse Spencer and Orlando Wells.", new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Tom_Hardy.jpg", "Tom Hardy" },
                    { 11L, "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business. Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry. Robert and his sister, Allyson Downey, were immersed in film and the performing arts from a very young age, leading Downey Jr. to study at the Stagedoor Manor Performing Arts Training Center in upstate New York, before moving to California with his father following his parents' 1978 divorce. In 1982, he dropped out of Santa Monica High School to pursue acting full time. Downey Sr., himself a drug addict, exposed his son to drugs at a very early age, and Downey Jr. would go on to struggle with abuse for decades.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/Images/ActorImg/Robert_Downey_Jr.jpg", "Robert Downey Jr." }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "UserName" },
                values: new object[,]
                {
                    { "9b890576-aa15-4462-b71d-6242a310b95a", "corteaur@marriott.com", "Cornelle", "https://robohash.org/reprehenderitquaeratomnis.png?size=200x200&set=set1", "Orteau", "corteaur" },
                    { "1cde7869-3a95-492f-b208-06091017990b", "abrawnq@people.com.cn", "Allegra", "https://robohash.org/maximerationeet.png?size=200x200&set=set1", "Brawn", "abrawnq" },
                    { "b1122532-ab1e-4dea-b349-6ad129e86932", "rbraunterm@amazon.co.jp", "Rice", "https://robohash.org/quasicorporislaudantium.png?size=200x200&set=set1", "Braunter", "rbraunterm" },
                    { "919402ab-ceb9-4475-a7c3-ca0419c373a2", "nvasechkino@vistaprint.com", "Nilson", "https://robohash.org/rationecumquequis.png?size=200x200&set=set1", "Vasechkin", "nvasechkino" },
                    { "8d6c24d1-5e29-49a5-957a-852a72f2dc27", "henochn@ow.ly", "Hamnet", "https://robohash.org/sedautnatus.png?size=200x200&set=set1", "Enoch", "henochn" },
                    { "5243cce1-d4a5-4e5b-a019-0810474caa2d", "bnichollss@harvard.edu", "Bell", "https://robohash.org/quasincidunttemporibus.png?size=200x200&set=set1", "Nicholls", "bnichollss" },
                    { "db62733c-5c91-4fee-ba45-f69c0559edce", "btubbp@purevolume.com", "Boothe", "https://robohash.org/fugitanimidolorem.png?size=200x200&set=set1", "Tubb", "btubbp" },
                    { "b6da71c1-a50d-44c3-abea-54def1d6a293", "jpittett@fotki.com", "Jasun", "https://robohash.org/delectusdoloribusoccaecati.png?size=200x200&set=set1", "Pittet", "jpittett" },
                    { "c12d37b9-6bf6-40f4-a690-ee4b86a8c18a", "pgreenhillz@wisc.edu", "Pieter", "https://robohash.org/estenimsoluta.png?size=200x200&set=set1", "Greenhill", "pgreenhillz" },
                    { "0169ee2e-ac62-420a-81b1-5e2107c5229c", "dfallenw@cbc.ca", "Del", "https://robohash.org/excepturieumvitae.png?size=200x200&set=set1", "Fallen", "dfallenw" },
                    { "fe2dcf3f-c8f9-413f-b728-b8268e4ff250", "dfieldsendx@live.com", "Danya", "https://robohash.org/adipiscicorruptiquo.png?size=200x200&set=set1", "Fieldsend", "dfieldsendx" },
                    { "bb7bcba3-c15b-4948-9ed7-e2b03b6a56e3", "hmatyuginy@google.ca", "Hilliard", "https://robohash.org/doloreumearum.png?size=200x200&set=set1", "Matyugin", "hmatyuginy" },
                    { "69465360-555b-4a6e-a353-e92ffb1679a7", "rcrudgington10@sciencedirect.com", "Rosella", "https://robohash.org/etquoest.png?size=200x200&set=set1", "Crudgington", "rcrudgington10" },
                    { "06fc4b3c-070b-4cd4-bd21-37e2a799b973", "dchase11@mlb.com", "Dahlia", "https://robohash.org/minuspariaturvoluptatem.png?size=200x200&set=set1", "Chase", "dchase11" },
                    { "6cbfdcc5-f065-4b36-947e-6e383be9fa96", "sblakeston12@alibaba.com", "Siana", "https://robohash.org/autofficiavoluptatem.png?size=200x200&set=set1", "Blakeston", "sblakeston12" },
                    { "f8e204c0-5642-481f-995d-cab4cb457e1f", "sfriskey13@xrea.com", "Shae", "https://robohash.org/areprehenderitrepudiandae.png?size=200x200&set=set1", "Friskey", "sfriskey13" },
                    { "9110e2cd-ddd4-472c-98bf-6b667321426d", "showenl@spiegel.de", "Siward", "https://robohash.org/eosconsequaturautem.png?size=200x200&set=set1", "Howen", "showenl" },
                    { "efa3ba3d-7e04-40c4-b869-bcedc77371b0", "dpitwayv@acquirethisname.com", "Derk", "https://robohash.org/etquasiveniam.png?size=200x200&set=set1", "Pitway", "dpitwayv" },
                    { "486eb8b1-0fd0-4010-9ddd-2d102e279d18", "jmcdonoghk@blogger.com", "Jannelle", "https://robohash.org/utperspiciatisut.png?size=200x200&set=set1", "McDonogh", "jmcdonoghk" },
                    { "373e0ebe-edf7-456f-87ab-9083a98cec16", "cstainesu@uol.com.br", "Cecilla", "https://robohash.org/occaecatiestvoluptates.png?size=200x200&set=set1", "Staines", "cstainesu" },
                    { "191768fe-daf3-4854-9ac7-0c9066d564f6", "tandreiai@360.cn", "Travers", "https://robohash.org/similiquevelitaque.png?size=200x200&set=set1", "Andreia", "tandreiai" },
                    { "a35f9512-7b70-4dc4-91ad-ff3bab79c9c5", "glarcombej@nytimes.com", "Garvin", "https://robohash.org/quiillumvoluptate.png?size=200x200&set=set1", "Larcombe", "glarcombej" },
                    { "8998b136-ce57-4ce1-a245-264750d6d5a9", "gpapen0@t-online.de", "Gwyneth", "https://robohash.org/atnulladolor.png?size=200x200&set=set1", "Papen", "gpapen0" },
                    { "8d8c5811-068d-4422-9ca3-0b73db5db489", "dtorbet1@weather.com", "Dalis", "https://robohash.org/perferendisatveniam.png?size=200x200&set=set1", "Torbet", "dtorbet1" },
                    { "d07a98ed-d98b-48b1-8fe6-5947359f936d", "dmcelwee2@surveymonkey.com", "Dougy", "https://robohash.org/nonquiaipsa.png?size=200x200&set=set1", "McElwee", "dmcelwee2" },
                    { "f617a491-c12c-4352-a1d6-dc4484876f18", "vsydney3@spiegel.de", "Vally", "https://robohash.org/consequaturinciduntquaerat.png?size=200x200&set=set1", "Sydney", "vsydney3" },
                    { "3a98651d-c672-4b2f-ba1a-2d91609630d1", "bstryde4@yahoo.co.jp", "Bastien", "https://robohash.org/laudantiumestdeserunt.png?size=200x200&set=set1", "Stryde", "bstryde4" },
                    { "5c69ae15-a4ad-4e0e-9466-46372339e4b0", "vkillingback5@bing.com", "Violetta", "https://robohash.org/expeditaveritatisconsectetur.png?size=200x200&set=set1", "Killingback", "vkillingback5" },
                    { "7bf6c2cd-0f1e-42da-b8a3-4f6c2d86b6f2", "lserrier6@xinhuanet.com", "Loria", "https://robohash.org/quibusdamdoloremqueet.png?size=200x200&set=set1", "Serrier", "lserrier6" },
                    { "f17e9da9-50f4-4148-b4f9-d3d634f04341", "aoneill8@comcast.net", "Alyse", "https://robohash.org/quisquamoccaecatiautem.png?size=200x200&set=set1", "Oneill", "aoneill8" },
                    { "bd24214f-91d0-4ed4-8dcf-f8d75ff64cab", "rreihm7@1688.com", "Richard", "https://robohash.org/enimquoet.png?size=200x200&set=set1", "Reihm", "rreihm7" },
                    { "32f6f64a-22f9-42a5-a218-26f7203436cd", "cmatveiko9@youtube.com", "Cash", "https://robohash.org/autemconsecteturlaudantium.png?size=200x200&set=set1", "Matveiko", "cmatveiko9" },
                    { "ad9d1515-d2ac-416f-9415-6dae316339b4", "sbemrosea@prweb.com", "Shane", "https://robohash.org/remrepellatcupiditate.png?size=200x200&set=set1", "Bemrose", "sbemrosea" },
                    { "6d5a0ee9-b73a-4ad6-b06d-168b65f112ce", "acrannyb@rambler.ru", "Ardenia", "https://robohash.org/consecteturfugitest.png?size=200x200&set=set1", "Cranny", "acrannyb" },
                    { "8cbd8b6f-0dd5-4f67-ad0d-16c5ae77b5fe", "nbollinsc@flavors.me", "Newton", "https://robohash.org/consequunturestcupiditate.png?size=200x200&set=set1", "Bollins", "nbollinsc" },
                    { "d3b54d21-adfd-4ae7-8e4e-58e7e67e6286", "amacd@skype.com", "Agatha", "https://robohash.org/voluptatemtemporeveritatis.png?size=200x200&set=set1", "Mac", "amacd" },
                    { "9b46aa5a-fec8-4e87-9b91-4ceabd656d4c", "fderre@posterous.com", "Fawn", "https://robohash.org/quiaquoet.png?size=200x200&set=set1", "Derr", "fderre" },
                    { "ee8c7b7b-67b3-49cf-b382-7dacc6fa8285", "bbodleighf@blogger.com", "Brittaney", "https://robohash.org/accusantiumexplicabofugit.png?size=200x200&set=set1", "Bodleigh", "bbodleighf" },
                    { "11b823e7-441e-4649-bbd4-8a81c70551e0", "esawdayg@nature.com", "Eartha", "https://robohash.org/quisquamquosquo.png?size=200x200&set=set1", "Sawday", "esawdayg" },
                    { "f673974f-004e-4b7b-998e-d998f233df09", "avedekhinh@soundcloud.com", "Alysia", "https://robohash.org/consequaturnonaperiam.png?size=200x200&set=set1", "Vedekhin", "avedekhinh" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9L, "War" },
                    { 13L, "Romance" },
                    { 11L, "Thriller" },
                    { 10L, "Comedy" },
                    { 14L, "History" },
                    { 8L, "Fantasy" },
                    { 12L, "Biography" },
                    { 6L, "Sci-Fi" },
                    { 5L, "Mystery" },
                    { 4L, "Drama" },
                    { 3L, "Crime" },
                    { 2L, "Adventure" },
                    { 1L, "Action" },
                    { 7L, "Western" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AverageRating", "Description", "Duration", "EmbeddedTrailerUrl", "Image", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 17L, 8.8000000000000007, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", 148, "https://www.youtube.com/embed/YoHD9XEInc0", "/Images/MovieImg/Inception.jpg", "Inception", new DateTime(2010, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, 8.1999999999999993, "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", 180, "https://www.youtube.com/embed/iszwuX1AK6A", "/Images/MovieImg/The_Wolf_of_Wall_Street.jpg", "The Wolf of Wall Street", new DateTime(2013, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, 7.5999999999999996, "A faded television actor and his stunt double strive to achieve fame and success in the final years of Hollywood's Golden Age in 1969 Los Angeles.", 161, "https://www.youtube.com/embed/ELeMaP8EPAA", "/Images/MovieImg/Once_Upon_a_Time_in_Hollywood.jpg", "Once Upon a Time... in Hollywood", new DateTime(2019, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, 8.0, "A frontiersman on a fur trading expedition in the 1820s fights for survival after being mauled by a bear and left for dead by members of his own hunting team.", 156, "https://www.youtube.com/embed/LoebZZ8K5N0", "/Images/MovieImg/The_Revenant.jpg", "The Revenant", new DateTime(2015, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, 7.2000000000000002, "A writer and wall street trader, Nick, finds himself drawn to the past and lifestyle of his millionaire neighbor, Jay Gatsby.", 143, "https://www.youtube.com/embed/sN183rJltNM", "/Images/MovieImg/The_Great_Gatsby.jpg", "The Great Gatsby", new DateTime(2013, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, 7.5999999999999996, "A grizzled tank commander makes tough decisions as he and his crew fight their way across Germany in April, 1945.", 134, "https://www.youtube.com/embed/DNHuK1rteF4", "/Images/MovieImg/Fury.jpg", "Fury", new DateTime(2014, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, 7.2999999999999998, "An adaptation of Homer's great epic, the film follows the assault on Troy by the united Greek forces and chronicles the fates of the men involved.", 163, "https://www.youtube.com/embed/znTLzRJimeY", "/Images/MovieImg/Troy.jpg", "Troy", new DateTime(2004, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, 6.5, "The Four Horsemen resurface, and are forcibly recruited by a tech genius to pull off their most impossible heist yet.", 129, "https://www.youtube.com/embed/4I8rVcSQbic", "/Images/MovieImg/Now_You_See_Me_2.jpg", "Now You See Me 2", new DateTime(2016, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, 7.0, "An ancient struggle between two Cybertronian races, the heroic Autobots and the evil Decepticons, comes to Earth, with a clue to the ultimate power held by a teenager.", 144, "https://www.youtube.com/embed/dxQxgAfNzyE", "/Images/MovieImg/Transformers.jpg", "Transformers", new DateTime(2007, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, 6.0, "Sam Witwicky leaves the Autobots behind for a normal life. But when his mind is filled with cryptic symbols, the Decepticons target him and he is dragged back into the Transformers' war.", 149, "https://www.youtube.com/embed/fnXzKwUgDhg", "/Images/MovieImg/Transformers_Revenge_of_the_Fallen.jpg", "Transformers: Revenge of the Fallen", new DateTime(2009, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, 6.2000000000000002, "The Autobots learn of a Cybertronian spacecraft hidden on the moon, and race against the Decepticons to reach it and to learn its secrets.", 154, "https://www.youtube.com/embed/bTIrEZM-cFE", "/Images/MovieImg/Transformers_Dark_of_the_Moon.jpg", "Transformers: Dark of the Moon", new DateTime(2011, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, 8.0, "Blacksmith Will Turner teams up with eccentric pirate Captain Jack Sparrow to save his love, the governor's daughter, from Jack's former pirate allies, who are now undead.", 143, "https://www.youtube.com/embed/-9HT0l9HV4", "/Images/MovieImg/Pirates_of_the_Caribbean_The_Curse_of_the_Black_Pearl.jpg", "Pirates of the Caribbean: The Curse of the Black Pearl", new DateTime(2003, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, 8.1999999999999993, "In 1954, a U.S. Marshal investigates the disappearance of a murderer who escaped from a hospital for the criminally insane.", 138, "https://www.youtube.com/embed/5iaYLCiq5RM", "/Images/MovieImg/Shutter_Island.jpg", "Shutter Island", new DateTime(2010, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, 7.2000000000000002, "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money.", 115, "https://www.youtube.com/embed/KzJNYYkkhzc", "/Images/MovieImg/Now_You_See_Me.jpg", "Now You See Me", new DateTime(2013, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, 8.4000000000000004, "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", 149, "https://www.youtube.com/embed/6ZfuNTqbHE8", "/Images/MovieImg/Avengers_Infinity_War.jpg", "Avengers: Infinity War", new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, 8.4000000000000004, "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", 181, "https://www.youtube.com/embed/TcMBFSGVi1c", "/Images/MovieImg/Avengers_Endgame.jpg", "Avengers: Endgame", new DateTime(2019, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 7.2999999999999998, "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", 141, "https://www.youtube.com/embed/tmeOjFno6Do", "/Images/MovieImg/Avengers_Age_of_Ultron.jpg", "Avengers: Age of Ultron", new DateTime(2015, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 8.0, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", 143, "https://www.youtube.com/embed/eOrNdBpGMv8", "/Images/MovieImg/The_Avengers.jpg", "The Avengers", new DateTime(2012, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 5.7000000000000002, "Jean Grey begins to develop incredible powers that corrupt and turn her into a Dark Phoenix, causing the X-Men to decide if her life is worth more than all of humanity.", 113, "https://www.youtube.com/embed/1-q8C_c-nlM", "/Images/MovieImg/X-Men_Dark_Phoenix.jpg", "X-Men: Dark Phoenix", new DateTime(2019, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 6.9000000000000004, "In the 1980s the X-Men must defeat an ancient all-powerful mutant, En Sabah Nur, who intends to thrive through bringing destruction to the world.", 144, "https://www.youtube.com/embed/COvnHv42T-A", "/Images/MovieImg/X-Men_Apocalypse.jpg", "X-Men: Apocalypse", new DateTime(2016, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7.7000000000000002, "In the 1960s, superpowered humans Charles Xavier and Erik Lensherr work together to find others like them, but Erik's vengeful pursuit of an ambitious mutant who ruined his life causes a schism to divide them.", 131, "https://www.youtube.com/embed/zp4rIZnQobE", "/Images/MovieImg/X-Men_First_Class.jpg", "X-Men: First Class", new DateTime(2011, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 8.3000000000000007, "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.", 153, "https://www.youtube.com/embed/KnrRy6kSFF0", "/Images/MovieImg/Inglourious_Basterds.jpg", "Inglourious Basterds", new DateTime(2009, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 8.4000000000000004, "With the help of a German bounty-hunter, a freed slave sets out to rescue his wife from a brutal plantation-owner in Mississippi.", 165, "https://www.youtube.com/embed/0fUCuvNlOCg", "/Images/MovieImg/Django_Unchained.jpg", "Django Unchained", new DateTime(2012, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 8.5, "After a tragic accident, two stage magicians in 1890s London engage in a battle to create the ultimate illusion while sacrificing everything they have to outwit each other.", 130, "https://www.youtube.com/embed/ObGVA1WOqyE", "/Images/MovieImg/The_Prestige.jpg", "The Prestige", new DateTime(2006, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 8.4000000000000004, "Despite his tarnished reputation after the events of The Dark Knight (2008), in which he took the rap for Dent's crimes, Batman feels compelled to intervene to assist the city and its Police force, which is struggling to cope with Bane's plans to destroy the city.", 164, "https://www.youtube.com/embed/g8evyE9TuYk", "/Images/MovieImg/The_Dark_Knight_Rises.jpg", "The Dark Knight Rises", new DateTime(2012, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 9.0, "Set within a year after the events of Batman Begins (2005), Batman, Lieutenant James Gordon, and new District Attorney Harvey Dent successfully begin to round up the criminals that plague Gotham City, until a mysterious and sadistic criminal mastermind known only as The Joker appears in Gotham, creating a new wave of chaos. Batman's struggle against The Joker becomes deeply personal, forcing him to confront everything he believes and improve his technology to stop him. A love triangle develops between Bruce Wayne, Dent, and Rachel Dawes", 152, "https://www.youtube.com/embed/TQfATDZY5Y4", "/Images/MovieImg/The_Dark_Knight.jpg", "The Dark Knight", new DateTime(2008, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, 8.1999999999999993, "When his parents are killed, billionaire playboy Bruce Wayne relocates to Asia, where he is mentored by Henri Ducard and Ra's Al Ghul in how to fight evil. When learning about the plan to wipe out evil in Gotham City by Ducard, Bruce prevents this plan from getting any further and heads back to his home. Back in his original surroundings, Bruce adopts the image of a bat to strike fear into the criminals and the corrupt as the icon known as 'Batman'. But it doesn't stay quiet for long.", 140, "https://www.youtube.com/embed/qHhHIbNuok8", "/Images/MovieImg/Batman_Begins.jpg", "Batman Begins", new DateTime(2005, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, 7.2999999999999998, "Jack Sparrow races to recover the heart of Davy Jones to avoid enslaving his soul to Jones' service, as other friends and foes seek the heart for their own agenda as well.", 151, "https://www.youtube.com/embed/ozk0-RHXtFw", "/Images/MovieImg/Pirates_of_the_Caribbean_Dead_Man's_Chest.jpg", "Pirates of the Caribbean: Dead Man's Chest", new DateTime(2006, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, 7.7999999999999998, "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.", 147, "https://www.youtube.com/embed/dKrVegVI0Us", "/Images/MovieImg/Captain_America_Civil_War.jpg", "Captain America: Civil War", new DateTime(2016, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, 7.0999999999999996, "Captain Barbossa, Will Turner and Elizabeth Swann must sail off the edge of the map, navigate treachery and betrayal, find Jack Sparrow, and make their final alliances for one last decisive battle.", 169, "https://www.youtube.com/embed/0op_XllRaAw", "/Images/MovieImg/Pirates_of_the_Caribbean_At_World's_End.jpg", "Pirates of the Caribbean: At World's End", new DateTime(2007, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "Id", "ApplicationUserId", "MovieId" },
                values: new object[,]
                {
                    { 1L, "8998b136-ce57-4ce1-a245-264750d6d5a9", 1L },
                    { 27L, "f617a491-c12c-4352-a1d6-dc4484876f18", 7L },
                    { 15L, "f617a491-c12c-4352-a1d6-dc4484876f18", 26L },
                    { 9L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 8L },
                    { 23L, "f617a491-c12c-4352-a1d6-dc4484876f18", 25L },
                    { 12L, "f617a491-c12c-4352-a1d6-dc4484876f18", 9L },
                    { 38L, "f617a491-c12c-4352-a1d6-dc4484876f18", 9L },
                    { 37L, "f617a491-c12c-4352-a1d6-dc4484876f18", 24L },
                    { 42L, "f617a491-c12c-4352-a1d6-dc4484876f18", 10L },
                    { 34L, "f617a491-c12c-4352-a1d6-dc4484876f18", 23L },
                    { 7L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 11L },
                    { 14L, "f617a491-c12c-4352-a1d6-dc4484876f18", 11L },
                    { 30L, "f617a491-c12c-4352-a1d6-dc4484876f18", 11L },
                    { 26L, "f617a491-c12c-4352-a1d6-dc4484876f18", 22L },
                    { 5L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 12L },
                    { 11L, "f617a491-c12c-4352-a1d6-dc4484876f18", 12L },
                    { 25L, "f617a491-c12c-4352-a1d6-dc4484876f18", 12L },
                    { 6L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 22L },
                    { 33L, "f617a491-c12c-4352-a1d6-dc4484876f18", 13L },
                    { 36L, "f617a491-c12c-4352-a1d6-dc4484876f18", 14L },
                    { 41L, "f617a491-c12c-4352-a1d6-dc4484876f18", 20L },
                    { 4L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 15L },
                    { 22L, "f617a491-c12c-4352-a1d6-dc4484876f18", 15L },
                    { 39L, "f617a491-c12c-4352-a1d6-dc4484876f18", 19L },
                    { 16L, "f617a491-c12c-4352-a1d6-dc4484876f18", 16L },
                    { 13L, "f617a491-c12c-4352-a1d6-dc4484876f18", 19L },
                    { 10L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 19L },
                    { 17L, "f617a491-c12c-4352-a1d6-dc4484876f18", 17L },
                    { 28L, "f617a491-c12c-4352-a1d6-dc4484876f18", 17L },
                    { 31L, "f617a491-c12c-4352-a1d6-dc4484876f18", 17L },
                    { 21L, "f617a491-c12c-4352-a1d6-dc4484876f18", 5L },
                    { 20L, "f617a491-c12c-4352-a1d6-dc4484876f18", 5L },
                    { 18L, "f617a491-c12c-4352-a1d6-dc4484876f18", 18L },
                    { 2L, "8998b136-ce57-4ce1-a245-264750d6d5a9", 3L },
                    { 40L, "f617a491-c12c-4352-a1d6-dc4484876f18", 29L },
                    { 32L, "f617a491-c12c-4352-a1d6-dc4484876f18", 3L },
                    { 3L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 2L },
                    { 19L, "f617a491-c12c-4352-a1d6-dc4484876f18", 4L },
                    { 24L, "f617a491-c12c-4352-a1d6-dc4484876f18", 2L },
                    { 29L, "f617a491-c12c-4352-a1d6-dc4484876f18", 1L },
                    { 35L, "f617a491-c12c-4352-a1d6-dc4484876f18", 4L },
                    { 8L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 30L }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "Id", "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 40L, 14L, 12L },
                    { 39L, 13L, 12L },
                    { 37L, 11L, 12L },
                    { 36L, 8L, 12L },
                    { 41L, 15L, 12L },
                    { 65L, 3L, 21L },
                    { 35L, 5L, 12L },
                    { 38L, 12L, 12L },
                    { 79L, 22L, 28L },
                    { 3L, 1L, 3L },
                    { 66L, 3L, 22L },
                    { 67L, 14L, 22L },
                    { 34L, 15L, 11L },
                    { 78L, 21L, 28L },
                    { 32L, 13L, 11L },
                    { 31L, 12L, 11L },
                    { 30L, 11L, 11L },
                    { 29L, 8L, 11L },
                    { 42L, 5L, 13L },
                    { 43L, 8L, 13L },
                    { 46L, 13L, 13L },
                    { 45L, 12L, 13L },
                    { 59L, 17L, 18L },
                    { 57L, 3L, 17L },
                    { 56L, 2L, 17L },
                    { 1L, 1L, 1L },
                    { 85L, 22L, 30L },
                    { 55L, 16L, 16L },
                    { 54L, 14L, 16L },
                    { 84L, 21L, 30L },
                    { 60L, 3L, 19L },
                    { 61L, 6L, 19L },
                    { 62L, 17L, 19L },
                    { 53L, 16L, 15L },
                    { 52L, 14L, 15L },
                    { 2L, 1L, 2L },
                    { 83L, 20L, 30L },
                    { 63L, 3L, 20L },
                    { 51L, 5L, 14L },
                    { 50L, 12L, 14L },
                    { 49L, 11L, 14L },
                    { 64L, 2L, 20L },
                    { 48L, 15L, 13L },
                    { 47L, 14L, 13L },
                    { 28L, 5L, 11L },
                    { 44L, 11L, 13L },
                    { 4L, 2L, 3L },
                    { 33L, 14L, 11L },
                    { 81L, 21L, 29L },
                    { 72L, 18L, 25L },
                    { 73L, 19L, 25L },
                    { 17L, 10L, 8L },
                    { 16L, 9L, 8L },
                    { 15L, 7L, 8L },
                    { 82L, 22L, 29L },
                    { 7L, 5L, 4L },
                    { 74L, 18L, 26L },
                    { 6L, 4L, 4L },
                    { 14L, 10L, 7L },
                    { 12L, 7L, 7L },
                    { 75L, 19L, 26L },
                    { 76L, 18L, 27L },
                    { 11L, 7L, 6L },
                    { 10L, 6L, 6L },
                    { 77L, 20L, 28L },
                    { 9L, 8L, 5L },
                    { 8L, 3L, 5L },
                    { 13L, 9L, 7L },
                    { 5L, 1L, 4L },
                    { 24L, 12L, 10L },
                    { 19L, 9L, 9L },
                    { 18L, 7L, 9L },
                    { 58L, 3L, 18L },
                    { 23L, 11L, 10L },
                    { 26L, 14L, 10L },
                    { 27L, 15L, 10L },
                    { 22L, 8L, 10L },
                    { 70L, 6L, 24L },
                    { 71L, 18L, 24L },
                    { 21L, 5L, 10L },
                    { 20L, 10L, 9L },
                    { 80L, 20L, 29L },
                    { 68L, 6L, 23L },
                    { 69L, 21L, 23L },
                    { 25L, 13L, 10L }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 73L, 2L, 27L },
                    { 74L, 6L, 27L },
                    { 72L, 1L, 27L },
                    { 82L, 2L, 30L },
                    { 69L, 1L, 26L },
                    { 51L, 12L, 18L },
                    { 50L, 10L, 18L },
                    { 49L, 3L, 18L },
                    { 71L, 6L, 26L },
                    { 75L, 1L, 28L },
                    { 70L, 2L, 26L },
                    { 81L, 1L, 30L },
                    { 61L, 4L, 23L },
                    { 52L, 4L, 19L },
                    { 60L, 11L, 22L },
                    { 79L, 2L, 29L },
                    { 58L, 13L, 21L },
                    { 57L, 4L, 21L },
                    { 64L, 4L, 24L },
                    { 80L, 8L, 29L },
                    { 65L, 9L, 24L },
                    { 63L, 1L, 24L },
                    { 78L, 1L, 29L },
                    { 62L, 14L, 23L },
                    { 55L, 2L, 20L },
                    { 54L, 1L, 20L },
                    { 66L, 1L, 25L },
                    { 67L, 2L, 25L },
                    { 68L, 6L, 25L },
                    { 77L, 8L, 28L },
                    { 53L, 10L, 19L },
                    { 59L, 5L, 22L },
                    { 76L, 2L, 28L },
                    { 56L, 4L, 20L },
                    { 34L, 1L, 13L },
                    { 48L, 6L, 17L },
                    { 7L, 3L, 3L },
                    { 14L, 4L, 6L },
                    { 29L, 2L, 11L },
                    { 28L, 1L, 11L },
                    { 27L, 6L, 10L },
                    { 26L, 2L, 10L },
                    { 25L, 1L, 10L },
                    { 8L, 4L, 4L },
                    { 9L, 5L, 4L },
                    { 24L, 6L, 9L },
                    { 6L, 1L, 3L },
                    { 23L, 2L, 9L },
                    { 10L, 6L, 4L },
                    { 21L, 6L, 8L },
                    { 20L, 2L, 8L },
                    { 19L, 1L, 8L },
                    { 11L, 4L, 5L },
                    { 18L, 6L, 7L },
                    { 12L, 7L, 5L },
                    { 17L, 2L, 7L },
                    { 16L, 1L, 7L },
                    { 15L, 9L, 6L },
                    { 22L, 1L, 9L },
                    { 31L, 1L, 12L },
                    { 30L, 6L, 11L },
                    { 40L, 3L, 15L },
                    { 47L, 2L, 17L },
                    { 46L, 1L, 17L },
                    { 1L, 1L, 1L },
                    { 45L, 10L, 16L },
                    { 2L, 2L, 1L },
                    { 44L, 2L, 16L },
                    { 43L, 1L, 16L },
                    { 42L, 11L, 15L },
                    { 41L, 5L, 15L },
                    { 39L, 6L, 14L },
                    { 3L, 1L, 2L },
                    { 38L, 2L, 14L },
                    { 13L, 2L, 6L },
                    { 37L, 1L, 14L },
                    { 32L, 2L, 12L },
                    { 33L, 6L, 12L },
                    { 5L, 4L, 2L },
                    { 83L, 8L, 30L },
                    { 35L, 2L, 13L },
                    { 36L, 4L, 13L },
                    { 4L, 3L, 2L }
                });

            migrationBuilder.InsertData(
                table: "Watchlist",
                columns: new[] { "Id", "ApplicationUserId", "MovieId" },
                values: new object[,]
                {
                    { 34L, "f617a491-c12c-4352-a1d6-dc4484876f18", 4L },
                    { 33L, "f617a491-c12c-4352-a1d6-dc4484876f18", 3L },
                    { 1L, "8998b136-ce57-4ce1-a245-264750d6d5a9", 1L },
                    { 3L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 3L },
                    { 28L, "f617a491-c12c-4352-a1d6-dc4484876f18", 28L },
                    { 27L, "f617a491-c12c-4352-a1d6-dc4484876f18", 27L },
                    { 29L, "f617a491-c12c-4352-a1d6-dc4484876f18", 29L },
                    { 2L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 2L },
                    { 31L, "f617a491-c12c-4352-a1d6-dc4484876f18", 1L },
                    { 5L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 5L },
                    { 35L, "f617a491-c12c-4352-a1d6-dc4484876f18", 5L },
                    { 4L, "8d8c5811-068d-4422-9ca3-0b73db5db489", 4L },
                    { 32L, "f617a491-c12c-4352-a1d6-dc4484876f18", 2L },
                    { 38L, "f617a491-c12c-4352-a1d6-dc4484876f18", 8L },
                    { 6L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 6L },
                    { 16L, "f617a491-c12c-4352-a1d6-dc4484876f18", 16L },
                    { 18L, "f617a491-c12c-4352-a1d6-dc4484876f18", 18L },
                    { 15L, "f617a491-c12c-4352-a1d6-dc4484876f18", 15L },
                    { 14L, "f617a491-c12c-4352-a1d6-dc4484876f18", 14L },
                    { 19L, "f617a491-c12c-4352-a1d6-dc4484876f18", 19L },
                    { 13L, "f617a491-c12c-4352-a1d6-dc4484876f18", 13L },
                    { 20L, "f617a491-c12c-4352-a1d6-dc4484876f18", 20L },
                    { 12L, "f617a491-c12c-4352-a1d6-dc4484876f18", 12L },
                    { 21L, "f617a491-c12c-4352-a1d6-dc4484876f18", 21L },
                    { 41L, "f617a491-c12c-4352-a1d6-dc4484876f18", 21L },
                    { 40L, "f617a491-c12c-4352-a1d6-dc4484876f18", 11L },
                    { 26L, "f617a491-c12c-4352-a1d6-dc4484876f18", 26L },
                    { 11L, "f617a491-c12c-4352-a1d6-dc4484876f18", 11L },
                    { 10L, "f617a491-c12c-4352-a1d6-dc4484876f18", 10L },
                    { 39L, "f617a491-c12c-4352-a1d6-dc4484876f18", 9L },
                    { 23L, "f617a491-c12c-4352-a1d6-dc4484876f18", 23L },
                    { 9L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 9L },
                    { 17L, "f617a491-c12c-4352-a1d6-dc4484876f18", 17L },
                    { 8L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 8L },
                    { 24L, "f617a491-c12c-4352-a1d6-dc4484876f18", 24L },
                    { 37L, "f617a491-c12c-4352-a1d6-dc4484876f18", 7L },
                    { 7L, "d07a98ed-d98b-48b1-8fe6-5947359f936d", 7L },
                    { 25L, "f617a491-c12c-4352-a1d6-dc4484876f18", 25L },
                    { 36L, "f617a491-c12c-4352-a1d6-dc4484876f18", 6L },
                    { 22L, "f617a491-c12c-4352-a1d6-dc4484876f18", 22L },
                    { 30L, "f617a491-c12c-4352-a1d6-dc4484876f18", 30L }
                });

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
                name: "IX_MovieActors_MovieId",
                table: "MovieActors",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlist_ApplicationUserId",
                table: "Watchlist",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Watchlist_MovieId",
                table: "Watchlist",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Watchlist");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}