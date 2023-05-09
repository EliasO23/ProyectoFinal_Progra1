using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.DAO
{
    public class CrudCliente
    {
        TiendaOnlineContext db = new TiendaOnlineContext();

        public void AgregarCliente(Cliente ParamCliente)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = ParamCliente.Nombre;
            cliente.Apellido = ParamCliente.Apellido;
            cliente.Direccion = ParamCliente.Direccion;
            cliente.Correo = ParamCliente.Correo;
            cliente.Contraseña = ParamCliente.Contraseña;
            cliente.Cargo = ParamCliente.Cargo;

            db.Add(cliente);
            db.SaveChanges();
        }

        public bool Acceso(Cliente ParamCliente)
        {
            var Acceder = db.Clientes.Where(x => x.Correo == ParamCliente.Correo && x.Contraseña == ParamCliente.Contraseña).ToList();

            if (Acceder.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Cliente ClienteAdministrador(string correo)
        {
            var buscar = db.Clientes.FirstOrDefault(x => x.Correo == correo);
            return buscar;
        }

        public Cliente EncontrarUsuario(string nombre)
        {
            var buscar = db.Clientes.FirstOrDefault(x => x.Nombre == nombre);
            return buscar;
        }

        public Cliente ClienteIndividual(int id)
        {
            var buscar = db.Clientes.FirstOrDefault(x => x.IdCliente == id);
            return buscar;
        }

        public List<Cliente> ListarClientes()
        {
            return db.Clientes.ToList();
        }


        public void ActualizarCliente(Cliente ParamCliente, int Lector)
        {
            var buscar = ClienteIndividual(ParamCliente.IdCliente);

            if (buscar == null)
            {
                Console.WriteLine("El ID no existe");
            }
            else
            {
                switch (Lector)
                {
                    case 1:
                        buscar.Nombre = ParamCliente.Nombre;
                        break;

                    case 2:
                        buscar.Apellido = ParamCliente.Apellido;
                        break;

                    case 3:
                        buscar.Direccion = ParamCliente.Direccion;
                        break;

                    case 4:
                        buscar.Correo = ParamCliente.Correo;
                        break;

                    case 5:
                        buscar.Contraseña = ParamCliente.Contraseña;
                        break;

                    case 6:
                        buscar.Cargo = ParamCliente.Cargo;
                        break;
                }
                db.Update(buscar);
                db.SaveChanges();
            }
        }
    }
}
