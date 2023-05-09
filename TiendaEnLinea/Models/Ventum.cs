using System;
using System.Collections.Generic;

namespace TiendaEnLinea.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int? IdMetodoPago { get; set; }

    public DateTime? FechaVenta { get; set; }

    public decimal? TotalPagar { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; }
}
