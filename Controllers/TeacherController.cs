using Common.Dtos.RequestDto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    public TeacherController(ITeacherService teacherService)
    {
          _teacherService = teacherService;
    }
    [HttpGet]
    public async Task<IActionResult> GetTeacher()
    {
        IEnumerable<TeacherDto> response = await _teacherService.GetAsync();
        return new ApiResponseActionResult<IEnumerable<TeacherDto>>(response);
    }
    [HttpPost]
    public async Task<IActionResult> AddTeacher([FromBody] TeacherDto teacher)
    {
        string response = await _teacherService.AddAsync(teacher);
        return new ApiResponseActionResult<string>(response);
    }
    [HttpPost("AssignSubjectToTeacher")]
    public async Task<IActionResult> AssignSubjectToTeacher(TeacherSubjectDto teacherSubjectDto)
    {
        string response=await _teacherService.AssignSubjectToTeacherAsync(teacherSubjectDto);
        return new ApiResponseActionResult<string>(response);
    }
    [HttpGet("GetSubjectTeacher")]
    public async Task<IActionResult> GetSubjectTeacher()
    {
        IEnumerable<TeacherSubjectResponseDto> teacherSubjectResponseDtos=await _teacherService.GetSubjectTeacherAsync();
        return new ApiResponseActionResult<IEnumerable<TeacherSubjectResponseDto>>(teacherSubjectResponseDtos);
    }
}
