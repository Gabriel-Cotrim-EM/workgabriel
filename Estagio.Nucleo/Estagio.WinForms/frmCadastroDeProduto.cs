using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estagio.Nucleo;
using Estagio.Nucleo.Repositorio;

namespace Estagio.WinForms
{
    public partial class frmCadastroDeProduto : Form
    {
        public frmCadastroDeProduto()
        {
            InitializeComponent();

            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AllowUserToResizeColumns = false;


            var colunaID = new DataGridViewTextBoxColumn();
            colunaID.HeaderText = "ID";
            colunaID.DataPropertyName = "ColunaID";
            colunaID.Width = 90;
            colunaID.ReadOnly = true;
            dgvProdutos.Columns.Add(colunaID);

            var colunaDescricao = new DataGridViewTextBoxColumn();
            colunaDescricao.HeaderText = "Descrição";
            colunaDescricao.DataPropertyName = "ColunaDescricao";
            colunaDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvProdutos.Columns.Add(colunaDescricao);



        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var produtoUm = new Produto();
            produtoUm.Descricao = "banana";
            produtoUm.Id = 1;
            produtoUm.PrecoUnitario = 2.0m;
            produtoUm.QuantidadeMinimaEstoque = 3;
            RepositorioDeProduto.Instancia.Add(produtoUm);


            bsProdutos.DataSource = RepositorioDeProduto.Instancia.GetAll();
            bsProdutos.ResetBindings(false);
            dgvProdutos.DataSource = bsProdutos;

        }

        private void frmCadastroDeProduto_Load(object sender, EventArgs e)
        {
         
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
