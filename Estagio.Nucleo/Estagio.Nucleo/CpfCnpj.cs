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
            this.Numero = numero;
        }

        public bool ValidaCpf(string cpf)
        {
            int tamanho = cpf.Length;
            if(tamanho == 11)
            {
                var digitosQuery =
                        from numeros in cpf
                        select Convert.ToInt32(numeros.ToString());


                int[] digitosVetor = digitosQuery.ToArray();
                var tamanhoVetor = digitosVetor.Length;

                int[] vetorExemplo = new int[11];

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
                    char[] cpfChar = new char[11];
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
            int tamanho = cnpj.Length;
            if(tamanho == 14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
