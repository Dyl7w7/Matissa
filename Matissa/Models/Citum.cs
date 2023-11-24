using System;
using System.Collections.Generic;

namespace Matissa.Models
{
    public partial class Citum
    {
        public Citum()
        {
            DetalleCita = new HashSet<DetalleCitum>();
            VentaServicios = new HashSet<VentaServicio>();
        }

        public int IdCita { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double CostoTotal { get; set; }
        public byte Estado { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<DetalleCitum> DetalleCita { get; set; }
        public virtual ICollection<VentaServicio> VentaServicios { get; set; }
    }
}
