using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaganDex.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SaganDex.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly Contexto db;

        public ClaimsIdentity Nome { get; internal set; }

        public UsuariosController(Contexto contexto)
        {
            db = contexto;
        }

        // GET: UsuariosController
        public ActionResult Index(string query, string tipoPesquisa)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(db.USUARIOS.ToList());
            }
            else if(tipoPesquisa == "Todos")
            {
                return View(db.USUARIOS.Where(a => a.Login.Contains(query) || a.Nome.Contains(query) ));
            }
            else if(tipoPesquisa == "PorNome")
            {
                return View(db.USUARIOS.Where(a => a.Nome.Contains(query)));
            }
            else if (tipoPesquisa == "PorLogin")
            {
                return View(db.USUARIOS.Where(a => a.Login.Contains(query)));
            }
            else
            {
                return View(db.USUARIOS.ToList());
            }
        }

        

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection)
        {
            try
            {
                db.USUARIOS.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault() );
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios collection)
        {
            try
            {
                db.USUARIOS.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            db.USUARIOS.Remove(db.USUARIOS.Where(a => a.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
