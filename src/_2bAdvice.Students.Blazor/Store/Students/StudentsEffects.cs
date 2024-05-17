using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.Student;

namespace _2bAdvice.Students.Blazor.Store.Students;

public class StudentsEffects
{
    /// <summary>
    /// The student service
    /// </summary>
    private readonly IStudentService? _studentService;

    /// <summary>
    /// The students state
    /// </summary>
    private readonly IState<StudentsState>? _studentsState;

    /// <summary>
    /// The object mapper
    /// </summary>
    private readonly IObjectMapper? _objectMapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsEffects" /> class.
    /// </summary>
    /// <param name="studentService">
    /// The student service.
    /// </param>
    /// <param name="studentsState">
    /// State of the students.
    /// </param>
    /// <param name="objectMapper">
    /// The object mapper.
    /// </param>
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

    /// <summary>
    /// Loads the students.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(LoadStudentsAction))]
    public async Task LoadStudents(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetStudentsLoadingAction());
        var response = await this._studentService!.GetStudentsAsync(
            this._studentsState!.Value.QueryParameters!
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentsAction(response.Data!));
    }

    /// <summary>
    /// Adds the student.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(SetStudentForAddAction))]
    public async Task AddStudent(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddStudentSubmittingAction());
        var studentCreateDto = this._objectMapper!.Map<UpdateStudentDto, CreateStudentDto>(
            this._studentsState!.Value.StudentToAddOrEdit!
        );
        var response = await this._studentService!.PostStudentAsync(studentCreateDto);
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentAddedOrEditedAction());
        dispatcher.Dispatch(new LoadStudentsAction());
    }

    /// <summary>
    /// Edits the student.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(SetStudentForEditAction))]
    public async Task EditStudent(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddStudentSubmittingAction());
        var response = await this._studentService!.PutStudentAsync(
            this._studentsState!.Value.StudentToAddOrEdit!
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new SetStudentAddedOrEditedAction());
        dispatcher.Dispatch(new LoadStudentsAction());
    }

    /// <summary>
    /// Deletes the student.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(DeleteStudentAction))]
    public async Task DeleteStudent(IDispatcher dispatcher)
    {
        var response = await this._studentService!.DeleteStudentAsync(
            this._studentsState!.Value.StudentToRemove!.Id
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetStudentsErrorAction());
        }
        dispatcher.Dispatch(new LoadStudentsAction());
    }
}
