﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Database
{
    public class EntityFrameworkDatabase : DbContext, IDatabase
    {
        public EntityFrameworkDatabase(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public IQueryable<T> Select<T>() where T : class
        {
            return Set<T>().AsQueryable();
        }

        public IQueryable<T> Select<T>(params Expression<Func<T, object>>[] joins) where T : class
        {
            IQueryable<T> query = Select<T>();

            foreach (var join in joins)
            {
                query = query.Include(join);
            }

            return query;
        }

        public async Task<T> Insert<T>(T entitity) where T : class
        {
            T added = Set<T>().Add(entitity);
            await SaveChangesAsync();

            return added;
        }

        public async Task<IEnumerable<T>> Insert<T>(IEnumerable<T> entities) where T : class
        {
            IEnumerable<T> added = Set<T>().AddRange(entities);
            await SaveChangesAsync();

            return added;
        }

        public async Task Update<T>(T entitity) where T : class
        {
            AttachAndSetState(entitity, EntityState.Modified);
            await SaveChangesAsync();
        }

        public async Task Update<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                AttachAndSetState(entity, EntityState.Modified);
            }

            await SaveChangesAsync();
        }

        public async Task Delete<T>(T entitity) where T : class
        {
            AttachAndSetState(entitity, EntityState.Deleted);
            await SaveChangesAsync();
        }

        public async Task Delete<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                AttachAndSetState(entity, EntityState.Deleted);
            }

            await SaveChangesAsync();
        }

        private void AttachAndSetState<T>(T entity, EntityState state) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = state;
        }
    }
}
