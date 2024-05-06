using System;
using System.Collections.Generic;
using System.Text;
using _2bAdvice.Students.Localization;
using Volo.Abp.Application.Services;

namespace _2bAdvice.Students;

/* Inherit your application services from this class.
 */
public abstract class StudentsAppService : ApplicationService
{
    protected StudentsAppService()
    {
        LocalizationResource = typeof(StudentsResource);
    }
}
