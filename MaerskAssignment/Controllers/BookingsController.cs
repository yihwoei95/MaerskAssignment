using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaerskAssignment.Models;

namespace MaerskAssignment.Controllers
{
    public class BookingsController : Controller
    {
        private MaerskAssignmentContext db = new MaerskAssignmentContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Container).Include(b => b.Ship).Include(b => b.Shipyard).Include(b => b.Shipyard1);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription");
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName");
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "BookingID,ShipID,ContainerID,Price,ArrivalDate,DepartureDate,DepartureShipyardID,ArrivalShipyardID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", booking.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", booking.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.ArrivalShipyardID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", booking.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", booking.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.ArrivalShipyardID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "BookingID,ShipID,ContainerID,Price,ArrivalDate,DepartureDate,DepartureShipyardID,ArrivalShipyardID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContainerID = new SelectList(db.Containers, "ContainerID", "ContainerDescription", booking.ContainerID);
            ViewBag.ShipID = new SelectList(db.Ships, "ShipID", "ShipName", booking.ShipID);
            ViewBag.DepartureShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.DepartureShipyardID);
            ViewBag.ArrivalShipyardID = new SelectList(db.Shipyards, "ShipyardID", "ShipyardName", booking.ArrivalShipyardID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
