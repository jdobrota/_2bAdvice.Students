using System.Collections.Generic;
using _2bAdvice.Students.Blazor.Services.Base;

namespace _2bAdvice.Students.Blazor.Store;

public class SetStudentsAction
{
    public List<StudentDto> Students { get; }

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
    public UpdateStudentDto Student { get; }

    public bool IsEditMode { get; set; }

    public SetStudentForAddOrEditAction(UpdateStudentDto student, bool isEditMode)
    {
        this.Student = student;
        this.IsEditMode = isEditMode;
    }
}

public class SetStudentForAddAction
{
    public UpdateStudentDto Student { get; }

    public SetStudentForAddAction(UpdateStudentDto student)
    {
        this.Student = student;
    }
}

public class SetStudentForEditAction
{
    public UpdateStudentDto Student { get; }

    public SetStudentForEditAction(UpdateStudentDto student)
    {
        this.Student = student;
    }
}

public class SetStudentAddedOrEditedAction { }

public class SetAddStudentSubmittingAction { }

public class DeleteStudentAction
{
    public StudentDto Student { get; }

    public DeleteStudentAction(StudentDto student)
    {
        this.Student = student;
    }
}
