using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using _2bAdvice.Students.Students;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace _2bAdvice.Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class StudentsController : ODataController
    {
        private readonly ILogger? _logger;
        private readonly IRepository<Student, Guid>? _studentRepository;

        public StudentsController(IRepository<Student, Guid>? studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            try
            {
                var studentDtos = await this._studentRepository!.GetListAsync();
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
