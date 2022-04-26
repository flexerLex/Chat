using Chat.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat
{
    public class DbService: IDbService
    {
        private readonly DatabaseContext _databaseContext;


        public DbService(DatabaseContext databaseContext) =>
           _databaseContext = databaseContext;

        public async Task<User> GetUserByIDAsync(int id)
        {
            var a = await _databaseContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
            if (a != null)
            {
                return a;
            }
            return null;
        }

        public async Task AddPersonalMessage(Message message)
        {
            await _databaseContext.Messages.AddAsync(message);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task AddUserAsync(User user)
        {
            if (await _databaseContext.Users.FindAsync(user) != null)
            {
                user.UserId += _databaseContext.Users.Count();
                await _databaseContext.Users.AddAsync(user);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task<List<Message>> GetAllUserMessagesAsync(User user)
        {
            return await _databaseContext.Messages.Where(s => s.User == user).ToListAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _databaseContext.Entry(user).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)=>
             await _databaseContext.Users.FirstOrDefaultAsync(user => user.UserName == username);
    }
}
