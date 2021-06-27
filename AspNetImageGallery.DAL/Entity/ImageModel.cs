using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AspNetImageGallery.DAL.Entity
{
    public class ImageModel
    {
        public ImageModel()
        {

        }
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ImageCaption { get; set; }
        public string UploadedDate { get; set; }


        [NotMapped]
        public IFormFile File { get; set; }
    }
}
