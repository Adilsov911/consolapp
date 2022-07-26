using Core.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class AdminRepository : IRepositary<Admin>
    {
        private static int id;
        public Admin Create(Admin entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DxContext.Admins.Add(entity);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Admin entity)
        {
            try
            {
                DxContext.Admins.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public Admin Get(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DxContext.Admins[0];
            }
            else
            {
                return DxContext.Admins.Find(filter);
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            if (filter == null)
            {
                return DxContext.Admins;
            }
            else
            {
                return DxContext.Admins.FindAll(filter);
            }
        }

        public void Update(Admin entity)
        {
            try
            {

              var admin = DxContext.Admins.Find(g => g.Id == entity.Id);
                  if (admin != null)
                  {
                     admin.Username = admin.Username;
                     admin.Password = admin.Password;
                  }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }


    }
}
