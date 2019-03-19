namespace SAP2000_WFA
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
            this.dgvTest = new System.Windows.Forms.DataGridView();
            this.ButtonCloseForm = new System.Windows.Forms.Button();
            this.ButtonKillSap = new System.Windows.Forms.Button();
            this.ButtonStartSAP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTest
            // 
            this.dgvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTest.Location = new System.Drawing.Point(12, 12);
            this.dgvTest.Name = "dgvTest";
            this.dgvTest.Size = new System.Drawing.Size(776, 397);
            this.dgvTest.TabIndex = 0;
            // 
            // ButtonCloseForm
            // 
            this.ButtonCloseForm.Location = new System.Drawing.Point(713, 415);
            this.ButtonCloseForm.Name = "ButtonCloseForm";
            this.ButtonCloseForm.Size = new System.Drawing.Size(75, 23);
            this.ButtonCloseForm.TabIndex = 1;
            this.ButtonCloseForm.Text = "Close Form";
            this.ButtonCloseForm.UseVisualStyleBackColor = true;
            this.ButtonCloseForm.Click += new System.EventHandler(this.ButtonCloseForm_Click);
            // 
            // ButtonKillSap
            // 
            this.ButtonKillSap.Location = new System.Drawing.Point(632, 415);
            this.ButtonKillSap.Name = "ButtonKillSap";
            this.ButtonKillSap.Size = new System.Drawing.Size(75, 23);
            this.ButtonKillSap.TabIndex = 2;
            this.ButtonKillSap.Text = "Kill Sap";
            this.ButtonKillSap.UseVisualStyleBackColor = true;
            this.ButtonKillSap.Click += new System.EventHandler(this.ButtonKillSap_Click);
            // 
            // ButtonStartSAP
            // 
            this.ButtonStartSAP.Location = new System.Drawing.Point(551, 415);
            this.ButtonStartSAP.Name = "ButtonStartSAP";
            this.ButtonStartSAP.Size = new System.Drawing.Size(75, 23);
            this.ButtonStartSAP.TabIndex = 3;
            this.ButtonStartSAP.Text = "Start Sap";
            this.ButtonStartSAP.UseVisualStyleBackColor = true;
            this.ButtonStartSAP.Click += new System.EventHandler(this.ButtonStartSAP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonStartSAP);
            this.Controls.Add(this.ButtonKillSap);
            this.Controls.Add(this.ButtonCloseForm);
            this.Controls.Add(this.dgvTest);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTest;
        private System.Windows.Forms.Button ButtonCloseForm;
        private System.Windows.Forms.Button ButtonKillSap;
        private System.Windows.Forms.Button ButtonStartSAP;
    }
}

