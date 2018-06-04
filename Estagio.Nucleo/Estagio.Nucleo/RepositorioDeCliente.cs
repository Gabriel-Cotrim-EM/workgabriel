using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class RepositorioDeCliente : IRepositorio<Cliente>
    {

        private RepositorioDeCliente()
        {

        }

        public static RepositorioDeCliente Instancia { get; set; }

        public void Add(Cliente item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cliente item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente item)
        {
            throw new NotImplementedException();
        }
    }
}
