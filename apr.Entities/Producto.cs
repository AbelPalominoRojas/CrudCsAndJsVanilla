
using System;


namespace apr.Entities
{
    public class Producto
    {

        public Int32 IdProducto { get; set; }
        public Int32 IdCategoria { get; set; }
        public String Nombre { get; set; }
        public String Presentacion { get; set; }
        public Decimal Precio { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
