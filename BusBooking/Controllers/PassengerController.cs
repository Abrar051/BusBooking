using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusBooking.Controllers
{
    public class PassengerController : Controller
    {
        // GET: Passenger
        public ActionResult Index()
        {
            PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
            List<Passenger> passengers = passengerBusinessLayer.Passengers.ToList();
            return View(passengers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
                passengerBusinessLayer.AddPassenger(passenger);
                return RedirectToAction("Index","Passenger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit (int id)
        {
            PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
            Passenger passenger = passengerBusinessLayer.Passengers.Single(psng => psng.PassengerId = id);
            return View (passenger)
        }
        [HttpPost]
        public ActionResult Edit (Passenger passenger)
        {
            if (ModelState.Isvalid)
            {
                PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
                passengerBusinessLayer.UpdatePassengers(passenger);
                return RedirectToAction("Index","Passenger");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete (int id)
        {
            PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
            passengerBusinessLayer.DeletePassengers(id);
            return RedirectToAction("Index","Passenger");
        }

        public ActionResult Details(int id)
        {
            PassengerBusinessLayer passengerBusinessLayer = new PassengerBusinessLayer();
            Passenger passenger = passengerBusinessLayer.Passengers.Single(psng=>psng.PassengerId = id);
            return View(passenger);
        }

    }
}