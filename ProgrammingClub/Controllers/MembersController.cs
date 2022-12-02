using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClub.Models;
using ProgrammingClub.Services;

namespace ProgrammingClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;

        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }

        [Route("GetMembers")]
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            DbSet<Member> members = await _membersService.GetMembers();
            if (members != null)
            {
                if (members.ToList().Count > 0)
                    return StatusCode(200, members);
                else return StatusCode(404, "Nu este niciun membru in tabel!");
            }
            return StatusCode(404);
        }

        [Route("PostMember")]
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] Member member)
        {
            try
            {
                if (member != null)
                {
                    await _membersService.CreateMember(member);
                    return StatusCode(201, "Membrul a fost adaugat in tabel");
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }

        [Route("DeleteMember")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMember([FromBody] Member member)
        {
            if (member != null)
            {
                await _membersService.DeleteMember(member);
                return StatusCode(200, "Membrul a fost sters");
            }
            return StatusCode(500, "A aparut o eroare!Membrul nu a fost sters");
        }

        [Route("PutMember")]
        [HttpPut]
        public async Task<IActionResult> PutMember([FromBody] Member member)
        {
            if (member != null)
            {
                await _membersService.UpdateMember(member);
                return StatusCode(200, "Membrul a fost modificat!");
            }
            return StatusCode(500, "A aparut o eroare!Membrul nu a fost modificat!");
        }
    }
}