﻿using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store;

namespace _2bAdvice.Students.Blazor.Pages.Students;

public partial class AddStudentModal
{
    [Inject]
    IDispatcher? Dispatcher { get; set; }

    private CreateUpdateStudentDto? Student;

    private void HandleCreate()
    {
        //this.Dispatcher!.Dispatch(new AddStudentAction(this.Student!));
    }
}