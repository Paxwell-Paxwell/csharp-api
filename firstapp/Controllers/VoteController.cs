using Microsoft.AspNetCore.Mvc;
using firstapp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using firstapp.Data;
using System.Threading.Tasks;
namespace firstapp.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public VoteController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Vote>> CreateVote(Vote vote)
        {
            await _context.Votes.InsertOneAsync(vote);
            return CreatedAtRoute( new { id = vote.Id }, vote);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(string id)
        {
            var vote = await _context.Votes.Find(p => p.Id ==id).FirstOrDefaultAsync();

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Vote>>> GetAll(int page = 1, int pageSize = 10)
        {
            var skip = (page - 1) * pageSize;
            var votes = await _context.Votes.Find(_ => true)
                                            .Skip(skip)
                                            .Limit(pageSize)
                                            .ToListAsync();

            return votes;
        }

        // Add more methods as needed
    }
}
