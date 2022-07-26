﻿using Core.Entities;
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
            try
            {
                DxContext.Groups.Add(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Group entity)
        {
            try
            {
                DxContext.Groups.Remove(entity);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);


            }
        }

        public Group Get(Predicate<Group> filter = null)
        {
            try
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            try
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
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Update(Group entity)
        {
            try
            {

                var group = DxContext.Groups.Find(g => g.Id == entity.Id);
                if (group != null)
                {
                    group.Name = entity.Name;
                    group.MaxSize = entity.MaxSize;


                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                
            }
        }
    }
}
