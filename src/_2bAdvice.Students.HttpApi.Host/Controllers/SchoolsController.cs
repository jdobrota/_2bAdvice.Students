using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using _2bAdvice.Students.Schools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2bAdvice.Students.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class SchoolsController : ODataController
{
    /// <summary>
    /// The logger
    /// </summary>
    private readonly ILogger? _logger;

    /// <summary>
    /// The schools application service
    /// </summary>
    private readonly ISchoolsAppService? _schoolsAppService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolsController" /> class.
    /// </summary>
    /// <param name="logger">
    /// The logger.
    /// </param>
    /// <param name="schoolsAppService">
    /// The schools application service.
    /// </param>
    public SchoolsController(
        ILogger<SchoolsController> logger,
        ISchoolsAppService schoolsAppService
    )
    {
        this._logger = logger;
        this._schoolsAppService = schoolsAppService;
    }

    /// <summary>
    /// Gets the schools.
    /// </summary>
    /// <returns>
    /// Task&lt;ActionResult&lt;List&lt;SchoolDto&gt;&gt;&gt; <br /></returns>
    [HttpGet]
    [EnableQuery]
    public async Task<ActionResult<List<SchoolDto>>> GetSchools()
    {
        try
        {
            var schoolsDto = await this._schoolsAppService!.GetSchoolsDtoAsync();

            return this.Ok(schoolsDto);
        }
        catch (Exception ex)
        {
            this._logger!.LogError(ex, $"Error performing GET in {nameof(GetSchools)}");
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Posts the school.
    /// </summary>
    /// <param name="schoolDto">
    /// The school dto.
    /// </param>
    /// <returns>
    /// Task&lt;ActionResult&lt;CreateSchoolDto&gt;&gt;
    /// </returns>
    [HttpPost]
    public async Task<ActionResult<CreateSchoolDto>> PostSchool(CreateSchoolDto schoolDto)
    {
        try
        {
            var school = await this._schoolsAppService!.AddSchoolAsync(schoolDto);

            return this.CreatedAtAction(nameof(PostSchool), new { id = school.Id }, school);
        }
        catch (Exception ex)
        {
            this._logger!.LogError(ex, $"Error performing POST in {nameof(PostSchool)}");
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Deletes the school.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <returns>
    /// Task&lt;IActionResult&gt;
    /// </returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteSchool(Guid id)
    {
        try
        {
            var result = await this._schoolsAppService!.DeleteSchoolAsync(id);
            if (!result)
            {
                this._logger!.LogWarning(
                    $"{nameof(School)} record not found: {nameof(DeleteSchool)} - ID: {id}"
                );
                return this.NotFound();
            }

            return this.NoContent();
        }
        catch (Exception ex)
        {
            this._logger!.LogError(
                $"{nameof(School)} error occured while deleting: {nameof(DeleteSchool)} - ID: {id}"
            );
            return this.StatusCode(500, ex);
        }
    }

    /// <summary>
    /// Puts the school.
    /// </summary>
    /// <param name="id">
    /// The identifier.
    /// </param>
    /// <param name="student">
    /// The school.
    /// </param>
    /// <returns>
    /// Task&lt;IActionResult&gt;
    /// </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSchool(Guid id, UpdateSchoolDto school)
    {
        if (id != school.Id)
        {
            this._logger!.LogWarning($"Update ID invalid: {nameof(PutSchool)} - ID: {id}");
            return this.BadRequest();
        }

        var result = await this._schoolsAppService!.PutSchoolAsync(id, school);
        if (!result)
        {
            this._logger!.LogWarning(
                $"{nameof(School)} record not found: {nameof(PutSchool)} - ID: {id}"
            );
            return this.NotFound();
        }

        return this.NoContent();
    }
}
