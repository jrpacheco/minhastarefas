using Business;
using Business.Interface;
using Entity;
using Entity.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ListaController : Controller
    {
        private IListaBusiness _businessLista = null;

        public ListaController()
        {
            _businessLista = new ListaBusiness();
        }

        public ActionResult Index()
        {
            var lista = _businessLista.Lista();

            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo,DataAlteracao")] ListaEntity listaEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Retorno retorno = _businessLista.Insert(listaEntity);

                    return RedirectToAction("Index");
                }

                return View(listaEntity);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Retorno retorno = _businessLista.Find((int)id);

            if (retorno.Objeto == null)
            {
                return HttpNotFound();
            }
            return View(retorno.Objeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo,DataAlteracao")] ListaEntity listaEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Retorno retorno = _businessLista.Update(listaEntity);

                    return RedirectToAction("Index");
                }

                return View(listaEntity);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Retorno retorno = _businessLista.Find((int)id);

            if (retorno.Objeto == null)
            {
                return HttpNotFound();
            }
            return View(retorno.Objeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Retorno retorno = _businessLista.Delete(id);

                if (retorno.Sucesso)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Delete", id);
            }
            catch
            {
                return View();
            }
        }
    }
}