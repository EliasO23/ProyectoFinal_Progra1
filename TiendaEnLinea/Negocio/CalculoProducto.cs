using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.Negocio
{
    public class CalculoProducto
    {
        TiendaOnlineContext db = new TiendaOnlineContext();
        public int CalcularStock(int Stock, int cantidad)
        {
            return Stock - cantidad;

        }
    }
}
