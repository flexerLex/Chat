using Chat.Database.Models;

namespace Chat
{
    public interface IDbService
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByIDAsync(int id);
        Task UpdateUserAsync(User user);
        Task AddPersonalMessage(Message message);
        Task<List<Message>> GetAllUserMessagesAsync(User user);

        Task<User> GetUserByUsernameAsync(string username);
    }
}