using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;

namespace Menage.Contreoller
{
    public class StudentController
    {
        private StudentRepository studentRepositories;
        private GroupRepositories groupRepositories;
        public StudentController()
        {
            studentRepositories = new StudentRepository();
            groupRepositories = new GroupRepositories();
        }
        #region CreatStudent
        public void StudentCreat()
        {
            var groups = groupRepositories.GetAll();
            if (groups.Count != 0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student name:");
                string name = Console.ReadLine();

                Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student surname:");
                string surname = Console.ReadLine();

                Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter student age:");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);

            AllGroupList: Helper.WriteTextWithColor(ConsoleColor.Green, "All Groups");

                foreach (var group in groups)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                }
                Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter group Name:");
                string groupName = Console.ReadLine();

                var dbGroup = groupRepositories.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbGroup != null)
                {
                    if (dbGroup.MaxSize > dbGroup.CurrentSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            Age = studentAge,
                            Group = dbGroup

                        };
                        dbGroup.CurrentSize++;

                        studentRepositories.Create(student);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"Name: {student.Name} Surname: {student.Surname} Age:{student.Age} Group:{dbGroup.Name}");
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, $"Group is full, max size of group{dbGroup.MaxSize}");
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Including group doesn't exist");
                    goto AllGroupList;
                }




            }
        }
        #endregion
        #region GetAllStudentsByGroup
        public void GetStudentsByGroup()
        {
            var groups = groupRepositories.GetAll();

        Grouplist: Helper.WriteTextWithColor(ConsoleColor.Yellow, "All Group");

            foreach (var group in groups)
            {
                Helper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
            }
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name: ");
            string groupName = Console.ReadLine();

            var dbGroup = groupRepositories.Get(g => g.Name.ToLower()==groupName.ToLower());
            if (dbGroup!=null)
            {
                var groupStudents = studentRepositories.GetAll(s => s.Group.Id == dbGroup.Id);
                if (groupStudents.Count!= 0)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Magenta, "All studets of the group:");
                    foreach(var groupStudent in groupStudents)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name} {groupStudent.Surname} {groupStudent.Age}");

                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red,$"There is no student in this group - {dbGroup.Name}");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Including group dosen't exist");
                goto Grouplist;
            }
        }
        #endregion
        #region DeleteStudent
        public void StudentDelete()
        {
            var groups = groupRepositories.GetAll();

           Helper.WriteTextWithColor(ConsoleColor.Yellow, "All Group");

            foreach (var group in groups)
            {
                Helper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
            }
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name: ");
            string groupName = Console.ReadLine();

            var dbGroup = groupRepositories.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {

                    Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Name Student:");
                string name = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Surname Student:");
                string surname = Console.ReadLine();
                var student = studentRepositories.Get(g => g.Name.ToLower() == name.ToLower());
                if (name != null)
                {
                    student = studentRepositories.Get(g => g.Surname.ToLower() == surname.ToLower());
                    if (surname!=null)
                    {
                        studentRepositories.Delete(student);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{name} {surname} is Student Deleted");
                        

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "There is no student with this Surname");
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "There is no student with this Name");
                }

            }


        }
        #endregion

        public void GetStudentByGroup()
        {
            var groups = groupRepositories.GetAll();

         Helper.WriteTextWithColor(ConsoleColor.Yellow, "All Group");

            foreach (var group in groups)
            {
                Helper.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
            }
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name: ");
            string groupName = Console.ReadLine();
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Student Name: ");
            string name = Console.ReadLine();

            var dbGroup = groupRepositories.GetAll(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
              var  student = studentRepositories.Get(g => g.Name.ToLower() == name.ToLower());
                if (name!=null)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Name student: {student.Name} Surname: {student.Surname} Age : {student.Age}");
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "There is no student with this name");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Including group dosen't exist");
                
            }
        }
    }

}
