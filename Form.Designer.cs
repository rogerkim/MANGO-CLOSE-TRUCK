namespace CloseTruck
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrackingNo = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnCloseTruck = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "운송장번호 스캔:";
            // 
            // txtTrackingNo
            // 
            this.txtTrackingNo.Location = new System.Drawing.Point(111, 83);
            this.txtTrackingNo.Name = "txtTrackingNo";
            this.txtTrackingNo.Size = new System.Drawing.Size(251, 21);
            this.txtTrackingNo.TabIndex = 1;
            this.txtTrackingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView.Location = new System.Drawing.Point(0, 307);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(551, 321);
            this.dataGridView.TabIndex = 3;
            // 
            // btnCloseTruck
            // 
            this.btnCloseTruck.Enabled = false;
            this.btnCloseTruck.Location = new System.Drawing.Point(368, 81);
            this.btnCloseTruck.Name = "btnCloseTruck";
            this.btnCloseTruck.Size = new System.Drawing.Size(116, 23);
            this.btnCloseTruck.TabIndex = 4;
            this.btnCloseTruck.Text = "Close Truck";
            this.btnCloseTruck.UseVisualStyleBackColor = true;
            this.btnCloseTruck.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Arial", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.Location = new System.Drawing.Point(198, 122);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(139, 153);
            this.labelCount.TabIndex = 6;
            this.labelCount.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(551, 628);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.btnCloseTruck);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtTrackingNo);
            this.Controls.Add(this.label1);
            this.Name = "Form";
            this.Text = "Mango Close Truck V1.1";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTrackingNo;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnCloseTruck;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

