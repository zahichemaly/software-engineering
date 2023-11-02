using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tp4.Models;
using tp4.Repositories;
using tp4.Models;
using tp4.Repositories;



namespace tp4.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;



        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }



        public ActionResult Index()
        {
            return View(_carRepository.Get());
        }



        // GET: CarsController/Details/5
        public ActionResult Details(string id)
        {
            var car = _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }



        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }



        // GET: CarsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _carRepository.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }



        // GET: CarsController/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }



        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            _carRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}