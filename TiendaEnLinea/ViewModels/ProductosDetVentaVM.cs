﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaEnLinea.ViewModels
{
    public class ProductosDetVentaVM
    {
        public int Cantidad { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
