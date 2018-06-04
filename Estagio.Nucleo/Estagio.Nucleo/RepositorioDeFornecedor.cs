using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class RepositorioDeFornecedor : IRepositorio<Fornecedor>
    {

        private RepositorioDeFornecedor()
        {

        }

        public static RepositorioDeFornecedor Instancia { get; set; }

        public void Add(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Fornecedor item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Fornecedor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Fornecedor item)
        {
            throw new NotImplementedException();
        }
    }
}
