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
        public void GetAllStudentsByGroup()
        {
            var groups = groupRepositories.GetAll();
            if (groups.Count > 0)
            {

                Helper.WriteTextWithColor(ConsoleColor.Yellow, "All Group");

                foreach (var group in groups)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Yellow, $"Id- {group.Id} {group.Name}");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Id: ");
                string id = Console.ReadLine();
                int groupId;
                var result = int.TryParse(id, out groupId);
                if (result)
                {
                    var group = groupRepositories.Get(g => g.Id == groupId);
                    if (group != null)
                    {
                        var groupStudent = studentRepositories.GetAll();
                        if (groupStudent.Count != 0)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "All studets of the group:");
                            foreach (var Student in groupStudent)
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Green, $"Name:{Student.Name} Surname: {Student.Surname} Age: {Student.Age} ID: {Student.Id}");

                            }
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Not student this group");
                        }


                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                        goto id;
                    }

                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct format id");
                }


            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Nothing groups");
            }

        }
        #endregion
        #region DeleteStudent
        public void StudentDelete()
        {
            var students = studentRepositories.GetAll();
            if (students.Count > 0)
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Students List");
            {
                foreach (var student in students)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {student.Id} FullName - {student.Name} {student.Surname}");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter student Id");
                string id = Console.ReadLine();
                int studentId;
                var result = int.TryParse(id, out studentId);
                if (true)
                {
                    var student = studentRepositories.Get(t => t.Id == studentId);
                    if (student != null)
                    {
                        string fullName = $"{student.Name} {student.Surname}";
                        studentRepositories.Delete(student);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{student.Name} {student.Surname} is deleted");

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Student donsn't with dis id");
                        goto id;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct id");
                    goto id;
                }
            }
        }
        #endregion
        #region GetStudentByGroup
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
                var student = studentRepositories.Get(g => g.Name.ToLower() == name.ToLower());
                if (name != null)
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
        #endregion
        #region UpdateStudnet
        public void UpdateStudent()
        {

            GetAllStudentsByGroup();

            Helper.WriteTextWithColor(ConsoleColor.Yellow, "Please enter id");
            string id = Console.ReadLine();
            int studentid;
            bool result = int.TryParse(id, out studentid);
            var student = studentRepositories.Get(s => s.Id == studentid);
            if (studentid != null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new student name");
                string newName = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new student surname");
                string newSurname = Console.ReadLine();
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "Please enter new student age");
                string Age = Console.ReadLine();
                byte newAge;
                result = byte.TryParse(Age, out newAge);
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter new group name");
                string newGroupName = Console.ReadLine();
                if (student.Group.Name.ToLower() == newGroupName)
                {
                    student.Surname = newSurname;
                    student.Name = newName;
                    student.Age = newAge;
                    studentRepositories.Update(student);
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"New name :{newName} New Surname: {newSurname} New Age: {newAge} Group: {newGroupName}");
                }
                else
                {

                    if (student.Group != null)
                    {
                        student.Surname = newSurname;
                        student.Name = newName;
                        student.Age = newAge;
                        studentRepositories.Update(student);
                        student.Group.CurrentSize--;
                        student.Group = groupRepositories.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                        student.Group.CurrentSize++;
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"New Name: {newName} New Surname: {newSurname} New Age: {newAge} New Group Name: {newGroupName}");

                    }


                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct student ID");

            }

        }

        #endregion
        public void Exit()
        {
            Helper.WriteTextWithColor(ConsoleColor.Green, "Thanks Using our Aplication");
        }
    }

}
