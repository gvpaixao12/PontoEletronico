using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronico.Telas
{
    public partial class Home : Form
    {
        public Form1 ponto = new Form1();
        public string usu;
        public int id;
        public string senha;

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void BaterPonto_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ponto.id = id;
            ponto.usu = usu;
            ponto.ShowDialog();
        }
    }
}
