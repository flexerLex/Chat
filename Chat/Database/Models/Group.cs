namespace Chat.Database.Models

{
    public class Group
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<UserGroup> UserGroups { get; set; }
        public IList<Message> Messages { get; set; }

    }
}