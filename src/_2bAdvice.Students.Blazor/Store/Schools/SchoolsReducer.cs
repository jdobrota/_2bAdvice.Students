using Fluxor;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Store.Schools;

public static class SchoolsReducer
{
    /// <summary>
    /// Called when [set schools].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod]
    public static SchoolsState OnSetSchools(SchoolsState state, SetSchoolsAction action)
    {
        return state with { Schools = action.Schools, IsLoading = false, IsError = false };
    }

    /// <summary>
    /// Called when [set loading].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod(typeof(SetSchoolsLoadingAction))]
    public static SchoolsState OnSetLoading(SchoolsState state)
    {
        return state with { IsLoading = true };
    }

    /// <summary>
    /// Called when [set initialized].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod(typeof(SetSchoolsInitializedAction))]
    public static SchoolsState OnSetInitialized(SchoolsState state)
    {
        return state with { IsInitialized = true };
    }

    /// <summary>
    /// Called when [set error].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod(typeof(SetSchoolsErrorAction))]
    public static SchoolsState OnSetError(SchoolsState state)
    {
        return state with { IsError = true };
    }

    /// <summary>
    /// Called when [set add or edit student].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod]
    public static SchoolsState OnSetAddOrEditSchool(
        SchoolsState state,
        SetSchoolForAddOrEditAction action
    )
    {
        return state with { SchoolToAddOrEdit = action.School, };
    }

    /// <summary>
    /// Called when [delete school].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod]
    public static SchoolsState OnDeleteStudent(SchoolsState state, DeleteSchoolAction action)
    {
        return state with { SchoolToRemove = action.School, };
    }

    /// <summary>
    /// Called when [added or edited school].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod(typeof(SetSchoolAddedOrEditedAction))]
    public static SchoolsState OnAddedOrEditedSchool(SchoolsState state)
    {
        return state with
        {
            SchoolToAddOrEdit = state.IsEditMode ? state.SchoolToAddOrEdit : new UpdateSchoolDto(),
            IsSubmitting = false,
        };
    }

    /// <summary>
    /// Called when [set school for add or edit].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod]
    public static SchoolsState OnSetSchoolForAddOrEdit(
        SchoolsState state,
        SetSchoolForAddOrEditAction action
    )
    {
        return state with { SchoolToAddOrEdit = action.School, IsEditMode = action.IsEditMode };
    }

    /// <summary>
    /// Called when [set submitting].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// SchoolsState
    /// </returns>
    [ReducerMethod(typeof(SetAddSchoolSubmittingAction))]
    public static SchoolsState OnSetSubmitting(SchoolsState state)
    {
        return state with { IsSubmitting = true };
    }
}
