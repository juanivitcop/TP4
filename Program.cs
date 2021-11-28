using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP4
{
    class InterfazUsuario
    {

        // Archivos                
        private string archivoClientes = "archivoClientes.txt";
        private string archivoServicio = "archivoServicio.txt";
        private string archivoFacturas = "archivoFacturas.txt";

        //Listas que van a contener clientes, servicios y facturas
        private List<Cliente> listacliente = new List<Cliente>();
        private List<Servicio> listaservicio = new List<Servicio>();
        private List<Factura> listafacturas = new List<Factura>();

        int NUEVA_SOLICITUD_SERVICIOS = 1;
        int CONSULTAR_ESTADO_SERVICIOS = 2;
        int CONSULTAR_ESTADO_CUENTA_CORRIENTE = 3;
        int FINALIZAR = 4;

        public InterfazUsuario()
        {
            // Inicializacion de los datos.
            CargarArchivoServicio();
            CargarArchivoFacturas();
            CargarArchivoClientes();


            

            // Manejo del menu principal.
            int opcion;
            do
            {
                opcion = MostrarMenuPrincipal();
                if (opcion < NUEVA_SOLICITUD_SERVICIOS || opcion > FINALIZAR)
                {
                    Console.WriteLine("\nEl número ingresado no corresponde a una acción. Por favor ingrese nuevamente un número\n");
                }
                else if (opcion == NUEVA_SOLICITUD_SERVICIOS)
                {
                    ProcesoSolicitudServicio();
                    Console.WriteLine("Solicitud de servicio finalizada");
                }
                else if (opcion == CONSULTAR_ESTADO_SERVICIOS)
                {
                    ConsultarServicio();
                    Console.WriteLine("Consulta procesada exitosamente");
                }
                else if (opcion == CONSULTAR_ESTADO_CUENTA_CORRIENTE)
                {
                    ConsultarCuenta_Corriente();
                    Console.WriteLine("Consulta procesada exitosamente");
                }
            } while (opcion != FINALIZAR);

            

        }


        ~InterfazUsuario()
        {
            
            //actualizar.
            using (var writerServicio = new StreamWriter("archivoServicio.txt"))
            
            {
                foreach (var servicio in listaservicio)
                {
                    servicio.GrabarCon(writerServicio);
                }
            }

            using (var writerFactura = new StreamWriter("archivoFacturas.txt"))

            {
                foreach (var factura in listafacturas)
                {
                    factura.GrabarCon(writerFactura);
                }
            }
        }



        private int MostrarMenuPrincipal()
        {
            int opcion = 0;
            // Mostramos el menu principal en la consola.
            Console.WriteLine("Ingrese su opción\n");
            Console.WriteLine("1. Nueva Solicitud de servicio");
            Console.WriteLine("2. Consultar Estado de Servicio");
            Console.WriteLine("3. Consultar Estado de Cuenta Corriente");
            Console.WriteLine("4. Finalizar");


            // Tomamos el valor ingresado por el usuario y lo retornamos.
            Int32.TryParse(Console.ReadLine(), out opcion);

            return opcion;
        }

        private void ProcesoSolicitudServicio()
        {
            int indice;
            string respuesta;
            string tipodeservicio = null;
            Int32 idcliente;
            
            string tipodeenvio = null;
            Decimal Precio = 0;
            bool Facturado = false;
            bool Abonado = false;
            String Estado = "Pendiente";
            string CiudadDeEntrega;
            string CalleDeEntrega;
            Int32 AlturaCalle;
            Int32 Ingreso;
            Int32 Ingreso2;
            int Contador = 0;
            


            

            foreach (Servicio servicio in listaservicio)
            {
                Contador++;

            }
            Int32 idenvio = 20000000 + Contador;

            

            while (true)
            {
                Console.WriteLine("Ingrese su Id de cliente:");
                Int32.TryParse(Console.ReadLine(), out idcliente);


                indice = BuscarIndiceClienteUsuario(idcliente);
                if (indice == -1)
                {
                    Console.WriteLine("\nError:El usuario ingresado no se corresponde a un cliente corporativo.\n");
                    continue;
                }

                break;

            }

                Cliente cliente = listacliente[indice];

                while (true)
                {
                    Console.WriteLine("Ingrese el tipo de servicio:\n");
                    Console.WriteLine("1. Bulto");
                    Console.WriteLine("2. Carta");


                    Int32.TryParse(Console.ReadLine(), out Ingreso);

                    if (Ingreso < 1 || Ingreso > 2)
                    {
                        Console.WriteLine("\nPor favor ingrese “1” para Bulto o “2” para Carta.\n");
                    continue;
                    }
                  
                                     
                    break;
                  
                }

                while (true)
                {
                    Console.WriteLine("Ingrese el tipo de envío:\n");
                    Console.WriteLine("1. Normal");
                    Console.WriteLine("2. Urgente");

                    Int32.TryParse(Console.ReadLine(), out Ingreso2);

                    if (Ingreso2 < 1 || Ingreso2 > 2)
                    {
                        Console.WriteLine("\nPor favor ingrese “1” para Normal o “2” para Urgente.\n");
                    continue;
                    }
                    
                  
                    break;
                  
                }


                while (true)
                {
                    Console.WriteLine("Ingrese la ciudad del envio:");
                    var ciudadDeEntrega = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(ciudadDeEntrega))
                    {
                        Console.WriteLine("Por favor ingrese una ciudad.");
                        continue;
                    }

                    CiudadDeEntrega = ciudadDeEntrega;

                    break;

                }

                while (true)
                {
                    Console.WriteLine("Ingrese la calle del envio:");
                    var calleDeEntrega = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(calleDeEntrega))
                    {
                        Console.WriteLine("Por favor ingrese una calle.");
                        continue;
                    }

                    
                CalleDeEntrega = calleDeEntrega;

                    break;

                }

                while (true)
                {
                    Console.WriteLine("Ingrese la altura del envio:");
                    var Ingreso3 = Console.ReadLine();

                    if (!int.TryParse(Ingreso3, out int alturaCalle))
                    {
                        Console.WriteLine("Por favor ingrese una altura válida");
                        continue;
                    }

                    if (alturaCalle.ToString().Length > 4 || alturaCalle.ToString().Length < 1)
                    {
                        Console.WriteLine("Por favor ingrese una altura válida");
                        continue;
                    }
                    

                    AlturaCalle = alturaCalle;

                    break;

                }

                if (Ingreso == (1))
                {
                    tipodeservicio = "Bulto";
                    Precio += 200;
                }
                else if (Ingreso == (2))
                {
                    tipodeservicio = "Carta";
                    Precio += 100;
                }


                if (Ingreso2 == (1))
                {
                    tipodeenvio = "Normal";

                }
                else if (Ingreso2 == (2))
                {
                    tipodeenvio = "Urgente";
                    Precio += 100;
                }



            while (true)
            {
                Console.WriteLine($"\nConfirma el servicio de envío de {tipodeservicio} por un valor de {Precio}? (S: Sí / N: No)\n");
                respuesta = Console.ReadLine();
                if (respuesta.ToUpper() == "S")
                {
                    idenvio++;
                    
                    var Importe = Precio;
                    

                    Servicio servicio = new Servicio();
                    servicio.idenvio = idenvio;
                    servicio.idcliente = idcliente;
                    servicio.Estado = Estado;
                    servicio.tipodeservicio = tipodeservicio;
                    servicio.tipodeenvio = tipodeenvio;
                    servicio.Precio = Precio;
                    servicio.CiudadDeEntrega = CiudadDeEntrega;
                    servicio.CalleDeEntrega = CalleDeEntrega;
                    servicio.AlturaCalle = AlturaCalle;
                    servicio.Facturado = Facturado;
                    servicio.Abonado = Abonado;
                    listaservicio.Add(servicio);

                    

                    Console.WriteLine("\nGenerada exitosamente.\n");
                    Console.WriteLine($"\nSu ID de envio es: {idenvio}\n");


                }
                else if (respuesta.ToUpper() != "N")
                {
                    Console.WriteLine("Por favor ingrese “S” para confirmar o “N” para cancelar.");
                    continue;
                }
                else if (respuesta.ToUpper() == "N")
                {
                    Console.WriteLine("Solicitud de Servicio cancelada."); 


                }

                break;

            }
        }


        private void ConsultarServicio()
        {
            bool Flag;
            String idenvio;
            int Salida = 0;
            int indice;

            Console.WriteLine("Ingrese su Id de Envío:");
            idenvio = Console.ReadLine();
            ValidarIdEnvio(idenvio, ref Salida);
            indice = BuscarIndiceEnvio(Salida);
            
            if (indice == -1)
            {
                Console.WriteLine("\nError:El envío ingresado no se corresponde a un cliente corporativo.\n");
                return;
            }
            else
            {                
                Servicio servicio = listaservicio[indice];
                Console.WriteLine($"El envío {idenvio} con destino a {servicio.CiudadDeEntrega} se encuentra {servicio.Estado}");
                Console.WriteLine("Id de envio ingresado: " + Salida);
                Console.WriteLine("Estado: " + servicio.Estado);
                Console.WriteLine("Tipo de Envio: " + servicio.tipodeenvio);
                Console.WriteLine("Tipo de Servicio: " + servicio.tipodeservicio);
                Console.WriteLine("Ciudad de Entrega: " + servicio.CiudadDeEntrega + "\n");
                

            }


        }


        private void ConsultarCuenta_Corriente()
        {
                      
            int indice;
            Int32 idcliente;
            string Lista = "";
            string Lista2 = "";
            decimal Saldo = 0;
            decimal Saldo2 = 0;
            
            



            while (true)
            {
                Console.WriteLine("Ingrese su Id de cliente:");
                Int32.TryParse(Console.ReadLine(), out idcliente);

                if (idcliente.ToString().Length > 8 || idcliente.ToString().Length < 1)
                {
                    Console.WriteLine("Por favor ingrese un ID válido");
                    return;
                }

                indice = BuscarIndiceClienteUsuario(idcliente);
                if (indice == -1)
                {
                    Console.WriteLine("\nError:El usuario ingresado no se corresponde a un cliente corporativo.\n");
                    return;
                }

                else
                {
                    
                    foreach (Factura factura in listafacturas)
                    {
                        if (factura.idcliente == idcliente && factura.Abonado == false)
                        { 
                            
                            Lista += factura.NumFactura + "\n";
                            Saldo += factura.Importe;
                        }

                    }
                    

                    foreach (Servicio servicio in listaservicio)
                    {
                        if (servicio.idcliente == idcliente && servicio.Facturado == false)
                        {

                            Lista2 += servicio.idenvio + "\n";
                            Saldo2 += servicio.Precio;
                        }

                    }

                    decimal SaldoT = Saldo + Saldo2;

                    Console.WriteLine("Facturas pendientes:\n" + Lista);
                    Console.WriteLine("Saldo de facturas pendientes: " + Saldo + "\n");
                    Console.WriteLine("Id de Envio/s pendientes de facturar:\n" + Lista2);
                    Console.WriteLine("Saldo pendiente de facturar: " + Saldo2);
                    Console.WriteLine($"Saldo pendiente Total: {SaldoT}\n");


                }

                break;

            }

        }


        private bool ValidarIdEnvio(string Numero, ref int Salida)
        {
            bool F = false;

            
                if (!int.TryParse(Numero, out Salida))
                {
                    Console.WriteLine("Usted debe ingresar un valor numerico.");
                }
                else if (Salida <= 0)
                {
                    Console.WriteLine("Usted debe ingresar un valor numerico positivo.");
                }
                else if (Salida.ToString().Length > 8 || Salida.ToString().Length < 1)
                {
                    Console.WriteLine("Por favor ingrese un ID válido");

                }
                else
                {
                    F = true;
                }

                return F;
                        
        }

        

        private int BuscarIndiceClienteUsuario(Int32 idcliente)
        {
            int indice = 0;
            foreach (Cliente cliente in listacliente)
            {
                if (cliente.idcliente == idcliente)
                    return indice;
                indice += 1;
            }
            return -1;
        }

        private int BuscarIndiceEnvio(int idenvio)
        {
            int indice = 0;
            foreach (Servicio servicio in listaservicio)
            {
                if (servicio.idenvio == idenvio)
                    return indice;
                indice += 1;
            }
            return -1;
        }

      
        private void CargarArchivoServicio()
        {

            string[] lineas = File.ReadAllLines(archivoServicio);


            foreach (string linea in lineas)
            {

                string[] datos = linea.Split(';');


                Servicio servicio = new Servicio();
                servicio.idenvio = Int32.Parse(datos[0]);
                servicio.idcliente = Int32.Parse(datos[1]);
                servicio.Estado = datos[2];
                servicio.tipodeservicio = datos[3];
                servicio.tipodeenvio = datos[4];
                servicio.Precio = decimal.Parse(datos[5]);
                servicio.CiudadDeEntrega = datos[6];
                servicio.CalleDeEntrega = datos[7];
                servicio.AlturaCalle = int.Parse(datos[8]);
                servicio.Facturado = bool.Parse(datos[9]);
                servicio.Abonado = bool.Parse(datos[10]);
                listaservicio.Add(servicio);
            }
                        
        }

        private void CargarArchivoFacturas()
        {
            string[] lineas = File.ReadAllLines(archivoFacturas);


            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(';');

                Factura factura = new Factura();
                factura.NumFactura = Int32.Parse(datos[0]);
                factura.Importe = Decimal.Parse(datos[1]);
                factura.idcliente = Int32.Parse(datos[2]);
                factura.idenvio = Int32.Parse(datos[3]);
                factura.Abonado = bool.Parse(datos[4]);
                listafacturas.Add(factura);
            }
                        

        }

        private void CargarArchivoClientes()
        {
            string[] lineas = File.ReadAllLines(archivoClientes);


            foreach (string linea in lineas)
            {
                string[] datos = linea.Split(';');

                Cliente cliente = new Cliente();
                cliente.idcliente = Int32.Parse(datos[0]);
                cliente.RazonSocial = datos[1];
                cliente.CUIT = datos[2];
                listacliente.Add(cliente);
            }


        }
             

    }
}
