using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store;

namespace _2bAdvice.Students.Blazor.Pages.Students;

public partial class StudentTable
{
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
}
