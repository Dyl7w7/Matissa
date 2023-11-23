using System;
using System.Collections.Generic;

namespace Matissa.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string? Descripción { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public double PrecioVenta { get; set; }
        public int SaldoInventario { get; set; }
        public byte Estado { get; set; }

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
