using AspNetImageGallery.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetImageGallery.DAL.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext dbContext { get; set; }

        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(TEntity enity)
        {
            dbContext.Set<TEntity>().Add(enity);
        }

        public void Delete(TEntity enity)
        {
            dbContext.Set<TEntity>().Remove(enity);
        }

        public void DeleteById(object Id)
        {
            TEntity entity = dbContext.Set<TEntity>().Find(Id);
            this.Delete(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(object Id)
        {
            return dbContext.Set<TEntity>().Find(Id);
        }

        public int SaveChanges()
        {
           return dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
