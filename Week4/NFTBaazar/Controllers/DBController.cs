using DAL.Models;
using Entities;
using System;

namespace NFTBaazar.Controllers
{
    public class DBController
    {
        private NFTBaazarDBContext _context = new NFTBaazarDBContext();

        Logger _logger = new Logger();

        //for HTTPPost operation from NFTBaazarController
        public bool AddModel(NFTtoken _token)
        {
            try
            {
                _context.NFTtokens.Add(_token);
                _context.SaveChanges();
                _logger.createLog("Insert new NFT in database");
                return true;
            }
            catch (Exception ex)
            {
                _logger.createLog("Error: " + ex.Message);
                return false;
            }
        }

        public NFTtoken? FindNFT(int _id = 0, string _tokenName = "") //Not:search whatever name or id is given
        {
            //find NFT with name and id from NFT table
            NFTtoken? token = new NFTtoken();
            if (!string.IsNullOrEmpty(_tokenName))
            {
                token = _context.NFTtokens.FirstOrDefault(t => t.tokenName == _tokenName);
            }
            else if (_id > 0)
            {
                token = _context.NFTtokens.FirstOrDefault(t => t.tokenId == _id);
            }
            return token;
        }

        //for HTTPGet operations from NFTBaazarController
        public List<NFTtoken> GetNFTs()
        {
            //fetch all NFTs from database
            List <NFTtoken> tokens = new List <NFTtoken>();
            tokens = _context.NFTtokens.OrderBy(t => t.tokenId).ToList();
            _logger.createLog("All NFTs that are in list fetched sorted by their ids.");
            return tokens;
        }

        public List<NFTtoken> GetNFTsInnerJoın()
        {
            //fetch all NFTs from database
            List<NFTtoken> tokens = new List<NFTtoken>();
            tokens = _context.NFTtokens.Join(_context.Artists, n => n.artist_id, a => a.artist_id,
                (token,artist)=> new NFTtoken {
                tokenId = token.tokenId,
                tokenName = token.tokenName,
                dateOfCreate = token.dateOfCreate,
                price = token.price,
                artist = (artist.artist_firstName + artist.artist_lastName)
                }).ToList();
            _logger.createLog("All NFTs that are in list fetched sorted by their ids.");
            return tokens;
        }

        public NFTtoken? GetNFTId(int _id) //Not: this "?" is to possible null returns
        {
            //fetch one NFT from db
            _logger.createLog("NFT with " + _id + " was fetched from the list.");
            return _context.NFTtokens.Where(token => token.tokenId == _id).SingleOrDefault();
            
        }

        //for HTTPDelete operation from NFTBaazarController 

        public bool DeleteModel(int _id)
        {
            try
            {
                _context.NFTtokens.Remove(FindNFT(_id));
                _context.SaveChanges();
                _logger.createLog("Delete NFT in database");
                return true;
            }
            catch (Exception ex)
            {
                _logger.createLog("Error: " + ex.Message);
                return false;
            }
        }






    }
}
