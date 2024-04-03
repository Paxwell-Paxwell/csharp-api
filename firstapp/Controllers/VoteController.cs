using Microsoft.AspNetCore.Mvc;
using firstapp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using firstapp.Data;

namespace firstapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public VoteController(IMongoDatabase database)
        {
            _voteCollection = database.GetCollection<Vote>("Votes");
        }

        [HttpPost]
        public IActionResult CreateVote(Vote vote)
        {
            _voteCollection.InsertOne(vote);
            return CreatedAtAction(nameof(GetVote), new { id = vote.Id.ToString() }, vote);
        }

        [HttpGet("{id:length(24)}", Name = "GetVote")]
        public ActionResult<Vote> GetVote(string id)
        {
            var vote = _voteCollection.Find<Vote>(vote => vote.Id == ObjectId.Parse(id)).FirstOrDefault();
            if (vote == null)
            {
                return NotFound();
            }
            return vote;
        }

        // Add more methods as needed
    }
}
