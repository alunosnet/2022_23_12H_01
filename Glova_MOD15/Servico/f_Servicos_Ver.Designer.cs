namespace Glova_MOD15.Servico
{
    partial class f_Servicos_Ver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Servicos_Ver));
            this.dgvServicos = new System.Windows.Forms.DataGridView();
            this.btnPedClie = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnVerRealizados = new System.Windows.Forms.Button();
            this.lblClie = new System.Windows.Forms.Label();
            this.lblPrest = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvServicos
            // 
            this.dgvServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicos.Location = new System.Drawing.Point(-1, 0);
            this.dgvServicos.Name = "dgvServicos";
            this.dgvServicos.Size = new System.Drawing.Size(554, 208);
            this.dgvServicos.TabIndex = 0;
            this.dgvServicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicos_CellClick);
            // 
            // btnPedClie
            // 
            this.btnPedClie.Location = new System.Drawing.Point(196, 214);
            this.btnPedClie.Name = "btnPedClie";
            this.btnPedClie.Size = new System.Drawing.Size(101, 45);
            this.btnPedClie.TabIndex = 45;
            this.btnPedClie.Text = "Ver nº de pedidos por cliente";
            this.btnPedClie.UseVisualStyleBackColor = true;
            this.btnPedClie.Click += new System.EventHandler(this.btnPedClie_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(559, 236);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 47;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnTodos
            // 
            this.btnTodos.Location = new System.Drawing.Point(12, 214);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(70, 45);
            this.btnTodos.TabIndex = 48;
            this.btnTodos.Text = "Ver Pedidos";
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.Location = new System.Drawing.Point(559, 12);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 36);
            this.btnFinalizar.TabIndex = 49;
            this.btnFinalizar.Text = "Serviço Finalizado";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(-1, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.dateTimePicker1.TabIndex = 57;
            this.dateTimePicker1.Visible = false;
            // 
            // btnVerRealizados
            // 
            this.btnVerRealizados.Location = new System.Drawing.Point(88, 214);
            this.btnVerRealizados.Name = "btnVerRealizados";
            this.btnVerRealizados.Size = new System.Drawing.Size(81, 45);
            this.btnVerRealizados.TabIndex = 58;
            this.btnVerRealizados.Text = "Ver pedidos já realizados ";
            this.btnVerRealizados.UseVisualStyleBackColor = true;
            this.btnVerRealizados.Click += new System.EventHandler(this.btnVerRealizados_Click);
            // 
            // lblClie
            // 
            this.lblClie.AutoSize = true;
            this.lblClie.Location = new System.Drawing.Point(9, 61);
            this.lblClie.Name = "lblClie";
            this.lblClie.Size = new System.Drawing.Size(35, 13);
            this.lblClie.TabIndex = 59;
            this.lblClie.Text = "label1";
            this.lblClie.Visible = false;
            // 
            // lblPrest
            // 
            this.lblPrest.AutoSize = true;
            this.lblPrest.Location = new System.Drawing.Point(9, 87);
            this.lblPrest.Name = "lblPrest";
            this.lblPrest.Size = new System.Drawing.Size(35, 13);
            this.lblPrest.TabIndex = 60;
            this.lblPrest.Text = "label2";
            this.lblPrest.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(9, 109);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(35, 13);
            this.lblTipo.TabIndex = 61;
            this.lblTipo.Text = "label3";
            this.lblTipo.Visible = false;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(9, 133);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(35, 13);
            this.lblPreco.TabIndex = 62;
            this.lblPreco.Text = "label4";
            this.lblPreco.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 63;
            this.button1.Text = "Ver nº de pedidos realizados por Prestador";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_Servicos_Ver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblPrest);
            this.Controls.Add(this.lblClie);
            this.Controls.Add(this.btnVerRealizados);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnPedClie);
            this.Controls.Add(this.dgvServicos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f_Servicos_Ver";
            this.Text = "Serviços";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.f_Servicos_Ver_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServicos;
        private System.Windows.Forms.Button btnPedClie;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnVerRealizados;
        private System.Windows.Forms.Label lblClie;
        private System.Windows.Forms.Label lblPrest;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Button button1;
    }
}