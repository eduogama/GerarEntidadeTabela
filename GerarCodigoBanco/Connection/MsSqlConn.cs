using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace GerarCodigoBanco.Connection
{
    public class MsSqlConn
    {
        private SqlConnection conn;
        private SqlTransaction transac;
        private SqlCommand command;

        private enum IOdbcConnectionOwnership
        {
            Internal,
            External
        }

        #region Conexão

        public MsSqlConn(string bancoDados)
        {
            string sqlConn = $"Data Source=localhost,1450;Initial Catalog={bancoDados};Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Wowsan060";
            Conectar(sqlConn);
        }

        public void Conectar(string strConn)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                command = new SqlCommand("", conn);
            }

            catch
            {
                MessageBox.Show("Impossivel estabelecer conexao com a banco de dados");
            }
        }

        public void Desconectar()
        {
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }

            conn.Dispose();
        }

        #endregion

        #region Transação

        public void IniciarTransacao()
        {
            transac = conn.BeginTransaction();
            command.Transaction = transac;
        }

        public void AbortarTransacao()
        {
            transac?.Rollback();
        }

        public void ConfirmarTransacao()
        {
            //Após efetivar a transação anula o objeto para não gerar exceção nas demais processos.
            transac?.Commit();
        }

        #endregion

        #region Métodos de Execução

        public int Executar(string SQL)
        {
            return ExecuteNonQuery(transac, CommandType.Text, SQL);
        }

        public int Executar(string Proc, params object[] parValues)
        {
            return ExecuteNonQuery(transac, Proc, parValues); // implementado MontaProc
        }

        public object Escalar(string SQL)
        {
            if (transac != null)
            { return ExecuteScalar(transac, CommandType.Text, SQL); }
            else
            { return ExecuteScalar(conn, CommandType.Text, SQL); }
        }

        public object Escalar(string Proc, params object[] parValues)
        {
            if (transac != null)
            { return ExecuteScalar(transac, Proc, parValues); } // implementado MontaProc
            else
            { return ExecuteScalar(conn, Proc, parValues); }  // implementado MontaProc
        }

        public DataSet Consultar(string SQL)
        {
            if (transac != null)
            { return ExecuteDataset(transac, CommandType.Text, SQL); }
            else
            { return ExecuteDataset(conn, CommandType.Text, SQL); }
        }

        public DataSet Consultar(string Proc, params object[] parValues)
        {
            if (transac != null)
            { return ExecuteDataset(transac, Proc, parValues); }// implementado MontaProc
            else
            { return ExecuteDataset(conn, Proc, parValues); } // implementado MontaProc
        }

        public SqlDataReader ConsultarReader(string SQL)
        {
            if (transac != null)
            { return ExecuteReader(transac, CommandType.Text, SQL); }
            else
            { return ExecuteReader(conn, CommandType.Text, SQL); }
        }

        public SqlDataReader ConsultarReader(string Proc, params object[] parValues)
        {
            if (transac != null)
            { return ExecuteReader(transac, Proc, parValues); }
            else
            { return ExecuteReader(conn, Proc, parValues); }
        }

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                // Verifica se tem valor atribuído
                if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input || p.Direction == ParameterDirection.Output) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }

        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                //retorna nada, caso não tenha dados
                return;
            }

            // Verifica a quantidade de parâmetros existentes
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("A quantidade de parâmetros não correspondem a quantidade de itens.");
            }

            //Interage com os parâmetros do iDB2Parameters, atribuindo os valores de acordo com a posição do array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                commandParameters[i].Value = parameterValues[i];
            }
        }

        private static void AssignReturnValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                //retorna nada, caso não tenha dados
                return;
            }

            // Verifica a quantidade de parâmetros existentes
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("A quantidade de parâmetros não correspondem a quantidade de itens.");
            }

            //Interage com os parâmetros do iDB2Parameters, atribuindo os valores de retorno de acordo com a posição 
            //do array.
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                if (commandParameters[i].Direction == ParameterDirection.Output)
                {
                    parameterValues[i] = commandParameters[i].Value;
                }
            }
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            //Abre a conexão caso a mesma não estiver aberta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            //Associa a conexão com o comando.
            command.Connection = connection;

            //Seta o conteúdo do comando, podendo ser uma SP ou sintaxe SQL
            command.CommandText = commandText;

            //Caso não tenha uma transação, atribui uma
            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            //Seta o tipo do comando
            command.CommandType = commandType;

            //Atribui os parâmetros existentes
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion

        #region Comandos ExecuteNonQuery

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteNonQuery(connectionString, commandType, commandText, null);
        }

        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria e abre uma SqlConnection, e depois de utilizá-la, a destrói.
            using SqlConnection cn = new(connectionString);
            cn.Open();
            //Chama o método sobrecarregado que contem uma conexão no lugar da ConectionString
            return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
        }

        public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
            }
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteNonQuery(connection, commandType, commandText, null);
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria um comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters);

            //Ao término, executa o comando
            var ret = cmd.ExecuteNonQuery();

            cmd.Dispose();

            return ret;
        }

        public static int ExecuteNonQuery(SqlConnection connection, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
            }
        }

        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteNonQuery(transaction, commandType, commandText, null);
        }

        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            int ret;

            if (commandParameters != null)
            {
                commandText = MontaProc(commandText, commandParameters);
            }

            //Cria um comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

            ret = cmd.ExecuteNonQuery();

            cmd.Dispose();
            // throw new ApplicationException(commandParameters == null ? ret.ToString() : "ok");
            if (commandParameters != null)
            {

                for (int i = 0; commandParameters.Length > i; i++)
                {

                    if (commandParameters[i].Direction == ParameterDirection.Output)
                    {

                        ret = Convert.ToInt32(commandParameters[i].Value);
                        break;
                    }
                }
            }
            return ret;
        }

        public static int ExecuteNonQuery(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);


                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);


                //Chama o método sobrecarregado
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion

        #region Comandos ExecuteDataset

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteDataset(connectionString, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria e abre uma SqlConnection, e depois de utilizá-la, a destrói.
            using SqlConnection cn = new(connectionString);
            cn.Open();

            //Chama o método sobrecarregado de que contem ConectionString
            return ExecuteDataset(cn, commandType, commandText, commandParameters);
        }

        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            DataSet dsExecuteDataset;

            //Caso receba parâmetros
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                dsExecuteDataset = ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);

                //Atribui os parâmetros de retorno para o array inicial de forma a tratá-lo.
                AssignReturnValues(commandParameters, parameterValues);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                dsExecuteDataset = ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
            }
            return dsExecuteDataset;
        }

        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteDataset(connection, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria um comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters);

            //Cria um DataAdapter e um Dataset
            SqlDataAdapter da = new(cmd);
            DataSet ds = new();

            //Popula o Dataset usando os valores default para DataTable, names etc
            da.Fill(ds);

            cmd.Dispose();
            da.Dispose();

            //retorna o Dataset
            return ds;
        }

        public static DataSet ExecuteDataset(SqlConnection connection, string spName, params object[] parameterValues)
        {
            DataSet dsExecuteDataset;

            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                spName = MontaProc(spName, parameterValues);

                //Chama o método sobrecarregado
                dsExecuteDataset = ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);

                //Atribui os parâmetros de retorno para o array inicial de forma a tratá-lo.
                AssignReturnValues(commandParameters, parameterValues);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                spName = MontaProc(spName, null);

                dsExecuteDataset = ExecuteDataset(connection, CommandType.StoredProcedure, spName);
            }
            return dsExecuteDataset;
        }

        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteDataset(transaction, commandType, commandText, null);
        }

        public static DataSet ExecuteDataset(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (commandParameters != null)
            {
                commandText = MontaProc(commandText, commandParameters);
            }

            //Cria um Comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

            //Cria um DataAdapter e um Dataset
            SqlDataAdapter da = new(cmd);
            DataSet ds = new();

            //Popula o Dataset usando os valores default para DataTable, names etc
            da.Fill(ds);

            cmd.Dispose();
            da.Dispose();

            //retorna o Dataset
            return ds;
        }

        public static DataSet ExecuteDataset(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            DataSet dsExecuteDataset;

            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                dsExecuteDataset = ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);

                //Atribui os parâmetros de retorno para o array inicial de forma a tratá-lo.
                AssignReturnValues(commandParameters, parameterValues);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                dsExecuteDataset = ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
            }
            return dsExecuteDataset;
        }

        #endregion

        #region Comandos ExecuteReader

        private static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, IOdbcConnectionOwnership connectionOwnership)
        {
            //Cria um Comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);

            //Cria um DataReader
            SqlDataReader dr;

            // Chama o Método ExecuteReader com o apropriado Comando
            if (connectionOwnership == IOdbcConnectionOwnership.External)
            {
                dr = cmd.ExecuteReader();
            }
            else
            {
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

            cmd.Dispose();

            return dr;
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteReader(connectionString, commandType, commandText, null);
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria e Abre uma SqlConnection
            SqlConnection cn = new(connectionString);
            cn.Open();

            try
            {
                //Chama o método sobrecarregado privado que possui uma conexão
                return ExecuteReader(cn, null, commandType, commandText, commandParameters, IOdbcConnectionOwnership.Internal);
            }
            catch
            {
                //Em caso de erro, a conexão é fechada
                cn.Close();
                throw;
            }
            finally
            {
                cn.Close();

                cn.Dispose();
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
            }
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteReader(connection, commandType, commandText, null);
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros e uma conexão externa
            return ExecuteReader(connection, null, commandType, commandText, commandParameters, IOdbcConnectionOwnership.External);
        }

        public static SqlDataReader ExecuteReader(SqlConnection connection, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteReader(connection, CommandType.StoredProcedure, spName);
            }
        }

        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteReader(transaction, commandType, commandText, null);
        }

        public static SqlDataReader ExecuteReader(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, IOdbcConnectionOwnership.External);
        }

        public static SqlDataReader ExecuteReader(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
            }
        }

        #endregion

        #region Comandos ExecuteScalar

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteScalar(connectionString, commandType, commandText, null);
        }

        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //Cria e abre uma SqlConnection, e depois de utilizá-la, a destrói.
            using SqlConnection cn = new(connectionString);
            cn.Open();

            //Chama o método sobrecarregado que contem uma conexão no lugar da ConectionString
            return ExecuteScalar(cn, commandType, commandText, commandParameters);
        }

        public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
            }
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteScalar(connection, commandType, commandText, null);
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (commandParameters != null)
            {
                commandText = MontaProc(commandText, commandParameters);
            }

            //Cria um Comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters);

            //Executa o Comando e retorna o resultado
            var obj = cmd.ExecuteScalar();

            cmd.Dispose();

            return obj;
        }

        public static object ExecuteScalar(SqlConnection connection, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
            }
        }

        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText)
        {
            //Realiza a chamada, passando o valor nulo para os parâmetros
            return ExecuteScalar(transaction, commandType, commandText, null);
        }

        public static object ExecuteScalar(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (commandParameters != null)
            {
                commandText = MontaProc(commandText, commandParameters);
            }

            //Cria um Comando e o prepara para a execução
            SqlCommand cmd = new();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

            //Executa o comando e retorna os resultados
            var obj = cmd.ExecuteScalar();

            cmd.Dispose();

            return obj;

        }

        public static object ExecuteScalar(SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            //Caso receba parâmetros 
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                //Armazena os parâmetros da SP
                SqlParameter[] commandParameters = IOdbcHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

                //Atribui os valores dos parâmetros baseados na ordem
                AssignParameterValues(commandParameters, parameterValues);

                //Chama o método sobrecarregado
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            //Caso contrário, chama a SP sem parâmetros
            else
            {
                return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
            }
        }

        private static string MontaProc(string spName, params object[] parameterValues)
        {
            if (parameterValues != null)
            {
                string paramStr = "";
                foreach (var item in parameterValues)
                {
                    paramStr += "?,";
                }

                spName = string.Format("CALL {0}({1})", spName, paramStr[..^1]);
            }
            else
            {
                spName = string.Format("CALL {0}", spName);
            }

            return spName;
        }
        #endregion
    }

    public sealed class IOdbcHelperParameterCache
    {
        private IOdbcHelperParameterCache() { }

        private static readonly Hashtable paramCache = Hashtable.Synchronized([]);

        private static SqlParameter[] DiscoverSpParameterSet(string spName)
        {
            string sqlConn = "Data Source=localhost,1450;Initial Catalog=dbContrSolicIS;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Wowsan060";


            using SqlConnection cn = new(sqlConn);
            using SqlCommand cmd = new(spName, cn);
            cn.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder.DeriveParameters(cmd);
            SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count]; ;

            cmd.Parameters.CopyTo(discoveredParameters, 0);

            return discoveredParameters;
        }

        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
        {
            string hashKey = connectionString + ":" + commandText;
            paramCache[hashKey] = commandParameters;
        }

        public static SqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            string hashKey = connectionString + ":" + commandText;

            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
        {
            return GetSpParameterSet(connectionString, spName, false);
        }

        public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
        {
            string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

            SqlParameter[] cachedParameters;
            cachedParameters = (SqlParameter[])paramCache[hashKey];
            cachedParameters ??= (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(spName));

            return CloneParameters(cachedParameters);
        }
    }
}
