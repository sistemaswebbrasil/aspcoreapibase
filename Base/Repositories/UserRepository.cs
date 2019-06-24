using Base.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Base.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> FindByUsername(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(e => e.Username == username);
        }
    }
}
