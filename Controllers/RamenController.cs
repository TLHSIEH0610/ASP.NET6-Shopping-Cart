using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using RamenKing.Interfaces;
using RamenKing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RamenKing.Controllers
{
    public class RamenController : Controller
    {
        private IRamenRepository _ramenRepository;

        public RamenController(IRamenRepository ramenRepository)
        {
            _ramenRepository = ramenRepository;

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

            return View(currRamen);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Ramen ramen)
        {
            if (!ModelState.IsValid)
            {
                //trigger error prompt
                return View(ramen);
            }

            var findRamen = await _ramenRepository.GetRamenById(id);

            if (findRamen == null)
            {
                //trigger error prompt
            }

            var updatedRamen = new Ramen
            {
                Id = id,
                Name= ramen.Name,
                ShortDescription = ramen.ShortDescription,
                LongDescription = ramen.LongDescription,
                Price = ramen.Price,
                ImageURL = ramen.ImageURL
            };

            _ramenRepository.Update(updatedRamen);

            return RedirectToAction("All");

         }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create( Ramen Ramen)
        {

            return View();
        }
    }
}

