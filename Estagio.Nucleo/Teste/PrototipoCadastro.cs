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
    public partial class PrototipoCadastro : Form
    {
        public PrototipoCadastro()
        {
            InitializeComponent();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void PrototipoCadastro_Load(object sender, EventArgs e)
        {
            Produto prodUm = new Produto();
            prodUm.Id = 1;
            prodUm.Descricao = "Maçã";
            prodUm.QuantidadeMinimaEstoque = 5;
            prodUm.PrecoUnitario = 5.0m;
            RepositorioDeProduto.Instancia.Add(prodUm);

            Produto prodDois = new Produto();
            prodDois.Id = 1;
            prodDois.Descricao = "Pera";
            prodDois.QuantidadeMinimaEstoque = 5;
            prodDois.PrecoUnitario = 5.0m;
            RepositorioDeProduto.Instancia.Add(prodDois);

            var produtos = RepositorioDeProduto.Instancia.GetAll();

            foreach(Produto produto in produtos)
            {
                dgvProdutos.Rows.Add(produto.Id, produto.Descricao);
            }
        }
    }
}
