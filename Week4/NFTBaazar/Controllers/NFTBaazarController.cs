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

        DBController dbController = new DBController(); //db connection

        //Methods

        //endpoint that get token list
        [HttpGet]
        public List<NFTtoken> GetTokens()
        {
            // call function from dbContext
            return dbController.GetNFTs(); 
            
        }

        //get NFT by id
        [HttpGet("{id}")]
        public NFTtoken GetTokensId(int id)
        {
            if(dbController.FindNFT(id) == null)
            {
                logger.createLog("NFT (" + id + ") is not found.");
                return null;
            }
            else 
            {
                NFTtoken? token = dbController.GetNFTId(id);
                return token;
            }
            
        }

        //add new NFT to db
        [HttpPost]
        public Result AddToken(NFTtoken newNFT)
        {
            Result _result = new Result();

            //Is there new token in list?
            NFTtoken? nft = dbController.FindNFT(newNFT.tokenId, newNFT.tokenName);
            bool tokenCheck = (nft != null) ? true : false;
            
            if (tokenCheck)
            {
                _result.status = 0;
                _result.message = "NFT is already exist.";
                logger.createLog(_result.message);
            }
            else
            {
                //there isn't token in list
                if (dbController.AddModel(newNFT)) 
                {
                    _result.status = 1;
                    _result.message = "Insert new token in list";
                    _result.list = dbController.GetNFTs().ToList();
                }
                else
                {
                    _result.status = 0;
                    _result.message = "Don't insert new token";
                    _result.list = dbController.GetNFTs().ToList();

                }
            }
            return _result;
        }
        
        //update NFT information
        [HttpPut]
        public Result UpdateToken(int id, NFTtoken updatedToken)
        {
            Result _result = new Result();

            var token = dbController.FindNFT(0,updatedToken.tokenName);

            if (token == null)
            {
                _result.status= 0;
                _result.message = "Not found this token";
                logger.createLog(_result.message);
            }
            else
            {
                if(dbController.DeleteModel(id) && dbController.AddModel(updatedToken))
                {
                    _result.status = 1;
                    _result.message = "Updated successfully.";
                    _result.list = dbController.GetNFTs().ToList();
                    
                }
                else
                {
                    _result.status = 0;
                    _result.message = "Update Failed";
                }
                
                
            }
            return _result;
        }
        
        //delete NFT from db
        [HttpDelete("{id}")]
        public Result DeleteToken(int id)
        {
            Result _result = new Result();

            if(!dbController.DeleteModel(id))
            {
                _result.status = 0;
                _result.message = "Delete failed";
                
            }
            else
            {
                //successfully deleted
                _result.status = 1;
                _result.message = "Deleted successfully";
                _result.list= dbController.GetNFTs().ToList();
                
            }
            return _result;
        }
    }
}