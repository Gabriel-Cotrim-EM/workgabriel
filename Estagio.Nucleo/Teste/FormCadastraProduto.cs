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
    public partial class FormCadastraProduto : Form
    {

        private Form1 _formPrincipal;

        public FormCadastraProduto(Form1 formPrincipal)
        {
            _formPrincipal = formPrincipal;
            InitializeComponent();
        }

        private void FormCadastraProduto_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LimpaCampos()
        {
            txtDescricao.Text = string.Empty;
            txtID.Text = string.Empty;
            txtQuantidadeMinima.Text = string.Empty;
            txtPrecoUnitario.Text = string.Empty;
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {

            RepositorioDeProduto.Instancia.Add(new Produto
            {
                Id = Convert.ToInt32(txtID.Text),
                Descricao = txtDescricao.Text,
                QuantidadeMinimaEstoque = Convert.ToInt32(txtQuantidadeMinima.Text),
                PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text)
            });
            LimpaCampos();
            txtID.Focus();

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
