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

        public static readonly RepositorioDeFornecedor Instancia = new RepositorioDeFornecedor();

        private List<Fornecedor> _fornecedores = new List<Fornecedor>();

        public void Add(Fornecedor item)
        {
            _fornecedores.Add(item);
        }

        public void Delete(Fornecedor item)
        {
            _fornecedores.Remove(item);
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _fornecedores;
        }

        public Fornecedor GetById(int id)
        {
            return _fornecedores.Find(x => x.Id == id);
        }

        public void Update(Fornecedor item)
        {
            throw new NotImplementedException();
        }
    }
}
