namespace Projekat
{
    partial class GlavnaAdminForma
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
            this.smerButton = new System.Windows.Forms.Button();
            this.studentButton = new System.Windows.Forms.Button();
            this.predmetButton = new System.Windows.Forms.Button();
            this.izbornaListaButton = new System.Windows.Forms.Button();
            this.statistikaButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // smerButton
            // 
            this.smerButton.Location = new System.Drawing.Point(33, 70);
            this.smerButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.smerButton.Name = "smerButton";
            this.smerButton.Size = new System.Drawing.Size(100, 28);
            this.smerButton.TabIndex = 0;
            this.smerButton.Text = "Smer";
            this.smerButton.UseVisualStyleBackColor = true;
            this.smerButton.Click += new System.EventHandler(this.smerButton_Click);
            // 
            // studentButton
            // 
            this.studentButton.Location = new System.Drawing.Point(277, 70);
            this.studentButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentButton.Name = "studentButton";
            this.studentButton.Size = new System.Drawing.Size(100, 28);
            this.studentButton.TabIndex = 1;
            this.studentButton.Text = "Student";
            this.studentButton.UseVisualStyleBackColor = true;
            this.studentButton.Click += new System.EventHandler(this.studentButton_Click);
            // 
            // predmetButton
            // 
            this.predmetButton.Location = new System.Drawing.Point(33, 165);
            this.predmetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.predmetButton.Name = "predmetButton";
            this.predmetButton.Size = new System.Drawing.Size(100, 28);
            this.predmetButton.TabIndex = 2;
            this.predmetButton.Text = "Predmet";
            this.predmetButton.UseVisualStyleBackColor = true;
            this.predmetButton.Click += new System.EventHandler(this.predmetButton_Click);
            // 
            // izbornaListaButton
            // 
            this.izbornaListaButton.Location = new System.Drawing.Point(277, 165);
            this.izbornaListaButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.izbornaListaButton.Name = "izbornaListaButton";
            this.izbornaListaButton.Size = new System.Drawing.Size(100, 28);
            this.izbornaListaButton.TabIndex = 3;
            this.izbornaListaButton.Text = "Izborna Lista";
            this.izbornaListaButton.UseVisualStyleBackColor = true;
            this.izbornaListaButton.Click += new System.EventHandler(this.izbornaListaButton_Click);
            // 
            // statistikaButton
            // 
            this.statistikaButton.Location = new System.Drawing.Point(161, 302);
            this.statistikaButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statistikaButton.Name = "statistikaButton";
            this.statistikaButton.Size = new System.Drawing.Size(100, 28);
            this.statistikaButton.TabIndex = 4;
            this.statistikaButton.Text = "Statistika";
            this.statistikaButton.UseVisualStyleBackColor = true;
            this.statistikaButton.Click += new System.EventHandler(this.statistikaButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Izaberite oblast koju zlite da menjate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Pregled statistike";
            // 
            // GlavnaAdminForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 370);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statistikaButton);
            this.Controls.Add(this.izbornaListaButton);
            this.Controls.Add(this.predmetButton);
            this.Controls.Add(this.studentButton);
            this.Controls.Add(this.smerButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GlavnaAdminForma";
            this.Text = "Administracija";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlavnaAdminForma_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button studentButton;
        private System.Windows.Forms.Button predmetButton;
        private System.Windows.Forms.Button izbornaListaButton;
        private System.Windows.Forms.Button statistikaButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button smerButton;
    }
}