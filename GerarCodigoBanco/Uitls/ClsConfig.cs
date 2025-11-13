using GerarCodigoBanco.Entidade;
using System.Text.Json;

namespace GerarCodigoBanco.Uitls
{
    public class ClsConfig
    {
        public static Config Obter()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string PathFile = string.Concat(path, "config.json");
            string json = File.ReadAllText(PathFile);

            List<Config> configs = JsonSerializer.Deserialize<List<Config>>(json);

            Config config = configs.FirstOrDefault() ?? throw new Exception("Sistema não encontrado.");

            return config;
        }

        public static string Gravar(List<Config> configs)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string PathFile = string.Concat(path, "config.json");

                string novoJson = JsonSerializer.Serialize(configs, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathFile, novoJson);

                return "Config Atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
    }
}
