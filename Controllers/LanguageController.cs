using Common.Dtos.RequestDto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ILanguageService _languageService;
    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeacher()
    {
        IEnumerable<LanguageDto> response = await _languageService.GetLanguages();
        return new ApiResponseActionResult<IEnumerable<LanguageDto>>(response);
    }
}
