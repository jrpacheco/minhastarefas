using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entity.Lista;
using WebApp.Models;
using Business.Interface;
using Business;

namespace WebApp.Controllers
{
    public class ListaAPIController : ApiController
    {
        private WebAppContext db = new WebAppContext();
        private IListaBusiness _businessLista = null;

        public ListaAPIController()
        {
            _businessLista = new ListaBusiness();
        }

        // GET: api/ListaAPI
        public IEnumerable<ListaEntity> GetLista()
        {
            return _businessLista.Lista();            
        }

        // GET: api/ListaAPI/5
        [ResponseType(typeof(ListaEntity))]
        public IHttpActionResult GetListaEntity(int id)
        {
            ListaEntity listaEntity = db.ListaEntities.Find(id);
            if (listaEntity == null)
            {
                return NotFound();
            }

            return Ok(listaEntity);
        }

        // PUT: api/ListaAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListaEntity(int id, ListaEntity listaEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listaEntity.Id)
            {
                return BadRequest();
            }

            db.Entry(listaEntity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListaEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ListaAPI
        [ResponseType(typeof(ListaEntity))]
        public IHttpActionResult PostListaEntity(ListaEntity listaEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _businessLista.Insert(listaEntity);

            return Ok(listaEntity);

            //return CreatedAtRoute("DefaultApi", new { id = listaEntity.Id }, listaEntity);
        }

        // DELETE: api/ListaAPI/5
        [ResponseType(typeof(ListaEntity))]
        public IHttpActionResult DeleteListaEntity(int id)
        {
            ListaEntity listaEntity = db.ListaEntities.Find(id);
            if (listaEntity == null)
            {
                return NotFound();
            }

            db.ListaEntities.Remove(listaEntity);
            db.SaveChanges();

            return Ok(listaEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListaEntityExists(int id)
        {
            return db.ListaEntities.Count(e => e.Id == id) > 0;
        }
    }
}