using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Localization;
using _2bAdvice.Students.Schools;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public class SchoolsAppService : ApplicationService, ISchoolsAppService
{
    private readonly IRepository<School, Guid>? _schoolRepository;

    public SchoolsAppService(IRepository<School, Guid>? schoolRepository)
    {
        this.LocalizationResource = typeof(StudentsResource);
        this._schoolRepository = schoolRepository;
    }

    public async Task<School> AddSchoolAsync(CreateSchoolDto schoolDto)
    {
        var school = this.ObjectMapper.Map<CreateSchoolDto, School>(schoolDto);
        return await this._schoolRepository!.InsertAsync(school);
    }

    public async Task<bool> DeleteSchoolAsync(Guid id)
    {
        var student = await this._schoolRepository!.GetAsync(s => s.Id == id);
        if (student == null)
        {
            return false;
        }

        await this._schoolRepository!.DeleteAsync(student.Id);
        return true;
    }

    public async Task<List<SchoolDto>> GetSchoolsDtoAsync()
    {
        var schools = await this._schoolRepository!.GetListAsync();
        var schoolDto = this.ObjectMapper.Map<List<School>, List<SchoolDto>>(schools);
        return schoolDto;
    }

    public async Task<bool> PutSchoolAsync(Guid id, UpdateSchoolDto schoolDto)
    {
        var school = await this._schoolRepository!.GetAsync(s => s.Id == id);
        if (school == null)
        {
            return false;
        }

        this.ObjectMapper.Map(schoolDto, school);

        await this._schoolRepository!.UpdateAsync(school);
        return true;
    }
}
