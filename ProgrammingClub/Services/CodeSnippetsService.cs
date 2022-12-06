using Microsoft.EntityFrameworkCore;
using ProgrammingClub.DataContext;
using ProgrammingClub.Models;

namespace ProgrammingClub.Services
{
    public class CodeSnippetsService : ICodeSnippetsService
    {
        private readonly ProgrammingClubDataContext _context;

        public CodeSnippetsService(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public async Task CreateCodeSnippetAsync(CodeSnippet codeSnippet)
        {
            codeSnippet.IdCodeSnippet = Guid.NewGuid();
            codeSnippet.DateTimeAdded = DateTime.UtcNow;
            _context.Entry(codeSnippet).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCodeSnippetAsync(CodeSnippet codeSnippet)
        {
            _context.CodeSnippets.Remove(codeSnippet);
            await _context.SaveChangesAsync();
        }

        public async Task<DbSet<CodeSnippet>> GetCodeSnippetsAsync()
        {
            return _context.CodeSnippets;
        }

        public async Task UpdateCodeSnippetAsync(CodeSnippet codeSnippet)
        {
            _context.CodeSnippets.Update(codeSnippet);
            await _context.SaveChangesAsync();
        }
    }
}
