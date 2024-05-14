using System;
using AutoMapper;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store;

namespace _2bAdvice.Students.Blazor.Pages.Students;

public partial class StudentForm
{
    [Inject]
    IState<StudentsState>? StudentsState { get; set; }

    [Inject]
    IDispatcher? Dispatcher { get; set; }

    private UpdateStudentDto Student => this.StudentsState!.Value.StudentToAddOrEdit!;

    private bool IsSubmitting => this.StudentsState!.Value.IsSubmitting!;

    private bool IsEditMode => this.StudentsState!.Value.IsEditMode!;

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
