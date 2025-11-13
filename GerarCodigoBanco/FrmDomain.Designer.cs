namespace GerarEntidadeTabela
{
    partial class FrmDomain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnExecutar = new Button();
            LblNameSpace = new Label();
            TxtNameSpace = new TextBox();
            LvwTabelas = new ListView();
            BtnTodasTabelas = new Button();
            BtnSair = new Button();
            GrpSistema = new GroupBox();
            GrpBanco = new GroupBox();
            BtnCarregarTabelas = new Button();
            TxtBancoDados = new TextBox();
            LblBanco = new Label();
            TxtSistema = new TextBox();
            GrpSistema.SuspendLayout();
            GrpBanco.SuspendLayout();
            SuspendLayout();
            // 
            // BtnExecutar
            // 
            BtnExecutar.BackColor = Color.DodgerBlue;
            BtnExecutar.Location = new Point(144, 127);
            BtnExecutar.Name = "BtnExecutar";
            BtnExecutar.Size = new Size(138, 36);
            BtnExecutar.TabIndex = 4;
            BtnExecutar.Text = "Gerar Selecionada";
            BtnExecutar.UseVisualStyleBackColor = false;
            BtnExecutar.Click += BtnExecutar_Click;
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
            // TxtNameSpace
            // 
            TxtNameSpace.Location = new Point(6, 80);
            TxtNameSpace.Name = "TxtNameSpace";
            TxtNameSpace.Size = new Size(270, 23);
            TxtNameSpace.TabIndex = 2;
            // 
            // LvwTabelas
            // 
            LvwTabelas.Location = new Point(12, 12);
            LvwTabelas.Name = "LvwTabelas";
            LvwTabelas.Size = new Size(186, 342);
            LvwTabelas.TabIndex = 5;
            LvwTabelas.UseCompatibleStateImageBehavior = false;
            // 
            // BtnTodasTabelas
            // 
            BtnTodasTabelas.BackColor = Color.Crimson;
            BtnTodasTabelas.Location = new Point(6, 127);
            BtnTodasTabelas.Name = "BtnTodasTabelas";
            BtnTodasTabelas.Size = new Size(138, 36);
            BtnTodasTabelas.TabIndex = 5;
            BtnTodasTabelas.Text = "Gerar Todas";
            BtnTodasTabelas.UseVisualStyleBackColor = false;
            BtnTodasTabelas.Click += BtnTodasTabelas_Click;
            // 
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(353, 318);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(138, 36);
            BtnSair.TabIndex = 6;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // GrpSistema
            // 
            GrpSistema.Controls.Add(TxtSistema);
            GrpSistema.Controls.Add(TxtNameSpace);
            GrpSistema.Controls.Add(BtnTodasTabelas);
            GrpSistema.Controls.Add(LblNameSpace);
            GrpSistema.Controls.Add(BtnExecutar);
            GrpSistema.Location = new Point(209, 143);
            GrpSistema.Name = "GrpSistema";
            GrpSistema.Size = new Size(282, 169);
            GrpSistema.TabIndex = 7;
            GrpSistema.TabStop = false;
            GrpSistema.Text = "Sistema";
            // 
            // GrpBanco
            // 
            GrpBanco.Controls.Add(BtnCarregarTabelas);
            GrpBanco.Controls.Add(TxtBancoDados);
            GrpBanco.Controls.Add(LblBanco);
            GrpBanco.Location = new Point(209, 21);
            GrpBanco.Name = "GrpBanco";
            GrpBanco.Size = new Size(282, 116);
            GrpBanco.TabIndex = 8;
            GrpBanco.TabStop = false;
            GrpBanco.Text = "Banco de Dados";
            // 
            // BtnCarregarTabelas
            // 
            BtnCarregarTabelas.BackColor = Color.DodgerBlue;
            BtnCarregarTabelas.Location = new Point(138, 74);
            BtnCarregarTabelas.Name = "BtnCarregarTabelas";
            BtnCarregarTabelas.Size = new Size(138, 36);
            BtnCarregarTabelas.TabIndex = 1;
            BtnCarregarTabelas.Text = "Carregar Tabelas";
            BtnCarregarTabelas.UseVisualStyleBackColor = false;
            BtnCarregarTabelas.Click += BtnCarregarTabelas_Click;
            // 
            // TxtBancoDados
            // 
            TxtBancoDados.Location = new Point(6, 38);
            TxtBancoDados.Name = "TxtBancoDados";
            TxtBancoDados.Size = new Size(270, 23);
            TxtBancoDados.TabIndex = 0;
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
            // TxtSistema
            // 
            TxtSistema.Location = new Point(6, 22);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(270, 23);
            TxtSistema.TabIndex = 6;
            // 
            // FrmDomain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 366);
            Controls.Add(GrpBanco);
            Controls.Add(GrpSistema);
            Controls.Add(BtnSair);
            Controls.Add(LvwTabelas);
            MaximizeBox = false;
            Name = "FrmDomain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerar Entidade";
            Load += FrmGerar_Load;
            GrpSistema.ResumeLayout(false);
            GrpSistema.PerformLayout();
            GrpBanco.ResumeLayout(false);
            GrpBanco.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnExecutar;
        private Label LblNameSpace;
        private TextBox TxtNameSpace;
        private ListView LvwTabelas;
        private Button BtnTodasTabelas;
        private Button BtnSair;
        private GroupBox GrpSistema;
        private GroupBox GrpBanco;
        private TextBox TxtBancoDados;
        private Label LblBanco;
        private Button BtnCarregarTabelas;
        private TextBox TxtSistema;
    }
}
