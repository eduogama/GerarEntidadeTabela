using GerarCodigoBanco.Entidade;
using GerarCodigoBanco.Repository;
using System.Text;

namespace GerarCodigoBanco.Uitls
{
    public class ClsGerar
    {
        public static void Entidade(string bancoDados, string namespaces, string tabela)
        {
            // Configurações
            string nomeClasse = char.ToUpper(tabela[0]) + tabela.Substring(1);
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Classes\\Domain\\"), nomeClasse + ".cs");
            List<Campos> campos = ClsBanco.ObterCampos(bancoDados, tabela);

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
            sb.AppendLine();
            sb.AppendLine($"        #region Primitive Properties");
            sb.AppendLine();

            foreach (var campo in campos)
            {
                string columnName = campo.COLUMN_NAME;
                string sqlType = campo.DATA_TYPE;
                string ordinalPosition = campo.ORDINAL_POSITION.ToString();
                string csharpType = Metodos.ObterTiposDados().TryGetValue(sqlType, out string value) ? value : "object";

                if (ordinalPosition.Equals("1"))
                {
                    sb.AppendLine("        [Key]");
                }

                sb.AppendLine($"        public {csharpType} {columnName} {{ get; set; }}");
            }

            sb.AppendLine();
            sb.AppendLine($"        #endregion");
            sb.AppendLine();
            sb.AppendLine("    }");
            sb.AppendLine();
            sb.AppendLine("}");

            // Salvar no arquivo .cs
            File.WriteAllText(caminhoArquivo, sb.ToString(), Encoding.UTF8);
        }

