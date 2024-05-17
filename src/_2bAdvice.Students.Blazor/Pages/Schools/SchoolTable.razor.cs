using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Store.Schools;

namespace _2bAdvice.Students.Blazor.Pages.Schools;

public partial class SchoolTable
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
    /// Gets or sets the state of the schools.
    /// </summary>
    /// <value>
    /// The state of the schools.
    /// </value>
    [Inject]
    IState<SchoolsState>? SchoolsState { get; set; }

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
    private List<SchoolDto>? Schools => this.SchoolsState!.Value.Schools;

    /// <summary>
    /// Gets a value indicating whether this instance is loading.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is loading; otherwise, <c>false</c>.
    /// </value>
    private bool IsLoading => this.SchoolsState!.Value.IsLoading;

    /// <summary>
    /// Gets a value indicating whether this instance is error.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
    /// </value>
    private bool IsError => this.SchoolsState!.Value.IsError;

    /// <summary>
    /// Method invoked when the component is ready to start, having received its
    /// initial parameters from its parent in the render tree.
    /// Override this method if you will perform an asynchronous operation and
    /// want the component to refresh when that operation is completed.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        if (this.SchoolsState!.Value.IsInitialized == false)
        {
            this.Dispatcher!.Dispatch(new LoadSchoolsAction());
        }
        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Deletes the school.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    private void DeleteSchool(SchoolDto school)
    {
        this.Dispatcher!.Dispatch(new DeleteSchoolAction(school));
    }

    /// <summary>
    /// Sets the school for edit.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    private void SetSchoolForEdit(SchoolDto school)
    {
        var schoolCreateDto = this.ObjectMapper!.Map<SchoolDto, UpdateSchoolDto>(school);

        this.Dispatcher!.Dispatch(new SetSchoolForAddOrEditAction(schoolCreateDto, true));
    }

    /// <summary>
    /// Adds the school.
    /// </summary>
    private void AddSchool()
    {
        this.Dispatcher!.Dispatch(new SetSchoolForAddOrEditAction(new UpdateSchoolDto(), false));
    }
}
