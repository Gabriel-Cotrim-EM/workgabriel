using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    public class CPFCNPJ
    {
        private string _numero;

        private const int TamanhoDoCNPJ = 14;
        private const int TamanhoDoCPF = 11;

        public CPFCNPJ(string numero)
        {
            _numero = numero ?? throw new ArgumentNullException(nameof(numero));

            RemovaCarecteresNaoNumericos();

            if (!(EhCPFValido() || EhCPNJValido()))
            {
                throw new ApplicationException("CPF/CNPJ inválido");
            }
        }

        public string Numero { get => _numero; }

        private bool EhDoTamanhoCorretoDeCNPJ(string numero)
        {
            return numero.Length == TamanhoDoCNPJ;
        }

        private bool EhDoTamanhoCorretoDoCPF(string numero)
        {
            return numero.Length == TamanhoDoCPF;
        }

        private void RemovaCarecteresNaoNumericos()
        {
            _numero = new string(_numero.Where(c => char.IsNumber(c)).ToArray());
        }

        private bool EhCPFValido()
        {
            if (!EhDoTamanhoCorretoDoCPF(_numero))
            {
                return false;
            }

            var numeros = _numero.Select(c => int.Parse(c.ToString())).ToArray();

            var soma = 0;
            for (var i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            var resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[9] != 0) return false;
            }
            else
            {
                if (numeros[9] != 11 - resto) return false;
            }

            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[10] != 0) return false;
            }
            else
            {
                if (numeros[10] != 11 - resto) return false;
            }


            return true;
        }

        private bool EhCPNJValido()
        {
            if (!EhDoTamanhoCorretoDeCNPJ(_numero))
            {
                return false;
            }

            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] numeros = new int[14];

            for (var i = 0; i < 12; i++)
            {
                numeros[i] = int.Parse(_numero[i].ToString());
            }

            var soma = 0;

            for (var i = 0; i < 9; i++)
            {
                soma += (10 - i) * multiplicador1[i];
            }

            var resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[9] != 0) return false;
            }
            else
            {
                if (numeros[9] != 11 - resto) return false;
            }

            soma = 0;
            for (var i = 0; i < 11; i++)
            {
                soma += (11 - i) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                if (numeros[10] != 0) return false;
            }
            else
            {
                if (numeros[10] != 11 - resto) return false;
            }

            return true;
        }

        public string ObtenhaCPFCNPJFormatado()
        {
            //TODO:
            return string.Empty;
        }

        public override string ToString()
        {
            return _numero;
        }

        public override bool Equals(object obj)
        {
            return (obj is CPFCNPJ cPFCNPJ) && cPFCNPJ._numero == _numero;
        }

        public override int GetHashCode()
        {
            return _numero.GetHashCode();
        }

    }
}