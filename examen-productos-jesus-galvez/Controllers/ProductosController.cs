using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConectarDatos;
using System.Data.Entity;

namespace examen_productos_jesus_galvez.Controllers
{
    public class ProductosController : ApiController
    {

        private pruebasEntities dbContext = new pruebasEntities();

        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            using (pruebasEntities pruebasEnt = new pruebasEntities())
            {
                return pruebasEnt.Productos.ToList();
            }
        }

        [HttpGet]
        public Productos Get(int id)
        {
            using (pruebasEntities pruebasEnt = new pruebasEntities())
            {
                return pruebasEnt.Productos.FirstOrDefault(e => e.id == id);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] Productos prod)
        {
            if(ModelState.IsValid)
            {
                dbContext.Productos.Add(prod);
                dbContext.SaveChanges();
                return Ok(prod);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult ActualizarProducto(int id, [FromBody] Productos prod)
        {
            if (ModelState.IsValid)
            {
                var productoExiste = dbContext.Productos.Count(c => c.id == id) > 0;
                  
                if(productoExiste)
                {
                    dbContext.Entry(prod).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
                 
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto(int id)
        {
            var prod = dbContext.Productos.Find(id);

            if(prod != null)
            {
                dbContext.Productos.Remove(prod);
                dbContext.SaveChanges();
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }

        }


    }
}
