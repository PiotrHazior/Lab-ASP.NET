using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [AllowAnonymous]
        public IActionResult Index()
        {
            var travels = _travelService.FindAll();
            var travelDictionary = travels.ToDictionary(c => c.Id);
            return View(travelDictionary);
        }

        private List<SelectListItem> CreateTravelAgenciesList()
        {
            return _travelService.FindAllTravelAgency()
                .Select(e => new SelectListItem()
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }).ToList();
        }

        [HttpGet]
        [Authorize(Roles = "client,admin")]
        public IActionResult Create() 
        {
            List<SelectListItem> travelagiencies = _travelService.FindAllTravelAgency()
                .Select(e => new SelectListItem()
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                }).ToList();
            return View(new Travel() { TravelAgenciesList = travelagiencies });
        }
        [HttpPost]
        [Authorize(Roles = "client,admin")]
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
        [Authorize(Roles = "client,admin")]
        public IActionResult CreateApi()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "client,admin")]
        public IActionResult CreateApi(Travel model)
        {
            if (ModelState.IsValid)
            {
                _travelService.add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            return View(_travelService.FindByID(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            return View(_travelService.FindByID(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Travel model)
        {
            _travelService.RemoveByID(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Details(int id)
        {
            return View(_travelService.FindByID(id));
        }
    }
}
