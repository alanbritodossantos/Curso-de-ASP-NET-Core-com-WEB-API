using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIIntroducao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIIntroducao.Controllers
{
    [Produces("application/json")]
    [Route("api/Categoria")]
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriaController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return context.Categorias.ToList();
        }

        [HttpGet("{id}", Name ="categoriaCriada")]
        public IActionResult GetById(int id)
        {
            var cat = context.Categorias.FirstOrDefault(x => x.Id == id);

            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria cat)
        {
            if (ModelState.IsValid) {
                context.Categorias.Add(cat);
                context.SaveChanges();
                return new CreatedAtRouteResult("categoriaCriada", new { id = cat.Id }, cat);
            }

            return BadRequest(ModelState);
        }
        
    }
}