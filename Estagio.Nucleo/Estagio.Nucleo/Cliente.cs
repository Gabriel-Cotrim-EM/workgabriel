﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class Cliente : MovimentacaoDeSaida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CpfCnpj cpfCnpj;
    }
}