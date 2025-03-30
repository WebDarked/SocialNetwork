using Microsoft.EntityFrameworkCore;
using SocialNetwork.dal.users;
using SocialNetwork.domain;
using SocialNetwork.domain.users;

namespace SocialNetwork.dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkDbContext _context;

        public UserRepository(SocialNetworkDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserWithEmailExist(string email)
        {
            var user = await _context.Users.FromSqlRaw($"select * from users where email = '{email}'").FirstOrDefaultAsync();
            return user != null;
        }

        public async Task RegisterUser(User user)
        {
            FormattableString sql = $"insert into users values({user.Id}, {user.LastName}, {user.FirstName}, {user.Email}, {user.Birthday}, {user.City}, {user.AboutMe}, {user.Sex})";
            await _context.Database.ExecuteSqlInterpolatedAsync(sql);
            await _context.SaveChangesAsync();

        }
    }
}
