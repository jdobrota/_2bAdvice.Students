using _2bAdvice.Students.Localization;
using Volo.Abp.AspNetCore.Components;

namespace _2bAdvice.Students.Blazor;

public abstract class StudentsComponentBase : AbpComponentBase
{
    protected StudentsComponentBase()
    {
        LocalizationResource = typeof(StudentsResource);
    }
}
