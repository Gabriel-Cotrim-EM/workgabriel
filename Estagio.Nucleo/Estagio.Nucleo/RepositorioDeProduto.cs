using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class RepositorioDeProduto : IRepositorio<Produto>
    {

        private RepositorioDeProduto()
        {

        }

        public static RepositorioDeProduto Instancia { get; set; }

        public void Add(Produto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Produto item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Produto item)
        {
            throw new NotImplementedException();
        }
    }
}
