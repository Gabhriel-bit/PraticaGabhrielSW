using System;
using Projeto_ICI.frmConsultas;
using Projeto_ICI.frmCadastros;
using Projeto_ICI.DAOs;
using Projeto_ICI.Controllers;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Projeto_ICI
{
    public partial class Gerente : Form
    {

        private daoCargos umaDaoCargo;
        private daoCidades umaDaoCidade;
        private daoClientes umaDaoCliente;
        private daoCondicoesPagamento umaDaoCondPag;
        private daoDepositos umaDaoDeposito;
        private daoEquipamentos umaDaoEquip;
        private daoEstados umaDaoEstado;
        private daoFormasPagamento umaDaoFormPag;
        private daoFornecedores umaDaoForn;
        private daoFuncionarios umaDaoFunc;
        private daoGrupos umaDaoGrupo;
        private daoMarcas umaDaoMarca;
        private daoModelos umaDaoModelo;
        private daoPaises umaDaoPais;
        private daoProdutos umaDaoProduto;
        private daoServicos umaDaoServico;
        private daoSubgrupos umaDaoSubgrupo;
        private daoTransportadoras umaDaoTransport;
        private daoCompras umaDaoCompra;
        private daoContasPagar UmaDaoContaPagar;

        private ctrlCargos umCtrlCargo;
        private ctrlCidades umCtrlCidade;
        private ctrlClientes umCtrlCliente;
        private ctrlCondicoesPagamento umCtrlCondPag;
        private ctrlDepositos umCtrlDeposito;
        private ctrlEquipamentos umCtrlEquip;
        private ctrlEstados umCtrlEstado;
        private ctrlFormasPagamento umCtrlFormPag;
        private ctrlFornecedores umCtrlForn;
        private ctrlFuncionarios umCtrlFunc;
        private ctrlGrupos umCtrlGrupo;
        private ctrlMarcas umCtrlMarca;
        private ctrlModelos umCtrlModelo;
        private ctrlPaises umCtrlPais;
        private ctrlProdutos umCtrlProduto;
        private ctrlServicos umCtrlServico;
        private ctrlSubgrupos umCtrlSubgrupo;
        private ctrlTransportadoras umCtrlTransport;
        private ctrlCompras umCtrlCompra;
        private ctrlContasPagar UmCtrlContaPagar;

        private frmCadastroCargos frmCadCargo;
        private frmCadastroCidades frmCadCidade;
        private frmCadastroClientes frmCadCliente;
        private frmCadastroCondicoesPagamento frmCadCondPag;
        private frmCadastroDepositos frmCadDeposito;
        private frmCadastroEquipamentos frmCadEquip;
        private frmCadastroEstados frmCadEstado;
        private frmCadastroFornecedores frmCadFornecedor;
        private frmCadastroFuncionarios frmCadFuncionario;
        private frmCadastroGrupos frmCadGrupo;
        private frmCadastroMarcas frmCadMarca;
        private frmCadastroModelos frmCadModelo;
        private frmCadastroPaises frmCadPais;
        private frmCadastroProdutos frmCadProduto;
        private frmCadastroFormasPagamento frmCadFormPag;
        private frmCadastroServicos frmCadServico;
        private frmCadastroSubGrupos frmCadSubgrupo;
        private frmCadastroTransportadoras frmCadTransport;
        private frmCadastroCompras frmCadCompra;

        private frmConsultaCargos frmConsCargo;
        private frmConsultaCidades frmConsCidade;
        private frmConsultaClientes frmConsCliente;
        private frmConsultaCondicoesPagamento frmConsCondPag;
        private frmConsultaDepositos frmConsDeposito;
        private frmConsultaEquipamentos frmConsEquip;
        private frmConsultaEstados frmConsEstado;
        private frmConsultaFornecedores frmConsFornecedor;
        private frmConsultaFuncionarios frmConsFuncionario;
        private frmConsultaGrupos frmConsGrupo;
        private frmConsultaMarcas frmConsMarca;
        private frmConsultaModelos frmConsModelo;
        private frmConsultaPaises frmConsPais;
        private frmConsultaProdutos frmConsProduto;
        private frmConsultasFormasPagamento frmConsFormPag;
        private frmConsultaServicos frmConsServico;
        private frmConsultaSubgrupos frmConsSubgrupo;
        private frmConsultaTranspotadoras frmConsTranspot;
        private frmConsultaCompras frmConsCompra;

        private BancoDados.conexoes umaConexao;

        public Gerente()
        {
            InitializeComponent();
            InicializarAtributos();

            mnItem_Equipamentos.Click += MnItem_Equipamentos_Click;
            mnItem_Transportadoras.Click += MnItem_Transportadoras_Click;

            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = false;
            gb_Atalhos.Enabled = false;
            consultasToolStripMenuItem.Enabled = false;
            cadastrosToolStripMenuItem.Enabled = false;
            /*
             * loginToolStripMenuItem.Enabled = true;
             * logoutToolStripMenuItem.Enabled = false;
             * frmCadastros.frmConsultaOrdensServico f = new frmCadastros.frmConsultaOrdensServico();
             * f.ShowDialog();
            */
        }

        private void InicializarAtributos()
        {
            try
            {
                //conexão com banco de dados
                umaConexao = new BancoDados.conexoes();

                umaDaoCargo = new daoCargos();
                umaDaoCidade = new daoCidades();
                umaDaoCliente = new daoClientes();
                umaDaoCondPag = new daoCondicoesPagamento();
                umaDaoDeposito = new daoDepositos();
                umaDaoEquip = new daoEquipamentos();
                umaDaoEstado = new daoEstados();
                umaDaoFormPag = new daoFormasPagamento();
                umaDaoForn = new daoFornecedores();
                umaDaoFunc = new daoFuncionarios();
                umaDaoGrupo = new daoGrupos();
                umaDaoMarca= new daoMarcas();
                umaDaoModelo = new daoModelos();
                umaDaoPais = new daoPaises();
                umaDaoProduto = new daoProdutos();
                umaDaoServico = new daoServicos();
                umaDaoSubgrupo = new daoSubgrupos();
                umaDaoTransport = new daoTransportadoras();
                umaDaoCompra = new daoCompras();
                UmaDaoContaPagar = new daoContasPagar();

                umCtrlCargo = new ctrlCargos(umaConexao, umaDaoCargo);
                umCtrlPais = new ctrlPaises(umaConexao, umaDaoPais);
                umCtrlGrupo = new ctrlGrupos(umaConexao, umaDaoGrupo);
                umCtrlMarca = new ctrlMarcas(umaConexao, umaDaoMarca);
                umCtrlEstado = new ctrlEstados(umaConexao, umaDaoEstado, umCtrlPais);
                umCtrlSubgrupo = new ctrlSubgrupos(umaConexao, umaDaoSubgrupo, umCtrlGrupo);
                umCtrlModelo = new ctrlModelos(umaConexao, umaDaoModelo, umCtrlMarca);
                umCtrlEquip = new ctrlEquipamentos(umaConexao, umaDaoEquip, umCtrlModelo);
                umCtrlFormPag = new ctrlFormasPagamento(umaConexao, umaDaoFormPag);
                umCtrlCidade = new ctrlCidades(umaConexao, umaDaoCidade, umCtrlEstado);
                umCtrlCondPag = new ctrlCondicoesPagamento(umaConexao, umCtrlFormPag, umaDaoCondPag);
                umCtrlForn = new ctrlFornecedores(umaConexao, umaDaoForn, umCtrlCidade, umCtrlCondPag);
                umCtrlProduto = new ctrlProdutos(umaConexao, umaDaoProduto, umCtrlModelo, umCtrlSubgrupo, umCtrlForn);
                umCtrlCliente = new ctrlClientes(umaConexao, umCtrlCidade, umCtrlCondPag, umaDaoCliente);
                umCtrlDeposito = new ctrlDepositos(umaConexao, umaDaoDeposito, umCtrlCidade, umCtrlProduto);
                umCtrlServico = new ctrlServicos(umaConexao, umaDaoServico);
                umCtrlFunc = new ctrlFuncionarios(umaConexao, umaDaoFunc, umCtrlCargo, umCtrlCidade);
                umCtrlTransport = new ctrlTransportadoras(umaConexao, umaDaoTransport, umCtrlCidade);
                UmCtrlContaPagar = new ctrlContasPagar(umaConexao, UmaDaoContaPagar, umCtrlForn, umCtrlFormPag);
                umCtrlCompra = new ctrlCompras(umaConexao, umaDaoCompra, umCtrlTransport, umCtrlCondPag,
                    umCtrlForn, umCtrlProduto, UmCtrlContaPagar);
                

                //formulários de cadastro
                frmCadCargo = new frmCadastroCargos(umCtrlCargo);
                frmCadCidade = new frmCadastroCidades(umCtrlCidade);
                frmCadCliente = new frmCadastroClientes(umCtrlCliente);
                frmCadCondPag = new frmCadastroCondicoesPagamento(umCtrlCondPag);
                frmCadDeposito = new frmCadastroDepositos(umCtrlDeposito);
                frmCadEquip = new frmCadastroEquipamentos(umCtrlEquip);
                frmCadEstado = new frmCadastroEstados(umCtrlEstado);
                frmCadFornecedor = new frmCadastroFornecedores(umCtrlForn);
                frmCadFuncionario = new frmCadastroFuncionarios(umCtrlFunc);
                frmCadGrupo = new frmCadastroGrupos(umCtrlGrupo);
                frmCadMarca = new frmCadastroMarcas(umCtrlMarca);
                frmCadModelo = new frmCadastroModelos(umCtrlModelo);
                frmCadPais = new frmCadastroPaises(umCtrlPais);
                frmCadProduto = new frmCadastroProdutos(umCtrlProduto);
                frmCadFormPag = new frmCadastroFormasPagamento(umCtrlFormPag);
                frmCadServico = new frmCadastroServicos(umCtrlServico);
                frmCadSubgrupo = new frmCadastroSubGrupos(umCtrlSubgrupo);
                frmCadTransport = new frmCadastroTransportadoras(umCtrlTransport);
                frmCadCompra = new frmCadastroCompras(umCtrlCompra);

                //formulários de consulta
                frmConsCargo = new frmConsultaCargos(umCtrlCargo);
                frmConsCidade = new frmConsultaCidades(umCtrlCidade);
                frmConsCliente = new frmConsultaClientes(umCtrlCliente);
                frmConsCondPag = new frmConsultaCondicoesPagamento(umCtrlCondPag);
                frmConsDeposito = new frmConsultaDepositos(umCtrlDeposito);
                frmConsEquip = new frmConsultaEquipamentos(umCtrlEquip);
                frmConsEstado = new frmConsultaEstados(umCtrlEstado);
                frmConsFornecedor = new frmConsultaFornecedores(umCtrlForn);
                frmConsFuncionario = new frmConsultaFuncionarios(umCtrlFunc);
                frmConsGrupo = new frmConsultaGrupos(umCtrlGrupo);
                frmConsMarca = new frmConsultaMarcas(umCtrlMarca);
                frmConsModelo = new frmConsultaModelos(umCtrlModelo);
                frmConsPais = new frmConsultaPaises(umCtrlPais);
                frmConsProduto = new frmConsultaProdutos(umCtrlProduto);
                frmConsFormPag = new frmConsultasFormasPagamento(umCtrlFormPag);
                frmConsServico = new frmConsultaServicos(umCtrlServico);
                frmConsSubgrupo = new frmConsultaSubgrupos(umCtrlSubgrupo);
                frmConsTranspot = new frmConsultaTranspotadoras(umCtrlTransport);
                frmConsCompra = new frmConsultaCompras(umCtrlCompra);

                //vincula os formulários de consulta com seus respectivos cadastros
                frmConsCargo.SetFrmCad(frmCadCargo);
                frmConsCidade.SetFrmCad(frmCadCidade);
                frmConsCliente.SetFrmCad(frmCadCliente);
                frmConsCondPag.SetFrmCad(frmCadCondPag);
                frmConsDeposito.SetFrmCad(frmCadDeposito);
                frmConsEquip.SetFrmCad(frmCadEquip);
                frmConsEstado.SetFrmCad(frmCadEstado);
                frmConsFornecedor.SetFrmCad(frmCadFornecedor);
                frmConsFuncionario.SetFrmCad(frmCadFuncionario);
                frmConsGrupo.SetFrmCad(frmCadGrupo);
                frmConsMarca.SetFrmCad(frmCadMarca);
                frmConsModelo.SetFrmCad(frmCadModelo);
                frmConsPais.SetFrmCad(frmCadPais);
                frmConsProduto.SetFrmCad(frmCadProduto);
                frmConsFormPag.SetFrmCad(frmCadFormPag);
                frmConsServico.SetFrmCad(frmCadServico);
                frmConsSubgrupo.SetFrmCad(frmCadSubgrupo);
                frmConsTranspot.SetFrmCad(frmCadTransport);
                frmConsCompra.SetFrmCad(frmCadCompra);

                //vincula os formulários de consulta com os formulários de cadastro com dependência
                frmCadCidade.SetFrmCons(frmConsEstado);
                frmCadCliente.SetFrmCons(new Form[] { frmConsCondPag,frmConsCidade });
                frmCadCondPag.SetFrmCons(frmConsFormPag);
                frmCadDeposito.SetFrmCons(new Form[] { frmConsCidade, frmConsProduto });
                frmCadEquip.SetFrmCons(frmConsModelo);
                frmCadEstado.SetFrmCons(frmConsPais);
                frmCadFornecedor.SetFrmCons(new Form[] { frmConsCondPag, frmConsCidade });
                frmCadFuncionario.SetFrmCons(new Form[] { frmConsCidade, frmConsCargo });
                frmCadModelo.SetFrmCons(frmConsMarca);
                frmCadProduto.SetFrmCons(new Form[] { frmConsSubgrupo, frmConsFornecedor, frmConsModelo });
                frmCadSubgrupo.SetFrmCons(frmConsGrupo);
                frmCadTransport.SetFrmCons(frmConsCidade);
                frmCadCompra.SetFrmCons(new Form[] { frmConsCondPag, frmConsTranspot, frmConsFornecedor, frmConsProduto });
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possivel inicializar os formulários!\n" +
                                "ERRO: " + e.Message, "ERRO");
                Close();
            }
        }

        private void carregarListaConsulta()
        {
            
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

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCargo.ShowDialog();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCidade.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCliente.ShowDialog();
        }

        private void condiçõesDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadCondPag.ShowDialog();
        }

        private void depositosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadDeposito.ShowDialog();
        }

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadEstado.ShowDialog();
        }

        private void formasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFormPag.ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFornecedor.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadFuncionario.ShowDialog();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadGrupo.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadMarca.ShowDialog();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadModelo.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadProduto.ShowDialog();
        }

        private void paisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadPais.ShowDialog();
        }

        private void subgruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadSubgrupo.ShowDialog();
        }

        private void mnItem_Servicos_Click(object sender, EventArgs e)
        {
            frmConsServico.ShowDialog();
        }

        private void servicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadServico.ShowDialog();
        }
        private void MnItem_Equipamentos_Click(object sender, EventArgs e)
        {
            frmConsEquip.ShowDialog();
        }
        private void MnItem_Transportadoras_Click(object sender, EventArgs e)
        {
            frmConsTranspot.ShowDialog();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            frmConsCompra.ShowDialog();
        }

        private void btn_AbrirOS_Click(object sender, EventArgs e)
        {
            var d = new frmCadastros.frmConsultaOrdensServico();
            d.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = true;
            //Fazer rotina para logar no sistema
            //Caso logado habilita os
            var vlLoguin = true; //= false;

            gb_Atalhos.Enabled = vlLoguin;
            consultasToolStripMenuItem.Enabled = vlLoguin;
            cadastrosToolStripMenuItem.Enabled = vlLoguin;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = false;
            gb_Atalhos.Enabled = false;
            consultasToolStripMenuItem.Enabled = false;
            cadastrosToolStripMenuItem.Enabled = false;
        }
    }
}

