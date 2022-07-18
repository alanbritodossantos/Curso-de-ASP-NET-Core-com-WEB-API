﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntroducao
{
    public class Categoria
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Nome { get; set; }
    }
}
