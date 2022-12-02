using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.Services
{
    public class MembersService : IMembersService
    {
        private readonly ProgrammingClubDataContext _context;

        public MembersService(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task DeleteMember(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public async Task<DbSet<Member>> GetMembers()
        {
            return _context.Members;
        }
        public async Task CreateMember(Member member)
        {
            var member_new = new Member
            {
                IdMember = Guid.NewGuid(),
                Name = member.Name,
                Title = member.Title,
                Position = member.Position,
                Description = member.Description,
                Resume = member.Resume,
            };
            _context.Entry(member_new).State = EntityState.Added;
            _context.SaveChanges();

        }

        public async Task UpdateMember(Member member)
        {
            _context.Update(member);
            _context.SaveChanges();
        }
    }
}
