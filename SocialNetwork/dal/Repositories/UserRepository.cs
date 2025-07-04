﻿
using Microsoft.EntityFrameworkCore;
using Npgsql;
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
            var user = await _context.Users.FromSql($"select * from users where email = '{email}'").FirstOrDefaultAsync();
            return user != null;
        }

        public async Task AddUser(User user)
        {
            FormattableString sql =
                $@"insert into users values({user.Id}, {user.LastName}, {user.FirstName}, {user.Email}, {user.Birthday}, {user.City},
                    {user.AboutMe}, {user.Sex}, {user.PasswordHash})";
            await _context.Database.ExecuteSqlInterpolatedAsync(sql);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var result = await _context.Users
                .FromSqlInterpolated($"select * from users where email = {email}")
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var result = await _context.Users
                .FromSqlInterpolated($"select * from users where id = {id}")
                .FirstOrDefaultAsync();
            return result;
        }

        public Task<Profile?> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}