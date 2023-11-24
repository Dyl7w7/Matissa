using System;
using System.Collections.Generic;

namespace Matissa.Models
{
    public partial class VentaServicio
    {
        public int IdVentaServicio { get; set; }
        public int IdCita { get; set; }
        public double ValorVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string FormaPago { get; set; } = null!;
        public byte Estado { get; set; }

        public virtual Citum IdCitaNavigation { get; set; } = null!;
    }
}
