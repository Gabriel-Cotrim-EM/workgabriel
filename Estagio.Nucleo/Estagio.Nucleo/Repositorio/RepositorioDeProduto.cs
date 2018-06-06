using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo.Repositorio
{
    public class RepositorioDeProduto : IRepositorio<Produto>
    {

        private RepositorioDeProduto()
        {

        }

        public static readonly RepositorioDeProduto Instancia = new RepositorioDeProduto();

        private List<Produto> _produtos = new List<Produto>();

        public void Add(Produto item)
        {
            _produtos.Add(item);
        }

        public void Delete(Produto item)
        {
            _produtos.Remove(item);
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtos;
        }

        public Produto GetById(int id)
        {
            return _produtos.Find(x => x.Id == id);
        }

        public void Update(Produto item)
        {
            _produtos.Remove(GetById(item.Id));
            _produtos.Add(item);
        }
    }
}
