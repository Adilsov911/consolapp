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
    public class GroupController
    {
        private GroupRepositories groupRepositories;

        public GroupController()
        {
            groupRepositories = new GroupRepositories();
        }


        #region CreatGroup
        public void CreatGroup()
        {
            Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Group Name:");
            string name = Console.ReadLine();
        MaxSize: Helper.WriteTextWithColor(ConsoleColor.Cyan, "Enter group Max Size:");
            string size = Console.ReadLine();
            int maxSize;
            bool result = int.TryParse(size, out maxSize);
            if (result)
            {
                Group group = new Group()
                {
                    Name = name,
                    MaxSize = maxSize,

                };
                var createdGroup = groupRepositories.Create(group);
                Helper.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is succesfully created with max size - {createdGroup.MaxSize}");
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max size");
                goto MaxSize;
            }
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var groups = groupRepositories.GetAll();
            Helper.WriteTextWithColor(ConsoleColor.Magenta, "All Groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name:{group.Name} , Max Size: {group.MaxSize}");
            }
        }
        #endregion

        #region Exit
        public void Exit()
        {
            Helper.WriteTextWithColor(ConsoleColor.Green, "Thanks Using our Aplication");
        }
        #endregion

        #region UpdateGroup
        public void UpdateGroup()
        {
            Helper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name:");
            string name = Console.ReadLine();

            var group = groupRepositories.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                int oldSize = group.MaxSize;
                Helper.WriteTextWithColor(ConsoleColor.DarkGreen, "Enter new group name");
                string newName = Console.ReadLine();

                Helper.WriteTextWithColor(ConsoleColor.DarkGreen, "Enter new group max size");
                string size = Console.ReadLine();

                int maxSize;
                bool result = int.TryParse(size, out maxSize);
                if (result)
                {
                    var newGroup = new Group
                    {
                        Id = group.Id,
                        Name = newName,
                        MaxSize = maxSize,

                    };
                    groupRepositories.Update(newGroup);
                    Helper.WriteTextWithColor(ConsoleColor.Green, $"Name:{newName}, Max Size {maxSize} updated old name:{name} old size:{oldSize}");
                }



            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
            }
        }
        #endregion]

        #region GetGroupName
        public void GetGroupName()
        {
            Helper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter group name");
            string name = Console.ReadLine();

            var group = groupRepositories.Get(g=>g.Name.ToLower()==name.ToLower());
            if (group!= null)
            {
                Helper.WriteTextWithColor(ConsoleColor.Magenta,$"group Name:{group.Name} Group Max Size:{group.MaxSize}");
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "This group doesn't exist");
            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            Helper.WriteTextWithColor(ConsoleColor.Yellow, "Enter Group Name");
            string name = Console.ReadLine();
            var group = groupRepositories.Get(g=>g.Name.ToLower()== name.ToLower());

            if (group!=null)
            {
                groupRepositories.Delete(group);
                Helper.WriteTextWithColor(ConsoleColor.Green, $"{name} is Deleted");
            }
            else
            {
                Helper.WriteTextWithColor(ConsoleColor.Red, "This group dosen't exist");
            }
        }
        #endregion



    }
}
