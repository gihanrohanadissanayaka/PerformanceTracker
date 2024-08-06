namespace PerformanceTracker.Views
{
    partial class StudySessionSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudySessionSetup));
            session = new RadioButton();
            breakType = new RadioButton();
            moduleLbl = new Label();
            logDateLbl = new Label();
            timespendLbl = new Label();
            Progress = new Label();
            moduleComboBox = new ComboBox();
            logDateTime = new DateTimePicker();
            timespendCnt = new NumericUpDown();
            progressRate = new NumericUpDown();
            sessionDataGrid = new DataGridView();
            toolStrip1 = new ToolStrip();
            deleteBtn = new ToolStripButton();
            editBtn = new ToolStripButton();
            save = new Button();
            updateBtn = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)timespendCnt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sessionDataGrid).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // session
            // 
            session.AutoSize = true;
            session.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            session.Location = new Point(37, 27);
            session.Name = "session";
            session.Size = new Size(57, 19);
            session.TabIndex = 0;
            session.TabStop = true;
            session.Text = "Study";
            session.UseVisualStyleBackColor = true;
            // 
            // breakType
            // 
            breakType.AutoSize = true;
            breakType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            breakType.Location = new Point(136, 27);
            breakType.Name = "breakType";
            breakType.Size = new Size(58, 19);
            breakType.TabIndex = 1;
            breakType.TabStop = true;
            breakType.Text = "Break";
            breakType.UseVisualStyleBackColor = true;
            // 
            // moduleLbl
            // 
            moduleLbl.AutoSize = true;
            moduleLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moduleLbl.Location = new Point(37, 67);
            moduleLbl.Name = "moduleLbl";
            moduleLbl.Size = new Size(49, 15);
            moduleLbl.TabIndex = 2;
            moduleLbl.Text = "Module";
            // 
            // logDateLbl
            // 
            logDateLbl.AutoSize = true;
            logDateLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logDateLbl.Location = new Point(37, 107);
            logDateLbl.Name = "logDateLbl";
            logDateLbl.Size = new Size(57, 15);
            logDateLbl.TabIndex = 3;
            logDateLbl.Text = "Log Date";
            // 
            // timespendLbl
            // 
            timespendLbl.AutoSize = true;
            timespendLbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timespendLbl.Location = new Point(388, 67);
            timespendLbl.Name = "timespendLbl";
            timespendLbl.Size = new Size(73, 15);
            timespendLbl.TabIndex = 4;
            timespendLbl.Text = "Time Spend";
            // 
            // Progress
            // 
            Progress.AutoSize = true;
            Progress.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Progress.Location = new Point(388, 107);
            Progress.Name = "Progress";
            Progress.Size = new Size(82, 15);
            Progress.TabIndex = 5;
            Progress.Text = "Progress ( % )";
            // 
            // moduleComboBox
            // 
            moduleComboBox.FormattingEnabled = true;
            moduleComboBox.Location = new Point(114, 64);
            moduleComboBox.Name = "moduleComboBox";
            moduleComboBox.Size = new Size(211, 23);
            moduleComboBox.TabIndex = 6;
            // 
            // logDateTime
            // 
            logDateTime.Location = new Point(114, 101);
            logDateTime.Name = "logDateTime";
            logDateTime.Size = new Size(211, 23);
            logDateTime.TabIndex = 7;
            // 
            // timespendCnt
            // 
            timespendCnt.Location = new Point(503, 64);
            timespendCnt.Name = "timespendCnt";
            timespendCnt.Size = new Size(120, 23);
            timespendCnt.TabIndex = 8;
            // 
            // progressRate
            // 
            progressRate.Location = new Point(503, 107);
            progressRate.Name = "progressRate";
            progressRate.Size = new Size(120, 23);
            progressRate.TabIndex = 9;
            // 
            // sessionDataGrid
            // 
            sessionDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sessionDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            sessionDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sessionDataGrid.Location = new Point(37, 187);
            sessionDataGrid.Name = "sessionDataGrid";
            sessionDataGrid.Size = new Size(607, 187);
            sessionDataGrid.TabIndex = 11;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { deleteBtn, editBtn });
            toolStrip1.Location = new Point(37, 377);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(58, 25);
            toolStrip1.TabIndex = 12;
            toolStrip1.Text = "toolStrip1";
            // 
            // deleteBtn
            // 
            deleteBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            deleteBtn.Image = (Image)resources.GetObject("deleteBtn.Image");
            deleteBtn.ImageTransparentColor = Color.Magenta;
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(23, 22);
            deleteBtn.Text = "toolStripButton1";
            deleteBtn.ToolTipText = "Delete session record";
            deleteBtn.Click += deleteBtn_Click;
            // 
            // editBtn
            // 
            editBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            editBtn.Image = (Image)resources.GetObject("editBtn.Image");
            editBtn.ImageTransparentColor = Color.Magenta;
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(23, 22);
            editBtn.Text = "toolStripButton2";
            editBtn.ToolTipText = "Edit session record";
            editBtn.Click += editBtn_Click;
            // 
            // save
            // 
            save.Location = new Point(263, 140);
            save.Name = "save";
            save.Size = new Size(147, 23);
            save.TabIndex = 13;
            save.Text = "Add";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(263, 139);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(147, 23);
            updateBtn.TabIndex = 14;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(660, 165);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            // 
            // StudySessionSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 411);
            Controls.Add(updateBtn);
            Controls.Add(save);
            Controls.Add(toolStrip1);
            Controls.Add(sessionDataGrid);
            Controls.Add(progressRate);
            Controls.Add(timespendCnt);
            Controls.Add(logDateTime);
            Controls.Add(moduleComboBox);
            Controls.Add(Progress);
            Controls.Add(timespendLbl);
            Controls.Add(logDateLbl);
            Controls.Add(moduleLbl);
            Controls.Add(breakType);
            Controls.Add(session);
            Controls.Add(groupBox1);
            Name = "StudySessionSetup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Session Seup";
            ((System.ComponentModel.ISupportInitialize)timespendCnt).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)sessionDataGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton session;
        private RadioButton breakType;
        private Label moduleLbl;
        private Label logDateLbl;
        private Label timespendLbl;
        private Label Progress;
        private ComboBox moduleComboBox;
        private DateTimePicker logDateTime;
        private NumericUpDown timespendCnt;
        private NumericUpDown progressRate;
        private DataGridView sessionDataGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton deleteBtn;
        private ToolStripButton editBtn;
        private Button save;
        private Button updateBtn;
        private GroupBox groupBox1;
    }
}