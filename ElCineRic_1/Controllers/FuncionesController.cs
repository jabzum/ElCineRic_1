using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ElCineRic_1.Models;
using Newtonsoft.Json.Linq;


namespace ElCineRic_1.Controllers
{
    public class FuncionesController : Controller
    {
        // GET: Funciones
        public ActionResult Index()
        {
            Funciones f = new Funciones();
            DataTable lf = f.listaFunciones();
            return View(lf);
        }



        // GET: Funciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funciones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funciones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Funciones/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Funciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funciones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
