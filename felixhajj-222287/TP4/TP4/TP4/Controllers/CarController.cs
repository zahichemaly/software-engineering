using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP4.CarRepository;
using TP4.Models;

namespace TP4.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        // GET: CarController
        public ActionResult Index()
        {
            return View(_carRepository.Get());
        }

       
        // GET: CarController/Create
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

        // GET: CarController/Edit/5
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

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
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

            _carRepository.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(string id)
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
    }
}
