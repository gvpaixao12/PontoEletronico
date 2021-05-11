using Dados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Negocio
{
    public class Clog
    {

        #region Atributos

        public dbConexao conexao = new dbConexao();
        public string sql;
        public string cQuery;
        public int cont;
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private int idUsu;

        public int IdUsu
        {
            get { return idUsu; }
            set { idUsu = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private DateTime dataentrada;

        public DateTime Dataentrada
        {
            get { return dataentrada; }
            set { dataentrada = DateTime.Now; }
        }

        #endregion

        #region Métodos

        public bool Login(string u, string s)
        {
            cQuery = ("SELECT usuario FROM CAD_USU where usuario = '{0}' and senha = {1}");

            cQuery = string.Format(cQuery, u, s);
            conexao.RetDataTable(cQuery);

            if (conexao.cont == 1)
            {
                sql = "" +
                        "select usuario, id_usuario from CAD_USU where usuario='{0}'";

                sql = string.Format(sql, u);
                conexao.retornoNome(sql, "usuario", "id_usuario");
                Usuario = conexao.str1;
                IdUsu = int.Parse(conexao.str2);

                return true;
            }
            else
            return false;
        }

        public DataTable ListarUsu()
        {
            cQuery = "" +
                "select " +
                "id_usuario AS ID," +
                "usuario AS NOME " +
                "from cad_usu ";

            conexao.RetDataTable(cQuery);
            cont = conexao.cont;

            return conexao.RetDataTable(cQuery);
        }


        #endregion

    }
}
