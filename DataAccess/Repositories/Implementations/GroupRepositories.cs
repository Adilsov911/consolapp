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
    public class GroupRepositories : IRepositary<Group>
    {
        private static int id;
        public Group Create(Group entity)
        {
            id++;
            entity.Id = id;
            DxContext.Groups.Add(entity);
            return entity;
        }

        public void Delete(Group entity)
        {
            DxContext.Groups.Add(entity);
        }

        public Group Get(Predicate<Group> filter = null)
        {
            if (filter == null)
            {
                return DxContext.Groups[0];
            }
            else
            {
                return DxContext.Groups.Find(filter);
            }
        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            if (filter == null)
            {
                return DxContext.Groups;
            }
            else
            {
                return DxContext.Groups.FindAll(filter);
            }
        }

        public void Update(Group entity)
        {
            var group = DxContext.Groups.Find(g=>g.Id == entity.Id);
            if (group == null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;




            }
        }
    }
}
