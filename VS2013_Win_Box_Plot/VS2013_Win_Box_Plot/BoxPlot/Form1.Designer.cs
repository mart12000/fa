namespace SoftwareFX.Samples._BoxPlot
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSamples = new System.Windows.Forms.ComboBox();
            this.chart1 = new ChartFX.WinForms.Chart();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sample:";
            // 
            // comboBoxSamples
            // 
            this.comboBoxSamples.FormattingEnabled = true;
            this.comboBoxSamples.Location = new System.Drawing.Point(61, 7);
            this.comboBoxSamples.Name = "comboBoxSamples";
            this.comboBoxSamples.Size = new System.Drawing.Size(165, 21);
            this.comboBoxSamples.TabIndex = 4;
            this.comboBoxSamples.SelectedIndexChanged += new System.EventHandler(this.comboBoxSamples_SelectedIndexChanged);
            // 
            // chart1
            // 
            this.chart1.AllowDrop = true;
            this.chart1.AllSeries.MarkerTemplate = null;
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.AxisX.Title.Separation = 10;
            this.chart1.AxisY.Title.Separation = 10;
            this.chart1.AxisY2.Title.Separation = 10;
            this.chart1.DataGrid.Visible = false;
            this.chart1.LegendBox.Visible = true;
            this.chart1.Location = new System.Drawing.Point(29, 34);
            this.chart1.MainPane.Title.Separation = 5;
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(811, 414);
            this.chart1.TabIndex = 6;
            this.chart1.ClientSizeChanged += new System.EventHandler(this.chart1_ClientSizeChanged);
            this.chart1.SizeChanged += new System.EventHandler(this.chart1_SizeChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Average",
            "Max Weight",
            "Min Weight",
            "Range"});
            this.listBox1.Location = new System.Drawing.Point(232, -31);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(118, 69);
            this.listBox1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 460);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxSamples);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSamples;
                private ChartFX.WinForms.Chart chart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}