using AspNetImageGallery.DAL.Entity;
using AspNetImageGallery.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetImageGallery.DAL.DBContext;
using Microsoft.EntityFrameworkCore;

namespace AspNetImageGallery.DAL.Implementations
{
    public class ImageRepository : Repository<ImageModel>, IImageRepository
    {
        private DatabaseContext Context
        {
            get
            {
                return dbContext as DatabaseContext;
            }

        }

        public ImageRepository(DbContext dbContext):base(dbContext)
        {
        
        }

    }
}
