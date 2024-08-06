using PerformanceTracker.Models;
using PerformanceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceTracker.Views
{
    public partial class PredictionSetup : Form
    {
        private List<Module> moduleList;
        private List<StudySession> studySessionList;
        private List<StudySession> filterSessionList;
        private readonly PredictionService predictionService;
        public PredictionSetup(List<Module> modules, List<StudySession> studySessions)
        {
            InitializeComponent();
            moduleList = modules;
            studySessionList = studySessions;
            predictionService = new PredictionService(Dashboard.baseUrl);
            PopulateModuleComboBox();
            predictDate.Value = DateTime.Now;
        }
        private void PopulateModuleComboBox()
        {
            moduleComboBox.Items.Clear();

            foreach (var module in moduleList)
            {
                if (module != null && !string.IsNullOrWhiteSpace(module.Name))
                {
                    moduleComboBox.Items.Add(module.Name);
                }
            }

            if (moduleComboBox.Items.Count > 0)
            {
                moduleComboBox.SelectedIndex = 0;
            }
        }

        private async void prediction_Click(object sender, EventArgs e)
        {
            int selectedModuleId = moduleList
                .Where(m => m.Name == moduleComboBox.SelectedItem.ToString())
                .Select(m => m.Id)
                .FirstOrDefault();

            // Call the LoadPredictionAsync method to get the prediction result
            string predictionResult = await predictionService.LoadPredictionAsync(predictDate.Value, selectedModuleId);

            // Split the prediction result based on the separator "$" and "~"
            var parts = predictionResult.Split('$');
            if (parts.Length > 1)
            {
                // Further split the second part based on "~"
                var details = parts[1].Split('~');
                if (details.Length >= 4)
                {
                    // Extract values from the details array
                    string predictedProgress = details[0];
                    string predictedGrade = details[1];
                    string totalStudyHours = details[2];
                    string totalBreakHours = details[3];

                    // Update the labels with the extracted values
                    predictedPercentageLabel.Text = $"Predicted Confidence : {predictedProgress}%";
                    predictedGradeLabel.Text = $"Predicted Grade : {predictedGrade}";
                    totalStudyHoursLabel.Text = $"Total Study Hours : {totalStudyHours} hours";
                    totalBreakHoursLabel.Text = $"Total Break Hours : {totalBreakHours} hours";
                }
                else
                {
                    // Handle the case where details are not as expected
                    MessageBox.Show("Unexpected prediction result format.");
                }
            }
            else
            {
                // Handle the case where predictionResult format is incorrect
                MessageBox.Show("Unexpected prediction result format.");
            }
        }

    }
}
