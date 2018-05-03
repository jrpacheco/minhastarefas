using Business;
using Business.Interface;
using Entity;
using Entity.ListaTarefa;
using Entity.Tarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class TarefaController : Controller
    {
        private ITarefaBusiness _businessTarefa = null;

        public TarefaController()
        {
            _businessTarefa = new TarefaBusiness();
        }
        
        public ActionResult Index(int IdLista)
        {
            var lista = _businessTarefa.TarefasPorLista(IdLista);

            return View(lista);
        }
                
        public ActionResult Create(int IdLista)
        {

            TarefaEntity tarefaEntity = new TarefaEntity { IdLista = IdLista };

            return View(tarefaEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdLista,IdTarefa,Nome,Importante,Prioridade,Ativo,DataAlteracao")] TarefaEntity tarefaEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Retorno retorno = _businessTarefa.Insert(tarefaEntity);

                    return RedirectToAction("Index", "Lista");
                }

                return View(tarefaEntity);
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int? id, int IdLista)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Retorno retorno = _businessTarefa.Find((int)id, IdLista);

            if (retorno.Objeto == null)
            {
                return HttpNotFound();
            }            

            return View(retorno.Objeto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdLista,Nome,Ativo,Importante,Prioridade,DataAlteracao")] TarefaEntity tarefaEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Retorno retorno = _businessTarefa.Update(tarefaEntity);

                    return RedirectToAction("Index", new {IdLista = tarefaEntity.IdLista });
                }

                return View(tarefaEntity);                
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int? id, int IdLista)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Retorno retorno = _businessTarefa.Find((int)id, IdLista);

            if (retorno.Objeto == null)
            {
                return HttpNotFound();
            }
            return View(retorno.Objeto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, int IdLista)
        {
            try
            {
                Retorno retorno = _businessTarefa.Delete(id, IdLista);

                if (retorno.Sucesso)
                    return RedirectToAction("Index", new { IdLista = IdLista});
                else
                    return RedirectToAction("Delete", new { id = id, IdLista = IdLista });
            }
            catch
            {
                return View();
            }
        }
    }
}