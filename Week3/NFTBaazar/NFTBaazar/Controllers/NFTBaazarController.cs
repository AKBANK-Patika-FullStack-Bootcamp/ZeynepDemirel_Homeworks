using DAL.Models;
using Microsoft.AspNetCore.Mvc;

//business layer
namespace NFTBaazar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NFTBaazarController : ControllerBase
    {
        Logger logger = new Logger(); //logger class

        //define list
        private static List<NFTtoken> tokens = new List<NFTtoken>()
        {
            new NFTtoken
            {
                tokenId = 1,
                tokenName = "1978 gold candy",
                dateOfCreate = new DateTime(2014,12,26), //26-Dec-14
                price = 4200,
                artist_id = 1
            },
            new NFTtoken
            {
                tokenId=2,
                tokenName = "rocking a cock near you.",
                dateOfCreate=new DateTime(2008,04,15),
                price = 2250,
                artist_id = 1
            },
            new NFTtoken
            {
                tokenId=3,
                tokenName ="ROUTINE MAINTENANCE",
                dateOfCreate=new DateTime(2019,12,28),
                price = 2000,
                artist_id = 1 //"MIKE WINKELMANN"
            }
        };
        //methods

        //endpoint that get token list
        [HttpGet]
        public List<NFTtoken> GetTokens()
        {
            var tokensList = tokens.OrderBy(t => t.tokenId).ToList();
            logger.createLog("All NFTs that are in list fetched sorted by their ids.");
            return tokensList;
        }

        [HttpGet("{id}")]
        public NFTtoken GetTokensId(int id)
        {
            var token = tokens.Where(token=> token.tokenId == id).SingleOrDefault();
            logger.createLog("NFT with "+token.tokenId+" was fetched from the list.");
            return token;
        }

        [HttpPost]
        public Result AddToken(NFTtoken newToken)
        {
            Result _result = new Result();

            //Is there new token in list?
            bool tokenCheck = tokens.Select(t => t.tokenId == newToken.tokenId || t.tokenName == newToken.tokenName).FirstOrDefault();

            if (tokenCheck == false)
            {
                //there isn't token in list
                tokens.Add(newToken);
                _result.status = 1;
                _result.message = "Insert new token in list";
                _result.list = tokens;
                logger.createLog(_result.message);
            }
            else
            {
                _result.status = 0;
                _result.message = "Don't insert new token because there is it";
                logger.createLog(_result.message);
            }
            return _result;
        }
        [HttpPut]
        public Result UpdateToken(NFTtoken updatedToken)
        {
            Result _result = new Result();

            var token = tokens.Find(t=> t.tokenId==updatedToken.tokenId);

            if (token == null)
            {
                _result.status= 0;
                _result.message = "Not found this token";
                logger.createLog(_result.message);
            }
            else
            {
                token.tokenId = updatedToken.tokenId != default ? updatedToken.tokenId : token.tokenId;
                token.tokenName = updatedToken.tokenName != default ? updatedToken.tokenName : token.tokenName;
                token.price = updatedToken.price != default ? updatedToken.price : token.price;
                token.dateOfCreate = updatedToken.dateOfCreate != default ? updatedToken.dateOfCreate : token.dateOfCreate;
                token.artist_id = updatedToken.artist_id != default ? updatedToken.artist_id : token.artist_id;
                _result.status = 1;
                _result.message = "Updated successfully.";
                _result.list = tokens.ToList();
                logger.createLog(_result.message);
            }
            return _result;
        }
        [HttpDelete("{id}")]
        public Result DeleteToken(int id)
        {
            Result _result = new Result();

            var token = tokens.SingleOrDefault(t=> t.tokenId == id);

            if(token == null)
            {
                _result.status = 0;
                _result.message = "Delete failed";
                logger.createLog(_result.message);
            }
            else
            {
                tokens.Remove(token);
                _result.status = 1;
                _result.message = "Deleted successfully";
                _result.list=tokens.ToList();
                logger.createLog(_result.message);
            }
            return _result;
        }
    }
}