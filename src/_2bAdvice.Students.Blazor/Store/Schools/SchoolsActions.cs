using System.Collections.Generic;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Store.Schools;

public class SetSchoolsAction
{
    /// <summary>
    /// Gets the schools.
    /// </summary>
    /// <value>
    /// The schools.
    /// </value>
    public List<SchoolDto> Schools { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetStudentsAction" /> class.
    /// </summary>
    /// <param name="schools">
    /// The schools.
    /// </param>
    public SetSchoolsAction(List<SchoolDto> schools)
    {
        this.Schools = schools;
    }
}

public class SetSchoolsInitializedAction { }

public class SetSchoolsErrorAction { }

public class SetSchoolsLoadingAction { }

public class LoadSchoolsAction { }

public class SetSchoolForAddOrEditAction
{
    /// <summary>
    /// Gets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    public UpdateSchoolDto School { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is edit mode.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
    /// </value>
    public bool IsEditMode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetSchoolForAddOrEditAction" /> class.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    /// <param name="isEditMode">
    /// if set to <c>true</c> [is edit mode].
    /// </param>
    public SetSchoolForAddOrEditAction(UpdateSchoolDto school, bool isEditMode)
    {
        this.School = school;
        this.IsEditMode = isEditMode;
    }
}

public class SetSchoolForAddAction
{
    /// <summary>
    /// Gets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    public UpdateSchoolDto School { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetSchoolForAddAction" /> class.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    public SetSchoolForAddAction(UpdateSchoolDto school)
    {
        this.School = school;
    }
}

public class SetSchoolForEditAction
{
    /// <summary>
    /// Gets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    public UpdateSchoolDto School { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetSchoolForEditAction" /> class.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    public SetSchoolForEditAction(UpdateSchoolDto school)
    {
        this.School = school;
    }
}

public class SetSchoolAddedOrEditedAction { }

public class SetAddSchoolSubmittingAction { }

public class DeleteSchoolAction
{
    /// <summary>
    /// Gets the school.
    /// </summary>
    /// <value>
    /// The school.
    /// </value>
    public SchoolDto School { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSchoolAction" /> class.
    /// </summary>
    /// <param name="school">
    /// The school.
    /// </param>
    public DeleteSchoolAction(SchoolDto school)
    {
        this.School = school;
    }
}
