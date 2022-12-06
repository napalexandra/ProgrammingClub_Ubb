using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClub.Models;
using ProgrammingClub.Services;

namespace ProgrammingClub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CodeSnippetsController : ControllerBase
    {
        private readonly ICodeSnippetsService _codeSnippetsService;

        public CodeSnippetsController(ICodeSnippetsService codeSnippetsService)
        {
            _codeSnippetsService = codeSnippetsService;
        }

        [Route("GetCodeSnippets")]
        [HttpGet]
        public async Task<IActionResult> GetCodeSnippets()
        {
            DbSet<CodeSnippet> codeSnippets = await _codeSnippetsService.GetCodeSnippetsAsync();
            return Ok(codeSnippets);
        }


        [Route("CreateCodeSnippets")]
        [HttpPost]
        public async Task<IActionResult> CreateCodeSnippet([FromBody] CodeSnippet codeSnippet)
        {
            await _codeSnippetsService.CreateCodeSnippetAsync(codeSnippet);
            return Ok("Code snippet a fost adaugat");
        }
    }
}
