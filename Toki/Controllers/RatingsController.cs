using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toki.Models;
using Toki.Services;

namespace Toki.Controllers
{
    public class RatingsController : Controller
    {
        private readonly IRatingService service;

        public RatingsController(IRatingService ser)
        {
            this.service = ser;
            //service = new RatingService();
            //if (rateList.Count == 0)
            //{
            //    rateList.Add(new Rating() { Id = 1, NameOfRater = "Yossi", Feedback = "Great!", RateNumber = 4, Time = DateTime.Now });
            //    rateList.Add(new Rating() { Id = 2, NameOfRater = "Sivan", Feedback = "Lame!!!", RateNumber = 1, Time = DateTime.Now });
           // }
        }

        // GET: RatingsController
        public ActionResult Index()
        {
            return View(service.GetAllRatings());
        }

        public ActionResult Search()
        {
            return View(service.GetAllRatings());
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                List<Rating> rateList = service.GetAllRatings();
                var q = from rank in rateList
                        where rank.Feedback.Contains(query)
                        select rank;
                return View(q.ToList());
            }
            return View(service.GetAllRatings());
        }

        // GET: RatingsController/Details/5
        public ActionResult Details(int id)
        {
            return View(service.GetRating(id));
        }

        // GET: RatingsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind("NameOfRater,RateNumber, Feedback")] Rating rating)
        public ActionResult Create(string  NameOfRater, int RateNumber, string Feedback)
        {

            if (ModelState.IsValid)
            {
                service.CreateRating(NameOfRater, RateNumber, Feedback);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: RatingsController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string NameOfRater, int RateNumber, string Feedback)
        {
            if (ModelState.IsValid)
            {
                service.EditRating(id, NameOfRater, RateNumber, Feedback);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
            //return RedirectToAction(nameof(Index));
        }

        // POST: RatingsController/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View(service.GetRating(id));
        }

        // GET: RatingsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(service.GetRating(id));
        }

        // POST: RatingsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            service.DeleteRanking(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
