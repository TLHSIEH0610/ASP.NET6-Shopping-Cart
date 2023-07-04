using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using RamenKing.Interfaces;
using RamenKing.Models;
using RamenKing.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RamenKing.Controllers
{
    public class RamenController : Controller
    {
        private IRamenRepository _ramenRepository;

        private ICloudinaryService _cloudinaryService;

        public RamenController(IRamenRepository ramenRepository, ICloudinaryService cloudinaryService)
        {
            _ramenRepository = ramenRepository;
            _cloudinaryService = cloudinaryService;

        }

        public async Task<ActionResult> All()
        {
            var RamenList = await _ramenRepository.GetAllRamen();
            return View(RamenList);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var currRamen = await _ramenRepository.GetRamenById(id);

            return View(currRamen);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var currRamen = await _ramenRepository.GetRamenById(id);

            var currRamenVM = new EditRamenViewModel
            {
                Id = id,
                Name = currRamen.Name,
                ShortDescription = currRamen.ShortDescription,
                LongDescription = currRamen.LongDescription,
                Price = currRamen.Price,
                ImageURL = currRamen.ImageURL
            };

            return View(currRamenVM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, EditRamenViewModel RamenVM)
        {
            if (!ModelState.IsValid)
            {
                //trigger error prompt
                return View(RamenVM);
            }

            var findRamen = await _ramenRepository.GetRamenById(id);

            if (findRamen == null)
            {
                //trigger error prompt
            }

            //Delete current Image
            var currRamen = await _ramenRepository.GetRamenById(id);

            if (!string.IsNullOrEmpty(currRamen.ImageURL))
            {
              await _cloudinaryService.DeletePhotoAsync(currRamen.ImageURL);
            }

            //Upload new Image

            var url = "";

            if (RamenVM.Photo != null)
            {
                 var result = await _cloudinaryService.AddPhotoAsync(RamenVM.Photo);
                 url = result.Url.ToString();
            }
         
            
            var updatedRamen = new Ramen
            {
                Id = id,
                Name = RamenVM.Name,
                ShortDescription = RamenVM.ShortDescription,
                LongDescription = RamenVM.LongDescription,
                Price = RamenVM.Price,
                ImageURL = url == "" ? findRamen.ImageURL : url
            };

            _ramenRepository.Update(updatedRamen);

            return RedirectToAction("All");

         }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EditRamenViewModel RamenVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _cloudinaryService.AddPhotoAsync(RamenVM.Photo);
                var newRamen = new Ramen
                {
                    Name = RamenVM.Name,
                    ShortDescription = RamenVM.ShortDescription,
                    LongDescription = RamenVM.LongDescription,
                    Price = RamenVM.Price,
                    ImageURL = result.Url.ToString()
                };
                _ramenRepository.Add(newRamen);
                return RedirectToAction("All");

            }
            else {
                return View(RamenVM);
            }

            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currRamen = await _ramenRepository.GetRamenById(id);
            _ramenRepository.Delete(currRamen);

            await _cloudinaryService.DeletePhotoAsync(currRamen.ImageURL);

            return RedirectToAction("All");
        }
    }
}

