namespace Glova_MOD15
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnServico = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtEmailPesq = new System.Windows.Forms.TextBox();
            this.dgvEmailPesq = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.verServiçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailPesq)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnServico
            // 
            this.btnServico.Location = new System.Drawing.Point(123, 59);
            this.btnServico.Name = "btnServico";
            this.btnServico.Size = new System.Drawing.Size(126, 43);
            this.btnServico.TabIndex = 2;
            this.btnServico.Text = "Fazer Pedido";
            this.btnServico.UseVisualStyleBackColor = true;
            this.btnServico.Click += new System.EventHandler(this.btnServico_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(137, 198);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(97, 27);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtEmailPesq
            // 
            this.txtEmailPesq.Location = new System.Drawing.Point(27, 33);
            this.txtEmailPesq.Name = "txtEmailPesq";
            this.txtEmailPesq.Size = new System.Drawing.Size(346, 20);
            this.txtEmailPesq.TabIndex = 5;
            this.txtEmailPesq.Text = "Email";
            this.txtEmailPesq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmailPesq_MouseClick);
            // 
            // dgvEmailPesq
            // 
            this.dgvEmailPesq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmailPesq.Location = new System.Drawing.Point(0, 27);
            this.dgvEmailPesq.Name = "dgvEmailPesq";
            this.dgvEmailPesq.Size = new System.Drawing.Size(390, 234);
            this.dgvEmailPesq.TabIndex = 6;
            this.dgvEmailPesq.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verServiçosToolStripMenuItem,
            this.novoAdminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(391, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // verServiçosToolStripMenuItem
            // 
            this.verServiçosToolStripMenuItem.Name = "verServiçosToolStripMenuItem";
            this.verServiçosToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.verServiçosToolStripMenuItem.Text = "Ver Serviços";
            this.verServiçosToolStripMenuItem.Click += new System.EventHandler(this.verServiçosToolStripMenuItem_Click);
            // 
            // novoAdminToolStripMenuItem
            // 
            this.novoAdminToolStripMenuItem.Name = "novoAdminToolStripMenuItem";
            this.novoAdminToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.novoAdminToolStripMenuItem.Text = "Novo Prestador";
            this.novoAdminToolStripMenuItem.Click += new System.EventHandler(this.novoAdminToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 228);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(391, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton1.Text = "Criar Cliente";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 253);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtEmailPesq);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnServico);
            this.Controls.Add(this.dgvEmailPesq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Glova";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmailPesq)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnServico;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgvEmailPesq;
        public System.Windows.Forms.TextBox txtEmailPesq;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem verServiçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

