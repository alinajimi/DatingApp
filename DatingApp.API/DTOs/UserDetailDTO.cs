using System.Collections.Generic;

namespace DatingApp.API.DTOs
{
    public class UserDetailDTO
    {
        
     public int id { get; set; }   
     public string Username { get; set; }
   public string MainPhotoUrl { get; set; }
     public string city { get; set; }
    public int Age { get; set; }
     public  string  Gender { get; set; }
     public string Interests { get; set; }
     public string Introduction { get; set; }
     public ICollection<PhotoForReturn> Photos { get; set; }
    }
}