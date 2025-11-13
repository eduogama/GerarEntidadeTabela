namespace GerarCodigoBanco
{
    partial class FrmServices
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
            GrpSistema = new GroupBox();
            TxtSistema = new TextBox();
            TxtNameSpace = new TextBox();
            BtnTodasTabelas = new Button();
            LblNameSpace = new Label();
            BtnExecutar = new Button();
            LvwTabelas = new ListView();
            GrpBanco = new GroupBox();
            BtnCarregarTabelas = new Button();
            TxtBancoDados = new TextBox();
            LblBanco = new Label();
            BtnSair = new Button();
            GrpSistema.SuspendLayout();
            GrpBanco.SuspendLayout();
            SuspendLayout();
            // 
            // GrpSistema
            // 
            GrpSistema.Controls.Add(TxtSistema);
            GrpSistema.Controls.Add(TxtNameSpace);
            GrpSistema.Controls.Add(BtnTodasTabelas);
            GrpSistema.Controls.Add(LblNameSpace);
            GrpSistema.Controls.Add(BtnExecutar);
            GrpSistema.Location = new Point(212, 138);
            GrpSistema.Name = "GrpSistema";
            GrpSistema.Size = new Size(282, 169);
            GrpSistema.TabIndex = 12;
            GrpSistema.TabStop = false;
            GrpSistema.Text = "Sistema";
            // 
            // TxtSistema
            // 
            TxtSistema.Location = new Point(5, 22);
            TxtSistema.Name = "TxtSistema";
            TxtSistema.Size = new Size(270, 23);
            TxtSistema.TabIndex = 6;
            // 
            // TxtNameSpace
            // 
            TxtNameSpace.Location = new Point(6, 81);
            TxtNameSpace.Name = "TxtNameSpace";
            TxtNameSpace.Size = new Size(270, 23);
            TxtNameSpace.TabIndex = 2;
            // 
            // BtnTodasTabelas
            // 
            BtnTodasTabelas.BackColor = Color.Crimson;
            BtnTodasTabelas.Location = new Point(-4, 123);
            BtnTodasTabelas.Name = "BtnTodasTabelas";
            BtnTodasTabelas.Size = new Size(138, 36);
            BtnTodasTabelas.TabIndex = 5;
            BtnTodasTabelas.Text = "Gerar Todas";
            BtnTodasTabelas.UseVisualStyleBackColor = false;
            BtnTodasTabelas.Click += BtnTodasTabelas_Click;
            // 
            // LblNameSpace
            // 
            LblNameSpace.AutoSize = true;
            LblNameSpace.Location = new Point(6, 63);
            LblNameSpace.Name = "LblNameSpace";
            LblNameSpace.Size = new Size(128, 15);
            LblNameSpace.TabIndex = 4;
            LblNameSpace.Text = "Informa o NameSpace:";
            // 
            // BtnExecutar
            // 
            BtnExecutar.BackColor = Color.DodgerBlue;
            BtnExecutar.Location = new Point(138, 123);
            BtnExecutar.Name = "BtnExecutar";
            BtnExecutar.Size = new Size(138, 36);
            BtnExecutar.TabIndex = 4;
            BtnExecutar.Text = "Gerar Selecionada";
            BtnExecutar.UseVisualStyleBackColor = false;
            BtnExecutar.Click += BtnExecutar_Click;
            // 
            // LvwTabelas
            // 
            LvwTabelas.Location = new Point(20, 13);
            LvwTabelas.Name = "LvwTabelas";
            LvwTabelas.Size = new Size(186, 342);
            LvwTabelas.TabIndex = 11;
            LvwTabelas.UseCompatibleStateImageBehavior = false;
            // 
            // GrpBanco
            // 
            GrpBanco.Controls.Add(BtnCarregarTabelas);
            GrpBanco.Controls.Add(TxtBancoDados);
            GrpBanco.Controls.Add(LblBanco);
            GrpBanco.Location = new Point(212, 16);
            GrpBanco.Name = "GrpBanco";
            GrpBanco.Size = new Size(282, 116);
            GrpBanco.TabIndex = 13;
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
            // BtnSair
            // 
            BtnSair.BackColor = Color.DodgerBlue;
            BtnSair.Location = new Point(356, 319);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(138, 36);
            BtnSair.TabIndex = 14;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // FrmServices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 368);
            Controls.Add(GrpSistema);
            Controls.Add(LvwTabelas);
            Controls.Add(GrpBanco);
            Controls.Add(BtnSair);
            MaximizeBox = false;
            Name = "FrmServices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Services";
            Load += FrmServices_Load;
            GrpSistema.ResumeLayout(false);
            GrpSistema.PerformLayout();
            GrpBanco.ResumeLayout(false);
            GrpBanco.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GrpSistema;
        private TextBox TxtSistema;
        private TextBox TxtNameSpace;
        private Button BtnTodasTabelas;
        private Label LblNameSpace;
        private Button BtnExecutar;
        private ListView LvwTabelas;
        private GroupBox GrpBanco;
        private Button BtnCarregarTabelas;
        private TextBox TxtBancoDados;
        private Label LblBanco;
        private Button BtnSair;
    }
}