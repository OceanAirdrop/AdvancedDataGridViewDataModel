using Zuby.ADGV;

namespace AdvancedDataGridViewDataTable
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
            this.dataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.textBox_sort = new System.Windows.Forms.TextBox();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.button_unloadfilters = new System.Windows.Forms.Button();
            this.label_filter = new System.Windows.Forms.Label();
            this.label_sort = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.FilterAndSortEnabled = true;
            this.dataGridView1.Location = new System.Drawing.Point(12, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.advancedDataGridView1_SortStringChanged);
            this.dataGridView1.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dataGridView1_FilterStringChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox_sort
            // 
            this.textBox_sort.Location = new System.Drawing.Point(301, 24);
            this.textBox_sort.Multiline = true;
            this.textBox_sort.Name = "textBox_sort";
            this.textBox_sort.ReadOnly = true;
            this.textBox_sort.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sort.Size = new System.Drawing.Size(264, 113);
            this.textBox_sort.TabIndex = 17;
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(17, 24);
            this.textBox_filter.Multiline = true;
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.ReadOnly = true;
            this.textBox_filter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_filter.Size = new System.Drawing.Size(264, 113);
            this.textBox_filter.TabIndex = 16;
            // 
            // button_unloadfilters
            // 
            this.button_unloadfilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_unloadfilters.Location = new System.Drawing.Point(639, 114);
            this.button_unloadfilters.Name = "button_unloadfilters";
            this.button_unloadfilters.Size = new System.Drawing.Size(150, 23);
            this.button_unloadfilters.TabIndex = 15;
            this.button_unloadfilters.Text = "Clean Filter And Sort";
            this.button_unloadfilters.UseVisualStyleBackColor = true;
            this.button_unloadfilters.Click += new System.EventHandler(this.button_unloadfilters_Click);
            // 
            // label_filter
            // 
            this.label_filter.AutoSize = true;
            this.label_filter.Location = new System.Drawing.Point(14, 8);
            this.label_filter.Name = "label_filter";
            this.label_filter.Size = new System.Drawing.Size(88, 13);
            this.label_filter.TabIndex = 18;
            this.label_filter.Text = "LINQ Filter string:";
            // 
            // label_sort
            // 
            this.label_sort.AutoSize = true;
            this.label_sort.Location = new System.Drawing.Point(298, 8);
            this.label_sort.Name = "label_sort";
            this.label_sort.Size = new System.Drawing.Size(85, 13);
            this.label_sort.TabIndex = 19;
            this.label_sort.Text = "LINQ Sort string:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 518);
            this.Controls.Add(this.label_sort);
            this.Controls.Add(this.label_filter);
            this.Controls.Add(this.textBox_sort);
            this.Controls.Add(this.textBox_filter);
            this.Controls.Add(this.button_unloadfilters);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ocean Airdrop - Advanced DGV - Model DataBinding ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdvancedDataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_sort;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Button button_unloadfilters;
        private System.Windows.Forms.Label label_filter;
        private System.Windows.Forms.Label label_sort;
    }
}

