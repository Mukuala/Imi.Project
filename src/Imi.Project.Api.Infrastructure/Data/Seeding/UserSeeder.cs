using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                    new ApplicationUser { Id = "8998b136-ce57-4ce1-a245-264750d6d5a9", FirstName = "Gwyneth", LastName = "Papen", Email = "gpapen0@t-online.de", UserName = "gpapen0", Image = "https://robohash.org/atnulladolor.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "8d8c5811-068d-4422-9ca3-0b73db5db489", FirstName = "Dalis", LastName = "Torbet", Email = "dtorbet1@weather.com", UserName = "dtorbet1", Image = "https://robohash.org/perferendisatveniam.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "d07a98ed-d98b-48b1-8fe6-5947359f936d", FirstName = "Dougy", LastName = "McElwee", Email = "dmcelwee2@surveymonkey.com", UserName = "dmcelwee2", Image = "https://robohash.org/nonquiaipsa.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "f617a491-c12c-4352-a1d6-dc4484876f18", FirstName = "Vally", LastName = "Sydney", Email = "vsydney3@spiegel.de", UserName = "vsydney3", Image = "https://robohash.org/consequaturinciduntquaerat.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "3a98651d-c672-4b2f-ba1a-2d91609630d1", FirstName = "Bastien", LastName = "Stryde", Email = "bstryde4@yahoo.co.jp", UserName = "bstryde4", Image = "https://robohash.org/laudantiumestdeserunt.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "5c69ae15-a4ad-4e0e-9466-46372339e4b0", FirstName = "Violetta", LastName = "Killingback", Email = "vkillingback5@bing.com", UserName = "vkillingback5", Image = "https://robohash.org/expeditaveritatisconsectetur.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "7bf6c2cd-0f1e-42da-b8a3-4f6c2d86b6f2", FirstName = "Loria", LastName = "Serrier", Email = "lserrier6@xinhuanet.com", UserName = "lserrier6", Image = "https://robohash.org/quibusdamdoloremqueet.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "bd24214f-91d0-4ed4-8dcf-f8d75ff64cab", FirstName = "Richard", LastName = "Reihm", Email = "rreihm7@1688.com", UserName = "rreihm7", Image = "https://robohash.org/enimquoet.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "f17e9da9-50f4-4148-b4f9-d3d634f04341", FirstName = "Alyse", LastName = "Oneill", Email = "aoneill8@comcast.net", UserName = "aoneill8", Image = "https://robohash.org/quisquamoccaecatiautem.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "32f6f64a-22f9-42a5-a218-26f7203436cd", FirstName = "Cash", LastName = "Matveiko", Email = "cmatveiko9@youtube.com", UserName = "cmatveiko9", Image = "https://robohash.org/autemconsecteturlaudantium.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "ad9d1515-d2ac-416f-9415-6dae316339b4", FirstName = "Shane", LastName = "Bemrose", Email = "sbemrosea@prweb.com", UserName = "sbemrosea", Image = "https://robohash.org/remrepellatcupiditate.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "6d5a0ee9-b73a-4ad6-b06d-168b65f112ce", FirstName = "Ardenia", LastName = "Cranny", Email = "acrannyb@rambler.ru", UserName = "acrannyb", Image = "https://robohash.org/consecteturfugitest.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "8cbd8b6f-0dd5-4f67-ad0d-16c5ae77b5fe", FirstName = "Newton", LastName = "Bollins", Email = "nbollinsc@flavors.me", UserName = "nbollinsc", Image = "https://robohash.org/consequunturestcupiditate.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "d3b54d21-adfd-4ae7-8e4e-58e7e67e6286", FirstName = "Agatha", LastName = "Mac", Email = "amacd@skype.com", UserName = "amacd", Image = "https://robohash.org/voluptatemtemporeveritatis.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "9b46aa5a-fec8-4e87-9b91-4ceabd656d4c", FirstName = "Fawn", LastName = "Derr", Email = "fderre@posterous.com", UserName = "fderre", Image = "https://robohash.org/quiaquoet.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "ee8c7b7b-67b3-49cf-b382-7dacc6fa8285", FirstName = "Brittaney", LastName = "Bodleigh", Email = "bbodleighf@blogger.com", UserName = "bbodleighf", Image = "https://robohash.org/accusantiumexplicabofugit.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "11b823e7-441e-4649-bbd4-8a81c70551e0", FirstName = "Eartha", LastName = "Sawday", Email = "esawdayg@nature.com", UserName = "esawdayg", Image = "https://robohash.org/quisquamquosquo.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "f673974f-004e-4b7b-998e-d998f233df09", FirstName = "Alysia", LastName = "Vedekhin", Email = "avedekhinh@soundcloud.com", UserName = "avedekhinh", Image = "https://robohash.org/consequaturnonaperiam.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "191768fe-daf3-4854-9ac7-0c9066d564f6", FirstName = "Travers", LastName = "Andreia", Email = "tandreiai@360.cn", UserName = "tandreiai", Image = "https://robohash.org/similiquevelitaque.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "a35f9512-7b70-4dc4-91ad-ff3bab79c9c5", FirstName = "Garvin", LastName = "Larcombe", Email = "glarcombej@nytimes.com", UserName = "glarcombej", Image = "https://robohash.org/quiillumvoluptate.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "486eb8b1-0fd0-4010-9ddd-2d102e279d18", FirstName = "Jannelle", LastName = "McDonogh", Email = "jmcdonoghk@blogger.com", UserName = "jmcdonoghk", Image = "https://robohash.org/utperspiciatisut.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "9110e2cd-ddd4-472c-98bf-6b667321426d", FirstName = "Siward", LastName = "Howen", Email = "showenl@spiegel.de", UserName = "showenl", Image = "https://robohash.org/eosconsequaturautem.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "b1122532-ab1e-4dea-b349-6ad129e86932", FirstName = "Rice", LastName = "Braunter", Email = "rbraunterm@amazon.co.jp", UserName = "rbraunterm", Image = "https://robohash.org/quasicorporislaudantium.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "8d6c24d1-5e29-49a5-957a-852a72f2dc27", FirstName = "Hamnet", LastName = "Enoch", Email = "henochn@ow.ly", UserName = "henochn", Image = "https://robohash.org/sedautnatus.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "919402ab-ceb9-4475-a7c3-ca0419c373a2", FirstName = "Nilson", LastName = "Vasechkin", Email = "nvasechkino@vistaprint.com", UserName = "nvasechkino", Image = "https://robohash.org/rationecumquequis.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "db62733c-5c91-4fee-ba45-f69c0559edce", FirstName = "Boothe", LastName = "Tubb", Email = "btubbp@purevolume.com", UserName = "btubbp", Image = "https://robohash.org/fugitanimidolorem.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "1cde7869-3a95-492f-b208-06091017990b", FirstName = "Allegra", LastName = "Brawn", Email = "abrawnq@people.com.cn", UserName = "abrawnq", Image = "https://robohash.org/maximerationeet.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "9b890576-aa15-4462-b71d-6242a310b95a", FirstName = "Cornelle", LastName = "Orteau", Email = "corteaur@marriott.com", UserName = "corteaur", Image = "https://robohash.org/reprehenderitquaeratomnis.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "5243cce1-d4a5-4e5b-a019-0810474caa2d", FirstName = "Bell", LastName = "Nicholls", Email = "bnichollss@harvard.edu", UserName = "bnichollss", Image = "https://robohash.org/quasincidunttemporibus.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "b6da71c1-a50d-44c3-abea-54def1d6a293", FirstName = "Jasun", LastName = "Pittet", Email = "jpittett@fotki.com", UserName = "jpittett", Image = "https://robohash.org/delectusdoloribusoccaecati.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "373e0ebe-edf7-456f-87ab-9083a98cec16", FirstName = "Cecilla", LastName = "Staines", Email = "cstainesu@uol.com.br", UserName = "cstainesu", Image = "https://robohash.org/occaecatiestvoluptates.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "efa3ba3d-7e04-40c4-b869-bcedc77371b0", FirstName = "Derk", LastName = "Pitway", Email = "dpitwayv@acquirethisname.com", UserName = "dpitwayv", Image = "https://robohash.org/etquasiveniam.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "0169ee2e-ac62-420a-81b1-5e2107c5229c", FirstName = "Del", LastName = "Fallen", Email = "dfallenw@cbc.ca", UserName = "dfallenw", Image = "https://robohash.org/excepturieumvitae.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "fe2dcf3f-c8f9-413f-b728-b8268e4ff250", FirstName = "Danya", LastName = "Fieldsend", Email = "dfieldsendx@live.com", UserName = "dfieldsendx", Image = "https://robohash.org/adipiscicorruptiquo.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "bb7bcba3-c15b-4948-9ed7-e2b03b6a56e3", FirstName = "Hilliard", LastName = "Matyugin", Email = "hmatyuginy@google.ca", UserName = "hmatyuginy", Image = "https://robohash.org/doloreumearum.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "c12d37b9-6bf6-40f4-a690-ee4b86a8c18a", FirstName = "Pieter", LastName = "Greenhill", Email = "pgreenhillz@wisc.edu", UserName = "pgreenhillz", Image = "https://robohash.org/estenimsoluta.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "69465360-555b-4a6e-a353-e92ffb1679a7", FirstName = "Rosella", LastName = "Crudgington", Email = "rcrudgington10@sciencedirect.com", UserName = "rcrudgington10", Image = "https://robohash.org/etquoest.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "06fc4b3c-070b-4cd4-bd21-37e2a799b973", FirstName = "Dahlia", LastName = "Chase", Email = "dchase11@mlb.com", UserName = "dchase11", Image = "https://robohash.org/minuspariaturvoluptatem.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "6cbfdcc5-f065-4b36-947e-6e383be9fa96", FirstName = "Siana", LastName = "Blakeston", Email = "sblakeston12@alibaba.com", UserName = "sblakeston12", Image = "https://robohash.org/autofficiavoluptatem.png?size=200x200&set=set1" },
                    new ApplicationUser { Id = "f8e204c0-5642-481f-995d-cab4cb457e1f", FirstName = "Shae", LastName = "Friskey", Email = "sfriskey13@xrea.com", UserName = "sfriskey13", Image = "https://robohash.org/areprehenderitrepudiandae.png?size=200x200&set=set1" }
            };

            //foreach (var user in users)
            //{
            //    user.PasswordHash = passwordHasher.HashPassword(user, "WKlYnFhm0ikG");
            //    user.NormalizedEmail = user.Email.ToUpper();
            //    user.NormalizedUserName = user.UserName.ToUpper();
            //    user.EmailConfirmed = true;
            //}

            modelBuilder.Entity<ApplicationUser>().HasData(users);
        }
    }
}
