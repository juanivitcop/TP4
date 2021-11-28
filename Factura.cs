using System;
using System.IO;
namespace TP4
{
    class Factura
    {
        public Int32 NumFactura{ get; set; }
        public decimal Importe { get; set; }
        public Int32 idcliente { get; set; }
        public Int32 idenvio { get; set; }
        public bool Abonado { get; set; }


        public void GrabarCon(StreamWriter writerFactura)
        {
            
            writerFactura.WriteLine($"{NumFactura};{Importe};{idcliente};{idenvio};{Abonado}");

        }

    }
}
