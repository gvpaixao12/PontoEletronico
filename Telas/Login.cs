using PontoEletronico.Negocio;
using PontoEletronico.Telas;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public Clog lg = new Clog();
        public Form1 ponto = new Form1();
        public Home home = new Home();
        public string usu;
        public string senha;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            usu = txtUsu.Text;
            senha = txtSenha.Text;
            lg.Login(usu, senha);

            home.id = lg.IdUsu;
            home.usu = usu;
            home.ShowDialog();
        }
    }
}
