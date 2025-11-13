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
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Domain\\"), nomeClasse + ".cs");
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

        public static void Repositorio(string bancoDados, string namespaces, string tabela)
        {
            // Configurações
            string nomeDomain = char.ToUpper(tabela[0]) + tabela.Substring(1);
            string caminhoArquivo = Path.Combine(String.Format("{0}\\{1}", Environment.CurrentDirectory, "Repository\\"), nomeDomain + ".cs");

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

    }
}

