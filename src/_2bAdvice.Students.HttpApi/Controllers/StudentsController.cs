using _2bAdvice.Students.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace _2bAdvice.Students.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StudentsController : AbpControllerBase
{
    protected StudentsController()
    {
        LocalizationResource = typeof(StudentsResource);
    }
}
