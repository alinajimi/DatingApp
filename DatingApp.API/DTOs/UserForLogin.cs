using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForLogin
    {
        [Required(ErrorMessage="username is required")]
        public string username { get; set; }
        [Required(ErrorMessage="password is required")]
       [StringLength(20,MinimumLength=4,ErrorMessage="soome issues with length")]
        public string password { get; set; }
        
    }
}