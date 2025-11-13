using GerarCodigoBanco.Entidade;
using GerarCodigoBanco.Uitls;
using System.Text.Json;

namespace GerarCodigoBanco
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            Config config = ClsConfig.Obter();
            config.BancoDados = TxtBancoDados.Text;
            config.NamespaceDominio = TxtNamespaceDominio.Text;
            config.NamespaceRepositorio = TxtNamespaceRepositorio.Text;
            config.Sistema = TxtSistema.Text;

            List<Config> configs = new List<Config>();
            configs.Add(config);
            string resultado = ClsConfig.Gravar(configs);
            MessageBox.Show(resultado, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CarregarDados();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarDados()
        {
            Config config = ClsConfig.Obter();
            TxtBancoDados.Text = config.BancoDados;
            TxtNamespaceDominio.Text = config.NamespaceDominio;
            TxtNamespaceRepositorio.Text = config.NamespaceRepositorio;
            TxtSistema.Text = config.Sistema;
        }
    }
}
