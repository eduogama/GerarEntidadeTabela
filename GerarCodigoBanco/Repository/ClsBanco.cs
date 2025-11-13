using GerarCodigoBanco.Connection;
using GerarCodigoBanco.Entidade;
using GerarCodigoBanco.Uitls;
using System.Data;
using System.Text;

namespace GerarCodigoBanco.Repository
{
    public class ClsBanco
    {
        public static List<Tabelas> ObterTabelas(string bancoDados)
        {
            DataTable dt;
            MsSqlConn msSqlConn = new(bancoDados);
            List<Tabelas> tabelas = [];

            try
            {
                StringBuilder query = new();
                query.Append(" SELECT TABLE_NAME ");
                query.Append(" FROM INFORMATION_SCHEMA.TABLES ");
                query.Append(" ORDER BY TABLE_NAME ");

                dt = msSqlConn.Consultar(query.ToString()).Tables[0];
                tabelas = Metodos.GetDados<Tabelas>(dt.CreateDataReader());

                msSqlConn.Desconectar();
            }
            catch { }
            finally
            {
                msSqlConn.Desconectar();
            }

            return tabelas;
        }

        public static List<Campos> ObterCampos(string bancoDados, string tabela)
        {
            DataTable dt;
            MsSqlConn msSqlConn = new(bancoDados);
            List<Campos> campos = [];

            try
            {
                StringBuilder query = new();
                query.Append(" SELECT COLUMN_NAME, DATA_TYPE, ORDINAL_POSITION ");
                query.Append(" FROM INFORMATION_SCHEMA.COLUMNS ");
                query.Append(" WHERE TABLE_NAME = '").Append(tabela).Append('\'');

                dt = msSqlConn.Consultar(query.ToString()).Tables[0];
                campos = Metodos.GetDados<Campos>(dt.CreateDataReader());

                msSqlConn.Desconectar();
            }
            catch { }
            finally
            {
                msSqlConn.Desconectar();
            }

            return campos;
        }
    }
}
