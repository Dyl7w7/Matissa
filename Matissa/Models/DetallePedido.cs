using System;
using System.Collections.Generic;

namespace Matissa.Models
{
    public partial class DetallePedido
    {
        public int IdDetallePedido { get; set; }
        public int IdProducto { get; set; }
        public int IdPedido { get; set; }
        public int CantidadProducto { get; set; }
        public double PrecioUnitario { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
