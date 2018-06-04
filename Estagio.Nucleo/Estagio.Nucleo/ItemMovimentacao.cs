using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class ItemMovimentacao
    {
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorMovimentacao { get
            { return ValorUnitario * Quantidade; }
             }
        public Produto Produto { get; private set; }


    }
}
