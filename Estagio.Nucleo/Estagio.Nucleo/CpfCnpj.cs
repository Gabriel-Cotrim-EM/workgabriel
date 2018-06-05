using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagio.Nucleo
{
    class CpfCnpj
    {
        public string Numero { get; set; }

        public CpfCnpj(string numero)
        {
            if(numero.Length == 14 || numero.Length == 11)
            {
                if(numero.Length == 14 && validaCnpj(numero))
                {
                    validaCnpj(numero);
                }
                else
                {
                    throw new ApplicationException($"Cnpj invalido {numero}");
                }
                if(numero.Length == 11 && ValidaCpf(numero))
                {
                    ValidaCpf(numero);
                }
                else
                {
                    throw new ApplicationException($"Cpf invalido {numero}");
                }
            }
            else
            {
                throw new ApplicationException($"Cpf ou cnpj invalido {numero}");
            }
        }

        public bool ValidaCpf(string cpf)
        {
            var numero =
                from n in cpf
                where char.IsNumber(n)
                select n;

            cpf = new string(numero.ToArray());

            int tamanho = cpf.Length;
            const int CpfTamanho = 11;
            if(tamanho == CpfTamanho)
            {
                var digitosQuery =
                        from numeros in cpf
                        select Convert.ToInt32(numeros.ToString());


                int[] digitosVetor = digitosQuery.ToArray();
                var tamanhoVetor = digitosVetor.Length;

                int[] vetorExemplo = new int[CpfTamanho];

                for (int i = 0; i < tamanho; i++)
                {
                    if (i < 9)
                    {
                        vetorExemplo[i] = digitosVetor[i];
                    }
                }

                var tamanhoExemplo = vetorExemplo.Length;
                var posicaoCrescente = 2;
                int[] multiplicaVetorExemplo = new int[tamanhoExemplo];

                for (int i = tamanhoExemplo - 1; i >= 0; i--)
                {
                    if (i < 9)
                    {
                        multiplicaVetorExemplo[i] = posicaoCrescente * vetorExemplo[i];
                        posicaoCrescente++;
                    }
                }

                var somaExemplo = 0;

                for (int i = 0; i < tamanhoExemplo; i++)
                {
                    if (i < 9)
                        somaExemplo += multiplicaVetorExemplo[i];
                }

                var restoExemplo = somaExemplo % tamanhoExemplo;

                var digitoInclusoExemplo = 0;

                if (restoExemplo < 2) digitoInclusoExemplo = 0;
                else if (restoExemplo >= 2) digitoInclusoExemplo = 11 - restoExemplo;

                vetorExemplo[9] = digitoInclusoExemplo;

                int[] multiplicaVetorParteDois = new int[tamanhoExemplo];

                posicaoCrescente = 2;

                for (int i = tamanhoExemplo - 1; i >= 0; i--)
                {
                    if (i < 10)
                    {
                        multiplicaVetorParteDois[i] = posicaoCrescente * vetorExemplo[i];
                        posicaoCrescente++;
                    }
                }

                somaExemplo = 0;

                for (int i = 0; i < tamanhoExemplo; i++)
                {
                    if (i < 10)
                        somaExemplo += multiplicaVetorParteDois[i];
                }

                restoExemplo = somaExemplo % tamanhoExemplo;

                digitoInclusoExemplo = 0;

                if (restoExemplo < 2) digitoInclusoExemplo = 0;
                else if (restoExemplo >= 2) digitoInclusoExemplo = 11 - restoExemplo;

                vetorExemplo[10] = digitoInclusoExemplo;

                if (vetorExemplo[9] == digitosVetor[9] && vetorExemplo[10] == digitosVetor[10])
                {
                    char[] cpfChar = new char[CpfTamanho];
                    for (int i = 0; i < tamanhoExemplo; i++)
                    {
                        cpfChar[i] = Convert.ToChar(vetorExemplo[i].ToString());
                    }

                    Numero = new string(cpfChar);

                    string posicaoTres = "." + cpfChar[3];
                    string posicaoSeis = "." + cpfChar[6];
                    string posicaoNove = "-" + cpfChar[9];

                    Numero = Numero.Remove(3, 1);
                    Numero = Numero.Remove(5, 1);
                    Numero = Numero.Remove(7, 1);

                    Numero = Numero.Insert(3, posicaoTres);
                    Numero = Numero.Insert(7, posicaoSeis);
                    Numero = Numero.Insert(11, posicaoNove);

                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
        }

        public bool validaCnpj(string cnpj)
        {

            var numeros =
                from n in cnpj
                where char.IsNumber(n)
                select n;

            cnpj = new string(numeros.ToArray());

            int tamanho = cnpj.Length;
            const int CnpjTamanho = 14;
            if(tamanho == CnpjTamanho)
            {

                var cnpjInt =
                    from digitos in cnpj
                    select Convert.ToInt32(digitos);

                int[] cnpjIntArray = cnpjInt.ToArray();

                int[] cnpjTeste = new int[12];

                for(int i = 0; i < cnpjTeste.Length; i++)
                {
                    cnpjTeste[i] = cnpjIntArray[i];
                }

                int[] multiplicadoresUm = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] resultados = new int[12];
                var soma = 0;

                for(int i = 0; i < cnpjTeste.Length; i++)
                {
                    resultados[i] = cnpjTeste[i] * multiplicadoresUm[i];
                    soma += resultados[i];
                }

                cnpjTeste = new int[13];

                int resto = (soma % 11);

                if(resto < 2)
                {
                    cnpjTeste[12] = 0;
                }
                else
                {
                    cnpjTeste[12] = (11 - resto);
                }

                int[] multiplicadoresDois = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                resultados = new int[13];

                soma = 0;

                for (int i = 0; i < cnpjTeste.Length; i++)
                {
                    resultados[i] = cnpjTeste[i] * multiplicadoresDois[i];
                    soma += resultados[i];
                }

                cnpjTeste = new int[CnpjTamanho];
                resto = (soma % 11);

                if (resto < 2)
                {
                    cnpjTeste[13] = 0;
                }
                else
                {
                    cnpjTeste[13] = (11 - resto);
                }
                if (cnpjIntArray[12] == cnpjTeste[12] && cnpjIntArray[13] == cnpjTeste[13])
                {
                    char[] cnpjChar = new char[CnpjTamanho];
                    for(int i = 0; i < CnpjTamanho; i++)
                    {
                        cnpjChar[i] = Convert.ToChar(cnpjIntArray[i].ToString());
                    }

                    Numero = new string(cnpjChar);

                    string posicaoDois = "." + cnpjChar[2];
                    string posicaoCinco = "." + cnpjChar[5];
                    string posicaoOito = "/" + cnpjChar[8];
                    string posicaoDoze = "-" + cnpjChar[12];

                    Numero = Numero.Remove(2, 1);
                    Numero = Numero.Remove(4, 1);
                    Numero = Numero.Remove(6, 1);
                    Numero = Numero.Remove(9, 1);

                    Numero = Numero.Insert(2, posicaoDois);
                    Numero = Numero.Insert(6, posicaoCinco);
                    Numero = Numero.Insert(10, posicaoOito);
                    Numero = Numero.Insert(15, posicaoDoze);

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}
