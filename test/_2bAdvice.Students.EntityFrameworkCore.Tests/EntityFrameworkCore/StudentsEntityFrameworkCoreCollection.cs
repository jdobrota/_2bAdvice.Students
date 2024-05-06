using Xunit;

namespace _2bAdvice.Students.EntityFrameworkCore;

[CollectionDefinition(StudentsTestConsts.CollectionDefinitionName)]
public class StudentsEntityFrameworkCoreCollection : ICollectionFixture<StudentsEntityFrameworkCoreFixture>
{

}
