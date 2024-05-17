using System;
using System.Collections.Generic;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store.Schools;

public record SchoolsState
{
    /// <summary>
    /// Gets the schools.
    /// </summary>
    /// <value>
    /// The schools.
    /// </value>
    public List<SchoolDto>? Schools { get; init; }

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
    public UpdateSchoolDto? SchoolToAddOrEdit { get; init; }

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
    public SchoolDto? SchoolToRemove { get; init; }

    /// <summary>
    /// Gets the schools query parameters.
    /// </summary>
    /// <value>
    /// The schools query parameters.
    /// </value>
    public string? QueryParameters { get; init; }
}

[FeatureState]
public class SchoolsFeatureState : Feature<SchoolsState>
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
        return nameof(SchoolsFeatureState);
    }

    /// <summary>
    /// Gets the initial state.
    /// </summary>
    /// <returns>
    ///   <br />
    /// </returns>
    protected override SchoolsState GetInitialState()
    {
        return new SchoolsState()
        {
            Schools = new(),
            IsError = false,
            IsLoading = false,
            SchoolToAddOrEdit = new UpdateSchoolDto(),
            IsSubmitting = false,
            IsEditMode = false,
            SchoolToRemove = new SchoolDto(),
            QueryParameters = string.Empty,
        };
    }
}
