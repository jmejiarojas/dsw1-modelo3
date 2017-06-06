using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_MVC_10.Entity;
using APP_MVC_10.Models;

namespace APP_MVC_10.Controllers
{
    public class ProductoController : Controller
    {
        // Instanciar objeto de la clase productoDAO
        ProductoDAO dao = new ProductoDAO();
        CategoriaDAO daocat = new CategoriaDAO();

        public ActionResult Index()
        {
            return View(dao.readAll());
        }

        public ActionResult Details(int id)
        {
            return View(dao.findForId(id));
        }

        // Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(
                daocat.readCatAll(), "IdCategoria", "Descripcion");
            //
            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //int cant = 89 + 1;
                    //string codigo = "CL" + cant.ToString("0000");
                    //pro.IdProducto = codigo;
                    dao.create(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            { return View(); }
        }

        //Editar
        public ActionResult Edit(int id)
        {
            return View(dao.findForId(id));
        }

        [HttpPost]
        public ActionResult Edit(Producto pro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    dao.update(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Eliminar
        public ActionResult Delete(int id)
        {
            return View(dao.findForId(id));
        }

        [HttpPost ActionName("delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Producto obj = new Producto();
                    obj.IdProducto = id;
                    dao.delete(obj);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProductoNombre(string nom)
        {
            if (nom == null)
            { nom = string.Empty; }
            return View(dao.productoNombre(nom));
        }
    }
}