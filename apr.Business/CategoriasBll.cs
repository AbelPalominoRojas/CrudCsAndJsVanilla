
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class CategoriasBll
    {

        public bool create(Categoria categorias)
        {
            return new CategoriasRepository().create(categorias);
        }

        public bool edit(Categoria categorias)
        {
            return new CategoriasRepository().edit(categorias);
        }

        public bool remove(Int32 idcategoria)
        {
            return new CategoriasRepository().remove(idcategoria);
        }

        public List<Categoria> findAll()
        {
            return new CategoriasRepository().findAll();
        }

        public Categoria find(Int32 idcategoria)
        {
            return new CategoriasRepository().find(idcategoria);
        }

    }
}
