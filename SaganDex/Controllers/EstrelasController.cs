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
    public class EstrelasController : Controller
    {
        private readonly Contexto db;

        public EstrelasController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: EstrelasController
        public ActionResult Index(string query3, string tipoPesquisa3)
        {
            if (string.IsNullOrEmpty(query3))
            {
                return View(db.ESTRELAS.ToList());
            }
            else if (tipoPesquisa3 == "Todos")
            {
                return View(db.ESTRELAS.Where(a => a.Constelacao.Contains(query3) || a.Nome.Contains(query3) ||
                a.Designacao.Contains(query3) || a.Tipo.Contains(query3)));
            }
            else if (tipoPesquisa3 == "PorNome")
            {
                return View(db.ESTRELAS.Where(a => a.Nome.Contains(query3)));
            }
            else if (tipoPesquisa3 == "PorConstelacao")
            {
                return View(db.ESTRELAS.Where(a => a.Constelacao.Contains(query3)));
            }
            else if (tipoPesquisa3 == "PorDesignacao")
            {
                return View(db.ESTRELAS.Where(a => a.Designacao.Contains(query3)));
            }
            else if (tipoPesquisa3 == "PorTipo")
            {
                return View(db.ESTRELAS.Where(a => a.Tipo.Contains(query3)));
            }
            else
            {
                return View(db.ESTRELAS.ToList());
            }
        }

        

        // GET: EstrelasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstrelasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estrelas collection)
        {
            try
            {
                db.ESTRELAS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstrelasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.ESTRELAS.Where(a => a.Id == id).FirstOrDefault());
        }

        // POST: EstrelasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estrelas collection)
        {
            try
            {
                db.ESTRELAS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstrelasController/Delete/5
        public ActionResult Delete(int id)
        {
            db.ESTRELAS.Remove(db.ESTRELAS.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
