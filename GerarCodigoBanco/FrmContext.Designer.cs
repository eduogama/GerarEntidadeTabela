namespace GerarCodigoBanco
{
    partial class FrmContext
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContext));
            TxtBancoDados = new TextBox();
            TxtNameSpace = new TextBox();
            LblNameSpace = new Label();
            BtnExecutar = new Button();
            LvwTabelas = new ListView();
            GrpSistema = new GroupBox();
            TxtSistema = new TextBox();
            BtnSair = new Button();
            GrpBanco = new GroupBox();
            BtnCarregarTabelas = new Button();
            LblBanco = new Label();
            GrpSistema.SuspendLayout();
            GrpBanco.SuspendLayout();
            SuspendLayout();
            // 
            // TxtBancoDados
            // 
            TxtBancoDados.Location = new Point(8, 53);
            TxtBancoDados.Margin = new Padding(4, 4, 4, 4);
            TxtBancoDados.Name = "TxtBancoDados";
            TxtBancoDados.Size = new Size(360, 29);
            TxtBancoDados.TabIndex = 0;
            // 
            // TxtNameSpace
            // 
            TxtNameSpace.Location = new Point(8, 112);
            TxtNameSpace.Margin = new Padding(4, 4, 4, 4);
            TxtNameSpace.Name = "TxtNameSpace";
            TxtNameSpace.Size = new Size(360, 29);
            TxtNameSpace.TabIndex = 2;
            // 
            // LblNameSpace
            // 
            LblNameSpace.AutoSize = true;
            LblNameSpace.Location = new Point(8, 87);
            LblNameSpace.Margin = new Padding(4, 0, 4, 0);
            LblNameSpace.Name = "LblNameSpace";
            LblNameSpace.Size = new Size(168, 21);
            LblNameSpace.TabIndex = 4;
            LblNameSpace.Text = "Informa o NameSpace:";
            // 
            // BtnExecutar
            // 
            BtnExecutar.BackColor = Color.DodgerBlue;
            BtnExecutar.Location = new Point(192, 178);
            BtnExecutar.Margin = new Padding(4, 4, 4, 4);
            BtnExecutar.Name = "BtnExecutar";
            BtnExecutar.Size = new Size(177, 50);
            BtnExecutar.TabIndex = 4;
            BtnExecutar.Text = "Gerar";
            BtnExecutar.UseVisualStyleBackColor = false;
            BtnExecutar.Click += BtnExecutar_Click;
            // 
            // LvwTabelas
            // 
            LvwTabelas.Location = new Point(15, 18);
            LvwTabelas.Margin = new Padding(4, 4, 4, 4);
            LvwTabelas.Name = "LvwTabelas";
            LvwTabelas.Size = new Size(238, 477);
            LvwTabelas.TabIndex = 9;
            LvwTabelas.UseCompatibleStateImageBehavior = false;
            // 
            // GrpSistema
            // 
            GrpSistema.Controls.Add(TxtSistema);
            GrpSistema.Controls.Add(TxtNameSpace);
            GrpSistema.Controls.Add(LblNameSpace);
            GrpSistema.Controls.Add(BtnExecutar);
            GrpSistema.Location = new Point(269, 202);
            GrpSistema.Margin = new Padding(4, 4, 4, 4);
            GrpSistema.Name = "GrpSistema";
            GrpSistema.Padding = new Padding(4, 4, 4, 4);
            GrpSistema.Size = new Size(377, 237);
            GrpSistema.TabIndex = 11;
            GrpSistema.TabStop = false;
            GrpSistema.Text = "Sistema";
            // 
            // TxtSistema
            // 
            TxtSistema.Location = new Point(8, 31);
            TxtSistema.Margin = new Padding(4, 4, 4, 4);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(360, 29);
            TxtSistema.TabIndex = 6;
            // 
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(460, 447);
            BtnSair.Margin = new Padding(4, 4, 4, 4);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(177, 50);
            BtnSair.TabIndex = 10;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // GrpBanco
            // 
            GrpBanco.Controls.Add(BtnCarregarTabelas);
            GrpBanco.Controls.Add(TxtBancoDados);
            GrpBanco.Controls.Add(LblBanco);
            GrpBanco.Location = new Point(269, 31);
            GrpBanco.Margin = new Padding(4, 4, 4, 4);
            GrpBanco.Name = "GrpBanco";
            GrpBanco.Padding = new Padding(4, 4, 4, 4);
            GrpBanco.Size = new Size(377, 162);
            GrpBanco.TabIndex = 12;
            GrpBanco.TabStop = false;
            GrpBanco.Text = "Banco de Dados";
            // 
            // BtnCarregarTabelas
            // 
            BtnCarregarTabelas.BackColor = Color.DodgerBlue;
            BtnCarregarTabelas.Location = new Point(192, 104);
            BtnCarregarTabelas.Margin = new Padding(4, 4, 4, 4);
            BtnCarregarTabelas.Name = "BtnCarregarTabelas";
            BtnCarregarTabelas.Size = new Size(177, 50);
            BtnCarregarTabelas.TabIndex = 1;
            BtnCarregarTabelas.Text = "Carregar Tabelas";
            BtnCarregarTabelas.UseVisualStyleBackColor = false;
            BtnCarregarTabelas.Click += BtnCarregarTabelas_Click;
            // 
            // LblBanco
            // 
            LblBanco.AutoSize = true;
            LblBanco.Location = new Point(6, 28);
            LblBanco.Margin = new Padding(4, 0, 4, 0);
            LblBanco.Name = "LblBanco";
            LblBanco.Size = new Size(193, 21);
            LblBanco.TabIndex = 0;
            LblBanco.Text = "Informe o Banco de Dados";
            // 
            // FrmContext
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 515);
            Controls.Add(LvwTabelas);
            Controls.Add(GrpSistema);
            Controls.Add(BtnSair);
            Controls.Add(GrpBanco);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "FrmContext";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DbContext";
            Load += FrmContext_Load;
            GrpSistema.ResumeLayout(false);
            GrpSistema.PerformLayout();
            GrpBanco.ResumeLayout(false);
            GrpBanco.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtBancoDados;
        private TextBox TxtNameSpace;
        private Label LblNameSpace;
        private Button BtnExecutar;
        private ListView LvwTabelas;
        private GroupBox GrpSistema;
        private TextBox TxtSistema;
        private Button BtnSair;
        private GroupBox GrpBanco;
        private Button BtnCarregarTabelas;
        private Label LblBanco;
    }
}