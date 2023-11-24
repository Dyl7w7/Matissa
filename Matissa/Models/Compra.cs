using System;
using System.Collections.Generic;

namespace Matissa.Models
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public string? Descripción { get; set; }
        public DateTime FechaCompra { get; set; }
        public double CostoTotalCompra { get; set; }
        public string? Factura { get; set; }
        public byte Estado { get; set; }
    }
}
