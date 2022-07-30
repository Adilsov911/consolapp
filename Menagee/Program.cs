using Core.Constant;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using Menage.Contreoller;
using System;


namespace Menagee
{
    internal class Program
    {

        static void Main(string[] args)
        {
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();
            AdminController admincontroller = new AdminController();
            TeacherController teacherController = new TeacherController();

           Admin: var admin = admincontroller.Authenticade();

            if (admin != null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Helper.WriteTextWithColor(ConsoleColor.White, "------");

                while (true)
                {
                    Helper.WriteTextWithColor(ConsoleColor.Blue, "Main Menu:");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Group Menu - 1");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Student Menu - 2");
                    Helper.WriteTextWithColor(ConsoleColor.Cyan, "Teacher Menu - 3");


                    Console.WriteLine("--------------------------------------------------");

                    Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);

                    
                    if (result)
                    {
                        if (selectedNumber == 1)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group By Name");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Back Main Menu");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {

                                    case (int)GroupOptions.CreateGroup:
                                        groupController.CreatGroup();
                                        break;
                                    case (int)GroupOptions.UpdateGroup:
                                        groupController.UpdateGroup();
                                        break;
                                    case (int)GroupOptions.DeleteGroup:
                                        groupController.DeleteGroup();
                                        break;
                                    case (int)GroupOptions.AllGroup:
                                        groupController.GetAll();
                                        break;
                                    case (int)GroupOptions.GetGroupByName:
                                        groupController.GetGroupName();
                                        break;
                                    case (int)GroupOptions.Exit:
                                        groupController.Exit();
                                        return;
                                    case (int)GroupOptions.BackMainMenu:
                                       
                                        break;

                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                            }
                        }
                       
                        else if (selectedNumber == 2)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Student");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Student");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Student");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Get All Student By Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Student By Group");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "6 - Back Main Menu");
                            Helper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                            Helper.WriteTextWithColor(ConsoleColor.Magenta, "Select Options:");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)StudentOptions.CreateStudent:
                                        studentController.StudentCreat();
                                        break;
                                    case (int)StudentOptions.UpdateStudent:
                                        studentController.UpdateStudent();
                                        break;
                                    case (int)StudentOptions.DeleteStudent:
                                        studentController.StudentDelete();
                                        break;
                                    case (int)StudentOptions.GetAllStudentByGroup:
                                        studentController.GetAllStudentsByGroup();
                                        break;
                                    case (int)StudentOptions.GetStudentByGroup:
                                        studentController.GetStudentByGroup();
                                        break;
                                    case (int)StudentOptions.Exit:
                                        studentController.Exit();
                                        return;
                                   

                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                            }
                        }
                        else if (selectedNumber == 3)
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Green, "1 - Creat Teacher");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "2 - Update Teacher");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "3 - Delete Teacher");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "4 - Get All Teacher");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "5 - Add Teacher To Group");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "6 - All Groups Of Teachers");
                            Helper.WriteTextWithColor(ConsoleColor.Green, "0 - Exit");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)TeacherOptions.CreatTeacher:
                                        teacherController.Creat();
                                        break;
                                    case (int)TeacherOptions.GetAll:
                                        teacherController.GetAll();
                                        break;
                                    case (int)TeacherOptions.UpdateTeacher:
                                        teacherController.Update();
                                        break;
                                    case (int)TeacherOptions.DeleteTeacher:
                                        teacherController.Delete();
                                        break;
                                    case (int)TeacherOptions.AddTeacherGroup:
                                        teacherController.AddGroupToTeacher();
                                        break;
                                    case (int)TeacherOptions.AllGroupsOfTeachers:
                                        teacherController.GetAllGroupsTeachers();
                                        break;
                                }
                            }
                            else
                            {
                                Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                            }
                        }
                        else
                        {
                            Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "Please, Select Correct Options...");
                    }

                }
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Username or Password incorrect");
                goto Admin;
            }




            
        }
        
    }
}

