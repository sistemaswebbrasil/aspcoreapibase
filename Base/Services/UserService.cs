using Base.Models;
using Base.Repositories;
using System.Threading.Tasks;

namespace Base.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Task<User> FindByEmail(string email)
        {
            return _repository.FindByEmail(email);
        }

        public Task<User> FindByUsername(string username)
        {
            return _repository.FindByUsername(username);
        }
    }
}
