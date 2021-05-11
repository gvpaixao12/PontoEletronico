using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace Dados
{
    public class dbConexao
    {
        #region Atributos       

        string sourcePath = @"pontoelet.txt";
        private string cServidor;
        private string cBanco;
        private string cUsuario = "System";
        private string cSenha = "oessystem";
        private string cPorta;
        private string cConexao = "Server={0};Database={1};Uid={2};Pwd={3};Port={4};";
        private MySqlConnection oConexao;
        public int cont = 0;
        public string str1;
        public string str2;
        public string aux;
        public string retornoComp;
        public string auxErro;
        #endregion

        /// <summary>
        /// Construtor para abrir conexão com o Banco de Dados
        /// </summary>
        public dbConexao()
        {
            VerificaURL();
            cConexao = string.Format(cConexao, cServidor, cBanco, cUsuario, cSenha, cPorta);
            oConexao = new MySqlConnection(cConexao);
            try
            {
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("erro de acesso ao MySql: " + ex.Message + "Erro");
            }
        }
        #region Métodos

        #region Verifica URL
        /// <summary>
        /// Método para ler o arquivo de configuração e retornar a URL 
        /// </summary>
        /// <returns></returns>
        public void VerificaURL()
        {
            try
            {
                if (!File.Exists(sourcePath))
                {
                    File.Create(sourcePath);
                }
                else
                {
                    string[] lines = File.ReadAllLines(sourcePath);
                    foreach (string line in lines)
                    {
                        cServidor = lines[0];
                        cBanco = lines[1];
                        cPorta = lines[2];
                    }
                }
            }
            catch (IOException e)
            {
                string aux = "Ocorreu um erro ao ler arquivo" + e;
            }
        }
        #endregion

        #region Consulta Padrão
        /// <summary>
        /// Para todas pesquisas "universais" do sistema, utilizaremos este método
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable RetDataTable(string sql)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            try
            {
                da.Fill(datatable);
                cont = datatable.Rows.Count;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "\n" + "\n" + " FAVOR VERIFICAR AS CREDENCIAIS DE ACESSO AO BANCO DE DADOS!!! ");

                Application.Exit();
            }
            return datatable;
        }
        #endregion        

        #region Inserir 
        /// <summary>
        /// Método utilizado para os insert no Banco
        /// </summary>
        /// <param name="sql"></param>
        public void ExSql(string sql)
        {
            oConexao.Open();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            command.ExecuteNonQuery();
            oConexao.Close();
        }
        #endregion

        #region Pesquisa Tamanho Tela
        /// <summary>
        /// Método para pesquisa especificamente do comprimento e da altura das telas.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable PesquisaTela(string sql)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(datatable);
            cont = datatable.Rows.Count;

            str1 = datatable.Rows[0]["comprimento"].ToString();
            str2 = datatable.Rows[0]["altura"].ToString();

            return datatable;
        }

        #endregion

        #region Retornar ID
        /// <summary>
        /// Método para retornar ID no campo, logo após fazer um novo cadastro
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public DataTable retorno(string sql, string a)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(datatable);
            cont = datatable.Rows.Count;

            if (datatable.Rows.Count != 0)
            {
                str1 = datatable.Rows[0][a].ToString();
            }
            else
            {
                return datatable;
            }

            return datatable;
        }
        #endregion

        #region Retornar Nome do Usuário Conectado
        /// <summary>
        /// Método para retornar Nome do Usuário conectado no sistema
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public DataTable retornoNome(string sql, string a, string i)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(datatable);
            cont = datatable.Rows.Count;

            str1 = datatable.Rows[0][a].ToString();
            str2 = datatable.Rows[0][i].ToString();
            return datatable;
        }
        #endregion

        #region Login
        public DataTable Login(string sql, string a)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            try
            {
                da.Fill(datatable);
                cont = datatable.Rows.Count;
                str1 = datatable.Rows[0][a].ToString();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex + "\n" + "\n" + " FAVOR VERIFICAR AS CREDENCIAIS DE ACESSO AO BANCO DE DADOS!!! ");
                Application.Exit();
            }
            return datatable;
        }
        #endregion

        #endregion

        #region Fechar Conexao com Banco

        /// <summary>
        /// Método para fechar conexao com o banco, para não haver um uso desnecessario de conexoes
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="a"></param>
        /// <returns></returns>

        //public bool FecharConexao(IDbConnection conexao)
        //{
        //    try
        //    {
        //        var MyConn = conexao as MySqlConnection;
        //        int PID = MyConn.ServerThread;
        //        string SQL = "kill " + PID.ToString();
        //        MySqlCommand MyCommand = new MySqlCommand(SQL, MyConn);
        //        MyCommand.ExecuteNonQuery();
        //        MyConn.Close();
        //        MyCommand.Dispose();
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        #endregion

        #region Atualiza Componentes
        /// <summary>
        /// Método para retornar ID no campo, logo após fazer um novo cadastro
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public string AtualizaComponentes(string sql, int col)
        {
            DataTable datatable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, oConexao);
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(datatable);
            cont = datatable.Rows.Count;
            retornoComp = null;

            if (datatable.Rows.Count != 0)
            {
                for (int i = 0; i <= col; i++)
                {
                    aux = datatable.Rows[0][i].ToString();
                    retornoComp += aux + ";";
                }
            }
            else
            {
            }
            return retornoComp;
        }
        #endregion
    }
}
