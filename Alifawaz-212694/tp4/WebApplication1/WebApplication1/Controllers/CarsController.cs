using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            return View(_carRepository.Get());
        }

        // GET: CarsController/Details/5
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

            try
            {
                var car = _carRepository.Get(id);
                if (id!=car.Id)
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
