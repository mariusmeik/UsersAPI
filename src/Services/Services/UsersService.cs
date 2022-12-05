using Core.Contracts;
using Core.Entities;

namespace APICallsService
{
    public class UsersService : IUsersService
    {
        private readonly IExternalUsersClient _client;
        public UsersService(IExternalUsersClient client)
        {
            _client = client;
        }
        public async Task<List<UserEntity>> GetUsersAsync(string name)
        {
            var users= await _client.GetUsersFromAPIAsync();
            if (name==null)
            {
                return users;
            }
            users=users.Where(x => x.Name == name).ToList();
            return users;
        }

       

      
    }
}