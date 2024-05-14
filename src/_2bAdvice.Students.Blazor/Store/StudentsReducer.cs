using System;
using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public static class StudentsReducer
{
    [ReducerMethod]
    public static StudentsState OnSetStudents(StudentsState state, SetStudentsAction action)
    {
        return state with { Students = action.Students, IsLoading = false, IsError = false };
    }

    [ReducerMethod(typeof(SetStudentsLoadingAction))]
    public static StudentsState OnSetLoading(StudentsState state)
    {
        return state with { IsLoading = true };
    }

    [ReducerMethod(typeof(SetStudentsInitializedAction))]
    public static StudentsState OnSetInitialized(StudentsState state)
    {
        return state with { IsInitialized = true };
    }

    [ReducerMethod(typeof(SetStudentsErrorAction))]
    public static StudentsState OnSetError(StudentsState state)
    {
        return state with { IsError = true };
    }

    [ReducerMethod]
    public static StudentsState OnSetAddOrEditStudent(
        StudentsState state,
        SetStudentForAddOrEditAction action
    )
    {
        return state with { StudentToAddOrEdit = action.Student, };
    }

    [ReducerMethod]
    public static StudentsState OnDeleteStudent(StudentsState state, DeleteStudentAction action)
    {
        return state with { StudentToRemove = action.Student, };
    }

    [ReducerMethod(typeof(SetStudentAddedOrEditedAction))]
    public static StudentsState OnAddedOrEditedStudent(StudentsState state)
    {
        return state with
        {
            StudentToAddOrEdit = state.IsEditMode
                ? state.StudentToAddOrEdit
                : new()
                {
                    DateOfBirth = DateTime.Now,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    TypeOfStudy = StudyTypeEnum.INTERNAL
                },
            IsSubmitting = false,
        };
    }

    [ReducerMethod]
    public static StudentsState OnSetStudentForAddOrEdit(
        StudentsState state,
        SetStudentForAddOrEditAction action
    )
    {
        return state with { StudentToAddOrEdit = action.Student, IsEditMode = action.IsEditMode };
    }

    [ReducerMethod(typeof(SetAddStudentSubmittingAction))]
    public static StudentsState OnSetSubmitting(StudentsState state)
    {
        return state with { IsSubmitting = true };
    }
}
