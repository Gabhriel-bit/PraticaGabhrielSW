using System;
using Projeto_ICI.frmConsultas;
using Projeto_ICI.frmCadastros;
using System.Text;
using System.Windows.Forms;

namespace Projeto_ICI
{
    public partial class Gerente : Form
    {
        private frmCadastroCargos frmCadCargo;
        private frmCadastroCidades frmCadCidade;
        private frmCadastroClientes frmCadCliente;
        private frmCadastroCondicoesPagamento frmCadCondPag;
        private frmCadastroDepositos frmCadDeposito;
        private frmCadastroEstados frmCadEstado;
        private frmCadastroFornecedores frmCadFornecedor;
        private frmCadastroFuncionario frmCadFuncionario;
        private frmCadastroGrupos frmCadGrupo;
        private frmCadastroMarcas frmCadMarca;
        private frmCadastroModelos frmCadModelo;
        private frmCadastroPaises frmCadPais;
        private frmCadastroProdutos frmCadProduto;
        private frmCadastroFormasPagamento frmCadFormPag;
        private frmCadastroSubGrupos frmCadSubgrupo;

        private frmConsultaCargos frmConsCargo;
        private frmConsultaCidades frmConsCidade;
        private frmConsultaClientes frmConsCliente;
        private frmConsultaCondicoesPagamento frmConsCondPag;
        private frmConsultaDepositos frmConsDeposito;
        private frmConsultaEstados frmConsEstado;
        private frmConsultaFornecedores frmConsFornecedor;
        private frmConsultaFuncionarios frmConsFuncionario;
        private frmConsultaGrupos frmConsGrupo;
        private frmConsultaMarcas frmConsMarca;
        private frmConsultaModelos frmConsModelo;
        private frmConsultaPaises frmConsPais;
        private frmConsultaProdutos frmConsProduto;
        private frmConsultasFormasPagamento frmConsFormPag;
        private frmConsultaSubgrupos frmConsSubgrupo;

        private BancoDados.conexoes umaConexao;
        public Gerente()
        {
            InitializeComponent();
            umaConexao = new BancoDados.conexoes();

            frmCadCargo = new frmCadastroCargos(umaConexao);
            frmCadCidade = new frmCadastroCidades(umaConexao);
            frmCadCliente = new frmCadastroClientes(umaConexao);
            frmCadCondPag = new frmCadastroCondicoesPagamento(umaConexao);
            frmCadDeposito = new frmCadastroDepositos(umaConexao);
            frmCadEstado = new frmCadastroEstados(umaConexao);
            frmCadFornecedor = new frmCadastroFornecedores(umaConexao);
            frmCadFuncionario = new frmCadastroFuncionario(umaConexao);
            frmCadGrupo = new frmCadastroGrupos(umaConexao);
            frmCadMarca = new frmCadastroMarcas(umaConexao);
            frmCadModelo = new frmCadastroModelos(umaConexao);
            frmCadPais = new frmCadastroPaises(umaConexao);
            frmCadProduto = new frmCadastroProdutos(umaConexao);
            frmCadFormPag = new frmCadastroFormasPagamento(umaConexao);
            frmCadSubgrupo = new frmCadastroSubGrupos(umaConexao);

            frmConsCargo = new frmConsultaCargos(umaConexao);
            frmConsCidade = new frmConsultaCidades(umaConexao);
            frmConsCliente = new frmConsultaClientes(umaConexao);
            frmConsCondPag = new frmConsultaCondicoesPagamento(umaConexao);
            frmConsDeposito = new frmConsultaDepositos(umaConexao);
            frmConsEstado = new frmConsultaEstados(umaConexao);
            frmConsFornecedor = new frmConsultaFornecedores(umaConexao);
            frmConsFuncionario = new frmConsultaFuncionarios(umaConexao);
            frmConsGrupo = new frmConsultaGrupos(umaConexao);
            frmConsMarca = new frmConsultaMarcas(umaConexao);
            frmConsModelo = new frmConsultaModelos(umaConexao);
            frmConsPais = new frmConsultaPaises(umaConexao);
            frmConsProduto = new frmConsultaProdutos(umaConexao);
            frmConsFormPag = new frmConsultasFormasPagamento(umaConexao);
            frmConsSubgrupo = new frmConsultaSubgrupos(umaConexao);

            frmConsCargo.SetFrmCad(frmCadCargo);
            frmConsCidade.SetFrmCad(frmCadCidade);
            frmConsCliente.SetFrmCad(frmCadCliente);
            frmConsCondPag.SetFrmCad(frmCadCondPag);
            frmConsDeposito.SetFrmCad(frmCadDeposito);
            frmConsEstado.SetFrmCad(frmCadEstado);
            frmConsFornecedor.SetFrmCad(frmCadFornecedor);
            frmConsFuncionario.SetFrmCad(frmCadFuncionario);
            frmConsGrupo.SetFrmCad(frmCadGrupo);
            frmConsMarca.SetFrmCad(frmCadMarca);
            frmConsModelo.SetFrmCad(frmCadModelo);
            frmConsPais.SetFrmCad(frmCadPais);
            frmConsProduto.SetFrmCad(frmCadProduto);
            frmConsFormPag.SetFrmCad(frmCadFormPag);
            frmConsSubgrupo.SetFrmCad(frmCadSubgrupo);

            //setar formulários de consulta em cadastro
        }

        private void mnItem_Cargos_Click(object sender, EventArgs e)
        {
            frmConsCargo.ShowDialog();
        }

        private void mnItem_Cidades_Click(object sender, EventArgs e)
        {
            frmConsCidade.ShowDialog();
        }

        private void mnItem_Clientes_Click(object sender, EventArgs e)
        {
            frmConsCliente.ShowDialog();
        }

        private void mnItem_CondicoesPagamento_Click(object sender, EventArgs e)
        {
            frmConsCondPag.ShowDialog();
        }

        private void mnItem_Depositos_Click(object sender, EventArgs e)
        {
            frmConsDeposito.ShowDialog();
        }

        private void mnItem_Estados_Click(object sender, EventArgs e)
        {
            frmConsEstado.ShowDialog();
        }

        private void mnItem_FormasPagamento_Click(object sender, EventArgs e)
        {
            frmConsFormPag.ShowDialog();
        }

        private void mnItem_Fornecedores_Click(object sender, EventArgs e)
        {
            frmConsFornecedor.ShowDialog();
        }

        private void mnItem_Funcionarios_Click(object sender, EventArgs e)
        {
            frmConsFuncionario.ShowDialog();
        }

        private void mnItem_Grupos_Click(object sender, EventArgs e)
        {
            frmConsGrupo.ShowDialog();
        }

        private void mnItem_Marcas_Click(object sender, EventArgs e)
        {
            frmConsMarca.ShowDialog();
        }

        private void mnItem_Modelos_Click(object sender, EventArgs e)
        {
            frmConsModelo.ShowDialog();
        }

        private void mnItem_Produtos_Click(object sender, EventArgs e)
        {
            frmConsProduto.ShowDialog();
        }

        private void mnItem_Paises_Click(object sender, EventArgs e)
        {
            frmConsPais.ShowDialog();
        }

        private void mnItem_Subgrupos_Click(object sender, EventArgs e)
        {
            frmConsSubgrupo.ShowDialog();
        }
    }
}

