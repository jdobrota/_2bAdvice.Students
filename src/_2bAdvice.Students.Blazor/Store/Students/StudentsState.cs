using System;
using System.Collections.Generic;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store.Students;

public record StudentsState
{
    /// <summary>
    /// Gets the students.
    /// </summary>
    /// <value>
    /// The students.
    /// </value>
    public List<StudentDto>? Students { get; init; }

    /// <summary>
    /// Gets a value indicating whether this instance is error.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
    /// </value>
    public bool IsError { get; init; }

    /// <summary>
    /// Gets a value indicating whether this instance is loading.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is loading; otherwise, <c>false</c>.
    /// </value>
    public bool IsLoading { get; init; }

    /// <summary>
    /// Gets a value indicating whether this instance is initialized.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
    /// </value>
    public bool IsInitialized { get; init; }

    /// <summary>
    /// Gets the student to add or edit.
    /// </summary>
    /// <value>
    /// The student to add or edit.
    /// </value>
    public UpdateStudentDto? StudentToAddOrEdit { get; init; }

    /// <summary>
    /// Gets a value indicating whether this instance is submitting.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is submitting; otherwise, <c>false</c>.
    /// </value>
    public bool IsSubmitting { get; init; }

    /// <summary>
    /// Gets a value indicating whether this instance is edit mode.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
    /// </value>
    public bool IsEditMode { get; init; }

    /// <summary>
    /// Gets the student to remove.
    /// </summary>
    /// <value>
    /// The student to remove.
    /// </value>
    public StudentDto? StudentToRemove { get; init; }

    /// <summary>
    /// Gets the students query parameters.
    /// </summary>
    /// <value>
    /// The students query parameters.
    /// </value>
    public string? QueryParameters { get; init; }
}

[FeatureState]
public class StudentsFeatureState : Feature<StudentsState>
{
    /// <summary>
    /// Gets or sets the student service.
    /// </summary>
    /// <value>
    /// The student service.
    /// </value>
    [Inject]
    IStudentService? StudentService { get; set; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <returns>
    ///   <br />
    /// </returns>
    public override string GetName()
    {
        return nameof(StudentsFeatureState);
    }

    /// <summary>
    /// Gets the initial state.
    /// </summary>
    /// <returns>
    ///   <br />
    /// </returns>
    protected override StudentsState GetInitialState()
    {
        return new StudentsState()
        {
            Students = new(),
            IsError = false,
            IsLoading = false,
            StudentToAddOrEdit = new UpdateStudentDto(),
            IsSubmitting = false,
            IsEditMode = false,
            StudentToRemove = new StudentDto(),
            QueryParameters = string.Empty,
        };
    }
}
