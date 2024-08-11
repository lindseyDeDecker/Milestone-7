namespace Milestone_2._1
{
    partial class FrmSearch
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
            dgvSearch = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSearch).BeginInit();
            SuspendLayout();
            // 
            // dgvSearch
            // 
            dgvSearch.BackgroundColor = Color.FromArgb(255, 192, 255);
            dgvSearch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSearch.Location = new Point(81, 27);
            dgvSearch.Name = "dgvSearch";
            dgvSearch.Size = new Size(612, 325);
            dgvSearch.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(255, 128, 255);
            btnClose.Font = new Font("Open Sans", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(330, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 34);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close Search";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FrmSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkViolet;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(dgvSearch);
            Name = "FrmSearch";
            Text = "FrmSearch";
            Load += FrmSearch_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSearch).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSearch;
        private Button btnClose;
    }
}