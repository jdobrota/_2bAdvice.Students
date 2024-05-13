using Volo.Abp.AspNetCore.Components;
using _2bAdvice.Students.Localization;

namespace _2bAdvice.Students.Blazor;

public abstract class StudentsComponentBase : AbpComponentBase
{
    protected StudentsComponentBase()
    {
        this.LocalizationResource = typeof(StudentsResource);
    }
}
