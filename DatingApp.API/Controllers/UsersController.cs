using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[Controller]")]
    public class UsersController:Controller
    {
        private IDatingAppRepository _repo;
        private IMapper _mapper;

        public UsersController(IDatingAppRepository repo , IMapper mapper)
        {
            _repo=repo;
            _mapper=mapper;
        }
        [HttpGet("{userid}" ,Name="getuser")]
        public async Task<IActionResult> GetCreatedUser(int userid)
        {
            var user= await _repo.GetUser(userid);
            return Ok(user);


        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user= await _repo.GetUser(id);
            var UsertoReturn =_mapper.Map<UserDetailDTO> (user);
            return Ok(UsertoReturn);


        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() {
            
            var users= await _repo.GetUsers();
            var UsersToReturn= _mapper.Map<List<UserListDTO>>(users);
            return Ok(UsersToReturn);

        }
    }
}
