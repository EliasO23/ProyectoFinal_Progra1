using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;
using TiendaEnLinea.ViewModels;

namespace TiendaEnLinea.DAO
{
    public class CrudDetalleVenta
    {
        TiendaOnlineContext db = new TiendaOnlineContext();

        public void AgregarDetalleVenta(DetalleVentum ParamDetVenta)
        {
            DetalleVentum DetVenta = new DetalleVentum();
            DetVenta.IdVenta = ParamDetVenta.IdVenta;
            DetVenta.IdProducto = ParamDetVenta.IdProducto;
            DetVenta.Cantidad = ParamDetVenta.Cantidad;
            DetVenta.Total = ParamDetVenta.Total;

            db.Add(DetVenta);
            db.SaveChanges();
        }

        public List<DetalleVentum> ListarDetallesVenta()
        {
            return db.DetalleVenta.ToList();
        }

        public DetalleVentum DetalleVentaIndividual(int id)
        {
            var buscar = db.DetalleVenta.FirstOrDefault(x => x.IdVenta == id);
            return buscar;
        }

        //List<DetalleVentum> DetalleVenta = new List<DetalleVentum>();
        //public void AgregarTotalPagar(DetalleVentum ParamDetVenta)
        //{
        //    DetalleVenta.Add(ParamDetVenta);
        //}

        //public List<DetalleVentum> ListarDetVenta()
        //{
        //    return DetalleVenta;
        //}

        public List<ProductosDetVentaVM> ProductoDetVenta(int IdVenta)
        {
            var ReciboCliente = db.ProductosDetVentaVMs.FromSqlRaw($"SELECT Dv.Cantidad, Pr.Nombre, Pr.Descripcion, Pr.Precio, Dv.Total FROM Producto AS Pr INNER JOIN DetalleVenta AS Dv ON Pr.IdProducto = Dv.IdProducto INNER JOIN Venta AS V ON V.IdVenta = Dv.IdVenta WHERE V.IdVenta = {IdVenta}").ToList();
            return ReciboCliente;
        }

        public List<TotalPagarVM> TotalAPagar(int IdVenta)
        {
            var TotalPagar = db.TotalPagarVMs.FromSqlRaw($"Select SUM(Total) as TotalPagar From DetalleVenta Where IdVenta = {IdVenta}").ToList();
            return TotalPagar;
        }

    }
}
