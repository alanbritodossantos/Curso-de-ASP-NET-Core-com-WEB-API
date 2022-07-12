using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntroducao.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
    }
}
