using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ElCineRic_1.Models;
using Newtonsoft.Json.Linq;
using ElCineRic_1.Objetos;


namespace ElCineRic_1.Controllers
{
    public class FuncionesController : Controller
    {
        public ActionResult movie()
        {
            return View();
        }

        public ActionResult db()
        {
            return View();
        }
        // GET: Funciones
        public ActionResult Index(string id)
        {
            Funciones f = new Funciones();
            DataTable sillas = f.ListadoSillas(Convert.ToInt32(id));
            Butacas b = new Butacas();
            for (int x = 0; x<sillas.Rows.Count; x++)
            {
                Butaca bt = new Butaca(sillas.Rows[x][2].ToString(), Convert.ToBoolean(sillas.Rows[x][3].ToString()), sillas.Rows[x][0].ToString());
                b.ListaButacas.Add(bt);
            }

            DataTable sala = f.SalaByID(Convert.ToInt32(Session["sala"].ToString()));
            Session["filas"] = sala.Rows[0][4].ToString();
            Session["columnas"] = sala.Rows[0][5].ToString();
            DataTable funcion = f.FuncionByID(Convert.ToInt32(id));
            Session["precio"] = funcion.Rows[0][12].ToString();

            return View(b);
        }

        public ActionResult MasBarato(string id, string sala, string idimdb)
        {
            Session["idimdb"] = idimdb;
            Session["sala"] = sala;
            Funciones f = new Funciones();
            return View(f.ListadoMasBaratas(Convert.ToInt32(id)));
        }

        public ActionResult SelPeliculas()
        {
            Funciones f = new Funciones();
            return View(f.PeliculasHoy());
        }

        public ActionResult Dia(string id, string sala, string idimdb)
        {
            Session["idmovie"] = id;
            Session["idimdb"] = idimdb;
            Session["sala"] = sala;
            List<DateTime> dias = new List<DateTime>();
            for(int x = 0; x<6; x++)
            {
                DateTime d = DateTime.Now.AddDays(x);
                dias.Add(d);
            }
            return View(dias);
        }



        public ActionResult Pelis()
        {
           
           return View();
        }

        public ActionResult Seleccionar(string id)
        {
            DateTime fecha = DateTime.Now.AddDays(Convert.ToInt32(id));
            int id_movie = Convert.ToInt32(Session["idmovie"].ToString());
            int sala = Convert.ToInt32(Session["sala"].ToString());
            Funciones f = new Funciones();            
            ObjSeleccionHoras obj = new ObjSeleccionHoras();
            DataTable tabla = f.FuncionesDelDia(1, id_movie, sala, fecha);
            obj.TablaFuncionesDelDia = tabla;
            return View(obj);
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
            Funciones f = new Funciones();
            try
            {
               foreach(string key in collection)
               {
                    f.ActualizarSilla(Convert.ToInt32(key), true);                    
               }
                Session["mensaje"] = "Exito!";
                return RedirectToAction("SelPeliculas");
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
