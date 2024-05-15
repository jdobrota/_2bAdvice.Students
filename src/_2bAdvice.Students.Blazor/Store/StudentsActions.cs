using System.Collections.Generic;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Store;

public class SetStudentsAction
{
    /// <summary>
    /// Gets the students.
    /// </summary>
    /// <value>
    /// The students.
    /// </value>
    public List<StudentDto> Students { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetStudentsAction" /> class.
    /// </summary>
    /// <param name="students">
    /// The students.
    /// </param>
    public SetStudentsAction(List<StudentDto> students)
    {
        this.Students = students;
    }
}

public class SetStudentsInitializedAction { }

public class SetStudentsErrorAction { }

public class SetStudentsLoadingAction { }

public class LoadStudentsAction { }

public class SetStudentForAddOrEditAction
{
    /// <summary>
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    public UpdateStudentDto Student { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is edit mode.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
    /// </value>
    public bool IsEditMode { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetStudentForAddOrEditAction" /> class.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    /// <param name="isEditMode">
    /// if set to <c>true</c> [is edit mode].
    /// </param>
    public SetStudentForAddOrEditAction(UpdateStudentDto student, bool isEditMode)
    {
        this.Student = student;
        this.IsEditMode = isEditMode;
    }
}

public class SetStudentForAddAction
{
    /// <summary>
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    public UpdateStudentDto Student { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetStudentForAddAction" /> class.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    public SetStudentForAddAction(UpdateStudentDto student)
    {
        this.Student = student;
    }
}

public class SetStudentForEditAction
{
    /// <summary>
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    public UpdateStudentDto Student { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetStudentForEditAction" /> class.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    public SetStudentForEditAction(UpdateStudentDto student)
    {
        this.Student = student;
    }
}

public class SetStudentAddedOrEditedAction { }

public class SetAddStudentSubmittingAction { }

public class DeleteStudentAction
{
    /// <summary>
    /// Gets the student.
    /// </summary>
    /// <value>
    /// The student.
    /// </value>
    public StudentDto Student { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteStudentAction" /> class.
    /// </summary>
    /// <param name="student">
    /// The student.
    /// </param>
    public DeleteStudentAction(StudentDto student)
    {
        this.Student = student;
    }
}
