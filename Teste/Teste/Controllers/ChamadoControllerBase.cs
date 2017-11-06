using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste.Contexts;

namespace Teste.Controllers
{
    public class ChamadoControllerBase<TEntity> : Controller where TEntity : class
    {
        protected ChamadoContext db = new ChamadoContext();
        protected DbSet<TEntity> dbSet;

        public ChamadoControllerBase()
        {
            dbSet = db.Set<TEntity>();
        }

        // GET: Usuarios
        public virtual ActionResult Index()
        {
            return View(GetAll());
        }

        // GET: Usuarios/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = GetById(id.Value);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Usuarios/Create
        public virtual ActionResult Create()
        {
            PopulateViewBag();
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TEntity resource)
        {
            if (ModelState.IsValid)
            {
                dbSet.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        // GET: Usuarios/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = GetById(id.Value);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEntity resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        // GET: Usuarios/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resource = GetById(id.Value);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            var resource = GetById(id);
            dbSet.Remove(resource);
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

        protected virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        protected virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        protected virtual void PopulateViewBag()
        {
        }
    }
}