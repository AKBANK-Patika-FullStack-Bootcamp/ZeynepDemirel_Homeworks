using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class NFTtoken
    {
        [Key]
        public int tokenId { get; set; }
        public string tokenName { get; set; }
        public DateTime dateOfCreate { get; set; }
        public Double price { get; set; }

        [ForeignKey("artist_id")]
        public int artist_id { get; set; }

    }
}