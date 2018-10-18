using System.ComponentModel.DataAnnotations.Schema;

namespace DatingApp.API.Model
{
    public class Photo
    {
        public string id { get; set; }
        public string Desciprion { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        [ForeignKey("user")]
        public int userid { get; set; }
        public User user { get; set; }

    }
}