﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeCliente : IRepositorio<Cliente>
    {

        private RepositorioDeCliente()
        {

        }

        public static readonly RepositorioDeCliente Instancia = new RepositorioDeCliente();

        private List<Cliente> _clientes = new List<Cliente>();

        public void Add(Cliente item)
        {
            _clientes.Add(item);
        }

        public void Delete(Cliente item)
        {
            _clientes.Remove(item);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clientes;
        }

        public Cliente GetById(int id)
        {
            return _clientes.Find(x => x.Id == id);
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
