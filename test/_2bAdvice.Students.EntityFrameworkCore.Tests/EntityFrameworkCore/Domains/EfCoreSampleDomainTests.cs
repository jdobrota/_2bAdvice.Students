using _2bAdvice.Students.Samples;
using Xunit;

namespace _2bAdvice.Students.EntityFrameworkCore.Domains;

[Collection(StudentsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<StudentsEntityFrameworkCoreTestModule>
{

}
