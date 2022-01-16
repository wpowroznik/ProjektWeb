using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektWeb.Models;

namespace ProjektWeb.Controllers
{



    public class MovieDetailsController : Controller
    {
        private ProjektEntities1 db = new ProjektEntities1();

        // GET: MovieDetails
        public ActionResult Index()
        {
            return View(db.MovieDetail.ToList());
        }

        // GET: MovieDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDetail movieDetail = db.MovieDetail.Find(id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            return View(movieDetail);
        }

        // GET: MovieDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieName,MovieDescription,MovieTime")] MovieDetail movieDetail)
        {
            if (ModelState.IsValid)
            {
                db.MovieDetail.Add(movieDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieDetail);
        }

        // GET: MovieDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDetail movieDetail = db.MovieDetail.Find(id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            return View(movieDetail);
        }

        // POST: MovieDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieName,MovieDescription,MovieTime")] MovieDetail movieDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieDetail);
        }

        // GET: MovieDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDetail movieDetail = db.MovieDetail.Find(id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            return View(movieDetail);
        }

        // POST: MovieDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieDetail movieDetail = db.MovieDetail.Find(id);
            db.MovieDetail.Remove(movieDetail);
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
