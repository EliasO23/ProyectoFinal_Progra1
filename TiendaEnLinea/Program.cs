// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq.Expressions;
using TiendaEnLinea.DAO;
using TiendaEnLinea.Models;
using TiendaEnLinea.Negocio;
using TiendaEnLinea.ViewModels;

Console.WriteLine("Hello, World!");

Console.WriteLine("          BIENVENIDO A SPACE STORE          ");
Console.WriteLine("     ¡Compra ya las grandes ofertas en       ");
Console.WriteLine("           productos tecnologicos!       ");

CrudCliente CrudCliente = new CrudCliente();
Cliente cliente = new Cliente();
CrudProducto CrudProducto = new CrudProducto();
Producto producto = new Producto();
CrudVenta CrudVenta = new CrudVenta();
Ventum venta = new Ventum();
CrudMetodoPago CrudMetodoPago = new CrudMetodoPago();
MetodoPago MetPago = new MetodoPago();
CrudDetalleVenta CrudDetVenta = new CrudDetalleVenta();
DetalleVentum DetVenta = new DetalleVentum();

//CalcularTotal CalTotal = new CalcularTotal();
CalculoDetVenta CalcDetVenta = new CalculoDetVenta();
CalculoProducto CalcProducto = new CalculoProducto();


bool continuar = true;
while (continuar)
{
    Console.WriteLine("\n      MENU PRINCIPAL      ");
    Console.WriteLine("  1. Crear Cuenta           ");
    Console.WriteLine("  2. Ingresar               ");
    Console.WriteLine("  3. Olvide mi contraseña   ");
    Console.WriteLine("  4. Salir                  ");
    Console.Write("- Que desea hacer: ");
    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {
        case 1:
            Console.WriteLine("\n------------------------");
            Console.WriteLine("       REGISTRARSE      ");
            Console.WriteLine("------------------------");
            Console.Write("- Ingrese su nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("- Ingrese su apellido: ");
            cliente.Apellido = Console.ReadLine();
            Console.Write("- Ingrese su direccion: ");
            cliente.Direccion = Console.ReadLine();
            Console.Write("- Ingrese su correo electronico: ");
            cliente.Correo = Console.ReadLine();
            Console.Write("- Ingrese su contraseña: ");
            cliente.Contraseña = Console.ReadLine();

            CrudCliente.AgregarCliente(cliente);
            Console.WriteLine("\nEL USUARIO SE REGISTRO CORRECTAMENTE");
            Console.WriteLine("           Inicie Sesion            ");

            break;

        case 2:
            Console.WriteLine("\n------------------------");
            Console.WriteLine("    INICIO DE SESION     ");
            Console.WriteLine("------------------------");
            //Console.WriteLine("Ingrese su nombre: ");
            //var BuesquedaAdministrado = CrudCliente.ClienteIndividual(Console.ReadLine());
            Console.WriteLine("Ingrese su Correo: ");
            cliente.Correo = Console.ReadLine();
            Console.WriteLine("Ingrese su Contraseña: ");
            cliente.Contraseña = Console.ReadLine();

            var Resultado = CrudCliente.Acceso(cliente);
            var BusquedaAdministrador = CrudCliente.ClienteAdministrador(cliente.Correo);

            switch (Resultado)
            {
                case true:
                    if (BusquedaAdministrador.Cargo == "Administrador")
                    {
                        bool comprobar = true;
                        while (comprobar)
                        {
                            Console.WriteLine("\n            MENU          ");
                            Console.WriteLine("  1. Agregar Usuarios     ");
                            Console.WriteLine("  2. Actualizar Usuarios   ");
                            Console.WriteLine("  3. Listar Usuarios   ");
                            Console.WriteLine("  4. Agregar Productos   ");
                            Console.WriteLine("  5. Actualizar Productos   ");
                            Console.WriteLine("  6. Eliminar Productos   ");
                            Console.WriteLine("  7. Listar Productos   ");
                            Console.WriteLine("  8. Agregar Metodo de Pago   ");
                            Console.WriteLine("  9. Actualizar Metodo de Pago   ");
                            Console.WriteLine("  10. Eliminar Metodo de Pago   ");
                            Console.WriteLine("  11. Listar Metodos de Pago   ");
                            Console.WriteLine("  12. Ventas realizadas   ");
                            Console.WriteLine("  13. Salir     \n");
                            Console.Write("- Que desea hacer: ");
                            var Menu1 = Convert.ToInt32(Console.ReadLine());

                            switch (Menu1)
                            {
                                case 1:
                                    int bucle = 1;
                                    while (bucle == 1)
                                    {
                                        Console.WriteLine("\n\n  AGREGAR USUARIOS:");
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine("- Ingrese el nombre del usuario: ");
                                        cliente.Nombre = Console.ReadLine();
                                        Console.WriteLine("- Ingrese el apellido del usuario: ");
                                        cliente.Apellido = Console.ReadLine();
                                        Console.WriteLine("- Ingrese su direccion: ");
                                        cliente.Direccion = Console.ReadLine();
                                        Console.WriteLine("- Ingrese el correo electronico: ");
                                        cliente.Correo = Console.ReadLine();
                                        Console.WriteLine("- Ingrese una contraseña: ");
                                        cliente.Contraseña = Console.ReadLine();
                                        Console.WriteLine("- Es administrador: ");
                                        Console.WriteLine(" 1. Si ");
                                        Console.WriteLine(" 2. No ");
                                        var Administrador = Console.ReadLine();

                                        if (Administrador == "1")
                                        {
                                            cliente.Cargo = "Administrador";
                                        }

                                        CrudCliente.AgregarCliente(cliente);
                                        Console.WriteLine(" - USUARIO INGRESADO CORRECTAMENTE \n");

                                        Console.WriteLine("Coloque: ");
                                        Console.WriteLine("   1. Continuar ingresando          ");
                                        Console.WriteLine("      productos                     ");
                                        Console.WriteLine("   2. Salir                         ");
                                        Console.Write("- ¿Que desea hacer? ");
                                        bucle = Convert.ToInt32(Console.ReadLine());
                                    }
                                    break;

                                case 2:
                                    int bucle1 = 1;
                                    while (bucle1 == 1)
                                    {
                                        Console.WriteLine("\n\nACTUALIZAR USUARIOS");
                                        Console.WriteLine("------------------------------------");
                                        Console.Write("Ingrese el ID del usuario a actualizar: ");
                                        var ClienteIndividualU = CrudCliente.ClienteIndividual(Convert.ToInt32(Console.ReadLine()));

                                        if (ClienteIndividualU == null)
                                        {
                                            Console.WriteLine("\nEl usuario no existe");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar          ");
                                            Console.WriteLine("   2. Salir              ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle1 = Convert.ToInt32(Console.ReadLine());
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nRegistro a actualizar:");
                                            Console.WriteLine($"- Id: {ClienteIndividualU.IdCliente}  \n- Nombre: {ClienteIndividualU.Nombre}   \n- Apellido: {ClienteIndividualU.Apellido}   \n- Direccion: {ClienteIndividualU.Direccion}    \n- Correo Electronico: {ClienteIndividualU.Correo}   \n- Contraseña: {ClienteIndividualU.Contraseña}   \n- Cargo: {ClienteIndividualU.Cargo}");

                                            Console.WriteLine("\nPara actualizar coloca:       ");
                                            Console.WriteLine("-----------------------------------");
                                            Console.WriteLine("   1. Nombre                      ");
                                            Console.WriteLine("   2. Apellido                    ");
                                            Console.WriteLine("   3. Direccion                   ");
                                            Console.WriteLine("   4. Correo                      ");
                                            Console.WriteLine("   5. Contraseña                  ");
                                            Console.WriteLine("   6. Cargo                       ");
                                            Console.WriteLine("-----------------------------------");
                                            Console.Write("- ¿Que desea actualizar? ");
                                            var Lector = Convert.ToInt32(Console.ReadLine());

                                            switch (Lector)
                                            {
                                                case 1:
                                                    Console.WriteLine("\nIngrese el nombre del usuario:");
                                                    ClienteIndividualU.Nombre = Console.ReadLine();
                                                    break;

                                                case 2:
                                                    Console.WriteLine("\nIngrese ingrese el apellido del usuario:");
                                                    ClienteIndividualU.Apellido = Console.ReadLine();
                                                    break;

                                                case 3:
                                                    Console.WriteLine("\nIngrese la direccion del usuario: ");
                                                    ClienteIndividualU.Direccion = Console.ReadLine();
                                                    break;

                                                case 4:
                                                    Console.WriteLine("\nIngrese el correo: ");
                                                    ClienteIndividualU.Correo = Console.ReadLine();
                                                    break;

                                                case 5:
                                                    Console.WriteLine("Ingrese la contraseña: ");
                                                    ClienteIndividualU.Contraseña = Console.ReadLine();
                                                    break;

                                                case 6:
                                                    Console.WriteLine("Ingrese el cargo: ");
                                                    Console.WriteLine("- Si es Administrador   ");
                                                    Console.WriteLine("- O si es Cliente precione ENTER");
                                                    ClienteIndividualU.Cargo = Console.ReadLine();
                                                    break;

                                                default:
                                                    Console.WriteLine("\nOpcion Invalida");
                                                    break;
                                            }
                                            CrudCliente.ActualizarCliente(ClienteIndividualU, Lector);
                                            Console.WriteLine("\n - ACTUALIZACIÓN CORRECTA");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar actualizando        ");
                                            Console.WriteLine("      usuarios                      ");
                                            Console.WriteLine("   2. Salir                         ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle1 = Convert.ToInt32(Console.ReadLine());

                                        }

                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("\n\nUSUARIOS REGISTRADOS");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    Console.WriteLine("  Id    Nombre Apellido            Correo               ");
                                    Console.WriteLine("         Direccion                                      ");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    var ListarUsuarios = CrudCliente.ListarClientes();
                                    foreach (var IteUsu in ListarUsuarios)
                                    {
                                        Console.WriteLine($"  {IteUsu.IdCliente}     {IteUsu.Nombre}  {IteUsu.Apellido}              {IteUsu.Correo}\n         {IteUsu.Direccion}");

                                    }
                                    Console.Write("\nPulse ENTER para continuar: ");
                                    var cont = Console.ReadLine();

                                    break;

                                case 4:
                                    int bucle2 = 1;
                                    while (bucle2 == 1)
                                    {
                                        Console.WriteLine("\n\n  AGREGAR PRODUCTOS:");
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine("- Nombre del producto: ");
                                        producto.Nombre = Console.ReadLine();
                                        Console.WriteLine("- Descripcion:");
                                        producto.Descripcion = Console.ReadLine();
                                        Console.WriteLine("- Precio: ");
                                        producto.Precio = Convert.ToDecimal(Console.ReadLine());
                                        Console.WriteLine("- Cantidad de productos existentes: ");
                                        producto.Stock = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("-----------------------------------\n");
                                        CrudProducto.AgregarProducto(producto);

                                        Console.WriteLine(" - PRODUCTO INGRESADO CORRECTAMENTE \n");

                                        Console.WriteLine("Coloque: ");
                                        Console.WriteLine("   1. Continuar ingresando          ");
                                        Console.WriteLine("      productos                     ");
                                        Console.WriteLine("   2. Salir                         ");
                                        Console.Write("- ¿Que desea hacer? ");
                                        bucle2 = Convert.ToInt32(Console.ReadLine());

                                    }
                                    break;

                                case 5:
                                    int bucle3 = 1;
                                    while (bucle3 == 1)
                                    {
                                        Console.WriteLine("\n\nACTUALIZAR PRODUCTOS");
                                        Console.WriteLine("------------------------------------");
                                        Console.Write("Ingrese el ID del producto a actualizar: ");
                                        var ProductoIndividualU = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));

                                        if (ProductoIndividualU == null)
                                        {
                                            Console.WriteLine("\nEl producto no existe");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar          ");
                                            Console.WriteLine("   2. Salir              ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle3 = Convert.ToInt32(Console.ReadLine());
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nRegistro a actualizar:");
                                            Console.WriteLine($"- Id: {ProductoIndividualU.IdProducto}  \n- Nombre Producto: {ProductoIndividualU.Nombre}   \n- Descripcion: {ProductoIndividualU.Descripcion}   \n- Precio: {ProductoIndividualU.Precio}    \n- Stock: {ProductoIndividualU.Stock}");

                                            Console.WriteLine("\nPara actualizar coloca:       ");
                                            Console.WriteLine("-----------------------------------");
                                            Console.WriteLine("   1. Nombre Producto             ");
                                            Console.WriteLine("   2. Descripcion                 ");
                                            Console.WriteLine("   3. Precio                      ");
                                            Console.WriteLine("   4. Stock                       ");
                                            Console.WriteLine("-----------------------------------");
                                            Console.Write("- ¿Que desea actualizar? ");
                                            var Lector = Convert.ToInt32(Console.ReadLine());

                                            switch (Lector)
                                            {
                                                case 1:
                                                    Console.WriteLine("\nIngrese el nombre del producto:");
                                                    ProductoIndividualU.Nombre = Console.ReadLine();
                                                    break;

                                                case 2:
                                                    Console.WriteLine("\nIngrese ingrese la descripcion del producto:");
                                                    ProductoIndividualU.Descripcion = Console.ReadLine();
                                                    break;

                                                case 3:
                                                    Console.WriteLine("\nIngrese el precio del producto: ");
                                                    ProductoIndividualU.Precio = Convert.ToDecimal(Console.ReadLine());
                                                    break;

                                                case 4:
                                                    Console.WriteLine("\nIngrese la cantidad de productos existente: ");
                                                    ProductoIndividualU.Stock = Convert.ToInt32(Console.ReadLine());
                                                    break;

                                                default:
                                                    Console.WriteLine("\nOpcion Invalida");
                                                    break;

                                            }
                                            CrudProducto.ActualizarProductos(ProductoIndividualU, Lector);
                                            Console.WriteLine("\n - ACTUALIZACIÓN CORRECTA");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar actualizando        ");
                                            Console.WriteLine("      productos                     ");
                                            Console.WriteLine("   2. Salir                         ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle3 = Convert.ToInt32(Console.ReadLine());

                                        }
                                    }
                                    break;

                                case 6:

                                    int bucle4 = 1;
                                    while (bucle4 == 1)
                                    {
                                        Console.WriteLine("\n\nELIMINAR PRODUCTOS");
                                        Console.WriteLine("------------------------------------");
                                        Console.Write("Ingrese el ID del producto a eliminar: ");
                                        var ProductoIndividualD = CrudProducto.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));

                                        if (ProductoIndividualD == null)
                                        {
                                            Console.WriteLine("\nEl producto no existe");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar          ");
                                            Console.WriteLine("   2. Salir              ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle4 = Convert.ToInt32(Console.ReadLine());
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nRegistro a eliminar:");
                                            Console.WriteLine($"- Id: {ProductoIndividualD.IdProducto}  \n- Nombre Producto: {ProductoIndividualD.Nombre}   \n- Descripcion: {ProductoIndividualD.Descripcion}   \n- Precio: {ProductoIndividualD.Precio}    \n- Stock: {ProductoIndividualD.Stock}");

                                            Console.WriteLine("\n¿Desea eliminar este producto permanentemente?");
                                            Console.WriteLine("  1. Si    ");
                                            Console.WriteLine("  2. No    ");
                                            Console.Write("  - Opcion: ");

                                            var Lector = Convert.ToInt32(Console.ReadLine());

                                            if (Lector == 1)
                                            {
                                                var Id = Convert.ToInt32(ProductoIndividualD.IdProducto);
                                                Console.WriteLine(CrudProducto.EliminarProducto(Id));


                                            }
                                            else
                                            {
                                                Console.WriteLine("\n Inicie nuevamente");

                                            }
                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar eliminando          ");
                                            Console.WriteLine("      productos                     ");
                                            Console.WriteLine("   2. Salir                         ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle4 = Convert.ToInt32(Console.ReadLine());

                                        }
                                    }
                                    break;

                                case 7:
                                    Console.WriteLine("PRODUCTOS REGISTRADOS");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    Console.WriteLine("  Id    Descripcion                                       ");
                                    Console.WriteLine("          Precio Unitario                    Stock        ");
                                    Console.WriteLine("-----------------------------------------------------------");

                                    var ListarProductos = CrudProducto.ListarProductos();
                                    foreach (var IteProducto in ListarProductos)
                                    {
                                        Console.WriteLine($"   {IteProducto.IdProducto}    {IteProducto.Nombre}: {IteProducto.Descripcion}\n          {IteProducto.Precio}                               {IteProducto.Stock}");
                                    }
                                    Console.Write("\nPulse ENTER para continuar: ");
                                    var contar = Console.ReadLine();
                                    break;

                                case 8:
                                    Console.WriteLine("\n\n  AGREGAR METODO DE PAGO:");
                                    Console.WriteLine("------------------------------------");
                                    Console.Write("- Ingrese el metodo de pago: ");
                                    MetPago.Nombre = Console.ReadLine();

                                    CrudMetodoPago.AgregarMetodoPago(MetPago);
                                    Console.WriteLine("\nMetodo de pago ingresado correctamente");
                                    break;

                                case 9:
                                    Console.WriteLine("\nACTUALIZAR METODO DE PAGO");
                                    Console.WriteLine("------------------------------------");
                                    Console.Write("Ingrese el ID del metodo de pago a actualizar: ");
                                    var MetPagoIndividualU = CrudMetodoPago.MetPagoIndividual(Convert.ToInt32(Console.ReadLine()));
                                    if (MetPagoIndividualU == null)
                                    {
                                        Console.WriteLine("El Metodo de pago no existe");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nMetodo de pago a actualizar:");
                                        Console.WriteLine($"- Id: {MetPagoIndividualU.IdMetodoPago}  \n- Metodo de Pago: {MetPagoIndividualU.Nombre} ");

                                        Console.Write("\nIngrese el nuevo metodo de pago: ");
                                        MetPagoIndividualU.Nombre = Console.ReadLine();

                                        CrudMetodoPago.ActualizarMetPago(MetPagoIndividualU);
                                        Console.WriteLine("- ACTUALIZACION CORRECTA");

                                    }
                                    break;

                                case 10:
                                    int bucle5 = 1;
                                    while (bucle5 == 1)
                                    {
                                        Console.WriteLine("\n\nELIMINAR METODO DE PAGO");
                                        Console.WriteLine("------------------------------------");
                                        Console.Write("Ingrese el ID del metodo de pago a eliminar: ");
                                        var MetPagoIndividualD = CrudMetodoPago.MetPagoIndividual(Convert.ToInt32(Console.ReadLine()));

                                        if (MetPagoIndividualD == null)
                                        {
                                            Console.WriteLine("\nEl metodo de pago no existe");

                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar          ");
                                            Console.WriteLine("   2. Salir              ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle5 = Convert.ToInt32(Console.ReadLine());
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nRegistro a eliminar:");
                                            Console.WriteLine($"- Id: {MetPagoIndividualD.IdMetodoPago}  \n- Metodo de Pago: {MetPagoIndividualD.Nombre} ");

                                            Console.WriteLine("\n¿Desea eliminar este producto permanentemente?");
                                            Console.WriteLine("  1. Si    ");
                                            Console.WriteLine("  2. No    ");
                                            Console.Write("  - Opcion: ");

                                            var Lector = Convert.ToInt32(Console.ReadLine());

                                            if (Lector == 1)
                                            {
                                                var Id = Convert.ToInt32(MetPagoIndividualD.IdMetodoPago);
                                                Console.WriteLine(CrudMetodoPago.EliminarMetPago(Id));

                                            }
                                            else
                                            {
                                                Console.WriteLine("\n Inicie nuevamente");

                                            }
                                            Console.WriteLine("\nColoque: ");
                                            Console.WriteLine("   1. Continuar eliminando          ");
                                            Console.WriteLine("      productos                     ");
                                            Console.WriteLine("   2. Salir                         ");
                                            Console.Write("- ¿Que desea hacer? ");
                                            bucle5 = Convert.ToInt32(Console.ReadLine());

                                        }
                                    }
                                    break;

                                case 11:
                                    Console.WriteLine("\nMETODOS DE PAGO");
                                    Console.WriteLine("------------------------------------");
                                    Console.WriteLine("  Id      Metodo de Pago");
                                    Console.WriteLine("------------------------------------");
                                    var ListarMetPagos2 = CrudMetodoPago.ListarMetodoPago();
                                    foreach (var ItePagos in ListarMetPagos2)
                                    {
                                        Console.WriteLine($"  {ItePagos.IdMetodoPago}       {ItePagos.Nombre} ");
                                    }
                                    Console.Write("\nPulse ENTER para continuar: ");
                                    var conta = Console.ReadLine();
                                    break;

                                case 12:
                                    Console.WriteLine("\nVENTAS REGISTRADAS");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    Console.WriteLine("  Id    Fecha Venta                Total a Pagar           ");
                                    Console.WriteLine("          Cliente     Metodo de Pago               ");
                                    Console.WriteLine("-----------------------------------------------------------");

                                    var ListarVentas = CrudVenta.ListaVentas();
                                    foreach (var indice in ListarVentas)
                                    {
                                        Console.WriteLine($"   {indice.IdVenta}    {indice.FechaVenta}               {indice.TotalPagar}\n            {indice.IdCliente}               {indice.IdMetodoPago}");
                                    }

                                    var bucle8 = 1;
                                    while (bucle8 == 1)
                                    {
                                        Console.Write("\nIngrese el Id de la venta para ver el detalle: ");
                                        var IdVenta = Convert.ToInt32(Console.ReadLine());

                                        var Venta = CrudDetVenta.ProductoDetVenta(IdVenta);
                                        Console.WriteLine("-----------------------------------------------------------");
                                        Console.WriteLine(" Cant.  Producto        Descripcion                       ");
                                        Console.WriteLine("        Precio Unitario              Total               ");
                                        Console.WriteLine("-----------------------------------------------------------");
                                        foreach (var indice in Venta)
                                        {
                                            Console.WriteLine($"  {indice.Cantidad}     {indice.Nombre}  {indice.Descripcion}  \n        {indice.Precio}                       {indice.Total}");
                                        }
                                        Console.WriteLine("\nColoque: ");
                                        Console.WriteLine("   1. Ver otro detalle          ");
                                        Console.WriteLine("   2. Salir                     ");
                                        Console.Write("- ¿Que desea hacer? ");
                                        bucle8 = Convert.ToInt32(Console.ReadLine());

                                    }
                                    break;

                                case 13:
                                    comprobar = false;
                                    break;

                                default:
                                    Console.WriteLine("\nOpcion Invalida");
                                    break;
                            }

                        }
                    }
                   
                    else if (BusquedaAdministrador.Cargo == null)
                    {
                        bool bucleOp = true;
                        while (bucleOp == true)
                        {

                            Console.WriteLine("\nOpciones: ");
                            Console.WriteLine(" 1. Lista de Productos ");
                            Console.WriteLine(" 2. Realizar una compra ");
                            Console.WriteLine(" 3. Salir      ");
                            Console.Write("Que desea hacer: ");
                            var desi = Convert.ToInt32(Console.ReadLine());

                            switch (desi)
                            {
                                case 1:
                                    Console.WriteLine("\nPRODUCTOS:");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    Console.WriteLine("  Id    Descripcion                                       ");
                                    Console.WriteLine("          Precio Unitario                    Stock        ");
                                    Console.WriteLine("-----------------------------------------------------------");

                                    var ListaProductos = CrudProducto.ListarProductos();
                                    foreach (var IteProducto in ListaProductos)
                                    {
                                        Console.WriteLine($"   {IteProducto.IdProducto}    {IteProducto.Descripcion}\n          {IteProducto.Precio}                               {IteProducto.Stock}");
                                    }
                                    break;

                                case 2:
                                    
                                    venta.IdCliente = BusquedaAdministrador.IdCliente;

                                    //Agregar una venta a la Tabla Ventas
                                    CrudVenta.AgregarVenta(venta);

                                    Console.WriteLine("\nREALIZAR UNA COMPRA");
                                    Console.WriteLine("------------------------------------\n");
                                    Console.WriteLine("PRODUCTOS:");
                                    Console.WriteLine("-----------------------------------------------------------");
                                    Console.WriteLine("  Id    Descripcion                                       ");
                                    Console.WriteLine("          Precio Unitario                    Stock        ");
                                    Console.WriteLine("-----------------------------------------------------------");


                                    var ListarProductos = CrudProducto.ListarProductos();
                                    foreach (var IteProducto in ListarProductos)
                                    {
                                        Console.WriteLine($"   {IteProducto.IdProducto}    {IteProducto.Nombre}: {IteProducto.Descripcion}\n          {IteProducto.Precio}                               {IteProducto.Stock}");
                                    }

                                    int bucle6 = 1;
                                    while (bucle6 == 1)
                                    {

                                        var BusquedaIdVenta = CrudVenta.EncontrarIdVenta(venta.IdCliente);

                                        foreach (var IteVenta in BusquedaIdVenta)
                                        {
                                            DetVenta.IdVenta = IteVenta.IdVenta;
                                        }

                                        Console.WriteLine("\nIngrese el ID del producto a comprar: ");
                                        DetVenta.IdProducto = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Ingrese la cantidad a comprar del producto:");
                                        DetVenta.Cantidad = Convert.ToInt32(Console.ReadLine());

                                        var buscarSt = CrudProducto.ProductoIndividual(DetVenta.IdProducto);
                                        var resultado = CalcProducto.CalcularStock(buscarSt.Stock, DetVenta.Cantidad);

                                        if (buscarSt.Stock < DetVenta.Cantidad)
                                        {
                                            Console.WriteLine("No hay la cantidad suficiente de productos");
                                            continue;
                                        }
                                        else
                                        {
                                            buscarSt.Stock = resultado;

                                            //Actualizar el Stock en la tabla Productos, cuando compra un cliente
                                            CrudProducto.ActualizarStock(buscarSt);
                                            //CrudProducto.ActualizarProductos(buscarSt, 4);

                                        }

                                        var buscar = CrudProducto.ProductoIndividual(DetVenta.IdProducto);

                                        //Agregar el total por cada compra
                                        DetVenta.Total = Convert.ToDecimal(CalcDetVenta.TotalProducto(DetVenta.Cantidad, buscar.Precio));


                                        Console.WriteLine($"\nTotal: {DetVenta.Total}");

                                        Console.WriteLine("\nColoque: ");
                                        Console.WriteLine("   1. Agregar otro producto      ");
                                        Console.WriteLine("   2. Completar pago                      ");
                                        Console.Write("- ¿Que desea hacer? ");
                                        bucle6 = Convert.ToInt32(Console.ReadLine());


                                        //Agregar el detalle de la compra a la tabla DetalleVenta
                                        CrudDetVenta.AgregarDetalleVenta(DetVenta);

                                    }

                                    if (bucle6 == 2)
                                    {
                                        Console.WriteLine("\nMETODO DE PAGO");
                                        Console.WriteLine("------------------------------------");
                                        var BusquedaMetPago = CrudVenta.VentaIndividual(DetVenta.IdVenta);

                                        if (BusquedaMetPago == null)
                                        {
                                            Console.WriteLine("El metodo de pago no existe");
                                        }
                                        else
                                        {
                                            var ListarMetPagos2 = CrudMetodoPago.ListarMetodoPago();
                                            foreach (var ItePagos in ListarMetPagos2)
                                            {
                                                Console.WriteLine($" {ItePagos.IdMetodoPago}  {ItePagos.Nombre} ");
                                            }
                                            Console.Write("\n- Ingrese el metodo de pago: ");
                                            BusquedaMetPago.IdMetodoPago = Convert.ToInt32(Console.ReadLine());
                                            
                                            CrudVenta.ActMetPagoCliente(BusquedaMetPago);


                                        }

                                        Console.WriteLine("\nRECIBO");
                                        Console.WriteLine("------------------------------------");
                                        Console.WriteLine("              SPACE STORE             ");
                                        Console.WriteLine("       Donde encuentras de todo       ");
                                        Console.WriteLine("           y al mejor precio          \n");

                                        var Usuario = CrudCliente.ClienteIndividual(venta.IdCliente);
                                        Console.WriteLine($"Cliente: {Usuario.IdCliente} \nNombre: {Usuario.Nombre} {Usuario.Apellido}");

                                        var Fecha = CrudVenta.VentaIndividual(DetVenta.IdVenta);
                                        Console.WriteLine($"Fecha de Compra: {Fecha.FechaVenta}");

                                        var TotalPagar = CrudVenta.VentaIndividual(DetVenta.IdVenta);
                                        Console.WriteLine($"Venta : {TotalPagar.IdVenta}");


                                        Console.WriteLine("-----------------------------------------------------------");
                                        Console.WriteLine(" Cant.  Producto        Descripcion                       ");
                                        Console.WriteLine("        Precio Unitario              Total               ");
                                        Console.WriteLine("-----------------------------------------------------------");

                                        var ReciboCliente = CrudDetVenta.ProductoDetVenta(TotalPagar.IdVenta);
                                        foreach (var indice in ReciboCliente)
                                        {
                                            Console.WriteLine($"  {indice.Cantidad}     {indice.Nombre}  {indice.Descripcion}  \n        {indice.Precio}                       {indice.Total}");
                                        }

                                        var Pagar = CrudDetVenta.TotalAPagar(TotalPagar.IdVenta);

                                        foreach (var indice in Pagar)
                                        {

                                            var BuscarTPagar = CrudVenta.VentaIndividual(DetVenta.IdVenta);

                                            if (BuscarTPagar == null)
                                            {
                                                Console.WriteLine("La venta no existe");
                                            }
                                            else
                                            {
                                                BuscarTPagar.TotalPagar = indice.TotalPagar;

                                                CrudVenta.ActualizarTotal(BuscarTPagar);
                                                Console.WriteLine($"\nTotal a pagar: {BuscarTPagar.TotalPagar}");
                                                Console.WriteLine("\n- Compra hecha satisfactoriamente\n");

                                            }

                                        }

                                    }
                                    break;

                                case 3:
                                    bucleOp = false;
                                    break;

                                default:
                                    Console.WriteLine("\nOpcion Invalida");
                                    break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Su cuenta a sido deshabilitada");
                        Console.WriteLine("- Comuniquese con un administrador");
                        
                    }
                    break;

                case false:
                    Console.WriteLine("Usuario no encontrado: ");
                    Console.WriteLine("- Ingrese correctamente sus crendeciales");
                    Console.WriteLine("- O cree una cuenta ");

                    break;
            }
            break;

        case 3:
            Console.WriteLine("\nRECUPERAR CONTRASEÑA");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Buscar por: ");
            Console.WriteLine("1. Correo ");
            Console.WriteLine("2. Nombre de usuario \n");
            Console.Write("Que desea hacer: ");
            var desicion = Convert.ToInt32(Console.ReadLine());

            switch (desicion)
            {
                case 1:
                    Console.WriteLine("- Ingrese su correo: ");
                    var Cliente = Console.ReadLine();

                    var BuscarContraseña = CrudCliente.ClienteAdministrador(Cliente);

                    if (BuscarContraseña == null)
                    {
                        Console.WriteLine("\nUsuario no encontrado");
                    }
                    else
                    {
                        Console.WriteLine("\nSUS CREDENCIALES SON:");
                        Console.WriteLine($"- Usuario: {BuscarContraseña.Nombre} {BuscarContraseña.Apellido}");
                        Console.WriteLine($"- Contraseña: {BuscarContraseña.Contraseña}");
                        Console.Write("\nPulse ENTER para continuar: ");
                        var contad = Console.ReadLine();
                    }
                    break;

                case 2:
                    Console.WriteLine("- Ingrese su nombre de usuario: ");
                    var NomUsuario = Console.ReadLine();

                    var BuscarContra = CrudCliente.EncontrarUsuario(NomUsuario);

                    if (BuscarContra == null)
                    {
                        Console.WriteLine("\nUsuario no encontrado");
                    }
                    else
                    {
                        Console.WriteLine("\nSUS CREDENCIALES SON:");
                        Console.WriteLine($"- Correo: {BuscarContra.Correo}");
                        Console.WriteLine($"- Contraseña: {BuscarContra.Contraseña}");
                        Console.Write("\nPulse ENTER para continuar: ");
                        var conta = Console.ReadLine();
                    }
                    break;

                default:
                    Console.WriteLine("\nOpcion Invalida");
                    break;
            } 
            
            break;

        case 4:
            Console.WriteLine("\n\n----------------------------------------------------------");
            Console.WriteLine("           ¡GRACIAS POR VISITAR NUESTRA TIENDA!           ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(" - Vueva pronto");
            Console.WriteLine(" - Lo esperamos\n");

            continuar = false;
            break;

        default:
            Console.WriteLine("\nOpcion Invalida");
            break;
    }
}

