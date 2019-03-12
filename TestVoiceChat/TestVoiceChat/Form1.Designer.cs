namespace TestVoiceChat
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.reAdd = new System.Windows.Forms.TextBox();
            this.rePort = new System.Windows.Forms.TextBox();
            this.loAdd = new System.Windows.Forms.TextBox();
            this.loPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Connect_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reAdd
            // 
            this.reAdd.Location = new System.Drawing.Point(15, 25);
            this.reAdd.Name = "reAdd";
            this.reAdd.Size = new System.Drawing.Size(100, 20);
            this.reAdd.TabIndex = 0;
            this.reAdd.TextChanged += new System.EventHandler(this.reAdd_TextChanged);
            // 
            // rePort
            // 
            this.rePort.Location = new System.Drawing.Point(15, 64);
            this.rePort.Name = "rePort";
            this.rePort.Size = new System.Drawing.Size(100, 20);
            this.rePort.TabIndex = 1;
            this.rePort.TextChanged += new System.EventHandler(this.rePort_TextChanged);
            // 
            // loAdd
            // 
            this.loAdd.Location = new System.Drawing.Point(15, 103);
            this.loAdd.Name = "loAdd";
            this.loAdd.Size = new System.Drawing.Size(100, 20);
            this.loAdd.TabIndex = 2;
            this.loAdd.TextChanged += new System.EventHandler(this.loAdd_TextChanged);
            // 
            // loPort
            // 
            this.loPort.Location = new System.Drawing.Point(15, 142);
            this.loPort.Name = "loPort";
            this.loPort.Size = new System.Drawing.Size(100, 20);
            this.loPort.TabIndex = 3;
            this.loPort.TextChanged += new System.EventHandler(this.loPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remote address:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Remote port:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Local address:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Local port:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Connect_button
            // 
            this.Connect_button.Location = new System.Drawing.Point(15, 177);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(100, 32);
            this.Connect_button.TabIndex = 8;
            this.Connect_button.Text = "Connect";
            this.Connect_button.UseVisualStyleBackColor = true;
            this.Connect_button.Click += new System.EventHandler(this.Connect_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 227);
            this.Controls.Add(this.Connect_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loPort);
            this.Controls.Add(this.loAdd);
            this.Controls.Add(this.rePort);
            this.Controls.Add(this.reAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox reAdd;
        private System.Windows.Forms.TextBox rePort;
        private System.Windows.Forms.TextBox loAdd;
        private System.Windows.Forms.TextBox loPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Connect_button;
    }
}

