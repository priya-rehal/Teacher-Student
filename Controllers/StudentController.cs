using Common.Dtos;
using Common.Dtos.RequestDto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpGet]
    public async Task<IActionResult> GetStudents(int pageNumber, int pageSize,string? searchItem)
    {
        PaginationData<IEnumerable<StudentDto>> response =await _studentService.GetStudents(pageNumber,pageSize,searchItem);
        return new ApiResponseActionResult<PaginationData<IEnumerable<StudentDto>>>(response);
    }
    [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
    {
        string response=await _studentService.AddStudent(studentDto);
        return new ApiResponseActionResult<string>(response);
    }
    [HttpGet("GetSubjectAndTeacherByStudent")]
    public async Task<IActionResult> GetSubjectAndTeacherByStudent(int classId)
    {
        dynamic response = _studentService.GetStudentSubjectByClassId(classId);
        return new ApiResponseActionResult<dynamic>(response);
    }
    [HttpGet("GetStudentByClass")]
    public async Task<IActionResult> GetStudentByClass(int classId)
    {
        IEnumerable<StudentDto> studentDtos =await _studentService.GetStudentByClass(classId);
        return new ApiResponseActionResult<IEnumerable<StudentDto>>(studentDtos);

    }
}
