using Microsoft.EntityFrameworkCore;
using ProgrammingClub.Models;

namespace ProgrammingClub.Services
{
    public interface IMembersService
    {
        public Task<DbSet<Member>> GetMembers();
        public Task CreateMember(Member member);
        public Task DeleteMember(Member member);
        public Task UpdateMember(Member member);
    }
}
