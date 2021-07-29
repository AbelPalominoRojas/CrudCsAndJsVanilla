
using System;
using System.Collections.Generic;

namespace apr.Entities
{
    public class Pedido
    {

        public Int32 IdPedido { get; set; }
        public Int32 IdCliente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual String FechaString { get { return (Fecha != null ? Fecha.ToShortDateString() : ""); } }
        public virtual Cliente Cliente { get; set; }
        public List<DetallePedido> DetallePedido { get; set; }
    }
}
