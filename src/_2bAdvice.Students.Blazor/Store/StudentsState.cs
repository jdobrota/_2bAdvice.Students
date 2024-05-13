using System.Collections.Generic;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public record StudentsState
{
    public List<StudentDto> Students = new();

    public bool IsError = false;

    public bool IsLoading = false;

    public bool IsInitialized = false;
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
            IsLoading = false
        };
    }
}
