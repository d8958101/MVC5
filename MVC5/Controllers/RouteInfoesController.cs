using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class RouteInfoesController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: RouteInfoes
        public ActionResult Index()
        {
            return View(db.RouteInfo.ToList());
        }

        // GET: RouteInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInfo routeInfo = db.RouteInfo.Find(id);
            if (routeInfo == null)
            {
                return HttpNotFound();
            }
            return View(routeInfo);
        }

        // GET: RouteInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RouteInfoes/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,city,title,biketype,geography,time")] RouteInfo routeInfo)
        {
            if (ModelState.IsValid)
            {
                db.RouteInfo.Add(routeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routeInfo);
        }

        // GET: RouteInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInfo routeInfo = db.RouteInfo.Find(id);
            if (routeInfo == null)
            {
                return HttpNotFound();
            }
            return View(routeInfo);
        }

        // POST: RouteInfoes/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,city,title,biketype,geography,time")] RouteInfo routeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routeInfo);
        }

        // GET: RouteInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RouteInfo routeInfo = db.RouteInfo.Find(id);
            if (routeInfo == null)
            {
                return HttpNotFound();
            }
            return View(routeInfo);
        }

        // POST: RouteInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RouteInfo routeInfo = db.RouteInfo.Find(id);
            db.RouteInfo.Remove(routeInfo);
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
