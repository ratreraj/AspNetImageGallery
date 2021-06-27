using AspNetImageGallery.DAL.Entity;
using AspNetImageGallery.DAL.Interfaces;
using AspNetImageGallery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IRepository<ImageModel> _imageRepository;
        IConfiguration _config;
        public ImageController(IRepository<ImageModel> imageRepository, IConfiguration configuration)
        {
            _imageRepository = imageRepository;
            _config = configuration;
        }
        public IActionResult Index()
        {
            var data = _imageRepository.GetAll();
            return View(data);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImageModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileName(model.File.FileName);

                BlobStorageService blobService = new BlobStorageService(_config);
                model.ImageName = fileName;
                model.ImagePath = blobService.UploadFileToBlobAsync(model.File.FileName, model.File.OpenReadStream(), model.File.ContentType).Result;

                _imageRepository.Add(model);
                _imageRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }


        public IActionResult Edit(int ImageId)
        {
            //var data = _imageRepository.GetById(ImageId);
            //if (data != null)
            //{
            //    BlobStorageService objBlob = new BlobStorageService(_config);
            //    objBlob.DeleteBlobData(data.ImagePath);
            //    _imageRepository.Update(data);
            //    _imageRepository.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int ImageId)
        {
            var data = _imageRepository.GetById(ImageId);
            if (data != null)
            {
                BlobStorageService objBlob = new BlobStorageService(_config);
                objBlob.DeleteBlobData(data.ImagePath);
                _imageRepository.Delete(data);
                _imageRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
