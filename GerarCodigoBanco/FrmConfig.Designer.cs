namespace GerarCodigoBanco
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            PnlConfig = new Panel();
            TxtNamespaceService = new TextBox();
            BtnAtualizar = new Button();
            LblService = new Label();
            BtnSair = new Button();
            TxtNamespaceRepositorio = new TextBox();
            TxtNamespaceDominio = new TextBox();
            TxtBancoDados = new TextBox();
            TxtSistema = new TextBox();
            LblNamespaceRepositorio = new Label();
            LblNamespaceDominio = new Label();
            LblBancoDados = new Label();
            LblSistema = new Label();
            PnlConfig.SuspendLayout();
            SuspendLayout();
            // 
            // PnlConfig
            // 
            PnlConfig.Controls.Add(TxtNamespaceService);
            PnlConfig.Controls.Add(BtnAtualizar);
            PnlConfig.Controls.Add(LblService);
            PnlConfig.Controls.Add(BtnSair);
            PnlConfig.Controls.Add(TxtNamespaceRepositorio);
            PnlConfig.Controls.Add(TxtNamespaceDominio);
            PnlConfig.Controls.Add(TxtBancoDados);
            PnlConfig.Controls.Add(TxtSistema);
            PnlConfig.Controls.Add(LblNamespaceRepositorio);
            PnlConfig.Controls.Add(LblNamespaceDominio);
            PnlConfig.Controls.Add(LblBancoDados);
            PnlConfig.Controls.Add(LblSistema);
            PnlConfig.Location = new Point(15, 17);
            PnlConfig.Margin = new Padding(4, 4, 4, 4);
            PnlConfig.Name = "PnlConfig";
            PnlConfig.Size = new Size(392, 489);
            PnlConfig.TabIndex = 0;
            // 
            // TxtNamespaceService
            // 
            TxtNamespaceService.Location = new Point(4, 379);
            TxtNamespaceService.Margin = new Padding(4, 4, 4, 4);
            TxtNamespaceService.Name = "TxtNamespaceService";
            TxtNamespaceService.Size = new Size(383, 29);
            TxtNamespaceService.TabIndex = 10;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.BackColor = Color.DodgerBlue;
            BtnAtualizar.Location = new Point(207, 434);
            BtnAtualizar.Margin = new Padding(4, 4, 4, 4);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(177, 50);
            BtnAtualizar.TabIndex = 8;
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.UseVisualStyleBackColor = false;
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // LblService
            // 
            LblService.AutoSize = true;
            LblService.Location = new Point(0, 354);
            LblService.Margin = new Padding(4, 0, 4, 0);
            LblService.Name = "LblService";
            LblService.Size = new Size(145, 21);
            LblService.TabIndex = 9;
            LblService.Text = "Namespace Service";
            // 
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(22, 434);
            BtnSair.Margin = new Padding(4, 4, 4, 4);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(177, 50);
            BtnSair.TabIndex = 7;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // TxtNamespaceRepositorio
            // 
            TxtNamespaceRepositorio.Location = new Point(4, 301);
            TxtNamespaceRepositorio.Margin = new Padding(4, 4, 4, 4);
            TxtNamespaceRepositorio.Name = "TxtNamespaceRepositorio";
            TxtNamespaceRepositorio.Size = new Size(383, 29);
            TxtNamespaceRepositorio.TabIndex = 7;
            // 
            // TxtNamespaceDominio
            // 
            TxtNamespaceDominio.Location = new Point(4, 220);
            TxtNamespaceDominio.Margin = new Padding(4, 4, 4, 4);
            TxtNamespaceDominio.Name = "TxtNamespaceDominio";
            TxtNamespaceDominio.Size = new Size(383, 29);
            TxtNamespaceDominio.TabIndex = 6;
            // 
            // TxtBancoDados
            // 
            TxtBancoDados.Location = new Point(4, 136);
            TxtBancoDados.Margin = new Padding(4, 4, 4, 4);
            TxtBancoDados.Name = "TxtBancoDados";
            TxtBancoDados.Size = new Size(383, 29);
            TxtBancoDados.TabIndex = 5;
            // 
            // TxtSistema
            // 
            TxtSistema.Location = new Point(4, 48);
            TxtSistema.Margin = new Padding(4, 4, 4, 4);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(383, 29);
            TxtSistema.TabIndex = 4;
            // 
            // LblNamespaceRepositorio
            // 
            LblNamespaceRepositorio.AutoSize = true;
            LblNamespaceRepositorio.Location = new Point(4, 276);
            LblNamespaceRepositorio.Margin = new Padding(4, 0, 4, 0);
            LblNamespaceRepositorio.Name = "LblNamespaceRepositorio";
            LblNamespaceRepositorio.Size = new Size(175, 21);
            LblNamespaceRepositorio.TabIndex = 3;
            LblNamespaceRepositorio.Text = "Namespace Repositorio";
            // 
            // LblNamespaceDominio
            // 
            LblNamespaceDominio.AutoSize = true;
            LblNamespaceDominio.Location = new Point(4, 195);
            LblNamespaceDominio.Margin = new Padding(4, 0, 4, 0);
            LblNamespaceDominio.Name = "LblNamespaceDominio";
            LblNamespaceDominio.Size = new Size(155, 21);
            LblNamespaceDominio.TabIndex = 2;
            LblNamespaceDominio.Text = "Namespace Dominio";
            // 
            // LblBancoDados
            // 
            LblBancoDados.AutoSize = true;
            LblBancoDados.Location = new Point(4, 111);
            LblBancoDados.Margin = new Padding(4, 0, 4, 0);
            LblBancoDados.Name = "LblBancoDados";
            LblBancoDados.Size = new Size(123, 21);
            LblBancoDados.TabIndex = 1;
            LblBancoDados.Text = "Bando de Dados";
            // 
            // LblSistema
            // 
            LblSistema.AutoSize = true;
            LblSistema.Location = new Point(4, 22);
            LblSistema.Margin = new Padding(4, 0, 4, 0);
            LblSistema.Name = "LblSistema";
            LblSistema.Size = new Size(65, 21);
            LblSistema.TabIndex = 0;
            LblSistema.Text = "Sistema";
            // 
            // FrmConfig
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 522);
            Controls.Add(PnlConfig);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "FrmConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuração";
            Load += FrmConfig_Load;
            PnlConfig.ResumeLayout(false);
            PnlConfig.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlConfig;
        private Label LblNamespaceRepositorio;
        private Label LblNamespaceDominio;
        private Label LblBancoDados;
        private Label LblSistema;
        private TextBox TxtNamespaceRepositorio;
        private TextBox TxtNamespaceDominio;
        private TextBox TxtBancoDados;
        private TextBox TxtSistema;
        private Button BtnAtualizar;
        private Button BtnSair;
        private TextBox TxtNamespaceService;
        private Label LblService;
    }
}