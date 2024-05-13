using System.Threading.Tasks;
using Fluxor;
using Microsoft.AspNetCore.Components;
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

    //[ReducerMethod]
    //public static StudentsState OnAddStudent(StudentsState state, AddStudentAction action)
    //{
    //    return state;
    //}
}
