using Core.Constant;
using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;


namespace Menagee
{
    internal class Program
    { 

        static void Main(string[] args)
        {
            GroupRepositories groupRepositories = new GroupRepositories();
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
                                Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Name:");
                                string name = Console.ReadLine();
                                MaxSize:Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter group Max Size:");
                                string size = Console.ReadLine();
                                int maxSize;
                                result = int.TryParse(size, out maxSize);
                                if (result)
                                {
                                    Group group = new Group()
                                    {
                                        Name = name,
                                        MaxSize = maxSize,

                                    };
                                    var createdGroup = groupRepositories.Create(group);
                                    Helper.WriteTextWithColor(ConsoleColor.Green,$"{createdGroup.Name} is succesfully created with max size - {createdGroup.MaxSize}");
                                }
                                else
                                {
                                    Helper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size");
                                    goto MaxSize;
                                }
                                break;
                            #endregion
                            case (int)Options.UpdateGroup:
                                break;
                            case (int)Options.DeleteGroup:
                                break;
                            case (int)Options.AllGroups:
                                var groups = groupRepositories.GetAll();
                                Helper.WriteTextWithColor(ConsoleColor.Magenta, "All Groups");
                                foreach(var group in groups)
                                {
                                    Console.WriteLine($"Name:{group.Name} , Max Size: {group.MaxSize}");
                                }

                                break;
                            case (int)Options.GetGroupByName:
                                break;
                            case (int)Options.Exit:
                                Helper.WriteTextWithColor(ConsoleColor.Green, "Thanks Using our Aplication");
                                return;
                        }
                    }
                    else
                    {
                        Helper.WriteTextWithColor(ConsoleColor.Red, "please enter correct number");
                    }

                }
                else
                {

                }


            }



        }
    }
}
