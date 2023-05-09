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
    public class CrudVenta
    {
        TiendaOnlineContext db = new TiendaOnlineContext();

        public void AgregarVenta(Ventum ParamVenta)
        {
            Ventum venta = new Ventum();
            venta.IdCliente = ParamVenta.IdCliente;
            venta.FechaVenta = ParamVenta.FechaVenta;
            venta.IdMetodoPago = ParamVenta.IdMetodoPago;

            db.Add(venta);
            db.SaveChanges();
        }

        public Ventum VentaIndividual(int id)
        {
            var buscar = db.Venta.FirstOrDefault(x => x.IdVenta == id);
            return buscar;
        }

        public void ActualizarTotal(Ventum ParamVenta)
        {
            var buscar = VentaIndividual(ParamVenta.IdVenta);
            if (buscar == null)
            {
                Console.WriteLine("El Id del producto no existe");
            }
            else
            {
                buscar.TotalPagar = ParamVenta.TotalPagar;

                db.Update(buscar);
                db.SaveChanges();
            }
        }

        //public decimal TotalProducto(int cantidad, decimal precio)
        //{
        //    return cantidad * precio;
        //}

        public void ActMetPagoCliente(Ventum ParamVenta)
        {
            var buscar = VentaIndividual(ParamVenta.IdVenta);
            if (buscar == null)
            {
                Console.WriteLine("El Id del metodo de pago no existe");
            }
            else
            {
                buscar.IdMetodoPago = ParamVenta.IdMetodoPago;

                db.Update(buscar);
                db.SaveChanges();
            }
        }
        public List<VentaVM> EncontrarIdVenta(int IdCliente)
        {
            var IdDeLaVenta = db.VentaVMs.FromSqlRaw($"SELECT TOP 1 IdVenta FROM Venta Where IdCliente = {IdCliente} ORDER BY IdVenta DESC;").ToList();
            return IdDeLaVenta;
        }

        public List<Ventum> ListaVentas()
        {
            return db.Venta.ToList();
        }

    }
}
