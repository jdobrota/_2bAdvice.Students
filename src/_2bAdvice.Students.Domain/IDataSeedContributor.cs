using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using _2bAdvice.Students.Schools;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Student, Guid> _studentRepository;
    private readonly IRepository<School, Guid> _schoolRepository;

    public BookStoreDataSeederContributor(
        IRepository<Student, Guid> studentRepository,
        IRepository<School, Guid> schoolRepository
    )
    {
        this._studentRepository = studentRepository;
        this._schoolRepository = schoolRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await this._studentRepository.GetCountAsync() <= 0)
        {
            var dumbierska = await this._schoolRepository.InsertAsync(
                new School()
                {
                    Name = "ZŠ Ďumbierska",
                    Address = "Ďumbierska 17, Banská Bystrica",
                    TypeOfSchool = SchoolTypeEnum.PUBLIC,
                },
                autoSave: true
            );

            var dlheHony = await this._schoolRepository.InsertAsync(
                new School()
                {
                    Name = "ZŠ Dlhé Hony",
                    Address = "Dlhé Hony 1, Trenčín",
                    TypeOfSchool = SchoolTypeEnum.PUBLIC,
                },
                autoSave: true
            );

            await this._studentRepository.InsertAsync(
                new Student
                {
                    FirstName = "Juraj",
                    LastName = "Dobrota",
                    DateOfBirth = new DateOnly(1996, 10, 9),
                    TypeOfStudy = Shared.StudyTypeEnum.INTERNAL,
                    SchoolId = dumbierska.Id,
                },
                autoSave: true
            );

            await this._studentRepository.InsertAsync(
                new Student
                {
                    FirstName = "Jožo",
                    LastName = "Pročko",
                    DateOfBirth = new DateOnly(1950, 12, 12),
                    TypeOfStudy = Shared.StudyTypeEnum.EXTERNAL,
                    SchoolId = dlheHony.Id,
                },
                autoSave: true
            );
        }
    }
}
