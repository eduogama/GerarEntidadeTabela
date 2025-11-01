using Microsoft.Data.SqlClient;

namespace GerarEntidadeTabela
{
    public partial class FrmGerar : Form
    {
        public FrmGerar()
        {
            InitializeComponent();
        }

        private void FrmGerar_Load(object sender, EventArgs e)
        {

        }

        private void BtnCarregarTabelas_Click(object sender, EventArgs e)
        {
            if (TxtBancoDados.Text != "")
            {
                CarregarListView(TxtBancoDados.Text);
                MessageBox.Show("Tabela Carregas com Sucesso");
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
                TxtTabela.Text = LvwTabelas.SelectedItems[0].Text; // Coluna principal

                if (TxtNameSpace.Text != "")
                {
                    Metodos.GerarEntidade(TxtNameSpace.Text, TxtTabela.Text);
                    MessageBox.Show("Classe Gerada com Sucesso");
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
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
                        Metodos.GerarEntidade(TxtNameSpace.Text, item.SubItems[i].Text);
                    }
                }
                MessageBox.Show("Classe Gerada com Sucesso");
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CarregarListView(string bancoDados)
        {
            // String de conexão (ajuste conforme seu servidor e banco)
            string connectionString = String.Format("Data Source=localhost,1450;Initial Catalog={0};Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=Wowsan060", bancoDados);

            using SqlConnection conn = new(connectionString);
            conn.Open();
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME"; // Ajuste a tabela e colunas

            SqlCommand cmd = new(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            // Configura o ListView
            LvwTabelas.View = View.Details;
            LvwTabelas.Columns.Clear();
            LvwTabelas.Columns.Add("TABELA", 200);
            LvwTabelas.Items.Clear();

            // Preenche com os dados do banco
            int id = 1;
            while (reader.Read())
            {
                ListViewItem item = new(reader["TABLE_NAME"].ToString());
                LvwTabelas.Items.Add(item);
                id++;
            }

            reader.Close();
        }
    }
}
