
using System;


namespace apr.Entities
{
    public class DetallePedido
    {

        public Int32 IdPedido { get; set; }
        public Int32 IdProducto { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Cantidad { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
