using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using Projeto_ICI.Classes;
using Projeto_ICI.Controllers;
using Projeto_ICI.DAOs;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Projeto_ICI
{
    public partial class formularioBase : Form
    {
        public NumberStyles vgEstilo = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
        public CultureInfo vgProv = new CultureInfo("fr-FR");
        protected Image umImgPesquisaEntrar;
        protected Image umImgPesquisaSair;
        public formularioBase()
        {
            InitializeComponent();
            CarregarImgs();
        }
        public virtual void ConhecaOBJ(object pOBJ)
        {

        }
        public virtual void SetFrmCad(Form pFrmCad)
        {

        }
        public virtual void SetFrmCad(Form[] pFrmCad)
        {

        }
        public virtual void SetFrmCons(Form pFrmCad)
        {

        }
        public virtual void SetFrmCons(Form[] pFrmCad)
        {
            
        }
        protected void showErrorMsg(string pMsg)
        {
            if (pMsg != "")
            { MessageBox.Show(pMsg, "ERRO --> " + this.Text.ToString()); }
        }
        protected void showErrorMsg(string[] pMsgList)
        {
            if (pMsgList != null && pMsgList.Length > 0)
            {
                string vlMsg = "";
                foreach (string vlMsgFor in pMsgList)
                {
                    if (vlMsgFor != "")
                    { vlMsg += vlMsgFor + '\n'; }
                }
                if (vlMsg != "")
                { MessageBox.Show(vlMsg.Remove(vlMsg.Length - 1), "ERRO --> " + this.Text.ToString()); }      
            }
        }
        private void CarregarImgs()
        {
            try
            {
                umImgPesquisaEntrar = Image.FromFile(@"C:\Users\gabhr\Documents\GitHub\PraticaGabhrielSW\imagens\arquivo_de_pesquisa_entrar.png");
                umImgPesquisaSair = Image.FromFile(@"C:\Users\gabhr\Documents\GitHub\PraticaGabhrielSW\imagens\arquivo_de_pesquisa_sair.png");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao carregar imagens dos formulários\n" + e.Message, "ERRO");
            }
        }
        public static string FormatCPF(string pCPF)
        {
            pCPF = pCPF.Replace(".", "");
            pCPF = pCPF.Replace("-", "");
            if (pCPF != "")
                return pCPF.Substring(0, 3) + "." +
                       pCPF.Substring(3, 3) + "." +
                       pCPF.Substring(6, 3) + "-" +
                       pCPF.Substring(9, 2);
            else
                return "";
        }
        public static string FormatCNPJ(string pCNPJ)
        {
            pCNPJ = pCNPJ.Replace(".", "");
            pCNPJ = pCNPJ.Replace("/", "");
            pCNPJ = pCNPJ.Replace("-", "");

            if (pCNPJ != "")
                return pCNPJ.Substring(0, 2) + "." +
                       pCNPJ.Substring(2, 3) + "." +
                       pCNPJ.Substring(5, 3) + "/" +
                       pCNPJ.Substring(8, 4) + "-" +
                       pCNPJ.Substring(12, 2);
            else
                return "";
        }
        public static bool ValidacaoCPF(string pCPF)
        {
            string valor = pCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
            { return false; }

            if (!ValidacaoIntPositivo("1" + valor, false))
            { return false; }

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
        public static bool ValidacaoCNPJ(string pCNPJ)
        {
            string CNPJ = pCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            if (!ValidacaoIntPositivo("1" + CNPJ, false))
            { return false; }

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
        public static bool ValidacaoNome(string pNome, int pNumMinLetPalavra, bool pEspaco)
        {
            if (string.IsNullOrEmpty(pNome))
            {
                return false;
            }
            else if (pNome.Length < pNumMinLetPalavra)
            {
                return false;
            }
            else
            {
                Encoding extendedASCII = Encoding.GetEncoding(1252);
                byte[] byteNome = extendedASCII.GetBytes(pNome.ToLower());

                if (byteNome[0] == 32 || byteNome[byteNome.Length - 1] == 32)
                {
                    return false;
                }
                else
                {
                    int countEspaco = 0, countLetra = 0;
                    for (int i = 0; i <= pNome.Length - 1; i++)
                    {
                        if (byteNome[i] != 32)
                        {
                            countEspaco = 0;
                            if ((byteNome[i] < 97 || byteNome[i] > 122) &&
                                ConfereNumTabelaExASCII(byteNome[i]))
                            {
                                return false;
                            }
                            else
                            {
                                if (pEspaco)
                                    countLetra += 1;
                                else
                                    return false;
                            }
                        }
                        else
                        {
                            if (countLetra < pNumMinLetPalavra)
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
        public static bool ValidacaoIntPositivo(float pNum, bool incZero)
        {
            return ValidacaoIntPositivo(pNum.ToString(), incZero);
        }
        public static bool ValidacaoIntPositivo(decimal pNum, bool incZero)
        {
            return ValidacaoIntPositivo(pNum.ToString(), incZero);
        }
        public static bool ValidacaoIntPositivo(int pNum, bool incZero)
        {
            return ValidacaoIntPositivo(pNum.ToString(), incZero);
        }
        public static bool ValidacaoIntPositivo(string pNum, bool incZero)
        {
            if (string.IsNullOrEmpty(pNum))
            { return false; }
            else
            {
                try
                {
                    var i = Int64.Parse(pNum);
                    if (!incZero)
                    {
                        if (i <= 0)
                        { return false; }
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ValidacaoDoubleMoeda(double pNum)
        {
            return ValidacaoDoubleMoeda(pNum.ToString());
        }
        public static bool ValidacaoDoubleMoeda(string pNum)
        {
            if (string.IsNullOrEmpty(pNum))
            { return false; }
            else
            {
                if (!double.TryParse(pNum, out double i))
                { return false; }
                else if (i <= 0)
                { return false; }
                else
                {
                    string[] splitV = pNum.Split(','), splitD = pNum.Split('.');
                    if (splitD[splitD.Length - 1].Length > 4 &&
                        splitV[splitV.Length - 1].Length > 4)
                    { return false; }
                }
            }
            return true;
        }
        public static string[] CalcularPorcParcelasTxT(int totalParc, string pValorentrada)
        {
            var valorentrada = double.Parse(pValorentrada);
            var retorno = new string[totalParc];
            var vetor = CalcularPorcParcelas(totalParc, valorentrada);
            for (int i = 0; i <= totalParc - 1; i++)
            {
                retorno[i] = vetor[i].ToString();
            }
            return retorno;
        }
        public static string[] CalcularPorcParcelasTxT(int totalParc, double valorentrada)
        {
            var retorno = new string[totalParc];
            var vetor = CalcularPorcParcelas(totalParc, valorentrada);
            for (int i = 0; i <= totalParc - 1; i++)
            {
                retorno[i] = vetor[i].ToString();
            }
            return retorno;
        }
        public static double[] CalcularPorcParcelas(int totalParc, double valorentrada)
        {
            //valor da parcela que o usuario informou
            var parcelas = new double[totalParc];

            //vc pode colocar uma entrada,
            //como por exemplo totalParc = 8, porcentagem = 30 e o resto (70%) gera automatico
            //com base nos totalParc e subtrai o valor integral 100% do valor da entrada 
            double valorParcelas = 100 - valorentrada;

            //variavel que vai armazenar o valor automatico da parcela, ele muda ao longo do programa
            double parcela = valorParcelas;

            //estima qual o valor da parcela com base na divisao com total de parcelas
            string divisao = (parcela / totalParc).ToString();

            //ja que eu trabalho com o numero em forma de string, essa variavel vai
            //armazenar onde fica a virgula
            int posDot = 0;

            //caso aconteca, esse var vai pegar o que falta para completar 100%
            double sobra = 0;

            //confere se a divizão for inteira ele retorna o valor direto
            if ((divisao.Length == 1) || (divisao.Length == 2) || (divisao == valorParcelas.ToString()))
            {
                parcela = int.Parse(divisao);
            }
            else
            {
                //procura onde esta o ponto e formata o numero para 00,0000 
                //caso necessario
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
            //confere se a soma das parcelas da o total de 100%
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
            //calcula a sobra para calcular 100%
            while (soma < 100)
            {
                sobra = Math.Round(sobra + 0.0001, 4);
                soma = Math.Round(soma + 0.0001, 4);
            }
            //acrecenta a sobra na primeira parcela
            parcelas[0] = Math.Round(parcelas[0] + sobra, 4);
            return parcelas;
        }
        private static bool ConfereNumTabelaExASCII(int pNum)
        {
            /*
             á é í ó ú = 225 233 237 243 250
             à è ì ò ù = 226 234 238 244 251
             â ê î ô û = 224 232 236 242 249
             ã õ ç = 227 245 231

             224 225 226 227 231 232 233 234 236 237 238 242 243 244 245 249 250 251
            */
            int[] lista = { 224, 225, 226, 227, 231, 232, 233, 234, 236,
                            237, 238, 242, 243, 244, 245, 249, 250, 251 };
            foreach (int valor in lista)
            {
                if (valor == pNum)
                { return false; }
            }
            return true;
        }
        public static bool ValidacaoPorcentagem(double pNum)
        {
            return ValidacaoPorcentagem(pNum.ToString());
        }
        public static bool ValidacaoPorcentagem(string pNum)
        {
            if (string.IsNullOrEmpty(pNum))
            { return false; }
            else
            {
                if (pNum[0] == '-')
                { return false; }
                else
                {
                    char[] carac = { ',', '.' };
                    var inteira = int.Parse(pNum.Split(carac)[0]);
                    if (inteira > 1)
                    { return false; }
                }
            }
            return true;
        }
        public static void ValidacaoCodigo(TextBox txtb, KeyPressEventArgs e)
        {
            if (!ValidacaoIntPositivo(e.KeyChar.ToString(), false) && e.KeyChar != (char)Keys.Back)
            {
                if (!string.IsNullOrEmpty(txtb.Text))
                {
                    int len = txtb.Text.Length;
                    char num = txtb.Text[len - 1];
                    txtb.Text = txtb.Text.Remove(len - 1, 1);
                    e.KeyChar = num;
                    txtb.Select(len + 1, 0);
                }
                else
                {
                    e.KeyChar = '0';
                }
            }
        }
        public static bool ValidacaoEmail(string pEmail)
        {
            if (string.IsNullOrWhiteSpace(pEmail))
                return false;

            try
            {
                // Normalize the domain
                pEmail = Regex.Replace(pEmail, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(pEmail,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void formularioBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            errorMSG.Clear();
        }
    }
}
