using Common.Dtos.RequestDto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;
    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }
    [HttpGet]
    public async Task<IActionResult> GetSubject()
    {
        IEnumerable<SubjectResponseDto> response = await _subjectService.GetAllAsync();
        return new ApiResponseActionResult<IEnumerable<SubjectResponseDto>>(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddSubject([FromBody] SubjectRequestDto subject)
    {
        string response = await _subjectService.AddAsync(subject);
        return new ApiResponseActionResult<string>(response);
    }
}
