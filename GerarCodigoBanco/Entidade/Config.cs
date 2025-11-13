using System.Text.Json.Serialization;

namespace GerarCodigoBanco.Entidade
{
    public class Config
    {
        [JsonPropertyName("sistema")]
        public string Sistema { get; set; }

        [JsonPropertyName("bancoDados")]
        public string BancoDados { get; set; }

        [JsonPropertyName("namespaceDominio")]
        public string NamespaceDominio { get; set; }

        [JsonPropertyName("namespaceRepositorio")]
        public string NamespaceRepositorio { get; set; }
    }
}
