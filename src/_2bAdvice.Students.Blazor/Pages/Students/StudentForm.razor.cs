using System;
using AutoMapper;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store;

namespace _2bAdvice.Students.Blazor.Pages.Students;

public partial class StudentForm
{
    /// <summary>
    /// Gets or sets the state of the students.
    /// </summary>
    /// <value>
    /// The state of the students.
    /// </value>
    [Inject]
    IState<StudentsState>? StudentsState { get; set; }

    /// <summary>
    /// Gets or sets the dispatcher.
    /// </summary>
    /// <value>
    /// The dispatcher.
    /// </value>
    [Inject]
    IDispatcher? Dispatcher { get; set; }

    /// <summary>
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    private UpdateStudentDto Student => this.StudentsState!.Value.StudentToAddOrEdit!;

    /// <summary>
    /// Gets a value indicating whether this instance is submitting.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is submitting; otherwise, <c>false</c>.
    /// </value>
    private bool IsSubmitting => this.StudentsState!.Value.IsSubmitting!;

    /// <summary>
    /// Gets a value indicating whether this instance is edit mode.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
    /// </value>
    private bool IsEditMode => this.StudentsState!.Value.IsEditMode!;

    /// <summary>
    /// Handles the submit form.
    /// </summary>
    private void HandleSubmitForm()
    {
        if (this.IsEditMode)
        {
            this.Dispatcher!.Dispatch(new SetStudentForEditAction(this.Student));
        }
        else
        {
            this.Dispatcher!.Dispatch(new SetStudentForAddAction(this.Student));
        }
    }
}
