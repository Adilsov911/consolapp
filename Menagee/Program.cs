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
            GroupRepositories groupRepositories = new GroupRepositories();
            GroupController groupController = new GroupController();
            Helper.WriteTextWithColor(ConsoleColor.Green, "Welcome");
           Console.WriteLine("-----");

            while (true)
            {
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Group");
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "4 - GetAll Group");
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get  Group by name");
                Helper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                Console.WriteLine("-----");
                Helper.WriteTextWithColor(ConsoleColor.Blue, "Select option");
                string number = Console.ReadLine();

                int selectnumber;
                bool result = int.TryParse(number, out selectnumber);
                if (result)
                {
                    if (selectnumber >= 0 && selectnumber<=5)
                    {
                        switch (selectnumber)
                        {
                            #region CreatGroup
                            case (int)Options.CreatGroup:
                                groupController.CreatGroup();
                                break;
                            #endregion
                            #region UpdateGroup
                            case (int)Options.UpdateGroup:
                                groupController.UpdateGroup();
                                break;
                            #endregion
                            #region DeleteGroup
                            case (int)Options.DeleteGroup:
                                groupController.DeleteGroup();
                                break;
                            #endregion
                            #region AllGroups
                            case (int)Options.AllGroups:
                                groupController.GetAll();
                                break;
                            #endregion
                            #region GetGroupName
                            case (int)Options.GetGroupByName:
                                groupController.GetGroupName();
                                break;
                            #endregion
                            #region Exit
                            case (int)Options.Exit:
                               groupController.Exit();
                                return;
                                #endregion 
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                    }

                }
                else
                {
                    Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                }


            }



        }
    }
}
