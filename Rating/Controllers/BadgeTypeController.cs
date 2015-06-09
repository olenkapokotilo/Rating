using Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rating.Controllers
{
    public class BadgeTypeController : Controller
    {
        private IBadgeTypeRepository _badgeTypeRepository;
        private IFileRepository _fileRepository;
        public BadgeTypeController(IBadgeTypeRepository badgeTypeRepository, IFileRepository fileRepository)
        {
            _badgeTypeRepository = badgeTypeRepository;
            _fileRepository = fileRepository;
        }
        // GET: BadgeType
        public ActionResult List()
        {
            return View();
        }
        public ActionResult Create(int ratingTypeId)
        {
            return View(ratingTypeId);
        }
        [HttpPost]
        public ActionResult Create(Rating.Models.BadgeTypeModel badgeType, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (ModelState.IsValid && uploadImage != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    badgeType.Image = imageData;
                    int fileId = _fileRepository.Create(badgeType.Image);
                    badgeType.FileId = fileId;
                    _badgeTypeRepository.Create(badgeType.ToDomainModel());
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return Redirect("/Share/Error?message" + e);
            }
            return Redirect("~/RatingType/Edit/" + badgeType.RatingTypeId.ToString());
        }
        public FileContentResult GetImage(int fileId)
        {
            var image = _fileRepository.GetFile(fileId).Image;
            //Game game = repository.Games
            //    .FirstOrDefault(g => g.GameId == gameId);

            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }
    }
}