using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store.Schools;

namespace _2bAdvice.Students.Blazor.Pages.Schools;

public partial class SchoolForm
{
    /// <summary>
    /// Gets or sets the state of the schools.
    /// </summary>
    /// <value>
    /// The state of the schools.
    /// </value>
    [Inject]
    IState<SchoolsState>? SchoolsState { get; set; }

    /// <summary>
    /// Gets or sets the dispatcher.
    /// </summary>
    /// <value>
    /// The dispatcher.
    /// </value>
    [Inject]
    IDispatcher? Dispatcher { get; set; }

    /// <summary>
    /// Gets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    private UpdateSchoolDto School => this.SchoolsState!.Value.SchoolToAddOrEdit!;

    /// <summary>
    /// Gets a value indicating whether this instance is submitting.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is submitting; otherwise, <c>false</c>.
    /// </value>
    private bool IsSubmitting => this.SchoolsState!.Value.IsSubmitting!;

    /// <summary>
    /// Gets a value indicating whether this instance is edit mode.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
    /// </value>
    private bool IsEditMode => this.SchoolsState!.Value.IsEditMode!;

    /// <summary>
    /// Handles the submit form.
    /// </summary>
    private void HandleSubmitForm()
    {
        if (this.IsEditMode)
        {
            this.Dispatcher!.Dispatch(new SetSchoolForEditAction(this.School));
        }
        else
        {
            this.Dispatcher!.Dispatch(new SetSchoolForAddAction(this.School));
        }
    }
}
