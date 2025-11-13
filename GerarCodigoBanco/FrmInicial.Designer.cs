namespace GerarEntidadeTabela
{
    partial class FrmInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicial));
            Menu = new MenuStrip();
            sairToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            domainToolStripMenuItem = new ToolStripMenuItem();
            repositoryToolStripMenuItem = new ToolStripMenuItem();
            servicesToolStripMenuItem = new ToolStripMenuItem();
            contextToolStripMenuItem = new ToolStripMenuItem();
            Menu.SuspendLayout();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.Items.AddRange(new ToolStripItem[] { sairToolStripMenuItem, configurationToolStripMenuItem, domainToolStripMenuItem, repositoryToolStripMenuItem, servicesToolStripMenuItem, contextToolStripMenuItem });
            resources.ApplyResources(Menu, "Menu");
            Menu.Name = "Menu";
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(sairToolStripMenuItem, "sairToolStripMenuItem");
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(configurationToolStripMenuItem, "configurationToolStripMenuItem");
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // domainToolStripMenuItem
            // 
            domainToolStripMenuItem.Name = "domainToolStripMenuItem";
            resources.ApplyResources(domainToolStripMenuItem, "domainToolStripMenuItem");
            domainToolStripMenuItem.Click += domainToolStripMenuItem_Click;
            // 
            // repositoryToolStripMenuItem
            // 
            repositoryToolStripMenuItem.Name = "repositoryToolStripMenuItem";
            resources.ApplyResources(repositoryToolStripMenuItem, "repositoryToolStripMenuItem");
            repositoryToolStripMenuItem.Click += repositoryToolStripMenuItem_Click;
            // 
            // servicesToolStripMenuItem
            // 
            servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            resources.ApplyResources(servicesToolStripMenuItem, "servicesToolStripMenuItem");
            servicesToolStripMenuItem.Click += servicesToolStripMenuItem_Click;
            // 
            // contextToolStripMenuItem
            // 
            contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            resources.ApplyResources(contextToolStripMenuItem, "contextToolStripMenuItem");
            contextToolStripMenuItem.Click += contextToolStripMenuItem_Click;
            // 
            // FrmInicial
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(Menu);
            MainMenuStrip = Menu;
            MaximizeBox = false;
            Name = "FrmInicial";
            Menu.ResumeLayout(false);
            Menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Menu;
        private ToolStripMenuItem domainToolStripMenuItem;
        private ToolStripMenuItem repositoryToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem servicesToolStripMenuItem;
        private ToolStripMenuItem contextToolStripMenuItem;
    }
}