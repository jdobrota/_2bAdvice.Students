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
    /// <summary>
    /// Gets or sets the object mapper.
    /// </summary>
    /// <value>
    /// The object mapper.
    /// </value>
    [Inject]
    IObjectMapper? ObjectMapper { get; set; }

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
    /// Gets the students.
    /// </summary>
    /// <value>
    /// The students.
    /// </value>
    private List<StudentDto>? Students => this.StudentsState!.Value.Students;

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
    /// Method invoked when the component is ready to start, having received its
    /// initial parameters from its parent in the render tree.
    /// Override this method if you will perform an asynchronous operation and
    /// want the component to refresh when that operation is completed.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        if (this.StudentsState!.Value.IsInitialized == false)
        {
            this.Dispatcher!.Dispatch(new LoadStudentsAction());
        }
        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Deletes the student.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    private void DeleteStudent(StudentDto student)
    {
        this.Dispatcher!.Dispatch(new DeleteStudentAction(student));
    }

    /// <summary>
    /// Sets the student for edit.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    private void SetStudentForEdit(StudentDto student)
    {
        var studentCreateDto = this.ObjectMapper!.Map<StudentDto, UpdateStudentDto>(student);

        this.Dispatcher!.Dispatch(new SetStudentForAddOrEditAction(studentCreateDto, true));
    }

    /// <summary>
    /// Adds the student.
    /// </summary>
    private void AddStudent()
    {
        this.Dispatcher!.Dispatch(new SetStudentForAddOrEditAction(new UpdateStudentDto(), false));
    }
}
