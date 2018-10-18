using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[Controller]")]
    public class AuthController :Controller
    {
        private IAuthrepository _auth;
        private IMapper _mapper;
        private IConfiguration _config;

        public AuthController(IAuthrepository auth , IMapper mapper ,IConfiguration config )
        {
            _auth=auth;
            _mapper=mapper;
            _config=config;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister userforregister) 
        {
        return BadRequest("sa");
            if( await _auth.UserExists(userforregister.username))
            ModelState.AddModelError("duplicate user" ,"user already exists");
            if(ModelState.IsValid)
            {
var user = await _auth.Register(userforregister);
            if(user==null)
            return BadRequest("unable to create user");
          var UserToReturn =  _mapper.Map<UserDetailDTO>(user);
            
            return CreatedAtRoute("getuser" , new {Controller="users" , userid=user.id } , UserToReturn);

            }
            return BadRequest(ModelState);
            

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLogin userforlogin)
        {

                
  byte [] key=Encoding.ASCII.GetBytes(_config.GetSection("secrets:HashSalt").Value);
if(ModelState.IsValid)
{

    var user = await   _auth.Login(userforlogin);
    if(user==null)
    return Unauthorized();
 

    var tokenhandler=new JwtSecurityTokenHandler();

var descriptor= new SecurityTokenDescriptor(){

    Subject= new ClaimsIdentity(new Claim [] {

new Claim(ClaimTypes.NameIdentifier , user.id.ToString()),
new Claim(ClaimTypes.Name , user.Username),

    }) ,
    Expires=System.DateTime.Now.AddDays(2),
    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512)
};

 var tokenstring=   tokenhandler.CreateToken(descriptor);
 var token=tokenhandler.WriteToken(tokenstring);
 return Ok(new { token});


}
return BadRequest(ModelState);


        }

        
    }
}