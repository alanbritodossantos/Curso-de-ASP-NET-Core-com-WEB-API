﻿using System;
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
    }
}