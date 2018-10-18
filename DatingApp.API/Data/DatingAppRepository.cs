using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingAppRepository : IDatingAppRepository
    {
        private DataContext _db;

        public DatingAppRepository(DataContext db)
        {
            _db=db;
        }
        public async Task<User> GetUser(int id)
        {
            var user=  await _db.Users.Include(u=>u.Photos).FirstOrDefaultAsync(x=>x.id==id);
            return user;

            
        }

        public async Task<List<User>> GetUsers()
        {
           var users= await  _db.Users.Include(u=>u.Photos).ToListAsync();
           return users;
        }
    }
}