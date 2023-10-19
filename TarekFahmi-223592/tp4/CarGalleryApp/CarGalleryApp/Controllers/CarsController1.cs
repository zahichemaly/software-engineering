using CarGalleryApp.Models;
using CarGalleryApp.wwwroot.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGalleryApp.Controllers
{
    public class CarsController1 : Controller
    {
        private readonly ICarRepository _carRepository;
        // GET: CarsController1
        public CarsController1(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public ActionResult Index()
        {
            return View(_carRepository.Get());
        }

        // GET: CarsController1/Details/5
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

        // GET: CarsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController1/Create
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

        // GET: CarsController1/Edit/5
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

        // POST: CarsController1/Edit/5
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

        // GET: CarsController1/Delete/5
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

        // POST: CarsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {


            try
            {
                var car = _carRepository.Get(id);
                if (car == null)
                {
                    return NotFound();
                }

                _carRepository.Remove(car); 
                return RedirectToAction(nameof(Index)); 
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
