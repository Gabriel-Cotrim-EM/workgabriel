using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estagio.Nucleo
{
    public partial class Form1 : Form
    {

        CpfCnpj cpfCnpj;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtCnpjCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnValidaCpfCnpj_Click(object sender, EventArgs e)
        {
            cpfCnpj = new CpfCnpj(txtCnpjCpf.Text);
            txtCnpjCpf.Text = cpfCnpj.Numero;
        }
    }
}
