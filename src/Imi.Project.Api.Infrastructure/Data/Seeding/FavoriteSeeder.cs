using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public class FavoriteSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var list = new List<Favorite>
            {

                new Favorite {  ApplicationUserId = "8998b136-ce57-4ce1-a245-264750d6d5a9", MovieId = 1 },
                new Favorite {  ApplicationUserId = "8998b136-ce57-4ce1-a245-264750d6d5a9", MovieId = 3 },

                new Favorite {  ApplicationUserId = "8d8c5811-068d-4422-9ca3-0b73db5db489", MovieId = 2 },
                new Favorite {  ApplicationUserId = "8d8c5811-068d-4422-9ca3-0b73db5db489", MovieId = 15},
                new Favorite {  ApplicationUserId = "8d8c5811-068d-4422-9ca3-0b73db5db489", MovieId = 12 },
                new Favorite {  ApplicationUserId = "8d8c5811-068d-4422-9ca3-0b73db5db489", MovieId = 22 },

                new Favorite {  ApplicationUserId = "d07a98ed-d98b-48b1-8fe6-5947359f936d", MovieId = 11 },
                new Favorite {  ApplicationUserId = "d07a98ed-d98b-48b1-8fe6-5947359f936d", MovieId = 30 },
                new Favorite {  ApplicationUserId = "d07a98ed-d98b-48b1-8fe6-5947359f936d", MovieId = 8 },
                new Favorite {  ApplicationUserId = "d07a98ed-d98b-48b1-8fe6-5947359f936d", MovieId = 19 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 12 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 9 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 19 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 11 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 26 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 16 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 17 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 18 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 4 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 5 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 5 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 15 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 25 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 2 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 12 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 22 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 7 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 17 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 1 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 11 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 17 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 3 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 13 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 23 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 4 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 14 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 24 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 9 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 19 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 29 },

                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 20 },
                new Favorite {  ApplicationUserId = "f617a491-c12c-4352-a1d6-dc4484876f18", MovieId = 10 },
                //new Favorite { Id = 0, ApplicationUserId = "", MovieId = 0 },
            };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Id = i + 1;
            }

            modelBuilder.Entity<Favorite>().HasData(list);
        }
    }
}
