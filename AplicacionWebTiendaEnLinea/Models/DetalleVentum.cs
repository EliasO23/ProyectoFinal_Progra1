﻿using System;
using System.Collections.Generic;

namespace AplicacionWebTiendaEnLinea.Models;

public partial class DetalleVentum
{
    public int IdDetVenta { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Total { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
