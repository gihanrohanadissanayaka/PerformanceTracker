namespace PerformanceTracker.Views
{
    partial class PredictionSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredictionSetup));
            dateLbl = new Label();
            predictDate = new DateTimePicker();
            moduleLbl = new Label();
            moduleComboBox = new ComboBox();
            pictureBox1 = new PictureBox();
            predictionGroupBox = new GroupBox();
            prediction = new Button();
            predictedPercentageLabel = new Label();
            predictedGradeLabel = new Label();
            totalStudyHoursLabel = new Label();
            totalBreakHoursLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            predictionGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Location = new Point(33, 61);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(31, 15);
            dateLbl.TabIndex = 0;
            dateLbl.Text = "Date";
            // 
            // predictDate
            // 
            predictDate.Location = new Point(102, 55);
            predictDate.Name = "predictDate";
            predictDate.Size = new Size(200, 23);
            predictDate.TabIndex = 1;
            // 
            // moduleLbl
            // 
            moduleLbl.AutoSize = true;
            moduleLbl.Location = new Point(33, 107);
            moduleLbl.Name = "moduleLbl";
            moduleLbl.Size = new Size(48, 15);
            moduleLbl.TabIndex = 2;
            moduleLbl.Text = "Module";
            // 
            // moduleComboBox
            // 
            moduleComboBox.FormattingEnabled = true;
            moduleComboBox.Location = new Point(102, 104);
            moduleComboBox.Name = "moduleComboBox";
            moduleComboBox.Size = new Size(200, 23);
            moduleComboBox.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(360, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 155);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // predictionGroupBox
            // 
            predictionGroupBox.Controls.Add(prediction);
            predictionGroupBox.FlatStyle = FlatStyle.Popup;
            predictionGroupBox.Location = new Point(22, 29);
            predictionGroupBox.Name = "predictionGroupBox";
            predictionGroupBox.Size = new Size(309, 155);
            predictionGroupBox.TabIndex = 5;
            predictionGroupBox.TabStop = false;
            predictionGroupBox.Text = "Prediction";
            // 
            // prediction
            // 
            prediction.Location = new Point(124, 114);
            prediction.Name = "prediction";
            prediction.Size = new Size(75, 23);
            prediction.TabIndex = 6;
            prediction.Text = "Predict";
            prediction.UseVisualStyleBackColor = true;
            prediction.Click += prediction_Click;
            // 
            // predictedPercentageLabel
            // 
            predictedPercentageLabel.AutoSize = true;
            predictedPercentageLabel.Location = new Point(33, 225);
            predictedPercentageLabel.Name = "predictedPercentageLabel";
            predictedPercentageLabel.Size = new Size(130, 15);
            predictedPercentageLabel.TabIndex = 6;
            predictedPercentageLabel.Text = "Predicted Confidence : ";
            // 
            // predictedGradeLabel
            // 
            predictedGradeLabel.AutoSize = true;
            predictedGradeLabel.Location = new Point(33, 257);
            predictedGradeLabel.Name = "predictedGradeLabel";
            predictedGradeLabel.Size = new Size(97, 15);
            predictedGradeLabel.TabIndex = 7;
            predictedGradeLabel.Text = "Predicted Grade :";
            // 
            // totalStudyHoursLabel
            // 
            totalStudyHoursLabel.AutoSize = true;
            totalStudyHoursLabel.Location = new Point(33, 287);
            totalStudyHoursLabel.Name = "totalStudyHoursLabel";
            totalStudyHoursLabel.Size = new Size(106, 15);
            totalStudyHoursLabel.TabIndex = 8;
            totalStudyHoursLabel.Text = "Total Study Hours :";
            // 
            // totalBreakHoursLabel
            // 
            totalBreakHoursLabel.AutoSize = true;
            totalBreakHoursLabel.Location = new Point(33, 320);
            totalBreakHoursLabel.Name = "totalBreakHoursLabel";
            totalBreakHoursLabel.Size = new Size(105, 15);
            totalBreakHoursLabel.TabIndex = 9;
            totalBreakHoursLabel.Text = "Total Break Hours :";
            // 
            // PredictionSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 361);
            Controls.Add(totalBreakHoursLabel);
            Controls.Add(totalStudyHoursLabel);
            Controls.Add(predictedGradeLabel);
            Controls.Add(predictedPercentageLabel);
            Controls.Add(pictureBox1);
            Controls.Add(moduleComboBox);
            Controls.Add(moduleLbl);
            Controls.Add(predictDate);
            Controls.Add(dateLbl);
            Controls.Add(predictionGroupBox);
            Name = "PredictionSetup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Predict Grade";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            predictionGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dateLbl;
        private DateTimePicker predictDate;
        private Label moduleLbl;
        private ComboBox moduleComboBox;
        private PictureBox pictureBox1;
        private GroupBox predictionGroupBox;
        private Button prediction;
        private Label predictedPercentageLabel;
        private Label predictedGradeLabel;
        private Label totalStudyHoursLabel;
        private Label totalBreakHoursLabel;
    }
}