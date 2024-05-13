using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public class StudentsEffects
{
    private readonly IStudentService _studentService;
    private readonly IState<StudentsState> _studentsState;

    public StudentsEffects(IStudentService studentService, IState<StudentsState> studentsState)
    {
        this._studentService = studentService;
        this._studentsState = studentsState;
    }

    [EffectMethod(typeof(LoadStudentsAction))]
    public async Task LoadStudents(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetStudentsLoadingAction());
        var response = await this._studentService.GetStudentsAsync();
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentsAction(response.Data!));
    }

    //[EffectMethod]
    //public async Task AddStudent(IDispatcher dispatcher, AddStudentAction action)
    //{
    //    var response = await this._studentService.PostStudentAsync(action.Student);
    //    if (!response.Success)
    //    {
    //        dispatcher.Dispatch(new SetStudentsErrorAction());
    //    }
    //    dispatcher.Dispatch(new LoadStudentsAction());
    //}
}
