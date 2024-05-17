using System.Threading.Tasks;
using Fluxor;
using Volo.Abp.ObjectMapping;
using _2bAdvice.Students.Blazor.Services.Base;
using _2bAdvice.Students.Blazor.Services.School;

namespace _2bAdvice.Students.Blazor.Store.Schools;

public class SchoolsEffects
{
    /// <summary>
    /// The school service
    /// </summary>
    private readonly ISchoolService? _schoolService;

    /// <summary>
    /// The school state
    /// </summary>
    private readonly IState<SchoolsState>? _schoolsState;

    /// <summary>
    /// The object mapper
    /// </summary>
    private readonly IObjectMapper? _objectMapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="SchoolsEffects" /> class.
    /// </summary>
    /// <param name="schoolService">
    /// The school service.
    /// </param>
    /// <param name="schoolsState">
    /// State of the schools.
    /// </param>
    /// <param name="objectMapper">
    /// The object mapper.
    /// </param>
    public SchoolsEffects(
        ISchoolService schoolService,
        IState<SchoolsState> schoolsState,
        IObjectMapper objectMapper
    )
    {
        this._schoolService = schoolService;
        this._schoolsState = schoolsState;
        this._objectMapper = objectMapper;
    }

    /// <summary>
    /// Loads the schools.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(LoadSchoolsAction))]
    public async Task LoadSchools(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetSchoolsLoadingAction());
        var response = await this._schoolService!.GetSchoolsAsync(
            this._schoolsState!.Value.QueryParameters!
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetSchoolsErrorAction());
        }
        dispatcher.Dispatch(new SetSchoolsAction(response.Data!));
    }

    /// <summary>
    /// Adds the school.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(SetSchoolForAddAction))]
    public async Task AddSchool(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddSchoolSubmittingAction());
        var schoolCreateDto = this._objectMapper!.Map<UpdateSchoolDto, CreateSchoolDto>(
            this._schoolsState!.Value.SchoolToAddOrEdit!
        );
        var response = await this._schoolService!.PostSchoolAsync(schoolCreateDto);
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetSchoolsErrorAction());
        }
        dispatcher.Dispatch(new SetSchoolAddedOrEditedAction());
        dispatcher.Dispatch(new LoadSchoolsAction());
    }

    /// <summary>
    /// Edits the school.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(SetSchoolForEditAction))]
    public async Task EditSchool(IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetAddSchoolSubmittingAction());
        var response = await this._schoolService!.PutSchoolAsync(
            this._schoolsState!.Value.SchoolToAddOrEdit!
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetSchoolsErrorAction());
        }
        dispatcher.Dispatch(new SetSchoolAddedOrEditedAction());
        dispatcher.Dispatch(new LoadSchoolsAction());
    }

    /// <summary>
    /// Deletes the school.
    /// </summary>
    /// <param name="dispatcher">
    /// The dispatcher.
    /// </param>
    [EffectMethod(typeof(DeleteSchoolAction))]
    public async Task DeleteSchool(IDispatcher dispatcher)
    {
        var response = await this._schoolService!.DeleteSchoolAsync(
            this._schoolsState!.Value.SchoolToRemove!.Id
        );
        if (!response.Success)
        {
            dispatcher.Dispatch(new SetSchoolsErrorAction());
        }
        dispatcher.Dispatch(new LoadSchoolsAction());
    }
}
