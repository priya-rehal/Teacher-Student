using Common.Dtos.RequestDto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StandardController : ControllerBase
{
    private readonly IStandardService _standardService;
    public StandardController(IStandardService standardService)
    {
        _standardService = standardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStandard()
    {
        var response = await _standardService.GetAllAsync();      
        return new ApiResponseActionResult<List<StandardDto>>(response);
    }
    [HttpPost]
    public async Task<IActionResult> AddStandard([FromBody] StandardDto standardDto)
    {
        string response = await _standardService.AddStandardAsync(standardDto);
        return new ApiResponseActionResult<string>(response);
    }
}
