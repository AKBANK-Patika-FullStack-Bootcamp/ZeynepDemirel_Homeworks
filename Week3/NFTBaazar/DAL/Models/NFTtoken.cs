namespace DAL.Models
{
    public class NFTtoken
    {
        public int tokenId { get; set; }
        public string tokenName { get; set; }
        public DateTime dateOfCreate { get; set; }
        public Double price { get; set; }

        public int artist_id { get; set; }

    }
}