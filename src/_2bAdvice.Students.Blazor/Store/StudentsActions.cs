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

public class LoadStudentsAction() { }

//public class AddStudentAction
//{
//    public CreateUpdateStudentDto Student { get; }

//    public AddStudentAction(CreateUpdateStudentDto student)
//    {
//        this.Student = student;
//    }
//}
