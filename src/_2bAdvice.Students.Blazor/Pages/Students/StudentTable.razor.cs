using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2bAdvice.Students.Blazor.Pages.Students;

public partial class StudentTable
{
    [Inject]
    IObjectMapper? ObjectMapper { get; set; }

    [Inject]
    IState<StudentsState>? StudentsState { get; set; }

    [Inject]
    IDispatcher? Dispatcher { get; set; }

    private List<StudentDto>? Students => this.StudentsState!.Value.Students;

    private bool IsLoading => this.StudentsState!.Value.IsLoading;

    private bool IsError => this.StudentsState!.Value.IsError;

    protected override async Task OnInitializedAsync()
    {
        if (this.StudentsState!.Value.IsInitialized == false)
        {
            this.Dispatcher!.Dispatch(new LoadStudentsAction());
        }
        await base.OnInitializedAsync();
    }

    private void DeleteStudent(StudentDto student)
    {
        this.Dispatcher!.Dispatch(new DeleteStudentAction(student));
    }

    private void SetStudentForEdit(StudentDto student)
    {
        var studentCreateDto = this.ObjectMapper!.Map<StudentDto, UpdateStudentDto>(student);

        this.Dispatcher!.Dispatch(new SetStudentForAddOrEditAction(studentCreateDto, true));
    }

    private void AddStudent()
    {
        this.Dispatcher!.Dispatch(new SetStudentForAddOrEditAction(new UpdateStudentDto(), false));
    }
}
