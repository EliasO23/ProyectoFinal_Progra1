using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.DAO
{
    public class CrudMetodoPago
    {
        TiendaOnlineContext db = new TiendaOnlineContext();

        public void AgregarMetodoPago(MetodoPago ParamMetPago)
        {
            MetodoPago MetPago = new MetodoPago();
            MetPago.Nombre = ParamMetPago.Nombre;

            db.Add(MetPago);
            db.SaveChanges();
        }

        public MetodoPago MetPagoIndividual(int Id)
        {
            var buscar = db.MetodoPagos.FirstOrDefault(x => x.IdMetodoPago == Id);
            return buscar;
        }

        public void ActualizarMetPago(MetodoPago ParamMetPago)
        {
            var buscar = MetPagoIndividual(ParamMetPago.IdMetodoPago);
            if (buscar == null)
            {
                Console.WriteLine("El Id no existe");
            }
            else
            {
                buscar.Nombre = ParamMetPago.Nombre;

                db.Update(buscar);
                db.SaveChanges();
            }
        }

        public string EliminarMetPago(int Id)
        {
            var buscar = MetPagoIndividual(Id);
            if (buscar == null)
            {
                return "El Metodo de Pago no existe";
            }
            else
            {
                db.MetodoPagos.Remove(buscar);
                db.SaveChanges();
                return "El Metodo de Pago se elimino correctamente";
            }
        }

        public List<MetodoPago> ListarMetodoPago()
        {
            return db.MetodoPagos.ToList();
        }
    }
}
