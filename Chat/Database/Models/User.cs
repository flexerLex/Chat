using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Database.Models
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        

        public IList<UserGroup>? UserGroups { get; set; }
        public IList<User>? Users { get; set; }
        public IList<Message>? Messages { get; set; }
    }
}
