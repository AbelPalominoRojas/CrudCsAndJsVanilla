
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class ProductosBll
    {

        public bool create(Producto productos)
        {
            return new ProductosRepository().create(productos);
        }

        public bool edit(Producto productos)
        {
            return new ProductosRepository().edit(productos);
        }

        public bool remove(Int32 idproducto)
        {
            return new ProductosRepository().remove(idproducto);
        }

        public List<Producto> findAll()
        {
            return new ProductosRepository().findAll();
        }

        public Producto find(Int32 idproducto)
        {
            return new ProductosRepository().find(idproducto);
        }

        public List<Producto> findAllByIdCategoria(Int32 idcategoria)
        {
            return new ProductosRepository().findAllByIdCategoria(idcategoria);
        }
    }
}
