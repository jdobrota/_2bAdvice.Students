using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store.Schools;
using _2bAdvice.Students.Blazor.Store.Students;

namespace _2bAdvice.Students.Blazor.Pages.Schools;

public partial class SchoolTableForStudent
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
    /// Gets a value indicating whether this instance is loading.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is loading; otherwise, <c>false</c>.
    /// </value>
    private bool IsLoading => this.StudentsState!.Value.IsLoading;

    /// <summary>
    /// Gets a value indicating whether this instance is error.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
    /// </value>
    private bool IsError => this.StudentsState!.Value.IsError;

    /// <summary>
    /// Gets or sets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    [Parameter]
    public SchoolDto? School { get; set; } = null;

    /// <summary>
    /// Gets or sets the student identifier.
    /// </summary>
    /// <value>
    /// The student identifier.
    /// </value>
    [Parameter]
    public Guid? StudentId { get; set; }
}
