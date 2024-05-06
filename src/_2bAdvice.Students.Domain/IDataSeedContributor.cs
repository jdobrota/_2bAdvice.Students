using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using _2bAdvice.Students.Students;

namespace _2bAdvice.Students;

public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Student, Guid> _studentRepository;

    public BookStoreDataSeederContributor(IRepository<Student, Guid> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _studentRepository.GetCountAsync() <= 0)
        {
            await _studentRepository.InsertAsync(
                new Student
                {
                    FirstName = "Juraj",
                    LastName = "Dobrota",
                    DateOfBirth = new DateOnly(1996, 10, 9),
                    TypeOfStudy = Shared.StudyTypeEnum.INTERNAL,
                },
                autoSave: true
            );

            await _studentRepository.InsertAsync(
                new Student
                {
                    FirstName = "Jožo",
                    LastName = "Pročko",
                    DateOfBirth = new DateOnly(1950, 12, 12),
                    TypeOfStudy = Shared.StudyTypeEnum.EXTERNAL,
                },
                autoSave: true
            );
        }
    }
}
