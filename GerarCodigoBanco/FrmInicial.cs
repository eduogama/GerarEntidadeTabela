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
            FrmDomain frmGerar = new();
            frmGerar.ShowDialog();
        }

        private void repositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRepo frmRepo = new();
            frmRepo.ShowDialog();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new();
            frmConfig.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
