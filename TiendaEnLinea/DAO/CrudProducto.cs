using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.DAO
{
    public class CrudProducto
    {
        TiendaOnlineContext db = new TiendaOnlineContext();
        public void AgregarProducto(Producto ParamProducto)
        {
            Producto producto = new Producto();
            producto.Nombre = ParamProducto.Nombre;
            producto.Descripcion = ParamProducto.Descripcion;
            producto.Precio = ParamProducto.Precio;
            producto.Stock = ParamProducto.Stock;

            db.Add(producto);
            db.SaveChanges();
        }

        public List<Producto> ListarProductos()
        {
            return db.Productos.ToList();
        }

        public Producto ProductoIndividual(int id)
        {
            var buscar = db.Productos.FirstOrDefault(x => x.IdProducto == id);
            return buscar;
        }

        public void ActualizarProductos(Producto ParamProducto, int Lector)
        {
            var buscar = ProductoIndividual(ParamProducto.IdProducto);
            if (buscar == null)
            {
                Console.WriteLine("El Id no existe");
            }
            else
            {
                switch (Lector)
                {
                    case 1:
                        buscar.Nombre = ParamProducto.Nombre;
                        break;

                    case 2:
                        buscar.Descripcion = ParamProducto.Descripcion;
                        break;

                    case 3:
                        buscar.Precio = ParamProducto.Precio;
                        break;

                    case 4:
                        buscar.Stock = ParamProducto.Stock;
                        break;

                }
                db.Update(buscar);
                db.SaveChanges();
            }
        }

        public string EliminarProducto(int id)
        {
            var buscar = ProductoIndividual(id);
            if (buscar == null)
            {
                return "El Producto no existe";
            }
            else
            {
                db.Productos.Remove(buscar);
                db.SaveChanges();
                return "El Producto se elimino correctamente";
            }
        }

        //public void Precio(Producto ParamProducto)
        //{
        //    var buscar = ProductoIndividual(ParamProducto.IdProducto);
        //    return buscar;
        //}

        public void ActualizarStock(Producto ParamProducto)
        {
            var buscar = ProductoIndividual(ParamProducto.IdProducto);
            if (buscar == null)
            {
                Console.WriteLine("El Id del producto no existe");
            }
            else
            {
                buscar.Stock = ParamProducto.Stock;

                db.Update(buscar);
                db.SaveChanges();
            }
        }
    }
}
