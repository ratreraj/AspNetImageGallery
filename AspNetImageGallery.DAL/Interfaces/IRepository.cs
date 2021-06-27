using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetImageGallery.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        void Add(TEntity enity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(object Id);

        void Update(TEntity enity);

        void Delete(TEntity enity);
        void DeleteById(object Id);

        int SaveChanges();


    }
}
