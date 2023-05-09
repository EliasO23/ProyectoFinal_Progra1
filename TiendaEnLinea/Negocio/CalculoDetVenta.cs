using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Negocio
{
    public class CalculoDetVenta
    {
        TiendaOnlineContext db = new TiendaOnlineContext();
        public decimal TotalProducto(int cantidad, decimal precio)
        {
            return cantidad * precio;
        }
    }
}
