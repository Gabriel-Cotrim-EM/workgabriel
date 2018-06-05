using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class RepositorioDeMovimentacao : IRepositorio<MovimentacaoDeEstoqueAbstrato>
    {

        private RepositorioDeMovimentacao()
        {

        }

        public static readonly RepositorioDeMovimentacao Instancia = new RepositorioDeMovimentacao();

        private List<MovimentacaoDeEstoqueAbstrato> _movimentacoes = new List<MovimentacaoDeEstoqueAbstrato>();

        public void Add(MovimentacaoDeEstoqueAbstrato item)
        {
            _movimentacoes.Add(item);
        }

        public void Delete(MovimentacaoDeEstoqueAbstrato item)
        {
            _movimentacoes.Remove(item);
        }

        public IEnumerable<MovimentacaoDeEstoqueAbstrato> GetAll()
        {
            return _movimentacoes;
        }

        public MovimentacaoDeEstoqueAbstrato GetById(int id)
        {
            return _movimentacoes.Find(x => x.Id == id);
        }

        public void Update(MovimentacaoDeEstoqueAbstrato item)
        {
            throw new NotImplementedException();
        }
    }
}
