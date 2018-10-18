using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Model;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthrepository
    {
        private DataContext _db;
        private IMapper _mapper;
        private IConfiguration _config;
        private IDatingAppRepository _repo;

        public AuthRepository(DataContext db , IMapper mapper ,IConfiguration config )
        {
            _db=db;
            _mapper=mapper;
            _config=config;
            
        }
        public async Task<User> Login(UserForLogin userforlogin)
        {
            
            byte [] key=Encoding.ASCII.GetBytes(_config.GetSection("secrets:HashSalt").Value);
            userforlogin.username= userforlogin.username.ToLower();
            var userformdb= await _db.Users.FirstOrDefaultAsync(x=>x.Username==userforlogin.username);
            if(userformdb==null)
            return null;
            byte [] passwordsalt = userformdb.passwordsalt;
            byte [] passwordhash= userformdb.PasswordHash;
            byte [] Computedhash ;
            using (var hmac=new HMACSHA512 (key))
            {
                Computedhash=hmac.ComputeHash(Encoding.UTF8.GetBytes(userforlogin.password));
                
            }
            for (int i = 0; i < passwordhash.Length; i++)
            {
                if(passwordhash[i] !=Computedhash[i])
                return null;
                
            }
            return userformdb;

            
        }

        public async Task<User> Register(UserForRegister userforregister)
        {
            userforregister.username=userforregister.username.ToLower();
           User u= _mapper.Map<User>(userforregister);
            byte [] passwordsalt , passwordhash;
            createPasswordHashAndSalt(userforregister.password , out passwordhash , out passwordsalt);
            u.PasswordHash= passwordhash;
            u.passwordsalt= passwordsalt;
          await  _db.Users.AddAsync(u);
     if( await  _db.SaveChangesAsync() > 0) 
     return u;
     return null;

         
        }
        public void createPasswordHashAndSalt(string password, out byte [] passwordhash, out byte [] passwordsalt)
        {
            byte [] key=Encoding.ASCII.GetBytes(_config.GetSection("secrets:HashSalt").Value);
        using ( var hmac= new HMACSHA512 (key) )
        {
            passwordsalt= hmac.Key;
            passwordhash= hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            
        }

        }

        public async Task<bool> UserExists(string username)
        {
            username =username.ToLower();
            bool userexists= await _db.Users.AnyAsync(x=>x.Username == username);
         return userexists;
            
        }
    }
}