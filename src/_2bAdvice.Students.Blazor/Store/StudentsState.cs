using System;
using System.Collections.Generic;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public record StudentsState
{
    public List<StudentDto>? Students { get; init; }

    public bool IsError { get; init; }

    public bool IsLoading { get; init; }

    public bool IsInitialized { get; init; }

    public UpdateStudentDto? StudentToAddOrEdit { get; init; }

    public bool IsSubmitting { get; init; }

    public bool IsEditMode { get; init; }

    public StudentDto? StudentToRemove { get; init; }
}

[FeatureState]
public class StudentsFeatureState : Feature<StudentsState>
{
    [Inject]
    IStudentService? StudentService { get; set; }

    public override string GetName()
    {
        return nameof(StudentsFeatureState);
    }

    protected override StudentsState GetInitialState()
    {
        return new StudentsState()
        {
            Students = new(),
            IsError = false,
            IsLoading = false,
            StudentToAddOrEdit = new()
            {
                DateOfBirth = DateTime.Now,
                FirstName = string.Empty,
                LastName = string.Empty,
                TypeOfStudy = StudyTypeEnum.INTERNAL
            },
            IsSubmitting = false,
            IsEditMode = false,
            StudentToRemove = new(),
        };
    }
}
