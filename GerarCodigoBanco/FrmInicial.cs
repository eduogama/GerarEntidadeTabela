using GerarCodigoBanco;

namespace GerarEntidadeTabela
{
    public partial class FrmInicial : Form
    {
        public FrmInicial()
        {
            InitializeComponent();
        }

        private void domainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDomain form = new();
            form.ShowDialog();
        }

        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRepo form = new();
            form.ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig form = new();
            form.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmContext form = new();
            form.ShowDialog();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServices form = new();
            form.ShowDialog();
        }
    }
}
