namespace DentAnalyst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.MinBTTN = new System.Windows.Forms.Button();
            this.SizeBTTN = new System.Windows.Forms.Button();
            this.CloseBTTN = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.HomeBTTN = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.agendaControllers1 = new DentAnalyst.View.UserControllers.AgendaControllers();
            this.clientTable1 = new DentAnalyst.View.ClientTable();
            this.cargosController1 = new DentAnalyst.View.UserControllers.CargosController();
            this.funcionariosController1 = new DentAnalyst.View.UserControllers.FuncionariosController();
            this.serviçosController1 = new DentAnalyst.View.UserControllers.ServiçosController();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ServicoBTTN = new System.Windows.Forms.Button();
            this.CargosBTTN = new System.Windows.Forms.Button();
            this.FuncionariosBTTN = new System.Windows.Forms.Button();
            this.ClientesBTTN = new System.Windows.Forms.Button();
            this.Agenda = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.MinBTTN);
            this.panel1.Controls.Add(this.SizeBTTN);
            this.panel1.Controls.Add(this.CloseBTTN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 35);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans Black", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(33, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "TIME";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::DentAnalyst.Properties.Resources.denteazul;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(-28, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(84, 28);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // MinBTTN
            // 
            this.MinBTTN.BackgroundImage = global::DentAnalyst.Properties.Resources.MinimizarButton;
            this.MinBTTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinBTTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinBTTN.FlatAppearance.BorderSize = 0;
            this.MinBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinBTTN.Location = new System.Drawing.Point(1178, 0);
            this.MinBTTN.Name = "MinBTTN";
            this.MinBTTN.Size = new System.Drawing.Size(34, 35);
            this.MinBTTN.TabIndex = 2;
            this.MinBTTN.TabStop = false;
            this.MinBTTN.UseVisualStyleBackColor = true;
            this.MinBTTN.Click += new System.EventHandler(this.MinBTTN_Click);
            // 
            // SizeBTTN
            // 
            this.SizeBTTN.BackgroundImage = global::DentAnalyst.Properties.Resources.Maximizar2;
            this.SizeBTTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SizeBTTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.SizeBTTN.FlatAppearance.BorderSize = 0;
            this.SizeBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SizeBTTN.Location = new System.Drawing.Point(1212, 0);
            this.SizeBTTN.Name = "SizeBTTN";
            this.SizeBTTN.Size = new System.Drawing.Size(34, 35);
            this.SizeBTTN.TabIndex = 1;
            this.SizeBTTN.TabStop = false;
            this.SizeBTTN.UseVisualStyleBackColor = true;
            this.SizeBTTN.Click += new System.EventHandler(this.SizeBTTN_Click);
            // 
            // CloseBTTN
            // 
            this.CloseBTTN.BackgroundImage = global::DentAnalyst.Properties.Resources.CloseButton1;
            this.CloseBTTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBTTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBTTN.FlatAppearance.BorderSize = 0;
            this.CloseBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTTN.Location = new System.Drawing.Point(1246, 0);
            this.CloseBTTN.Name = "CloseBTTN";
            this.CloseBTTN.Size = new System.Drawing.Size(34, 35);
            this.CloseBTTN.TabIndex = 0;
            this.CloseBTTN.TabStop = false;
            this.CloseBTTN.UseVisualStyleBackColor = true;
            this.CloseBTTN.Click += new System.EventHandler(this.CloseBTTN_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.HomeBTTN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 685);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(3, 100);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // HomeBTTN
            // 
            this.HomeBTTN.BackgroundImage = global::DentAnalyst.Properties.Resources.homewhite;
            this.HomeBTTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HomeBTTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeBTTN.FlatAppearance.BorderSize = 0;
            this.HomeBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBTTN.Location = new System.Drawing.Point(0, 0);
            this.HomeBTTN.Name = "HomeBTTN";
            this.HomeBTTN.Size = new System.Drawing.Size(100, 100);
            this.HomeBTTN.TabIndex = 0;
            this.HomeBTTN.UseVisualStyleBackColor = true;
            this.HomeBTTN.Click += new System.EventHandler(this.HomeBTTN_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.agendaControllers1);
            this.panel3.Controls.Add(this.clientTable1);
            this.panel3.Controls.Add(this.cargosController1);
            this.panel3.Controls.Add(this.funcionariosController1);
            this.panel3.Controls.Add(this.serviçosController1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(100, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1180, 685);
            this.panel3.TabIndex = 2;
            // 
            // agendaControllers1
            // 
            this.agendaControllers1.BackColor = System.Drawing.Color.White;
            this.agendaControllers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agendaControllers1.Font = new System.Drawing.Font("Product Sans Black", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agendaControllers1.Location = new System.Drawing.Point(0, 30);
            this.agendaControllers1.Name = "agendaControllers1";
            this.agendaControllers1.Size = new System.Drawing.Size(1180, 655);
            this.agendaControllers1.TabIndex = 5;
            this.agendaControllers1.Load += new System.EventHandler(this.agendaControllers1_Load);
            // 
            // clientTable1
            // 
            this.clientTable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientTable1.Font = new System.Drawing.Font("Product Sans Black", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientTable1.Location = new System.Drawing.Point(0, 30);
            this.clientTable1.Name = "clientTable1";
            this.clientTable1.Size = new System.Drawing.Size(1180, 655);
            this.clientTable1.TabIndex = 4;
            // 
            // cargosController1
            // 
            this.cargosController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cargosController1.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargosController1.Location = new System.Drawing.Point(0, 30);
            this.cargosController1.Margin = new System.Windows.Forms.Padding(4);
            this.cargosController1.Name = "cargosController1";
            this.cargosController1.Size = new System.Drawing.Size(1180, 655);
            this.cargosController1.TabIndex = 3;
            // 
            // funcionariosController1
            // 
            this.funcionariosController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funcionariosController1.Font = new System.Drawing.Font("Product Sans Black", 8.249999F, System.Drawing.FontStyle.Bold);
            this.funcionariosController1.Location = new System.Drawing.Point(0, 30);
            this.funcionariosController1.Name = "funcionariosController1";
            this.funcionariosController1.Size = new System.Drawing.Size(1180, 655);
            this.funcionariosController1.TabIndex = 2;
            // 
            // serviçosController1
            // 
            this.serviçosController1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviçosController1.Font = new System.Drawing.Font("Product Sans Black", 8.249999F, System.Drawing.FontStyle.Bold);
            this.serviçosController1.Location = new System.Drawing.Point(0, 30);
            this.serviçosController1.Name = "serviçosController1";
            this.serviçosController1.Size = new System.Drawing.Size(1180, 655);
            this.serviçosController1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.ServicoBTTN);
            this.panel4.Controls.Add(this.CargosBTTN);
            this.panel4.Controls.Add(this.FuncionariosBTTN);
            this.panel4.Controls.Add(this.ClientesBTTN);
            this.panel4.Controls.Add(this.Agenda);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1180, 30);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 3);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ServicoBTTN
            // 
            this.ServicoBTTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ServicoBTTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.ServicoBTTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ServicoBTTN.FlatAppearance.BorderSize = 0;
            this.ServicoBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServicoBTTN.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServicoBTTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ServicoBTTN.Location = new System.Drawing.Point(640, 0);
            this.ServicoBTTN.Name = "ServicoBTTN";
            this.ServicoBTTN.Size = new System.Drawing.Size(160, 30);
            this.ServicoBTTN.TabIndex = 11;
            this.ServicoBTTN.Text = "SERVIÇOS";
            this.ServicoBTTN.UseVisualStyleBackColor = false;
            this.ServicoBTTN.Click += new System.EventHandler(this.ServicoBTTN_Click);
            // 
            // CargosBTTN
            // 
            this.CargosBTTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.CargosBTTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.CargosBTTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CargosBTTN.FlatAppearance.BorderSize = 0;
            this.CargosBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CargosBTTN.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargosBTTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.CargosBTTN.Location = new System.Drawing.Point(480, 0);
            this.CargosBTTN.Name = "CargosBTTN";
            this.CargosBTTN.Size = new System.Drawing.Size(160, 30);
            this.CargosBTTN.TabIndex = 10;
            this.CargosBTTN.Text = "CARGOS";
            this.CargosBTTN.UseVisualStyleBackColor = false;
            this.CargosBTTN.Click += new System.EventHandler(this.CargosBTTN_Click);
            // 
            // FuncionariosBTTN
            // 
            this.FuncionariosBTTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.FuncionariosBTTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.FuncionariosBTTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FuncionariosBTTN.FlatAppearance.BorderSize = 0;
            this.FuncionariosBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FuncionariosBTTN.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FuncionariosBTTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.FuncionariosBTTN.Location = new System.Drawing.Point(320, 0);
            this.FuncionariosBTTN.Name = "FuncionariosBTTN";
            this.FuncionariosBTTN.Size = new System.Drawing.Size(160, 30);
            this.FuncionariosBTTN.TabIndex = 9;
            this.FuncionariosBTTN.Text = "FUNCIONÁRIOS";
            this.FuncionariosBTTN.UseVisualStyleBackColor = false;
            this.FuncionariosBTTN.Click += new System.EventHandler(this.FuncionariosBTTN_Click);
            // 
            // ClientesBTTN
            // 
            this.ClientesBTTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientesBTTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClientesBTTN.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ClientesBTTN.FlatAppearance.BorderSize = 0;
            this.ClientesBTTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClientesBTTN.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientesBTTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientesBTTN.Location = new System.Drawing.Point(160, 0);
            this.ClientesBTTN.Name = "ClientesBTTN";
            this.ClientesBTTN.Size = new System.Drawing.Size(160, 30);
            this.ClientesBTTN.TabIndex = 4;
            this.ClientesBTTN.Text = "CLIENTES";
            this.ClientesBTTN.UseVisualStyleBackColor = false;
            this.ClientesBTTN.Click += new System.EventHandler(this.ClientesBTTN_Click);
            // 
            // Agenda
            // 
            this.Agenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.Agenda.Dock = System.Windows.Forms.DockStyle.Left;
            this.Agenda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Agenda.FlatAppearance.BorderSize = 0;
            this.Agenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agenda.Font = new System.Drawing.Font("Product Sans Black", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agenda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Agenda.Location = new System.Drawing.Point(0, 0);
            this.Agenda.Name = "Agenda";
            this.Agenda.Size = new System.Drawing.Size(160, 30);
            this.Agenda.TabIndex = 12;
            this.Agenda.Text = "AGENDA";
            this.Agenda.UseVisualStyleBackColor = false;
            this.Agenda.Click += new System.EventHandler(this.Agenda_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Product Sans Black", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CloseBTTN;
        private System.Windows.Forms.Button MinBTTN;
        private System.Windows.Forms.Button SizeBTTN;
        private System.Windows.Forms.Button HomeBTTN;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ServicoBTTN;
        private System.Windows.Forms.Button CargosBTTN;
        private System.Windows.Forms.Button FuncionariosBTTN;
        private System.Windows.Forms.Button ClientesBTTN;
        private View.ClientTable clientTable1;
        private View.UserControllers.CargosController cargosController1;
        private View.UserControllers.FuncionariosController funcionariosController1;
        private View.UserControllers.ServiçosController serviçosController1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private View.UserControllers.AgendaControllers agendaControllers1;
        private System.Windows.Forms.Button Agenda;
    }
}

