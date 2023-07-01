using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RamenKing.Interfaces;

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

        public ActionResult All()
        {
            ViewData["allRamen"] = _ramenRepository.GetAllRamen();
            return View(nameof(All));
        }

        public ActionResult Detail(int Id)
        {
            return View(nameof(Detail),_ramenRepository.GetRamenById(Id));
        }
    }
}

