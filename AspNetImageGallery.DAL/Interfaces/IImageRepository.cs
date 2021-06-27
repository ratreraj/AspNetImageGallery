using AspNetImageGallery.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetImageGallery.DAL.Interfaces
{
    public interface IImageRepository : IRepository<ImageModel>
    {
    }
}
