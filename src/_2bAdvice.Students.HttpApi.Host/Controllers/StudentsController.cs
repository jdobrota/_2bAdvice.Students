using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class StudentsController : ODataController
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger? _logger;

    /// <summary>
    /// The students application service
    /// </summary>
    private readonly IStudentsAppService? _studentsAppService;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsController" /> class.
    /// </summary>
    /// <param name="logger">
    /// The logger.
    /// </param>
    /// <param name="studentsAppService">
    /// The students application service.
    /// </param>
    public StudentsController(
        ILogger<StudentsController> logger,
        IStudentsAppService studentsAppService
    )
    {
        this._logger = logger;
        this._studentsAppService = studentsAppService;
    }

    /// <summary>
    /// Gets the students.
    /// </summary>
    /// <returns>
    /// Task&lt;ActionResult&lt;List&lt;StudentDto&gt;&gt;&gt; <br /></returns>
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<List<StudentDto>>> GetStudents()
    {
        try
        {
            var studentsDto = await this._studentsAppService!.GetStudentsDtoAsync();

            return this.Ok(studentsDto);
        }
        catch (Exception ex)
        {
            this._logger!.LogError(ex, $"Error performing GET in {nameof(GetStudents)}");
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Posts the student.
    /// </summary>
    /// <param name="studentDto">
    /// The student dto.
    /// </param>
    /// <returns>
    /// Task&lt;ActionResult&lt;CreateStudentDto&gt;&gt;
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<CreateStudentDto>> PostStudent(CreateStudentDto studentDto)
    {
        try
        {
            var student = await this._studentsAppService!.AddStudentAsync(studentDto);

            return this.CreatedAtAction(nameof(PostStudent), new { id = student.Id }, student);
        }
        catch (Exception ex)
        {
            this._logger!.LogError(ex, $"Error performing POST in {nameof(PostStudent)}");
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Deletes the student.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;IActionResult&gt;
    /// </returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        try
        {
            var result = await this._studentsAppService!.DeleteStudentAsync(id);
            if (!result)
            {
                this._logger!.LogWarning(
                    $"{nameof(Student)} record not found: {nameof(DeleteStudent)} - ID: {id}"
                );
                return this.NotFound();
            }

            return this.NoContent();
        }
        catch (Exception ex)
        {
            this._logger!.LogError(
                $"{nameof(Student)} error occured while deleting: {nameof(DeleteStudent)} - ID: {id}"
            );
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Puts the student.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <param name="student">
    /// The student.
    /// </param>
    /// <returns>
    /// Task&lt;IActionResult&gt;
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(Guid id, UpdateStudentDto student)
    {
        if (id != student.Id)
        {
            this._logger!.LogWarning($"Update ID invalid: {nameof(PutStudent)} - ID: {id}");
            return this.BadRequest();
        }

        var result = await this._studentsAppService!.PutStudentAsync(id, student);
        if (!result)
        {
            this._logger!.LogWarning(
                $"{nameof(Student)} record not found: {nameof(PutStudent)} - ID: {id}"
            );
            return this.NotFound();
        }

        return this.NoContent();
    }
}
