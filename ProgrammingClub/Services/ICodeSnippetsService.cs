using Microsoft.EntityFrameworkCore;
using ProgrammingClub.Models;

namespace ProgrammingClub.Services
{
    public interface ICodeSnippetsService
    {
        public Task<DbSet<CodeSnippet>> GetCodeSnippetsAsync();
        public Task CreateCodeSnippetAsync(CodeSnippet codeSnippet);
        public Task DeleteCodeSnippetAsync(CodeSnippet codeSnippet);
        public Task UpdateCodeSnippetAsync(CodeSnippet codeSnippet);
    }
}
