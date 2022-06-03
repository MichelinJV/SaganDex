using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaganDex.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaganDex.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class ExoPlanetasController : Controller
    {
        private readonly Contexto db;

        public ExoPlanetasController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: ExoPlanetasController
        public ActionResult Index(string query2, string tipoPesquisa2)
        {
            if (string.IsNullOrEmpty(query2))
            {
                return View(db.EXOPLANETAS.ToList());
            }
            else if (tipoPesquisa2 == "Todos")
            {
                return View(db.EXOPLANETAS.Where(a => a.Constelacao.Contains(query2) || a.Nome.Contains(query2) ||
                a.EstrelaMae.Contains(query2) || a.Categoria.Contains(query2)));
            }
            else if (tipoPesquisa2 == "PorNome")
            {
                return View(db.EXOPLANETAS.Where(a => a.Nome.Contains(query2)));
            }
            else if (tipoPesquisa2 == "PorConstelacao")
            {
                return View(db.EXOPLANETAS.Where(a => a.Constelacao.Contains(query2)));
            }
            else if (tipoPesquisa2 == "PorEstrelaMae")
            {
                return View(db.EXOPLANETAS.Where(a => a.EstrelaMae.Contains(query2)));
            }
            else if (tipoPesquisa2 == "PorCategoria")
            {
                return View(db.EXOPLANETAS.Where(a => a.Categoria.Contains(query2)));
            }
            else
            {
                return View(db.EXOPLANETAS.ToList());
            }
        }

        

        // GET: ExoPlanetasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExoPlanetasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExoPlanetas collection)
        {
            try
            {
                db.EXOPLANETAS.Add(collection);
                db.SaveChanges();                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExoPlanetasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.EXOPLANETAS.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: ExoPlanetasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExoPlanetas collection)
        {
            try
            {
                db.EXOPLANETAS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExoPlanetasController/Delete/5
        public ActionResult Delete(int id)
        {
            db.EXOPLANETAS.Remove(db.EXOPLANETAS.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
