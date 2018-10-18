using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Model;

namespace DatingApp.API.Data
{
    public interface IDatingAppRepository
    {
        
        Task<User> GetUser(int id);
        Task<List<User>> GetUsers();
    }
}