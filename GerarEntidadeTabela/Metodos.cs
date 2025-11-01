using Microsoft.Data.SqlClient;
using System.Text;

namespace GerarEntidadeTabela
{
    public class Metodos
    {
        public static void GerarEntidade(string namespaces, string tabela)
        {
            // Configurações
            string connectionString = "Data Source=localhost,1450;Initial Catalog=dbContrSolicIS;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Wowsan060";
            string nomeClasse = char.ToUpper(tabela[0]) + tabela.Substring(1);
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Domain\\"), nomeClasse + ".cs");

            // Mapeamento SQL -> C#
            var typeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "int", "int" },
                { "bigint", "long" },
                { "smallint", "short" },
                { "tinyint", "byte" },
                { "bit", "bool" },
                { "decimal", "decimal" },
                { "numeric", "decimal" },
                { "money", "decimal" },
                { "float", "double" },
                { "real", "float" },
                { "date", "DateTime" },
                { "datetime", "DateTime" },
                { "datetime2", "DateTime" },
                { "smalldatetime", "DateTime" },
                { "time", "TimeSpan" },
                { "char", "string" },
                { "varchar", "string" },
                { "nvarchar", "string" },
                { "text", "string" }
            };

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
            sb.AppendLine();
            sb.AppendLine($"namespace {namespaces}");
            sb.AppendLine("{");
            sb.AppendLine();
            sb.AppendLine($"    [Table(\"{tabela}\")]");
            sb.AppendLine($"    public class {nomeClasse}");
            sb.AppendLine("    {");

            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                string query = $"SELECT COLUMN_NAME, DATA_TYPE, ORDINAL_POSITION FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tabela}' ORDER BY ORDINAL_POSITION";

                using SqlCommand cmd = new(query, conn);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string columnName = reader.GetString(0);
                    string sqlType = reader.GetString(1);
                    string ordinalPosition = reader.GetInt32(2).ToString();
                    string csharpType = typeMap.TryGetValue(sqlType, out string? value) ? value : "object";

                    if (ordinalPosition.Equals("1"))
                    {
                        sb.AppendLine("        [Key]");
                    }
                    sb.AppendLine($"        public {csharpType} {columnName} {{ get; set; }}");
                }

                reader.Close();
            }

            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("}");

            // Salvar no arquivo .cs
            File.WriteAllText(caminhoArquivo, sb.ToString(), Encoding.UTF8);

            Console.WriteLine($"Classe gerada com sucesso em: {caminhoArquivo}");
        }
    }
}
