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
            TxtBancoDados.Location = new Point(6, 38);
            TxtBancoDados.Name = "TxtBancoDados";
            TxtBancoDados.Size = new Size(281, 23);
            TxtBancoDados.TabIndex = 0;
            // 
            // TxtNameSpace
            // 
            TxtNameSpace.Location = new Point(6, 80);
            TxtNameSpace.Name = "TxtNameSpace";
            TxtNameSpace.Size = new Size(281, 23);
            TxtNameSpace.TabIndex = 2;
            // 
            // LblNameSpace
            // 
            LblNameSpace.AutoSize = true;
            LblNameSpace.Location = new Point(6, 62);
            LblNameSpace.Name = "LblNameSpace";
            LblNameSpace.Size = new Size(128, 15);
            LblNameSpace.TabIndex = 4;
            LblNameSpace.Text = "Informa o NameSpace:";
            // 
            // BtnExecutar
            // 
            BtnExecutar.BackColor = Color.DodgerBlue;
            BtnExecutar.Location = new Point(149, 127);
            BtnExecutar.Name = "BtnExecutar";
            BtnExecutar.Size = new Size(138, 36);
            BtnExecutar.TabIndex = 4;
            BtnExecutar.Text = "Gerar";
            BtnExecutar.UseVisualStyleBackColor = false;
            BtnExecutar.Click += BtnExecutar_Click;
            // 
            // LvwTabelas
            // 
            LvwTabelas.Location = new Point(12, 13);
            LvwTabelas.Name = "LvwTabelas";
            LvwTabelas.Size = new Size(186, 342);
            LvwTabelas.TabIndex = 9;
            LvwTabelas.UseCompatibleStateImageBehavior = false;
            // 
            // GrpSistema
            // 
            GrpSistema.Controls.Add(TxtSistema);
            GrpSistema.Controls.Add(TxtNameSpace);
            GrpSistema.Controls.Add(LblNameSpace);
            GrpSistema.Controls.Add(BtnExecutar);
            GrpSistema.Location = new Point(209, 144);
            GrpSistema.Name = "GrpSistema";
            GrpSistema.Size = new Size(293, 169);
            GrpSistema.TabIndex = 11;
            GrpSistema.TabStop = false;
            GrpSistema.Text = "Sistema";
            // 
            // TxtSistema
            // 
            TxtSistema.Location = new Point(6, 22);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(281, 23);
            TxtSistema.TabIndex = 6;
            // 
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(358, 319);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(138, 36);
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
            GrpBanco.Location = new Point(209, 22);
            GrpBanco.Name = "GrpBanco";
            GrpBanco.Size = new Size(293, 116);
            GrpBanco.TabIndex = 12;
            GrpBanco.TabStop = false;
            GrpBanco.Text = "Banco de Dados";
            // 
            // BtnCarregarTabelas
            // 
            BtnCarregarTabelas.BackColor = Color.DodgerBlue;
            BtnCarregarTabelas.Location = new Point(149, 74);
            BtnCarregarTabelas.Name = "BtnCarregarTabelas";
            BtnCarregarTabelas.Size = new Size(138, 36);
            BtnCarregarTabelas.TabIndex = 1;
            BtnCarregarTabelas.Text = "Carregar Tabelas";
            BtnCarregarTabelas.UseVisualStyleBackColor = false;
            BtnCarregarTabelas.Click += BtnCarregarTabelas_Click;
            // 
            // LblBanco
            // 
            LblBanco.AutoSize = true;
            LblBanco.Location = new Point(5, 20);
            LblBanco.Name = "LblBanco";
            LblBanco.Size = new Size(147, 15);
            LblBanco.TabIndex = 0;
            LblBanco.Text = "Informe o Banco de Dados";
            // 
            // FrmContext
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 368);
            Controls.Add(LvwTabelas);
            Controls.Add(GrpSistema);
            Controls.Add(BtnSair);
            Controls.Add(GrpBanco);
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