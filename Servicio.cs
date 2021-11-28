using System;
using System.IO;
namespace TP4
{
    class Servicio
    {
        public Int32 idenvio { get; set; }
        public Int32 idcliente { get; set; }
        public string Estado { get; set; }
        public string tipodeservicio { get; set; }
        public string tipodeenvio { get; set; }
        public Decimal Precio { get; set; }
        public string CiudadDeEntrega { get; set; }
        public string CalleDeEntrega { get; set; }
        public Int32 AlturaCalle { get; set; }
        public bool Facturado { get; set; }
        public bool Abonado { get; set; }
                

        public void GrabarCon(StreamWriter writerServicio)
        {
            
            writerServicio.WriteLine($"{idenvio};{idcliente};{Estado};{tipodeservicio};{tipodeenvio};{Precio};{CiudadDeEntrega};{CalleDeEntrega};{AlturaCalle};{Facturado};{Abonado}");

        }

    }
}
