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

namespace Teste
{
    public partial class Form1 : Form
    {

        Produto produto;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            produto = new Produto(); 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        public void AdicionaConta()
        {
            cboProdutos.Items.AddRange(RepositorioDeProduto.Instancia.GetAll().ToArray());
        }


        private void btnCadastraProduto_Click(object sender, EventArgs e)
        {
            FormCadastraProduto frmAtualizaProduto = new FormCadastraProduto(this);
            frmAtualizaProduto.ShowDialog();
            cboProdutos.Items.Clear();
            AdicionaConta();
        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selecionado = (Produto)cboProdutos.SelectedItem;
            txtID.Text = Convert.ToString(selecionado.Id);
            txtQuantidadeMinima.Text = Convert.ToString(selecionado.QuantidadeMinimaEstoque);
            txtPrecoUnitario.Text = Convert.ToString(selecionado.PrecoUnitario);

        }

        private void btnFormAtualiza_Click(object sender, EventArgs e)
        {
            Produto produtoAtualizado = new Produto();
            produtoAtualizado.Id = ((Produto)cboProdutos.SelectedItem).Id;
            produtoAtualizado.QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidadeMinima.Text);
            produtoAtualizado.PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            produtoAtualizado.Descricao = cboProdutos.Text;
            RepositorioDeProduto.Instancia.Update(produtoAtualizado);
            cboProdutos.Text = string.Empty;
            txtID.Text = string.Empty;
            txtQuantidadeMinima.Text = string.Empty;
            txtPrecoUnitario.Text = string.Empty;
            cboProdutos.Items.Clear();
            AdicionaConta();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
