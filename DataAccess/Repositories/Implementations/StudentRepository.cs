using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Base;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository : IRepositary<Student>
    {
        private static int id;
        public Student Create(Student entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DxContext.Students.Add(entity);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }
            return entity;
        }

        public void Delete(Student entity)
        {
            try
            {
                id--;
                entity.Id = id;
                DxContext.Students.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Student Get(Predicate<Student> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DxContext.Students[0];
                }
                else
                {
                    return DxContext.Students.Find(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            try
            {

                if (filter == null)
                {
                    return DxContext.Students;
                }
                else
                {
                    return DxContext.Students.FindAll(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public void Update(Student entity)
        {
            try
            {

                var student = DxContext.Students.Find(g => g.Id == entity.Id);
                if (student == null)
                {
                    student.Name = entity.Name;
                    student.Surname = entity.Surname;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
