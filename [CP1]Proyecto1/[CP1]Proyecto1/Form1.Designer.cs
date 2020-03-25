namespace _CP1_Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPestañaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarThomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarTokensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorLéxicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.next1 = new System.Windows.Forms.Button();
            this.prev1 = new System.Windows.Forms.Button();
            this.prev2 = new System.Windows.Forms.Button();
            this.next2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.prev3 = new System.Windows.Forms.Button();
            this.next3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1094, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.nuevaPestañaToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.AbrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.GuardarToolStripMenuItem_Click);
            // 
            // nuevaPestañaToolStripMenuItem
            // 
            this.nuevaPestañaToolStripMenuItem.Name = "nuevaPestañaToolStripMenuItem";
            this.nuevaPestañaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.nuevaPestañaToolStripMenuItem.Text = "Nueva pestaña";
            this.nuevaPestañaToolStripMenuItem.Click += new System.EventHandler(this.NuevaPestañaToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarThomToolStripMenuItem,
            this.cargarTokensToolStripMenuItem,
            this.guardarErroresToolStripMenuItem});
            this.herramientasToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // cargarThomToolStripMenuItem
            // 
            this.cargarThomToolStripMenuItem.Name = "cargarThomToolStripMenuItem";
            this.cargarThomToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cargarThomToolStripMenuItem.Text = "Cargar Thompson";
            this.cargarThomToolStripMenuItem.Click += new System.EventHandler(this.CargarThomToolStripMenuItem_Click);
            // 
            // cargarTokensToolStripMenuItem
            // 
            this.cargarTokensToolStripMenuItem.Name = "cargarTokensToolStripMenuItem";
            this.cargarTokensToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cargarTokensToolStripMenuItem.Text = "Cargar tokens";
            this.cargarTokensToolStripMenuItem.Click += new System.EventHandler(this.CargarTokensToolStripMenuItem_Click);
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.guardarErroresToolStripMenuItem.Text = "Guardar errores";
            this.guardarErroresToolStripMenuItem.Click += new System.EventHandler(this.GuardarErroresToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorLéxicoToolStripMenuItem});
            this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // errorLéxicoToolStripMenuItem
            // 
            this.errorLéxicoToolStripMenuItem.Name = "errorLéxicoToolStripMenuItem";
            this.errorLéxicoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.errorLéxicoToolStripMenuItem.Text = "Error léxico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Consola";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(24, 361);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 190);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(314, 178);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(436, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "AFD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(436, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tabla transiciones";
            // 
            // next1
            // 
            this.next1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.next1.ForeColor = System.Drawing.Color.White;
            this.next1.Location = new System.Drawing.Point(724, 14);
            this.next1.Name = "next1";
            this.next1.Size = new System.Drawing.Size(36, 23);
            this.next1.TabIndex = 9;
            this.next1.Text = "next";
            this.next1.UseVisualStyleBackColor = false;
            this.next1.Click += new System.EventHandler(this.Next1_Click);
            // 
            // prev1
            // 
            this.prev1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prev1.ForeColor = System.Drawing.Color.White;
            this.prev1.Location = new System.Drawing.Point(679, 14);
            this.prev1.Name = "prev1";
            this.prev1.Size = new System.Drawing.Size(39, 23);
            this.prev1.TabIndex = 10;
            this.prev1.Text = "prev";
            this.prev1.UseVisualStyleBackColor = false;
            this.prev1.Click += new System.EventHandler(this.Prev1_Click);
            // 
            // prev2
            // 
            this.prev2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prev2.ForeColor = System.Drawing.Color.White;
            this.prev2.Location = new System.Drawing.Point(679, 241);
            this.prev2.Name = "prev2";
            this.prev2.Size = new System.Drawing.Size(39, 23);
            this.prev2.TabIndex = 11;
            this.prev2.Text = "prev";
            this.prev2.UseVisualStyleBackColor = false;
            this.prev2.Click += new System.EventHandler(this.Prev2_Click);
            // 
            // next2
            // 
            this.next2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.next2.ForeColor = System.Drawing.Color.White;
            this.next2.Location = new System.Drawing.Point(724, 241);
            this.next2.Name = "next2";
            this.next2.Size = new System.Drawing.Size(36, 23);
            this.next2.TabIndex = 12;
            this.next2.Text = "next";
            this.next2.UseVisualStyleBackColor = false;
            this.next2.Click += new System.EventHandler(this.Next2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(24, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(388, 301);
            this.tabControl1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(440, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 190);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(786, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 185);
            this.panel2.TabIndex = 15;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(293, 182);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(782, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "AFN";
            // 
            // prev3
            // 
            this.prev3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prev3.ForeColor = System.Drawing.Color.White;
            this.prev3.Location = new System.Drawing.Point(1001, 19);
            this.prev3.Name = "prev3";
            this.prev3.Size = new System.Drawing.Size(39, 23);
            this.prev3.TabIndex = 17;
            this.prev3.Text = "prev";
            this.prev3.UseVisualStyleBackColor = false;
            this.prev3.Click += new System.EventHandler(this.Prev3_Click);
            // 
            // next3
            // 
            this.next3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.next3.ForeColor = System.Drawing.Color.White;
            this.next3.Location = new System.Drawing.Point(1046, 19);
            this.next3.Name = "next3";
            this.next3.Size = new System.Drawing.Size(36, 23);
            this.next3.TabIndex = 18;
            this.next3.Text = "next";
            this.next3.UseVisualStyleBackColor = false;
            this.next3.Click += new System.EventHandler(this.Next3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(443, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(317, 178);
            this.panel3.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 483);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.next3);
            this.Controls.Add(this.prev3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.next2);
            this.Controls.Add(this.prev2);
            this.Controls.Add(this.prev1);
            this.Controls.Add(this.next1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "[CP1]Proyecto1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPestañaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarThomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarTokensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorLéxicoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button next1;
        private System.Windows.Forms.Button prev1;
        private System.Windows.Forms.Button prev2;
        private System.Windows.Forms.Button next2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button prev3;
        private System.Windows.Forms.Button next3;
        private System.Windows.Forms.Panel panel3;
    }
}

