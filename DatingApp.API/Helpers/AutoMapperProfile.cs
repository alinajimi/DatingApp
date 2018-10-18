using System.Linq;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Model;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfile :Profile
    {
        
        public AutoMapperProfile() {
            CreateMap<User,UserDetailDTO>().ForMember(dst => dst.Age , opt => {
                    opt.ResolveUsing(src =>src.DateOfBirth.Age());


            }).ForMember(dst => dst.MainPhotoUrl , opt => {

                opt.MapFrom(src => src.Photos.FirstOrDefault(x=>x.IsMain));
            });
              CreateMap<User,UserListDTO>().ForMember(dst => dst.Age , opt => {
                    opt.ResolveUsing(src =>src.DateOfBirth.Age());


            }).ForMember(dst => dst.MainPhotoUrl , opt => {

                opt.MapFrom(src => src.Photos.FirstOrDefault(x=>x.IsMain));
            });

            CreateMap<UserForRegister , User>();
            CreateMap<User , UserDetailDTO>();
            CreateMap<User, UserListDTO>();
        }
    }
}