using System;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public static class StudentsReducer
{
    /// <summary>
    /// Called when [set students].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod]
    public static StudentsState OnSetStudents(StudentsState state, SetStudentsAction action)
    {
        return state with { Students = action.Students, IsLoading = false, IsError = false };
    }

    /// <summary>
    /// Called when [set loading].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod(typeof(SetStudentsLoadingAction))]
    public static StudentsState OnSetLoading(StudentsState state)
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
    /// StudentsState
    /// </returns>
    [ReducerMethod(typeof(SetStudentsInitializedAction))]
    public static StudentsState OnSetInitialized(StudentsState state)
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
    /// StudentsState
    /// </returns>
    [ReducerMethod(typeof(SetStudentsErrorAction))]
    public static StudentsState OnSetError(StudentsState state)
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
    /// StudentsState
    /// </returns>
    [ReducerMethod]
    public static StudentsState OnSetAddOrEditStudent(
        StudentsState state,
        SetStudentForAddOrEditAction action
    )
    {
        return state with { StudentToAddOrEdit = action.Student, };
    }

    /// <summary>
    /// Called when [delete student].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod]
    public static StudentsState OnDeleteStudent(StudentsState state, DeleteStudentAction action)
    {
        return state with { StudentToRemove = action.Student, };
    }

    /// <summary>
    /// Called when [added or edited student].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod(typeof(SetStudentAddedOrEditedAction))]
    public static StudentsState OnAddedOrEditedStudent(StudentsState state)
    {
        return state with
        {
            StudentToAddOrEdit = state.IsEditMode
                ? state.StudentToAddOrEdit
                : new UpdateStudentDto(),
            IsSubmitting = false,
        };
    }

    /// <summary>
    /// Called when [set student for add or edit].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <param name="action">
    /// The action.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod]
    public static StudentsState OnSetStudentForAddOrEdit(
        StudentsState state,
        SetStudentForAddOrEditAction action
    )
    {
        return state with { StudentToAddOrEdit = action.Student, IsEditMode = action.IsEditMode };
    }

    /// <summary>
    /// Called when [set submitting].
    /// </summary>
    /// <param name="state">
    /// The state.
    /// </param>
    /// <returns>
    /// StudentsState
    /// </returns>
    [ReducerMethod(typeof(SetAddStudentSubmittingAction))]
    public static StudentsState OnSetSubmitting(StudentsState state)
    {
        return state with { IsSubmitting = true };
    }
}
