﻿using System.Collections.Generic;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store.Schools;
using _2bAdvice.Students.Blazor.Store.Students;
using _2bAdvice.Students.Localization;

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
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    private UpdateStudentDto Student => this.StudentsState!.Value.StudentToAddOrEdit!;

    /// <summary>
    /// Gets the schools.
    /// </summary>
    /// <value>
    /// The schools.
    /// </value>
    private List<SchoolDto> Schools => this.SchoolsState!.Value.Schools!;

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
    /// Gets or sets the l.
    /// </summary>
    /// <value>
    /// The l.
    /// </value>
    [Inject]
    IStringLocalizer<StudentsResource>? L { get; set; }

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
