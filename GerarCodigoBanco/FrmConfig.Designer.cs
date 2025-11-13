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
            BtnSair = new Button();
            BtnAtualizar = new Button();
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
            PnlConfig.Controls.Add(BtnSair);
            PnlConfig.Controls.Add(BtnAtualizar);
            PnlConfig.Controls.Add(TxtNamespaceRepositorio);
            PnlConfig.Controls.Add(TxtNamespaceDominio);
            PnlConfig.Controls.Add(TxtBancoDados);
            PnlConfig.Controls.Add(TxtSistema);
            PnlConfig.Controls.Add(LblNamespaceRepositorio);
            PnlConfig.Controls.Add(LblNamespaceDominio);
            PnlConfig.Controls.Add(LblBancoDados);
            PnlConfig.Controls.Add(LblSistema);
            PnlConfig.Location = new Point(12, 12);
            PnlConfig.Name = "PnlConfig";
            PnlConfig.Size = new Size(305, 310);
            PnlConfig.TabIndex = 0;
            // 
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(20, 271);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(138, 36);
            BtnSair.TabIndex = 7;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // BtnAtualizar
            // 
            BtnAtualizar.BackColor = Color.DodgerBlue;
            BtnAtualizar.Location = new Point(164, 271);
            BtnAtualizar.Name = "BtnAtualizar";
            BtnAtualizar.Size = new Size(138, 36);
            BtnAtualizar.TabIndex = 8;
            BtnAtualizar.Text = "Atualizar";
            BtnAtualizar.UseVisualStyleBackColor = false;
            BtnAtualizar.Click += BtnAtualizar_Click;
            // 
            // TxtNamespaceRepositorio
            // 
            TxtNamespaceRepositorio.Location = new Point(3, 215);
            TxtNamespaceRepositorio.Name = "TxtNamespaceRepositorio";
            TxtNamespaceRepositorio.Size = new Size(299, 23);
            TxtNamespaceRepositorio.TabIndex = 7;
            // 
            // TxtNamespaceDominio
            // 
            TxtNamespaceDominio.Location = new Point(3, 157);
            TxtNamespaceDominio.Name = "TxtNamespaceDominio";
            TxtNamespaceDominio.Size = new Size(299, 23);
            TxtNamespaceDominio.TabIndex = 6;
            // 
            // TxtBancoDados
            // 
            TxtBancoDados.Location = new Point(3, 97);
            TxtBancoDados.Name = "TxtBancoDados";
            TxtBancoDados.Size = new Size(299, 23);
            TxtBancoDados.TabIndex = 5;
            // 
            // TxtSistema
            // 
            TxtSistema.Location = new Point(3, 34);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(299, 23);
            TxtSistema.TabIndex = 4;
            // 
            // LblNamespaceRepositorio
            // 
            LblNamespaceRepositorio.AutoSize = true;
            LblNamespaceRepositorio.Location = new Point(3, 197);
            LblNamespaceRepositorio.Name = "LblNamespaceRepositorio";
            LblNamespaceRepositorio.Size = new Size(132, 15);
            LblNamespaceRepositorio.TabIndex = 3;
            LblNamespaceRepositorio.Text = "Namespace Repositorio";
            // 
            // LblNamespaceDominio
            // 
            LblNamespaceDominio.AutoSize = true;
            LblNamespaceDominio.Location = new Point(3, 139);
            LblNamespaceDominio.Name = "LblNamespaceDominio";
            LblNamespaceDominio.Size = new Size(118, 15);
            LblNamespaceDominio.TabIndex = 2;
            LblNamespaceDominio.Text = "Namespace Dominio";
            // 
            // LblBancoDados
            // 
            LblBancoDados.AutoSize = true;
            LblBancoDados.Location = new Point(3, 79);
            LblBancoDados.Name = "LblBancoDados";
            LblBancoDados.Size = new Size(93, 15);
            LblBancoDados.TabIndex = 1;
            LblBancoDados.Text = "Bando de Dados";
            // 
            // LblSistema
            // 
            LblSistema.AutoSize = true;
            LblSistema.Location = new Point(3, 16);
            LblSistema.Name = "LblSistema";
            LblSistema.Size = new Size(48, 15);
            LblSistema.TabIndex = 0;
            LblSistema.Text = "Sistema";
            // 
            // FrmConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 334);
            Controls.Add(PnlConfig);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
    }
}