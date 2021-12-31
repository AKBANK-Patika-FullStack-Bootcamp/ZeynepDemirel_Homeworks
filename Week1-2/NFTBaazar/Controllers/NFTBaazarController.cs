using Microsoft.AspNetCore.Mvc;

namespace NFTBaazar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NFTBaazarController : ControllerBase
    {
        private static List<NFTtoken> tokens = new List<NFTtoken>()
        {
            new NFTtoken
            {
                tokenId = 1,
                tokenName = "1978 gold candy",
                dateOfConsruction = new DateTime(2014,12,26), //26-Dec-14
                price = 4200
            },
            new NFTtoken
            {
                tokenId=2,
                tokenName = "rocking a cock near you.",
                dateOfConsruction=new DateTime(2008,04,15),
                price = 2250
            },
            new NFTtoken
            {
                tokenId=3,
                tokenName ="ROUTINE MAINTENANCE",
                dateOfConsruction=new DateTime(2019,12,28),
                price = 2000
            }
        };
        //methods

        //endpoint that get token list
        [HttpGet]
        public List<NFTtoken> GetTokens()
        {
            var tokensList = tokens.OrderBy(t => t.tokenId).ToList();
            return tokensList;
        }

        [HttpGet("{id}")]
        public NFTtoken GetTokensId(int id)
        {
            var token = tokens.Where(token=> token.tokenId == id).SingleOrDefault();
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
                _result.message = "Ýnsert new token in list";
            }
            else
            {
                _result.status = 0;
                _result.message = "Don't insert new token because there is it";
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
            }
            else
            {
                //update token features
                token.tokenId = updatedToken.tokenId != default ? updatedToken.tokenId : token.tokenId;
                token.tokenName = updatedToken.tokenName != default ? updatedToken.tokenName : token.tokenName;
                token.price = updatedToken.price != default ? updatedToken.price : token.price;
                token.dateOfConsruction = updatedToken.dateOfConsruction != default ? updatedToken.dateOfConsruction : token.dateOfConsruction;
                _result.status = 1;
                _result.message = "Updated successfully.";
                _result.list = tokens.ToList();
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
                _result.message = "Deleted wrong";
            }
            else
            {
                tokens.Remove(token);
                _result.status = 1;
                _result.message = "Deleted successfully";
                _result.list=tokens.ToList();
            }
            return _result;
        }
    }
}
