using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext Context) {
            _context = Context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = new List<AppUser>();

            users = await _context.Users.ToListAsync(); 

            return users;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var users = await _context.Users.Where(x => x.AppUserID == id).FirstOrDefaultAsync();
            var users2 = await _context.Users.FindAsync(id);

            return users;
        }
    }
}
