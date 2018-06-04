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

        public static RepositorioDeMovimentacao Instancia { get; set; }

        public void Add(MovimentacaoDeEstoqueAbstrato item)
        {
            throw new NotImplementedException();
        }

        public void Delete(MovimentacaoDeEstoqueAbstrato item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimentacaoDeEstoqueAbstrato> GetAll()
        {
            throw new NotImplementedException();
        }

        public MovimentacaoDeEstoqueAbstrato GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MovimentacaoDeEstoqueAbstrato item)
        {
            throw new NotImplementedException();
        }
    }
}
