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
    public class AdminController
    {
        private AdminRepository adminRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository();
        }

        public Admin Authenticade()
        {
            Helper.WriteTextWithColor(ConsoleColor.Green, "Enter admin username:");
            string username = Console.ReadLine();

            Helper.WriteTextWithColor(ConsoleColor.Green, "Enter admin password:");
            string password = Console.ReadLine();

            var admin = adminRepository.Get(g => g.Username.ToLower() == username.ToLower() && PasswordHasher.Decrypt(g.Password) == password
            );
            return admin;
        }

    }
}
