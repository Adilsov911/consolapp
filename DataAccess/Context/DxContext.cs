using Core.Entities;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    static class DxContext
    {
        static DxContext()
        {
            Students = new List<Student>();
            Groups = new List<Group>();
            Admins = new List<Admin>();
            teachers = new List<Teacher>();

            string password1 = "adil123";
            var hashedPassword1 = PasswordHasher.Encrypt(password1);
            Admin admin1 = new Admin("admin1",hashedPassword1);
            Admins.Add(admin1);

            string password2 = "adil1234";
            var hashedPassword2 = PasswordHasher.Encrypt(password2);
            Admin admin2 = new Admin("admin2",hashedPassword2);
            Admins.Add(admin2);
        }

        public static List<Student> Students { get; set; }
        public static List<Group> Groups { get; set; }
        public static List<Admin> Admins { get; set; }
        public static List<Teacher> teachers { get; set; }
    }   
}
