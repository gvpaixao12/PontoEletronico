using PontoEletronico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronico
{
    public partial class Form1 : Form
    {
        public string usu;
        public int id;
        public int cont = 0;
        public Clog cad = new Clog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToString();
            txtNome.Text = usu;
            txtID.Text = id.ToString();
            ListaUsu(); //Lista todos os usuários cadastrados
            cont = 0;
            btnPonto.Enabled = true;
        }
        private void ListaUsu()
        {
            dgUsu.DataSource = cad.ListarUsu();
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            if(cont == 0)
            {
                cont = 1;

                MessageBox.Show("Ponto batido com sucesso!");
                
                btnPonto.Enabled = false;
            }
            else
            {
                MessageBox.Show("O ponto já foi batido");
            }

            
        }
    }
}
