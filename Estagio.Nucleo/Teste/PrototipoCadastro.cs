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

        private void PrototipoCadastro_Load(object sender, EventArgs e)
        {
            var produtos = RepositorioDeProduto.Instancia.GetAll();
            
            foreach(Produto produto in produtos)
            {
                dgvProdutos.Rows.Add(produto.Id, produto.Descricao);
            }

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
