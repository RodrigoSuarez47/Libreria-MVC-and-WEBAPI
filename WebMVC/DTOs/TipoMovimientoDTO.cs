﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoMovimientoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool EsIncremento { get; set; }
    }
}
