using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Serilog;
using _2bAdvice.Students.Repositories.Students;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentsController : ODataController
    {
        private readonly IMapper? _mapper;
        private readonly ILogger? _logger;
        private readonly IStudentRepository? _studentRepository;

        [HttpGet()]
        [EnableQuery()]
        public async Task<ActionResult<List<StudentDto>>> GetStudents()
        {
            try
            {
                var studentDtos = await this._studentRepository!.GetAllAsync();
                return Ok(studentDtos);
            }
            catch (Exception ex)
            {
                this._logger!.Error(ex, $"Error performing GET in {nameof(GetStudents)}");
                return StatusCode(500, ex);
            }
        }
    }
}
