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
            GroupController _groupController = new GroupController();
            StudentController _studentController = new StudentController();



           Helper.WriteTextWithColor(ConsoleColor.Green, "Welcome");
            Console.WriteLine("--------------------------------------------------");



            while (true)
            {


            Mainmenu: Helper.WriteTextWithColor(ConsoleColor.Magenta, "Main Menu:");
                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Group Menu - 1");
               Helper.WriteTextWithColor(ConsoleColor.Cyan, "Student Menu - 2");

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
                                    _groupController.CreatGroup();
                                    break;
                                case (int)GroupOptions.UpdateGroup:
                                    _groupController.UpdateGroup();
                                    break;
                                case (int)GroupOptions.DeleteGroup:
                                    _groupController.DeleteGroup();
                                    break;
                                case (int)GroupOptions.AllGroup:
                                    _groupController.GetAll();
                                    break;
                                case (int)GroupOptions.GetGroupByName:
                                    _groupController.GetGroupName();
                                    break;
                                case (int)GroupOptions.Exit:
                                    _groupController.Exit();
                                    return;
                                case (int)GroupOptions.BackMainMenu:
                                    goto Mainmenu;
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

                                case (int)StudentOptions.UpdateStudent:
                                    _studentController.UpdateStudent();
                                    break;
                                case (int)StudentOptions.DeleteStudent:
                                    _studentController.StudentDelete();
                                    break;
                                case (int)StudentOptions.GetAllStudentByGroup:
                                    _studentController.GetAllStudentsByGroup();
                                    break;
                                case (int)StudentOptions.GetStudentByGroup:
                                    _studentController.GetStudentByGroup();
                                    break;
                                case (int)StudentOptions.Exit:
                                    _studentController.Exit();
                                    return;
                                case (int)StudentOptions.BackMainMenu:
                                    goto Mainmenu;
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
        
    }

}
      
