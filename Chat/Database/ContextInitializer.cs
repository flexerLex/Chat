using Chat.Database.Models;

namespace Chat.Database
{
    public class ContextInitializer
    {
        public static List<User> InitializeUser()
        {
            List<Group> Groups = new List<Group> {
                 new Group
                {
                    Name = "Alex Group",
                    Id = 1
                },
                    new Group {
                        Name = "Girls))",
                            Id=4
                    },
                new Group
                        {
                            Name = "Family",
                            Id = 2
                        },
                        new Group
                        {
                            Name = "Work",
                            Id = 3
                        }

            };


            User userAlex = new User
            {
                UserName = "Alex",
                //UserGroups = Groups.FirstOrDefault(c => c.Id.Equals(1)).UserGroups,
                UserId = 1

            };
            User userPolina = new User
            {
                UserName = "Poly",
                UserId = 2

            };
            User userMagdalena = new User
            {
                UserName = "Magdalena",
                UserId = 3

            };
            User userJarek = new User
            {
                UserName = "Jarek",
                UserId = 4

            };
            User userKirill = new User
            {
                UserName = "Kirill",
                //UserGroups = Groups.FirstOrDefault(c => c.Name == "Alex Group").UserGroups,
                UserId = 5

            };
            User userAntony = new User
            {
                UserName = "Antony",
                UserId = 6

            };
            //userAlex.Groups = new List<Group> { Groups[0], Groups[2] , Groups[3] };
            //userPolina.Groups = new List<Group> { Groups[0], Groups[1]};

           

            var users = new List<User> { userAlex, userAntony, userJarek, userKirill, userMagdalena, userPolina };

            return users;
        }
    }
}