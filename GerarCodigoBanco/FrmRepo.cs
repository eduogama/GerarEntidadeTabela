using GerarCodigoBanco.Entidade;
using GerarCodigoBanco.Repository;
using GerarCodigoBanco.Uitls;

namespace GerarEntidadeTabela
{
    public partial class FrmRepo : Form
    {
        public FrmRepo()
        {
            InitializeComponent();
        }

        private void FrmRepo_Load(object sender, EventArgs e)
        {
            Config config = ClsConfig.Obter();
            TxtBancoDados.Text = config.BancoDados;
            TxtSistema.Text = config.Sistema;
            TxtNameSpace.Text = String.Format("{0}.{1}", config.Sistema, config.NamespaceRepositorio);
        }

        private void BtnCarregarTabelas_Click(object sender, EventArgs e)
        {
            if (TxtBancoDados.Text != "")
            {

                if (TxtBancoDados.Text != "")
                {
                    List<Tabelas> tabelas = ClsBanco.ObterTabelas(TxtBancoDados.Text);
                    CarregarListView(tabelas);
                    MessageBox.Show("Tabela Carregas com Sucesso");
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void CarregarListView(List<Tabelas> tabelas)
        {
            // Configura o ListView
            LvwTabelas.View = View.Details;
            LvwTabelas.Columns.Clear();
            LvwTabelas.Columns.Add("TABELA", 200);
            LvwTabelas.Items.Clear();
            // Preenche com os dados do banco
            int id = 1;
            foreach (var tabela in tabelas)
            {
                ListViewItem item = new(tabela.TABLE_NAME);
                LvwTabelas.Items.Add(item);
                id++;
            }
        }

        private void BtnTodasTabelas_Click(object sender, EventArgs e)
        {
            if (TxtNameSpace.Text != "")
            {
                foreach (ListViewItem item in LvwTabelas.Items)
                {
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        ClsGerar.Repositorio(TxtBancoDados.Text, TxtNameSpace.Text, item.SubItems[i].Text);
                    }
                }
                MessageBox.Show("Classe Gerada com Sucesso");
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void BtnExecutar_Click(object sender, EventArgs e)
        {
            if (LvwTabelas.SelectedItems.Count > 0)
            {
                if (TxtNameSpace.Text != "")
                {
                    ClsGerar.Repositorio(TxtBancoDados.Text, TxtNameSpace.Text, LvwTabelas.SelectedItems[0].Text);
                    MessageBox.Show("Classe Gerada com Sucesso");
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
