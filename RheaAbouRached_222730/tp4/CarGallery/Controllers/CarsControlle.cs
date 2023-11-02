using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarGallery.Repositories;


namespace CarGallery.Controllers
{
    public class CarsController : Controller
    {

        private readonly ICarRepository _carRepository;
        // GET: CarsControlle

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
        

        // GET: CarsControlle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsControlle/Create
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

        // GET: CarsControlle/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
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
    }
}
