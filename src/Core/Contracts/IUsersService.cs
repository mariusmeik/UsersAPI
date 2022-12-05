using Core.Entities;

namespace Core.Contracts
{
    public interface IUsersService
    {
        public Task<List<UserEntity>> GetUsersAsync(string name);
    }
}
