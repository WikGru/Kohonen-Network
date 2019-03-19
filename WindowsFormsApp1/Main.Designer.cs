namespace KohonenNetwork
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.nr_iteracji = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.neighbourLabel = new System.Windows.Forms.Label();
            this.learningLabel = new System.Windows.Forms.Label();
            this.b_start = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.text_neigh = new System.Windows.Forms.TextBox();
            this.text_learning = new System.Windows.Forms.TextBox();
            this.text_iterations = new System.Windows.Forms.TextBox();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_Kmeans = new System.Windows.Forms.Button();
            this.text_groups = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Itaracja:";
            // 
            // nr_iteracji
            // 
            this.nr_iteracji.AutoSize = true;
            this.nr_iteracji.Location = new System.Drawing.Point(95, 545);
            this.nr_iteracji.Name = "nr_iteracji";
            this.nr_iteracji.Size = new System.Drawing.Size(37, 13);
            this.nr_iteracji.TabIndex = 20;
            this.nr_iteracji.Text = "10000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Sąsiedztwo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 597);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Tempo uczenia:";
            // 
            // neighbourLabel
            // 
            this.neighbourLabel.AutoSize = true;
            this.neighbourLabel.Location = new System.Drawing.Point(133, 619);
            this.neighbourLabel.Name = "neighbourLabel";
            this.neighbourLabel.Size = new System.Drawing.Size(19, 13);
            this.neighbourLabel.TabIndex = 50;
            this.neighbourLabel.Text = "25";
            // 
            // learningLabel
            // 
            this.learningLabel.AutoSize = true;
            this.learningLabel.Location = new System.Drawing.Point(133, 597);
            this.learningLabel.Name = "learningLabel";
            this.learningLabel.Size = new System.Drawing.Size(40, 13);
            this.learningLabel.TabIndex = 60;
            this.learningLabel.Text = "0.9999";
            // 
            // b_start
            // 
            this.b_start.Location = new System.Drawing.Point(394, 541);
            this.b_start.Name = "b_start";
            this.b_start.Size = new System.Drawing.Size(139, 23);
            this.b_start.TabIndex = 70;
            this.b_start.Text = "Start";
            this.b_start.UseVisualStyleBackColor = true;
            this.b_start.Click += new System.EventHandler(this.b_start_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Zasięg sąsiedztwa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 570);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "Tempo uczenia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 597);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ilość iteracji:";
            // 
            // text_neigh
            // 
            this.text_neigh.Location = new System.Drawing.Point(281, 542);
            this.text_neigh.Name = "text_neigh";
            this.text_neigh.Size = new System.Drawing.Size(107, 20);
            this.text_neigh.TabIndex = 0;
            // 
            // text_learning
            // 
            this.text_learning.Location = new System.Drawing.Point(281, 568);
            this.text_learning.Name = "text_learning";
            this.text_learning.Size = new System.Drawing.Size(107, 20);
            this.text_learning.TabIndex = 1;
            // 
            // text_iterations
            // 
            this.text_iterations.Location = new System.Drawing.Point(281, 594);
            this.text_iterations.Name = "text_iterations";
            this.text_iterations.Size = new System.Drawing.Size(107, 20);
            this.text_iterations.TabIndex = 2;
            // 
            // b_cancel
            // 
            this.b_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancel.Location = new System.Drawing.Point(394, 565);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(139, 23);
            this.b_cancel.TabIndex = 91;
            this.b_cancel.Text = "Stop";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_Kmeans
            // 
            this.b_Kmeans.Enabled = false;
            this.b_Kmeans.Location = new System.Drawing.Point(394, 621);
            this.b_Kmeans.Name = "b_Kmeans";
            this.b_Kmeans.Size = new System.Drawing.Size(139, 23);
            this.b_Kmeans.TabIndex = 92;
            this.b_Kmeans.Text = "Groups";
            this.b_Kmeans.UseVisualStyleBackColor = true;
            this.b_Kmeans.Click += new System.EventHandler(this.b_Kmeans_Click);
            // 
            // text_groups
            // 
            this.text_groups.Location = new System.Drawing.Point(281, 623);
            this.text_groups.Name = "text_groups";
            this.text_groups.Size = new System.Drawing.Size(107, 20);
            this.text_groups.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(219, 626);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 95;
            this.label7.Text = "Ilość grup:";
            // 
            // Main
            // 
            this.AcceptButton = this.b_start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancel;
            this.ClientSize = new System.Drawing.Size(559, 653);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text_groups);
            this.Controls.Add(this.b_Kmeans);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.text_iterations);
            this.Controls.Add(this.text_learning);
            this.Controls.Add(this.text_neigh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.b_start);
            this.Controls.Add(this.learningLabel);
            this.Controls.Add(this.neighbourLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nr_iteracji);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Sieć Kohonena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nr_iteracji;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label neighbourLabel;
        private System.Windows.Forms.Label learningLabel;
        private System.Windows.Forms.Button b_start;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox text_neigh;
        private System.Windows.Forms.TextBox text_learning;
        private System.Windows.Forms.TextBox text_iterations;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_Kmeans;
        private System.Windows.Forms.TextBox text_groups;
        private System.Windows.Forms.Label label7;
    }
}

