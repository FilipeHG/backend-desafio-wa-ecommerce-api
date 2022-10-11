using Microsoft.EntityFrameworkCore;
using ApiEcommerceDDD.Domain.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiEcommerceDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly Context context;

        public RepositoryBase(Context context)
        {
            this.context = context;
        }

        public void Add(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Add(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Remove(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(long id)
        {
            return context.Set<TEntity>().Find(id);
        }
    }
}