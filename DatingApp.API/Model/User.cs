using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DatingApp.API.Model
{
    public  enum Gender
    {
        man=1, female=2
    }
    public class User
    {

     public int id { get; set; }   
     public string Username { get; set; }
     public byte []  PasswordHash { get; set; }
     public byte [] passwordsalt { get; set; }
     public string city { get; set; }
     public DateTime DateOfBirth { get; set; }
     public DateTime DateAdded { get; set; }
     public  string  Gender { get; set; }
     public string Interests { get; set; }
     public string Introduction { get; set; }
     public ICollection<Photo> Photos { get; set; }
     public User() {
            DateAdded=DateTime.Now;
            Photos= new Collection<Photo>();
     }

    }
}