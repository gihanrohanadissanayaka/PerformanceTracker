namespace PerformanceTracker
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            splitter1 = new Splitter();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            versionLbl = new Label();
            splitter2 = new Splitter();
            moduleBtn = new Button();
            sessionLogBtn = new Button();
            filterBox = new GroupBox();
            filterBtn = new Button();
            sessionTypeComboBox = new ComboBox();
            sessionType = new Label();
            moduleComboBox = new ComboBox();
            moduleFilter = new Label();
            weekListComboBox = new ComboBox();
            weekFilter = new Label();
            filtersessionGrid = new DataGridView();
            toolStrip1 = new ToolStrip();
            exportBtn = new ToolStripButton();
            refreshBtn = new ToolStripButton();
            prediction = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            filterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filtersessionGrid).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ControlLight;
            splitter1.Dock = DockStyle.Top;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(734, 82);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Nirmala UI", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(188, 9);
            label1.Name = "label1";
            label1.Size = new Size(408, 65);
            label1.TabIndex = 1;
            label1.Text = "Grade Forecaster";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 63);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // versionLbl
            // 
            versionLbl.AutoSize = true;
            versionLbl.BackColor = SystemColors.ControlLight;
            versionLbl.Font = new Font("Sitka Display", 9.749999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            versionLbl.ForeColor = SystemColors.ActiveCaptionText;
            versionLbl.Location = new Point(678, 53);
            versionLbl.Name = "versionLbl";
            versionLbl.Size = new Size(44, 19);
            versionLbl.TabIndex = 3;
            versionLbl.Text = "V 1.0.0";
            versionLbl.Click += versionLbl_Click;
            // 
            // splitter2
            // 
            splitter2.BackColor = SystemColors.ControlLight;
            splitter2.Location = new Point(0, 82);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(114, 379);
            splitter2.TabIndex = 4;
            splitter2.TabStop = false;
            // 
            // moduleBtn
            // 
            moduleBtn.Location = new Point(12, 107);
            moduleBtn.Name = "moduleBtn";
            moduleBtn.Size = new Size(93, 23);
            moduleBtn.TabIndex = 5;
            moduleBtn.Text = "Module Setup";
            moduleBtn.UseVisualStyleBackColor = true;
            moduleBtn.Click += moduleBtn_Click;
            // 
            // sessionLogBtn
            // 
            sessionLogBtn.Location = new Point(12, 148);
            sessionLogBtn.Name = "sessionLogBtn";
            sessionLogBtn.Size = new Size(93, 23);
            sessionLogBtn.TabIndex = 6;
            sessionLogBtn.Text = "Log Time";
            sessionLogBtn.UseVisualStyleBackColor = true;
            sessionLogBtn.Click += sessionLogBtn_Click;
            // 
            // filterBox
            // 
            filterBox.Controls.Add(filterBtn);
            filterBox.Controls.Add(sessionTypeComboBox);
            filterBox.Controls.Add(sessionType);
            filterBox.Controls.Add(moduleComboBox);
            filterBox.Controls.Add(moduleFilter);
            filterBox.Controls.Add(weekListComboBox);
            filterBox.Controls.Add(weekFilter);
            filterBox.Location = new Point(131, 98);
            filterBox.Name = "filterBox";
            filterBox.Size = new Size(591, 137);
            filterBox.TabIndex = 7;
            filterBox.TabStop = false;
            filterBox.Text = "Select Filters";
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(262, 97);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(75, 23);
            filterBtn.TabIndex = 9;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += filterBtn_Click;
            // 
            // sessionTypeComboBox
            // 
            sessionTypeComboBox.FormattingEnabled = true;
            sessionTypeComboBox.Location = new Point(410, 26);
            sessionTypeComboBox.Name = "sessionTypeComboBox";
            sessionTypeComboBox.Size = new Size(149, 23);
            sessionTypeComboBox.TabIndex = 13;
            // 
            // sessionType
            // 
            sessionType.AutoSize = true;
            sessionType.Location = new Point(331, 29);
            sessionType.Name = "sessionType";
            sessionType.Size = new Size(73, 15);
            sessionType.TabIndex = 12;
            sessionType.Text = "Session Type";
            // 
            // moduleComboBox
            // 
            moduleComboBox.FormattingEnabled = true;
            moduleComboBox.Location = new Point(79, 60);
            moduleComboBox.Name = "moduleComboBox";
            moduleComboBox.Size = new Size(212, 23);
            moduleComboBox.TabIndex = 11;
            // 
            // moduleFilter
            // 
            moduleFilter.AutoSize = true;
            moduleFilter.Location = new Point(19, 63);
            moduleFilter.Name = "moduleFilter";
            moduleFilter.Size = new Size(48, 15);
            moduleFilter.TabIndex = 10;
            moduleFilter.Text = "Module";
            // 
            // weekListComboBox
            // 
            weekListComboBox.FormattingEnabled = true;
            weekListComboBox.Location = new Point(79, 26);
            weekListComboBox.Name = "weekListComboBox";
            weekListComboBox.Size = new Size(212, 23);
            weekListComboBox.TabIndex = 9;
            // 
            // weekFilter
            // 
            weekFilter.AutoSize = true;
            weekFilter.Location = new Point(19, 29);
            weekFilter.Name = "weekFilter";
            weekFilter.Size = new Size(36, 15);
            weekFilter.TabIndex = 8;
            weekFilter.Text = "Week";
            // 
            // filtersessionGrid
            // 
            filtersessionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            filtersessionGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            filtersessionGrid.BackgroundColor = SystemColors.ControlLight;
            filtersessionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filtersessionGrid.GridColor = SystemColors.ControlLight;
            filtersessionGrid.Location = new Point(131, 241);
            filtersessionGrid.Name = "filtersessionGrid";
            filtersessionGrid.ReadOnly = true;
            filtersessionGrid.Size = new Size(591, 183);
            filtersessionGrid.TabIndex = 8;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { exportBtn, refreshBtn });
            toolStrip1.Location = new Point(131, 427);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(58, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // exportBtn
            // 
            exportBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            exportBtn.Image = (Image)resources.GetObject("exportBtn.Image");
            exportBtn.ImageTransparentColor = Color.Magenta;
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(23, 22);
            exportBtn.Text = "toolStripButton1";
            exportBtn.ToolTipText = "Generate Report";
            exportBtn.Click += exportBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            refreshBtn.Image = (Image)resources.GetObject("refreshBtn.Image");
            refreshBtn.ImageTransparentColor = Color.Magenta;
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(23, 22);
            refreshBtn.Text = "toolStripButton2";
            refreshBtn.ToolTipText = "Refresh grid";
            // 
            // prediction
            // 
            prediction.Location = new Point(12, 189);
            prediction.Name = "prediction";
            prediction.Size = new Size(93, 23);
            prediction.TabIndex = 10;
            prediction.Text = "Prediction";
            prediction.UseVisualStyleBackColor = true;
            prediction.Click += prediction_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 461);
            Controls.Add(prediction);
            Controls.Add(toolStrip1);
            Controls.Add(filtersessionGrid);
            Controls.Add(filterBox);
            Controls.Add(sessionLogBtn);
            Controls.Add(moduleBtn);
            Controls.Add(splitter2);
            Controls.Add(versionLbl);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(splitter1);
            Name = "Dashboard";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grade Forecaster";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            filterBox.ResumeLayout(false);
            filterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filtersessionGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Splitter splitter1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label versionLbl;
        private Splitter splitter2;
        private Button moduleBtn;
        private Button sessionLogBtn;
        private GroupBox filterBox;
        private Label sessionType;
        private ComboBox moduleComboBox;
        private Label moduleFilter;
        private ComboBox weekListComboBox;
        private Label weekFilter;
        private ComboBox sessionTypeComboBox;
        private DataGridView filtersessionGrid;
        private Button filterBtn;
        private ToolStrip toolStrip1;
        private ToolStripButton exportBtn;
        private ToolStripButton refreshBtn;
        private Button prediction;
    }
}
