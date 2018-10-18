using System.Threading.Tasks;
using DatingApp.API.DTOs;
using DatingApp.API.Model;

namespace DatingApp.API.Data
{
    public interface IAuthrepository
    {
         Task<User> Login(UserForLogin userforlogin);
         Task<User> Register(UserForRegister userforregister);
         Task<bool> UserExists(string username);

    }
}