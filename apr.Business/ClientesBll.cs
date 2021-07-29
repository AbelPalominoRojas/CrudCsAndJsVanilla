
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class ClientesBll
    {

        public bool create(Cliente clientes)
        {
            return new ClientesRepository().create(clientes);
        }

        public bool edit(Cliente clientes)
        {
            return new ClientesRepository().edit(clientes);
        }

        public bool remove(Int32 idcliente)
        {
            return new ClientesRepository().remove(idcliente);
        }

        public List<Cliente> findAll()
        {
            return new ClientesRepository().findAll();
        }

        public Cliente find(Int32 idcliente)
        {
            return new ClientesRepository().find(idcliente);
        }

    }
}
