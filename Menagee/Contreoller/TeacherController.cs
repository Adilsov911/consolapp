using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menage.Contreoller
{
    internal class TeacherController
    {
        private TeacherRepository teacherRepository;
        private GroupRepositories groupRepository;

        public TeacherController()
        {
            teacherRepository = new TeacherRepository();
            groupRepository = new GroupRepositories();
        }
        #region Creat
        public void Creat()
        {

            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Teacher name:");
            string name = Console.ReadLine();

            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Teacher surname:");
            string surname = Console.ReadLine();

        age: Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Teacher age:");
            string Age = Console.ReadLine();
            int age;
            bool result = int.TryParse(Age, out age);

            if (result)
            {
                Teacher teacher = new Teacher()
                {
                    Name = name,
                    Surname = surname,
                    Age = age
                };
                var dbTeacher = teacherRepository.Create(teacher);
                if (dbTeacher != null)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Teacher Created Name :{dbTeacher.Name} Surname: {dbTeacher.Surname} Age: {dbTeacher.Age} ");

                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, $"Samtingh went wrong");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Enter correct age");
                goto age;
            }


        }
        #endregion


        public void Update()
        {
            var teachers = teacherRepository.GetAll();

            if (teachers.Count > 0)
            {
                foreach (var teacher in teachers)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Yellow, $"Id -{teacher.Id},Full Name - {teacher.Name} {teacher.Surname}");
                id: Helper.WriteTextWithColor(ConsoleColor.Magenta, "Enter teacher Id:");
                    string id = Console.ReadLine();
                    int teacherId;
                    var result = int.TryParse(id, out teacherId);
                    if (true)
                    {
                        var dbTeacher = teacherRepository.Get(t => t.Id == teacherId);
                        if (dbTeacher != null)
                        {
                            string oldName = dbTeacher.Name;
                            string oldSurname = dbTeacher.Surname;
                            int oldAge = dbTeacher.Age;
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher new Name");
                            string newName = Console.ReadLine();
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher new Surname");
                            string newSurname = Console.ReadLine();
                        Newage: Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher new Age");
                            string newAge = Console.ReadLine();
                            byte teacherNewAge;
                            result = byte.TryParse(newAge, out teacherNewAge);
                            if (result)
                            {
                                var updatedTeacher = new Teacher
                                {
                                    Id = teacherId,
                                    Name = newName,
                                    Surname = newSurname,
                                    Age = teacherNewAge,
                                };
                                teacherRepository.Update(updatedTeacher);
                                Helper.WriteTextWithColor(ConsoleColor.Green, $"{oldName} {oldSurname} {oldAge} is updatet {updatedTeacher.Name} {updatedTeacher.Surname} {updatedTeacher.Age}");
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "please enter age in correct format");
                                goto Newage;
                            }

                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Teacher dosnt exsost whit this id");
                            goto id;
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "please enter id corret format");
                        goto id;
                    }

                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "not teacher");

            }
        }

        public void Delete()
        {
            var teachers = teacherRepository.GetAll();
            if (teachers.Count > 0)
                Helper.WriteTextWithColor(ConsoleColor.Green, "All Teachers List");
            {
                foreach (var teacher in teachers)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} FullName - {teacher.Name} {teacher.Surname}");
                }
            id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Teacher Id");
                string id = Console.ReadLine();
                int teacherId;
                var result = int.TryParse(id, out teacherId);
                if (true)
                {
                    var teacher = teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher != null)
                    {
                        string fullName = $"{teacher.Name} {teacher.Surname}";
                        teacherRepository.Delete(teacher);
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{fullName} is deleted");

                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "teacher donsn't with dis id");
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

        public void GetAll()
        {
            var teachers = teacherRepository.GetAll();
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "All Teachers");
            if (teachers.Count > 0)
            {

                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.Id} {teacher.Name} {teacher.Surname} ");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "there is no any teacher");
            }
        }

        public void AddGroupToTeacher()
        {
            var groups = groupRepository.GetAll();
            if (groups.Count > 0)
            {

                var teachers = teacherRepository.GetAll();
                if (teachers.Count > 0)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, "All List Teachers");
                    foreach (var teacher in teachers)
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} FullName - {teacher.Name} {teacher.Surname}");
                    }
                id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter Teacher Id");
                    string id = Console.ReadLine();
                    int teacherId;
                    var result = int.TryParse(id, out teacherId);
                    if (result)
                    {
                        var teacher = teacherRepository.Get(t => t.Id == teacherId);
                        if (teacher != null)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, "All Groups list");
                            foreach (var group in groups)
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {group.Id} Name - {group.Name}");
                            }
                        it: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter group Id");
                            string groupid = Console.ReadLine();
                            int groupId;
                            result = int.TryParse(groupid, out groupId);
                            if (result)
                            {
                                var group = groupRepository.Get(g => g.Id == groupId);
                                if (group != null)
                                {
                                    if (group.Teacher == null)
                                    {
                                        teacher.Groups.Add(group);
                                        group.Teacher = teacher;
                                        Helper.WriteTextWithColor(ConsoleColor.Green, $"{group.Name} is succesfully added to {teacher.Name}");

                                    }
                                    else
                                    {
                                        Helper.WriteTextWithColor(ConsoleColor.Red, $"this group already has teacher {group.Teacher.Name} {group.Teacher.Surname} ");
                                    }


                                }
                                else
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Red, "Group dosnt whit this id ");
                                    goto it;
                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format");
                                goto it;
                            }
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "taecher dosnt exist whit dis id");
                            goto id;
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Please enter id in correct format");
                        goto id;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "There is no any teacher");
                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "You most creat a group beafore adding group to teacher");
            }


        }

        public void GetAllGroupsTeachers()
        {
            var teachers = teacherRepository.GetAll();
            if (teachers.Count>0)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, "All List Teachers");
                foreach (var teacher in teachers)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Id - {teacher.Id} FullName - {teacher.Name} {teacher.Surname}");
                }
                 id: Helper.WriteTextWithColor(ConsoleColor.Green, "Enter teacher id: ");
                string id = Console.ReadLine();

                int teacherId;
                var result = int.TryParse(id, out teacherId);
                if (result)
                {
                    var teacher = teacherRepository.Get(t => t.Id == teacherId);
                    if (teacher!=null)
                    {
                        var groups = groupRepository.GetAll(g => g.Teacher.Id == teacher.Id);
                        if (groups.Count>0)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, " The groups of teacher");
                            foreach (var group in groups)
                            {

                                Helper.WriteTextWithColor(ConsoleColor.Cyan, $"Id - {group.Id}, Name-{group.Name} ");
                            
                            }
                            
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Teacher has no group");
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Teacher dosnt exisit whit this id");
                        goto id;
                    }
                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "Enter id in correct format ");
                    goto id;
                }

            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "there is no any teacher ");
            }
        }



    }
}



