namespace PerformanceTracker.Views
{
    partial class ModuleSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleSetup));
            modulecodeLbl = new Label();
            moduleCodeTxt = new TextBox();
            moduleNameTxt = new TextBox();
            moduleNameLbl = new Label();
            save = new Button();
            pictureBox1 = new PictureBox();
            moduleDataGrid = new DataGridView();
            toolStrip1 = new ToolStrip();
            deleteBtn = new ToolStripButton();
            editBtn = new ToolStripButton();
            updateBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moduleDataGrid).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // modulecodeLbl
            // 
            modulecodeLbl.AutoSize = true;
            modulecodeLbl.Location = new Point(35, 36);
            modulecodeLbl.Name = "modulecodeLbl";
            modulecodeLbl.Size = new Size(79, 15);
            modulecodeLbl.TabIndex = 0;
            modulecodeLbl.Text = "Module Code";
            // 
            // moduleCodeTxt
            // 
            moduleCodeTxt.Location = new Point(137, 33);
            moduleCodeTxt.Name = "moduleCodeTxt";
            moduleCodeTxt.Size = new Size(183, 23);
            moduleCodeTxt.TabIndex = 1;
            // 
            // moduleNameTxt
            // 
            moduleNameTxt.Location = new Point(137, 79);
            moduleNameTxt.Name = "moduleNameTxt";
            moduleNameTxt.Size = new Size(183, 23);
            moduleNameTxt.TabIndex = 3;
            // 
            // moduleNameLbl
            // 
            moduleNameLbl.AutoSize = true;
            moduleNameLbl.Location = new Point(35, 82);
            moduleNameLbl.Name = "moduleNameLbl";
            moduleNameLbl.Size = new Size(83, 15);
            moduleNameLbl.TabIndex = 2;
            moduleNameLbl.Text = "Module Name";
            // 
            // save
            // 
            save.Location = new Point(170, 130);
            save.Name = "save";
            save.Size = new Size(150, 23);
            save.TabIndex = 4;
            save.Text = "Create";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(351, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(201, 120);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // moduleDataGrid
            // 
            moduleDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            moduleDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            moduleDataGrid.BackgroundColor = SystemColors.Control;
            moduleDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            moduleDataGrid.Location = new Point(35, 182);
            moduleDataGrid.Name = "moduleDataGrid";
            moduleDataGrid.ReadOnly = true;
            moduleDataGrid.Size = new Size(517, 139);
            moduleDataGrid.TabIndex = 6;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { deleteBtn, editBtn });
            toolStrip1.Location = new Point(35, 324);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(58, 25);
            toolStrip1.TabIndex = 7;
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
            deleteBtn.ToolTipText = "Delete module";
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
            editBtn.ToolTipText = "Edit module";
            editBtn.Click += editBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Location = new Point(170, 130);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(150, 23);
            updateBtn.TabIndex = 8;
            updateBtn.Text = "Update";
            updateBtn.TextAlign = ContentAlignment.BottomCenter;
            updateBtn.UseVisualStyleBackColor = true;
            updateBtn.Click += updateBtn_Click;
            // 
            // ModuleSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(updateBtn);
            Controls.Add(toolStrip1);
            Controls.Add(moduleDataGrid);
            Controls.Add(pictureBox1);
            Controls.Add(save);
            Controls.Add(moduleNameTxt);
            Controls.Add(moduleNameLbl);
            Controls.Add(moduleCodeTxt);
            Controls.Add(modulecodeLbl);
            Name = "ModuleSetup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModuleSetup";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)moduleDataGrid).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label modulecodeLbl;
        private TextBox moduleCodeTxt;
        private TextBox moduleNameTxt;
        private Label moduleNameLbl;
        private Button save;
        private PictureBox pictureBox1;
        private DataGridView moduleDataGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton deleteBtn;
        private ToolStripButton editBtn;
        private Button updateBtn;
    }
}