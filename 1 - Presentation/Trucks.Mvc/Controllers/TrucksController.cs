using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Trucks.Application.Contracts;
using Trucks.Application.ViewModels;

namespace Trucks.Mvc.Controllers
{
    public class TrucksController : Controller
    {
        private ILogger<TrucksController> Logger;
        private ITruckService TruckService;

        public TrucksController(
            ILogger<TrucksController> logger,
            ITruckService truckService)
        {
            Logger = logger;
            TruckService = truckService;
        }

        // GET: Truck
        public ActionResult Index()
        {
            var trucksViewModels = TruckService.GetAll();

            return View(trucksViewModels);
        }

        // GET: Truck/Details/5
        public ActionResult Details(int id)
        {
            var truckViewModel = TruckService.Find(id);

            return View(truckViewModel);
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            var truckViewModel = new TruckViewModel
            {
                Year = DateTime.Today.Year
            };

            return View(truckViewModel);
        }

        // POST: Truck/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TruckViewModel truckViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TruckService.Add(truckViewModel);

                    return RedirectToAction(nameof(Index));
                }

                return View(truckViewModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return View(truckViewModel);
            }
        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int id)
        {
            var truckViewModel = TruckService.Find(id);

            return View(truckViewModel);
        }

        // POST: Truck/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TruckViewModel truckViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TruckService.Update(truckViewModel);

                    return RedirectToAction(nameof(Index));
                }

                return View(truckViewModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return View(truckViewModel);
            }
        }

        // GET: Truck/Delete/5
        public ActionResult Delete(int id)
        {
            var truckViewModel = TruckService.Find(id);

            return View(truckViewModel);
        }

        // POST: Truck/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TruckViewModel truckViewModel)
        {
            try
            {
                TruckService.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return View(truckViewModel);
            }
        }
    }
}