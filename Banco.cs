using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Aplicativo_Pollock_Seven
{
    internal class Banco
    {
        private static SQLiteConnection conexao;

        private static SQLiteConnection ConexaoBanco()
        {
           
            string stringConexao = $"Data Source={Globais.caminhoBanco};";

            SQLiteConnection conexao = new SQLiteConnection(stringConexao);
            conexao.Open();
            return conexao;

        }

        public static DataTable dql(string sql)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                var vcon = ConexaoBanco();

                var cmd = vcon.CreateCommand();

                cmd.CommandText = sql;
                
                da = new SQLiteDataAdapter(cmd.CommandText, vcon);

                da.Fill(dt);
                vcon.Close();
                return dt; 


            }catch (Exception ex)
            {
                throw ex; 
            }

        }
       

    }
}
