using System;
using System.Collections.Generic;

namespace AplicacionWebTiendaEnLinea.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Cargo { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
