using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constant
{
    public enum GroupOptions
    {
        Exit,
        CreateGroup,
        UpdateGroup,
        DeleteGroup,
        AllGroup,
        GetGroupByName,
        BackMainMenu,

    }
    public enum StudentOptions
    {
        Exit,
        CreateStudent,
        UpdateStudent,
        DeleteStudent,
        GetAllStudentByGroup,
        GetStudentByGroup
        
    }
    public enum TeacherOptions
    {
        Exit,
        CreatTeacher,
        UpdateTeacher,
        DeleteTeacher,
        GetAll,
        AddTeacherGroup,
        AllGroupsOfTeachers
    }
}
