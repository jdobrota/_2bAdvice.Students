using _2bAdvice.Students.Samples;
using Xunit;

namespace _2bAdvice.Students.EntityFrameworkCore.Applications;

[Collection(StudentsTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<StudentsEntityFrameworkCoreTestModule>
{

}
