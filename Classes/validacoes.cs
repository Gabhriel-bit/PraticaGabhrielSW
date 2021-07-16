using System;
using System.Text;

namespace Projeto_ICI.Classes
{
    public class Validacoes
    {
        public static bool ValidacaoCPF(string pCPF = "")
        {
            string valor = pCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                    igual = false;
            }

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];


            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                    return false;
            }
            return true;
        }
        public static bool ValidacaoCNPJ(string pCNPJ = "")
        {
            string CNPJ = pCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                    {
                        soma[0] += (digitos[nrDig] *
                         int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    }

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                        int.Parse(ftmt.Substring(nrDig, 1)));
                }
                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    CNPJOk[nrDig] = (resultado[nrDig] == 0) || (resultado[nrDig] == 1) ? digitos[12 + nrDig] == 0 : digitos[12 + nrDig] == (11 - resultado[nrDig]);
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
        public static bool ValidacaoNome(string pNome)
        {
            if (string.IsNullOrEmpty(pNome))
            {
                return false;
            }
            else if (pNome.Length < 3)
            {
                return false;
            }
            else
            {
                byte[] byteNome = Encoding.ASCII.GetBytes(pNome.ToLower());
                if (byteNome[0] == 32 || byteNome[byteNome.Length - 1] == 32)
                {
                    return false;
                }
                else
                {
                    int countEspaco = 0, countLetra = 0;
                    for (int i = 0; i <= pNome.Length - 1; i++)
                    {
                        if ((pNome[i] != 'ç') && byteNome[i] != 32)
                        {
                            countEspaco = 0;
                            if (byteNome[i] < 97 || byteNome[i] > 122)
                            {
                                return false;
                            }
                            else
                            {
                                countLetra += 1;
                            }
                        }
                        else if (byteNome[i] == 32)
                        {
                            if (countLetra < 3)
                            {
                                return false;
                            }
                            else
                            {
                                countLetra = 0;
                                countEspaco += 1;
                                if (countEspaco >= 2)
                                { return false; }
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool ValidacaoIntPositivo(float pNum)
        {
            return ValidacaoIntPositivo(pNum.ToString());
        }
        public static bool ValidacaoIntPositivo(decimal pNum)
        {
            return ValidacaoIntPositivo(pNum.ToString());
        }
        public static bool ValidacaoIntPositivo(int pNum)
        {
            return ValidacaoIntPositivo(pNum.ToString());
        }
        public static bool ValidacaoIntPositivo(string pNum)
        {
            if (string.IsNullOrEmpty(pNum))
            {
                return false;
            }
            else
            {
                int i = 0;
                if (!(int.TryParse(pNum, out i)))
                {
                    return false;
                }
                else if (i <= 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static string[] CalcularPorcParcelasTxT(int totalParc)
        {
            var retorno = new string[totalParc];
            var vetor = CalcularPorcParcelas(totalParc);
            for (int i = 0; i <= totalParc - 1; i++)
            {
                retorno[i] = vetor[i].ToString();
            }
            return retorno;
        }
        public static double[] CalcularPorcParcelas(int totalParc)
        {
            var parcelas = new double[totalParc];
            double parcela = 100;
            string divisao = (parcela / totalParc).ToString();
            int posDot = 0;
            double sobra = 0;
            if ((divisao.Length == 1) || (divisao.Length == 2) || (divisao == "100"))
            {
                parcela = int.Parse(divisao);
            }
            else
            {
                while (divisao[posDot] != ',')
                { posDot++; }
                if (divisao.Length > posDot + 5)
                {
                    parcela = double.Parse(divisao.Substring(0, posDot + 5));
                }
                else
                {
                    parcela = double.Parse(divisao.Substring(0));
                }
            }
            double soma = 0;
            for (int i = 0; i <= totalParc - 1; i++)
            {
                soma += parcela;
                parcelas[i] = Math.Round(parcela, 4);
            }
            if (soma != 100)
            {
                soma = double.Parse(soma.ToString().Substring(0,
                                    soma.ToString().Length < 7 ? soma.ToString().Length : 7));
            }
            while (soma < 100)
            {
                sobra = Math.Round(sobra + 0.0001, 4);
                soma = Math.Round(soma + 0.0001, 4);
            }
            parcelas[0] = Math.Round(parcelas[0] + sobra, 4);
            return parcelas;
        }
    }
}