        public static void Repositorio(string namespaces, string tabela)
        {
            // Configurações
            string nomeDomain = char.ToUpper(tabela[0]) + tabela.Substring(1);
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Classes\\Repository\\"), nomeDomain + ".cs");

            String[] partes = namespaces.Split('.');
            string domain = String.Format("{0}.domain", string.Join(".", partes.Take(2)));

            var sb = new StringBuilder();
            sb.AppendLine($"using {domain};");
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using Microsoft.AspNetCore.Mvc.Rendering;");
            sb.AppendLine();
            sb.AppendLine($"namespace {namespaces}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class Dados{nomeDomain}");
            sb.AppendLine("     {");
            sb.AppendLine();
            sb.AppendLine("         private readonly SQLContext Contexto = new();");
            sb.AppendLine();
            sb.AppendLine($"         public IList<{nomeDomain}> Listar()");
            sb.AppendLine("         {");
            sb.AppendLine($"             IList<{nomeDomain}> entidade = [.. Contexto.{nomeDomain}.OrderBy(t => t.Descricao)];");
            sb.AppendLine("             return entidade;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine($"         public {nomeDomain} Obter(long id)");
            sb.AppendLine("         {");
            sb.AppendLine($"             {nomeDomain} entidade = Contexto.{nomeDomain}.Single(t => t.Codigo == id);");
            sb.AppendLine("             return entidade;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine($"         public string Gravar({nomeDomain} entidade)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine($"                 Contexto.{nomeDomain}.Add(entidade);");
            sb.AppendLine("                 Contexto.SaveChanges();");
            sb.AppendLine("                 Mensagem = \"Incluído com Sucesso\";");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine($"         public string Alterar({nomeDomain} entidade)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine($"                 Contexto.{nomeDomain}.Entry(entidade).State = EntityState.Modified;");
            sb.AppendLine("                 Contexto.SaveChanges();");
            sb.AppendLine("                 Mensagem = \"Alterado com Sucesso\";");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine($"         public string Excluir(long id)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine($"                 {nomeDomain} entidade = Contexto.{nomeDomain}.Single(t => t.Codigo == id);");
            sb.AppendLine();
            sb.AppendLine($"                 Contexto.{nomeDomain}.Remove(entidade);");
            sb.AppendLine("                 Contexto.SaveChanges();");
            sb.AppendLine("                 Mensagem = \"Excluído com Sucesso\";");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine("     }");
            sb.AppendLine("}");

            // Salvar no arquivo .cs
            File.WriteAllText(caminhoArquivo, sb.ToString(), Encoding.UTF8);
        }

        public static void DbContext(string namespaces, List<Tabelas> tabelas)
        {
            // Configurações
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Classes\\Repository\\"), "SQLContext.cs");

            String[] partes = namespaces.Split('.');
            string domain = String.Format("{0}.domain", string.Join(".", partes.Take(2)));
            string GetSet = "{ get; set; }";

            var sb = new StringBuilder();
            sb.AppendLine($"using {domain};");
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using Microsoft.Extensions.Configuration;");
            sb.AppendLine();
            sb.AppendLine($"namespace {namespaces}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class SQLContext : DbContext");
            sb.AppendLine("     {");
            sb.AppendLine();

            foreach (var tabela in tabelas)
            {
                string nomeTabela = char.ToUpper(tabela.TABLE_NAME[0]) + tabela.TABLE_NAME.Substring(1);
                sb.AppendLine($"         public DbSet<{nomeTabela}> {nomeTabela} {GetSet}");
            }

            sb.AppendLine();
            sb.AppendLine("     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
            sb.AppendLine("     {");
            sb.AppendLine("         IConfigurationRoot config = new ConfigurationBuilder()");
            sb.AppendLine("             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)");
            sb.AppendLine("             .AddJsonFile(\"appsettings.json\")");
            sb.AppendLine("             .Build();");
            sb.AppendLine();
            sb.AppendLine("         string sConn = config.GetConnectionString(\"Dev\");");
            sb.AppendLine();
            sb.AppendLine("         optionsBuilder.UseSqlServer(sConn);");
            sb.AppendLine("     }");
            sb.AppendLine();
            sb.AppendLine("         protected override void OnModelCreating(ModelBuilder modelBuilder)");
            sb.AppendLine("     {");
            sb.AppendLine();
            sb.AppendLine("     }");

            // Salvar no arquivo .cs
            File.WriteAllText(caminhoArquivo, sb.ToString(), Encoding.UTF8);
        }

        public static void Services(string namespaces, string tabela)
        {
            // Configurações
            string nomeDomain = char.ToUpper(tabela[0]) + tabela.Substring(1);
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Classes\\Services\\"), nomeDomain + ".cs");

            String[] partes = namespaces.Split('.');
            string usingDomain = String.Format("{0}.domain", string.Join(".", partes.Take(2)));
            string usingRepo = String.Format("{0}.repository.repositorio", string.Join(".", partes.Take(2)));
            string dadosRepo = "Dados" + nomeDomain;

            var sb = new StringBuilder();

            sb.AppendLine($"using {usingDomain};");
            sb.AppendLine($"using {usingRepo};");
            sb.AppendLine();
            sb.AppendLine($"namespace {namespaces}");
            sb.AppendLine("{");
            sb.AppendLine($"    public class Service{nomeDomain}");
            sb.AppendLine("     {");
            sb.AppendLine();
            sb.AppendLine($"         readonly {dadosRepo} Dados = new();");
            sb.AppendLine();
            sb.AppendLine("         /// <summary>");
            sb.AppendLine("         /// Listar");
            sb.AppendLine("         /// </summary>");
            sb.AppendLine($"         public IList<{nomeDomain}> Listar()");
            sb.AppendLine("         {");
            sb.AppendLine("             return Dados.Listar();");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         /// <summary>");
            sb.AppendLine("         /// Obter o Registro por Código");
            sb.AppendLine("         /// </summary>");
            sb.AppendLine($"         public {nomeDomain} Obter(long id)");
            sb.AppendLine("         {");
            sb.AppendLine("             return Dados.Obter(id);");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         /// <summary>");
            sb.AppendLine("         /// Gravar o Registro");
            sb.AppendLine("         /// </summary>");
            sb.AppendLine($"         public string Gravar({nomeDomain} entidade)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = Dados.Gravar(entidade);");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         /// <summary>");
            sb.AppendLine("         /// Alterar o Registro");
            sb.AppendLine("         /// </summary>");
            sb.AppendLine($"         public string Alterar({nomeDomain} entidade)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = Dados.Alterar(entidade);");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         /// <summary>");
            sb.AppendLine("         /// Excluir o Registro");
            sb.AppendLine("         /// </summary>");
            sb.AppendLine("         public string Excluir(long id)");
            sb.AppendLine("         {");
            sb.AppendLine("             string Mensagem;");
            sb.AppendLine("             try");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = Dados.Excluir(id);");
            sb.AppendLine("             }");
            sb.AppendLine("             catch (Exception ex)");
            sb.AppendLine("             {");
            sb.AppendLine("                 Mensagem = string.Concat(\"Erro: \", ex.Message);");
            sb.AppendLine("             }");
            sb.AppendLine("             return Mensagem;");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("     }");
            sb.AppendLine("}");

            // Salvar no arquivo .cs
            File.WriteAllText(caminhoArquivo, sb.ToString(), Encoding.UTF8);
        }
    }
}

