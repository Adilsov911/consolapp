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
            DxContext.Students.Add(entity);
            return entity;
        }

        public void Delete(Student entity)
        {
            id--;
            entity.Id = id;
            DxContext.Students.Add(entity);
        }

        public Student Get(Predicate<Student> filter = null)
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

        public List<Student> GetAll(Predicate<Student> filter = null)
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

        public void Update(Student entity)
        {
            var student = DxContext.Students.Find(g => g.Id == entity.Id);
            if (student == null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;




            }
        }
    }
}
