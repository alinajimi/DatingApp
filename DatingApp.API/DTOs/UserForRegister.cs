using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTOs
{
    public class UserForRegister
    {
        [Required]
        public string username { get; set; }
        [Required]
                [StringLength(20,MinimumLength=4,ErrorMessage="some issues with length")]
                public string password { get; set; }
        
    }
}