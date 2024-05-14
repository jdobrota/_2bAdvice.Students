using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store;

public class StudentsEffects
{
    private readonly IStudentService _studentService;
    private readonly IState<StudentsState> _studentsState;
    private readonly IObjectMapper _objectMapper;

    public StudentsEffects(
        IStudentService studentService,
        IState<StudentsState> studentsState,
        IObjectMapper objectMapper
    )
    {
        this._studentService = studentService;
        this._studentsState = studentsState;
        this._objectMapper = objectMapper;
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

    [EffectMethod(typeof(SetStudentForAddAction))]
    public async Task AddStudent(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddStudentSubmittingAction());
        var studentCreateDto = this._objectMapper!.Map<UpdateStudentDto, CreateStudentDto>(
            this._studentsState.Value.StudentToAddOrEdit!
        );
        var response = await this._studentService.PostStudentAsync(studentCreateDto);
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentAddedOrEditedAction());
        dispatcher.Dispatch(new LoadStudentsAction());
    }

    [EffectMethod(typeof(SetStudentForEditAction))]
    public async Task EditStudent(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddStudentSubmittingAction());
        var response = await this._studentService.PutStudentAsync(
            this._studentsState.Value.StudentToAddOrEdit!
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentAddedOrEditedAction());
        dispatcher.Dispatch(new LoadStudentsAction());
    }

    [EffectMethod(typeof(DeleteStudentAction))]
    public async Task DeleteStudent(IDispatcher dispatcher)
    {
        var response = await this._studentService.DeleteStudentAsync(
            this._studentsState.Value.StudentToRemove!.Id
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new LoadStudentsAction());
    }

    //[EffectMethod(typeof(SetEditStudentAction))]
    //public void EditStudent(IDispatcher dispatcher)
    //{
    //    var studentCreateDto = this._objectMapper.Map<StudentDto, CreateStudentDto>(
    //        this._studentsState.Value.StudentToEdit!
    //    );
    //}
}
