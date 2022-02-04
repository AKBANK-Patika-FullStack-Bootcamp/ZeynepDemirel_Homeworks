using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Artist
    {
        [Key]
        public int artist_id { get; set; }
        public string artist_firstName { get; set;}
        public string artist_lastName { get; set;}
    }
}
