using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using _2bAdvice.Students.Localization;

namespace _2bAdvice.Students.Blazor.Pages.Schools;

public partial class Index
{
    [Inject]
    IStringLocalizer<StudentsResource>? L { get; set; }
}
