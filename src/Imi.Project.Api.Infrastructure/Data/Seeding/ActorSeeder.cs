using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class ActorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var actors = new List<Actor>
            {
                new Actor
                {
                    Id = 1,
                    Name = "Christian Bale",
                    Biography = "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer Jenny (James) and David Bale. His mother was a circus performer and his father, who was born in South Africa, was a commercial pilot. The family lived in different countries throughout Bale's childhood, including England, Portugal, and the United States. Bale acknowledges the constant change was one of the influences on his career choice.",
                    Image = "/Images/ActorImg/Christian_Bale.jpg",
                    DateOfBirth=DateTime.Parse("30/01/1974")
                },
                new Actor
                {
                    Id = 2,
                    Name = "Tom Hardy",
                    Biography = $"Edward Thomas Hardy was born on September 15, 1977 in Hammersmith, London; his mother, Elizabeth Anne (Barrett), is an artist and painter, and his father, Chips Hardy, is a writer. He is of English and Irish descent. Hardy was brought up in East Sheen, London, and first studied at Reed's School. His education continued at Tower House School, then at Richmond Drama School, and subsequently at the Drama Centre London, along with fellow Oscar nominee Michael Fassbender. After winning a modeling competition at age 21, he had a brief contract with the agency Models One.{Environment.NewLine}{Environment.NewLine}Tom spent his teens and early twenties battling delinquency, alcoholism and drug addiction; after completing his work on Star Trek: Nemesis(2002), he sought treatment and has also admitted that his battles with addiction ended his five - year marriage to Sarah Ward. Returning to work in 2003, Hardy was awarded the Evening Standard Most Promising Newcomer Award for his theatre performances in the productions of In Arabia, We'd All Be Kings and Blood.In 2003, Tom also co - starred in the play The Modernists with Paul Popplewell, Jesse Spencer and Orlando Wells.",
                    Image = "/Images/ActorImg/Tom_Hardy.jpg",
                    DateOfBirth=DateTime.Parse("15/09/1977")
                },
                new Actor
                {
                    Id = 3,
                    Name = "Leonardo DiCaprio",
                    Biography = "Leonardo Wilhelm DiCaprio was born November 11, 1974 in Los Angeles, California, the only child of Irmelin DiCaprio (née Indenbirken) and former comic book artist George DiCaprio. His father is of Italian and German descent, and his mother, who is German-born, is of German and Russian ancestry. His middle name, Wilhelm, was his maternal grandfather's first name. Leonardo's father had achieved minor status as an artist and distributor of cult comic book titles, and was even depicted in several issues of American Splendor, the cult semi-autobiographical comic book series by the late 'Harvey Pekar', a friend of George's. Leonardo's performance skills became obvious to his parents early on, and after signing him up with a talent agent who wanted Leonardo to perform under the stage name Lenny Williams, DiCaprio began appearing on a number of television commercials and educational programs.\n\nFew actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies, such as Critters 3 (1991), to a major teenage heartthrob in the 1990s, as the hunky lead actor in movies such as Romeo + Juliet (1996) and Titanic (1997), to then become a leading man in Hollywood blockbusters, made by internationally renowned directors such as Martin Scorsese and Christopher Nolan.",
                    Image = "/Images/ActorImg/Leonardo_DiCaprio.jpg",
                    DateOfBirth = DateTime.Parse("11/11/1974")
                },
                new Actor
                {
                    Id=4,
                    Name = "Hugh Jackman",
                    Biography = "Hugh Michael Jackman is an Australian actor, singer, multi-instrumentalist, dancer and producer. Jackman has won international recognition for his roles in major films, notably as superhero, period, and romance characters. He is best known for his long-running role as Wolverine in the X-Men film series, as well as for his lead roles in the romantic-comedy fantasy Kate & Leopold (2001), the action-horror film Van Helsing (2004), the drama The Prestige and The Fountain (2006), the epic historical romantic drama Australia (2008), the film version of Les Misérables (2012), and the thriller Prisoners (2013). His work in Les Misérables earned him his first Academy Award nomination for Best Actor and his first Golden Globe Award for Best Actor - Motion Picture Musical or Comedy in 2013. In Broadway theatre, Jackman won a Tony Award for his role in The Boy from Oz. A four-time host of the Tony Awards themselves, he won an Emmy Award for one of these appearances. Jackman also hosted the 81st Academy Awards on 22 February 2009.",
                    Image = "/Images/ActorImg/Hugh_Jackman.jpg",
                    DateOfBirth = DateTime.Parse("12/10/1968")
                },
                new Actor
                {
                    Id=5,
                    Name = "Scarlett Johansson",
                    Biography = "Scarlett Ingrid Johansson was born on November 22, 1984 in Manhattan, New York City, New York. Her mother, Melanie Sloan is from a Jewish family from the Bronx and her father, Karsten Johansson is a Danish-born architect from Copenhagen. She has a sister, Vanessa Johansson, who is also an actress, a brother, Adrian, a twin brother, Hunter Johansson, born three minutes after her, and a paternal half-brother, Christian. Her grandfather was writer Ejner Johansson.\n\nJohansson began acting during childhood, after her mother started taking her to auditions. She made her professional acting debut at the age of eight in the off-Broadway production of Sophistry with Ethan Hawke, at New York's Playwrights Horizons. She would audition for commercials but took rejection so hard her mother began limiting her to film tryouts. She made her film debut at the age of nine, as John Ritter's character's daughter in the fantasy comedy North (1994). Following minor roles in Just Cause (1995), as the daughter of Sean Connery and Kate Capshaw's character, and If Lucy Fell (1996), she played the role of Amanda in Manny & Lo (1996). Her performance in Manny & Lo garnered a nomination for the Independent Spirit Award for Best Lead Female, and positive reviews.",
                    Image = "/Images/ActorImg/Scarlett_Johansson.jpg",
                    DateOfBirth = DateTime.Parse("22/11/1984")
                },
                new Actor
                {
                    Id=6,
                    Name = "Brad Pitt",
                    Biography = "An actor and producer known as much for his versatility as he is for his handsome face, Golden Globe-winner Brad Pitt's most widely recognized role may be Tyler Durden in Fight Club (1999). However, his portrayals of Billy Beane in Moneyball (2011), and Rusty Ryan in the remake of Ocean's Eleven (2001) and its sequels, also loom large in his filmography.\n\nPitt was born William Bradley Pitt on December 18th, 1963, in Shawnee, Oklahoma, and was raised in Springfield, Missouri. He is the son of Jane Etta (Hillhouse), a school counselor, and William Alvin Pitt, a truck company manager. He has a younger brother, Douglas (Doug) Pitt, and a younger sister, Julie Neal Pitt. At Kickapoo High School, Pitt was involved in sports, debating, student government and school musicals. Pitt attended the University of Missouri, where he majored in journalism with a focus on advertising. He occasionally acted in fraternity shows. He left college two credits short of graduating to move to California. Before he became successful at acting, Pitt supported himself by driving strippers in limos, moving refrigerators and dressing as a giant chicken while working for el Pollo Loco.",
                    Image = "/Images/ActorImg/Brad_Pitt.jpg",
                    DateOfBirth = DateTime.Parse("18/12/1963")
                },
                new Actor
                {
                    Id=7,
                    Name = "Michael Fassbender",
                    Biography = "Michael Fassbender is an Irish actor who was born in Heidelberg, Germany, to a German father, Josef, and an Irish mother, Adele (originally from Larne, County Antrim, in Northern Ireland). Michael was raised in the town of Killarney, Co. Kerry, in south-west Ireland, where his family moved to when he was two years old. His parents ran a restaurant (his father is a chef).Fassbender is based in London, England, and became known in the U.S. after his role in the Quentin Tarantino's Inglourious Basterds (2009). In 2011, Fassbender debuted as the Marvel antihero Magneto in the prequel X-Men: First Class (2011); he would go on to share the role with Ian McKellen in X-Men: Days of Future Past (2014). Also in 2011, Fassbender's performance as a sex addict in Shame (2011) received critical acclaim. He won the Volpi Cup for Best Actor at the Venice Film Festival and was nominated for Golden Globe and BAFTA Awards.In 2013, his role as slave owner Edwin Epps in slavery epic 12 Years a Slave(2013) was similarly praised, earning him his first Oscar nomination, for Best Supporting Actor.",
                    Image = "/Images/ActorImg/Michael_Fassbender.jpg",
                    DateOfBirth = DateTime.Parse("02/04/1977")
                },
                new Actor
                {
                    Id=8,
                    Name = "Samuel L. Jackson",
                    Biography = "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard: With a Vengeance (1995), Unbreakable (2000), Shaft (2000), The 51st State (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe.Samuel Leroy Jackson was born in Washington, D.C., to Elizabeth (Montgomery) and Roy Henry Jackson. He was raised by his mother, a factory worker, and his grandparents. At Morehouse College, Jackson was active in the black student movement. In the seventies, he joined the Negro Ensemble Company (together with Morgan Freeman). In the eighties, he became well-known after three movies made by Spike Lee: Do the Right Thing(1989), Mo' Better Blues (1990) and Jungle Fever (1991). He achieved prominence and critical acclaim in the early 1990s with films such as Patriot Games (1992), Amos & Andrew (1993), True Romance (1993), Jurassic Park (1993), and his collaborations with director Quentin Tarantino, including Pulp Fiction (1994), Jackie Brown (1997), and later Django Unchained (2012). Going from supporting player to leading man, his performance in Pulp Fiction (1994) gave him an Oscar nomination for his character Jules Winnfield, and he received a Silver Berlin Bear for his part as Ordell Robbi in Jackie Brown (1997). Jackson usually played bad guys and drug addicts before becoming an action hero.",
                    Image = "/Images/ActorImg/Samuel_L._Jackson.jpg",
                    DateOfBirth = DateTime.Parse("21/12/1948")
                },
                new Actor
                {
                    Id=9,
                    Name = "James McAvoy",
                    Biography = "McAvoy was born on 21 April 1979 in Glasgow, Scotland, to James, a bus driver, and Elizabeth (née Johnstone), a nurse. He was raised on a housing estate in Drumchapel, Glasgow by his maternal grandparents (James, a butcher, and Mary), after his parents divorced when James was 11. He went to St Thomas Aquinas Secondary in Jordanhill, Glasgow, where he did well enough and started 'a little school band with a couple of mates'.",
                    Image = "/Images/ActorImg/James_McAvoy.jpg",
                    DateOfBirth = DateTime.Parse("21/04/1979")
                },
                new Actor
                {
                    Id=10,
                    Name = "Jennifer Lawrence",
                    Biography = "As the highest-paid actress in the world in 2015 and 2016, and with her films grossing over $5.5 billion worldwide, Jennifer Lawrence is often cited as the most successful actress of her generation. She is also thus far the only person born in the 1990s to have won an acting Oscar. Jennifer Shrader Lawrence was born August 15, 1990, in Louisville, Kentucky, to Karen (Koch), who manages a children's camp, and Gary Lawrence, who works in construction. She has two older brothers, Ben and Blaine, and has English, German, Irish, and Scottish ancestry.",
                    Image = "/Images/ActorImg/Jennifer_Lawrence.jpg",
                    DateOfBirth = DateTime.Parse("15/08/1990")
                },
                new Actor
                {
                    Id=11,
                    Name = "Robert Downey Jr.",
                    Biography = "Robert Downey Jr. has evolved into one of the most respected actors in Hollywood. With an amazing list of credits to his name, he has managed to stay new and fresh even after over four decades in the business. Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry. Robert and his sister, Allyson Downey, were immersed in film and the performing arts from a very young age, leading Downey Jr. to study at the Stagedoor Manor Performing Arts Training Center in upstate New York, before moving to California with his father following his parents' 1978 divorce. In 1982, he dropped out of Santa Monica High School to pursue acting full time. Downey Sr., himself a drug addict, exposed his son to drugs at a very early age, and Downey Jr. would go on to struggle with abuse for decades.",
                    Image = "/Images/ActorImg/Robert_Downey_Jr.jpg",
                    DateOfBirth = DateTime.Parse("04/04/1965")
                },
                new Actor
                {
                    Id=12,
                    Name = "Chris Evans",
                    Biography = "Christopher Robert Evans began his acting career in typical fashion: performing in school productions and community theatre. He was born in Boston, Massachusetts, the son of Lisa (Capuano), who worked at the Concord Youth Theatre, and G. Robert Evans III, a dentist. His uncle is former U.S. Representative Mike Capuano. Chris's father is of half German and half Welsh/English/Scottish ancestry, while Chris's mother is of half Italian and half Irish descent. He has an older sister, Carly Evans, and two younger siblings, a brother named Scott Evans, who is also an actor, and a sister named Shana Evans. The family moved to suburban Sudbury when he was 11 years-old. Bitten by the acting bug in the first grade because his older sister, Carly, started performing, Evans followed suit and began appearing in school plays. While at Lincoln-Sudbury Regional High School, his drama teacher cited his performance as Leontes in The Winter's Tale as exemplary of his skill. After more plays and regional theatre, he moved to New York and attended the Lee Strasberg Theatre Institute.",
                    Image = "/Images/ActorImg/Chris_Evans.jpg",
                    DateOfBirth = DateTime.Parse("13/06/1981")
                },
                new Actor
                {
                    Id=13,
                    Name = "Chris Hemsworth",
                    Biography = "Christopher Hemsworth was born on August 11, 1983 in Melbourne, Victoria, Australia to Leonie Hemsworth (née van Os), an English teacher & Craig Hemsworth, a social-services counselor. His brothers are actors, Liam Hemsworth & Luke Hemsworth; he is of Dutch (from his immigrant maternal grandfather), Irish, English, Scottish, and German ancestry. His uncle, by marriage, was Rod Ansell, the bushman who inspired the comedy film Crocodile Dundee (1986).",
                    Image = "/Images/ActorImg/Chris_Hemsworth.jpg",
                    DateOfBirth = DateTime.Parse("11/08/1983")
                },
                new Actor
                {
                    Id=14,
                    Name = "Mark Ruffalo",
                    Biography = "Award-winning actor Mark Ruffalo was born on November 22, 1967, in Kenosha, Wisconsin, of humble means to father Frank Lawrence Ruffalo, a construction painter and Marie Rose (Hebert), a stylist and hairdresser; his father's ancestry is Italian and his mother is of half French-Canadian and half Italian descent. Mark moved with his family to Virginia Beach, Virginia, where he lived out most of his teenage years. Following high school, Mark moved with his family to San Diego and soon migrated north, eventually settling in Los Angeles.",
                    Image = "/Images/ActorImg/Mark_Ruffalo.jpg",
                    DateOfBirth = DateTime.Parse("22/11/1967")
                },
                new Actor
                {
                    Id=15,
                    Name = "Tom Hiddleston",
                    Biography = "Thomas William Hiddleston was born in Westminster, London, to English-born Diana Patricia (Servaes) and Scottish-born James Norman Hiddleston. His mother is a former stage manager, and his father, a scientist, was the managing director of a pharmaceutical company. He started off at the preparatory school, The Dragon School in Oxford, and by the time he was 13, he boarded at Eton College, at the same time that his parents were going through a divorce. He continued on to the University of Cambridge, where he earned a double first in Classics. He continued to study acting at the Royal Academy of Dramatic Art, from which he graduated in 2005.",
                    Image = "/Images/ActorImg/Tom_Hiddleston.jpg",
                    DateOfBirth = DateTime.Parse("9/02/1981")
                },
                new Actor
                {
                    Id=16,
                    Name = "Morgan Freeman",
                    Biography = "With an authoritative voice and calm demeanor, this ever popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber. The young Freeman attended Los Angeles City College before serving several years in the US Air Force as a mechanic between 1955 and 1959. His first dramatic arts exposure was on the stage including appearing in an all-African American production of the exuberant musical Hello, Dolly!.",
                    Image = "/Images/ActorImg/Morgan_Freeman.jpg",
                    DateOfBirth = DateTime.Parse("04/06/1937")
                },
                new Actor
                {
                    Id=17,
                    Name = "Margot Robbie",
                    Biography = "Margot Elise Robbie was born on July 2, 1990 in Dalby, Queensland, Australia to Scottish parents. Her mother, Sarie Kessler, is a physiotherapist, and her father, is Doug Robbie. She comes from a family of four children, having two brothers and one sister. She graduated from Somerset College in Mudgeeraba, Queensland, Australia, a suburb in the Gold Coast hinterland of South East Queensland, where she and her siblings were raised by their mother and spent much of her time at the farm belonging to her grandparents. In her late teens, she moved to Melbourne, Victoria, Australia to pursue an acting career.",
                    Image = "/Images/ActorImg/Margot_Robbie.jpg",
                    DateOfBirth = DateTime.Parse("02/07/1990")
                },                
                new Actor
                {
                    Id=18,
                    Name = "Shia LaBeouf",
                    Biography = "Shia Saide LaBeouf was born in Los Angeles, California, to Shayna (Saide) and Jeffrey Craig LaBeouf, and is an only child. His mother is from an Ashkenazi Jewish family, while his father has Cajun (French) ancestry. His parents are divorced. He started his career by doing stand-up comedy around places in his neighborhood, such as coffee clubs. One day, he saw a friend of his acting on Dr. Quinn, Medicine Woman (1993), and wanted to become an actor. Shia and his mother talked it over, and the next day, he started looking for an agent. He searched in the yellow pages, called one up, and did a stand-up routine in front of him. They liked him and signed him, and then he started auditioning. He is well known for playing Louis Stevens on the popular Disney Channel series Even Stevens (2000) and has won a Daytime Emmy Award for his performance. His best known role is as Sam Witwicky, the main protagonist of the first three installments of the Transformers series: Transformers (2007), Transformers: Revenge of the Fallen (2009) and Transformers: Dark of the Moon (2011).",
                    Image = "/Images/ActorImg/Shia_LaBeouf.jpg",
                    DateOfBirth = DateTime.Parse("11/06/1986")
                },         
                new Actor
                {
                    Id=19,
                    Name = "Megan Fox",
                    Biography = "Megan Denise Fox was born on May 16, 1986 in Oak Ridge, Tennessee and raised in Rockwood, Tennessee to Gloria Darlene Tonachio (née Cisson), a real estate manager and Franklin Thomas Fox, a parole officer. She began her drama and dance training at age 5 and at age 10, she moved to Port St. Lucie, Florida where she continued her training and finished school. Megan began acting and modeling at age 13 after winning several awards at the 1999 American Modeling and Talent Convention in Hilton Head, South Carolina. At age 17, she tested out of school using correspondence and eventually moved to Los Angeles, California. Megan made her film debut as Brianna Wallace in the Mary-Kate Olsen and Ashley Olsen film, Holiday in the Sun (2001). Her best known roles are as Sam Witwicky's love interest, Mikaela Banes in Transformers (2007) and Transformers: Revenge of the Fallen (2009), and as April O'Neil in the film reboot Teenage Mutant Ninja Turtles (2014) and its sequel Teenage Mutant Ninja Turtles: Out of the Shadows (2016).",
                    Image = "/Images/ActorImg/Megan_Fox.jpg",
                    DateOfBirth = DateTime.Parse("16/05/1986")
                },         
                new Actor
                {
                    Id=20,
                    Name = "Johnny Depp",
                    Biography = "Johnny Depp is perhaps one of the most versatile actors of his day and age in Hollywood. He was born John Christopher Depp II in Owensboro, Kentucky, on June 9, 1963, to Betty Sue (Wells), who worked as a waitress, and John Christopher Depp, a civil engineer. Depp was raised in Florida. He dropped out of school when he was 15, and fronted a series of music-garage bands, including one named 'The Kids'. When he married Lori Anne Allison (Lori A. Depp) he took a job as a ballpoint-pen salesman to support himself and his wife. A visit to Los Angeles, California, with his wife, however, happened to be a blessing in disguise, when he met up with actor Nicolas Cage, who advised him to turn to acting, which culminated in Depp's film debut in the low-budget horror film, A Nightmare on Elm Street (1984), where he played a teenager who falls prey to dream-stalking demon Freddy Krueger.",
                    Image = "/Images/ActorImg/Johnny_Depp.jpg",
                    DateOfBirth = DateTime.Parse("09/06/1963")
                },                
                new Actor
                {
                    Id=21,
                    Name = "Orlando Bloom",
                    Biography = "Orlando Jonathan Blanchard Copeland Bloom was born on January 13, 1977 in Canterbury, Kent, England. His mother, Sonia Constance Josephine Bloom (née Copeland), was born in Kolkata, India, to an English family then-resident there. The man he first knew as his father, Harry Bloom, was a legendary political activist who fought for civil rights in South Africa. But Harry died of a stroke when Orlando was only four years old. After that, Orlando and his older sister, Samantha Bloom, were raised by their mother and family friend, Colin Stone. When Orlando was 13, Sonia revealed to him that Colin is actually the biological father of Orlando and his sister; the two were conceived after an agreement by his parents, since Harry, who suffered a stroke in 1975, was unable to have children.",
                    Image = "/Images/ActorImg/Orlando_Bloom.jpg",
                    DateOfBirth = DateTime.Parse("13/01/1977")
                },                
                new Actor
                {
                    Id=22,
                    Name = "Keira Knightley",
                    Biography = "Keira Christina Knightley was born March 26, 1985 in the South West Greater London suburb of Richmond. She is the daughter of actor Will Knightley and actress turned playwright Sharman Macdonald. An older brother, Caleb Knightley, was born in 1979. Her father is English, while her Scottish-born mother is of Scottish and Welsh origin. Brought up immersed in the acting profession from both sides - writing and performing - it is little wonder that the young Keira asked for her own agent at the age of three. She was granted one at the age of six and performed in her first TV role as Little Girl in Screen One: Royal Celebration (1993), aged seven.",
                    Image = "/Images/ActorImg/Keira_Knightley.jpg",
                    DateOfBirth = DateTime.Parse("26/03/1985")
                },                
                //new Actor
                //{
                //    Id=0,
                //    Name = "",
                //    Biography = "",
                //    Image = "/Images/ActorImg/",
                //    DateOfBirth = DateTime.Parse("")
                //},

            };

            //for (int i = 0; i < actors.Count; i++)
            //{
            //    actors[i].Id = i + 1;
            //}
            modelBuilder.Entity<Actor>().HasData(actors);
        }

    }
}
