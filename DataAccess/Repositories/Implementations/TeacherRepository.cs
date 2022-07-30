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
    public class TeacherRepository : IRepositary<Teacher>
    {
        private static int id;
        public Teacher Create(Teacher entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DxContext.teachers.Add(entity);

                 return entity;
            }
            catch (Exception e)
            {
               
                return null;

            }
        }

        public void Delete(Teacher entity)
        {
            try
            {
                id--;
                entity.Id = id;
                DxContext.teachers.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Teacher Get(Predicate<Teacher> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DxContext.teachers[0];
                }
                else
                {
                    return DxContext.teachers.Find(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Teacher> GetAll(Predicate<Teacher> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DxContext.teachers;
                }
                else
                {
                    return DxContext.teachers.FindAll(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public void Update(Teacher entity)
        {
            try
            {

                var teacher = DxContext.teachers.Find(g => g.Id == entity.Id);
                if (teacher == null)
                {
                    teacher.Name = entity.Name;
                    teacher.Surname = entity.Surname;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
