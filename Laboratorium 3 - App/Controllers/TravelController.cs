using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        //static Dictionary<int, Travel> _travels = new Dictionary<int, Travel>();
        //static int id = 1;
        public IActionResult Index()
        {
            var travels = _travelService.FindAll();
            var travelDictionary = travels.ToDictionary(c => c.Id);
            return View(travelDictionary);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Travel model) 
        {
            if (ModelState.IsValid)
            {
                _travelService.add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_travelService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Update(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_travelService.FindByID(id));
        }

        [HttpPost]
        public IActionResult Delete(Travel model)
        {
            _travelService.RemoveByID(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_travelService.FindByID(id));
        }
    }
}
