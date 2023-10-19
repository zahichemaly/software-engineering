using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp4.Models;
using tp4.Repositories;

namespace tp4.Controllers
{
    public class CarsController : Controller
    {
        // GET: CarsController

        private readonly ICarRepository _carRepository;
        private CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public ActionResult Index()
        {
            return View(_carRepository.Get());

        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars car)
        {
            if (ModelState.IsValid)
            {
                _carRepository.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
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
        public ActionResult Edit(string id, Cars car)
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

    }
}
