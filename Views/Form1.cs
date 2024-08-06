using iTextSharp.text.pdf;
using iTextSharp.text;
using PerformanceTracker.Models;
using PerformanceTracker.Services;
using PerformanceTracker.Views;
using System.Windows.Forms;

namespace PerformanceTracker
{
    public partial class Dashboard : Form
    {
        private readonly ModuleService moduleService;
        private readonly StudySessionService studySessionService;
        private List<Module> moduleList = new List<Module>();
        private List<StudySession> studySessionList = new List<StudySession>();
        private List<StudySession> displaysessionList = new List<StudySession>();
        public static readonly string baseUrl = "https://myrestapiapp20240803103355.azurewebsites.net";
        public Dashboard()
        {
            InitializeComponent();
            // initialize records
            moduleService = new ModuleService(baseUrl);
            studySessionService = new StudySessionService(baseUrl);
            this.Load += Dashboard_Load;
        }
        private async void Dashboard_Load(object sender, EventArgs e)
        {
            moduleList = await moduleService.LoadAsync();
            studySessionList = await studySessionService.LoadAsync();
            initFilters();
            ApplyFilters();
        }
        private void PopulateWeekComboBox()
        {
            weekListComboBox.Items.Clear();

            var uniqueDates = studySessionList
                .Select(s => s.SessionDate.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            var weeks = new List<(DateTime Start, DateTime End)>();
            DateTime? currentWeekStart = null;
            foreach (var date in uniqueDates)
            {
                if (currentWeekStart == null)
                {
                    currentWeekStart = date.StartOfWeek(DayOfWeek.Monday);
                }

                var currentWeekEnd = currentWeekStart.Value.AddDays(6);

                if (date > currentWeekEnd)
                {
                    weeks.Add((currentWeekStart.Value, currentWeekEnd));
                    currentWeekStart = date.StartOfWeek(DayOfWeek.Monday);
                }
            }

            // Add the last week to the list
            if (currentWeekStart != null)
            {
                weeks.Add((currentWeekStart.Value, currentWeekStart.Value.AddDays(6)));
            }

            foreach (var week in weeks)
            {
                weekListComboBox.Items.Add($"{week.Start.ToShortDateString()} - {week.End.ToShortDateString()}");
            }

            if (weekListComboBox.Items.Count > 0)
            {
                weekListComboBox.SelectedIndex = weekListComboBox.Items.Count - 1;
            }
        }
        private void PopulateModuleComboBox()
        {
            moduleComboBox.Items.Clear();

            moduleComboBox.Items.Add("All");

            foreach (var module in moduleList)
            {
                if (module != null && !string.IsNullOrWhiteSpace(module.Name))
                {
                    moduleComboBox.Items.Add(module.Name);
                }
            }

            // Optionally, set the ComboBox to the first item
            if (moduleComboBox.Items.Count > 0)
            {
                moduleComboBox.SelectedIndex = 0;
            }
        }
        private void PopulateSessionTypeComboBox()
        {
            sessionTypeComboBox.Items.Clear();

            sessionTypeComboBox.Items.Add("All");
            sessionTypeComboBox.Items.Add("Study");
            sessionTypeComboBox.Items.Add("Break");

            // Optionally, set the ComboBox to the first item
            if (sessionTypeComboBox.Items.Count > 0)
            {
                sessionTypeComboBox.SelectedIndex = 0;
            }
        }
        private void versionLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User version - 1.0.0", "Student Performance Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void moduleBtn_Click(object sender, EventArgs e)
        {
            ModuleSetup moduleSetup = new ModuleSetup(moduleList);
            moduleSetup.FormClosed += ModuleSetup_FormClosed;
            moduleSetup.ShowDialog();
        }

        private async void ModuleSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            moduleList = await moduleService.LoadAsync();
            studySessionList = await studySessionService.LoadAsync();
            initFilters();
            ApplyFilters();
        }

        private void sessionLogBtn_Click(object sender, EventArgs e)
        {
            StudySessionSetup studySessionSetup = new StudySessionSetup(moduleList, studySessionList);
            studySessionSetup.ShowDialog();
        }
        private void prediction_Click(object sender, EventArgs e)
        {
            PredictionSetup predictionSetup = new PredictionSetup( moduleList, studySessionList);
            predictionSetup.ShowDialog();
        }
        private void initFilters()
        {
            PopulateModuleComboBox();
            PopulateSessionTypeComboBox();
            PopulateWeekComboBox();
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            string selectedModuleName = moduleComboBox.SelectedItem.ToString();
            string selectedSessionType = sessionTypeComboBox.SelectedItem.ToString();
            string selectedWeek = weekListComboBox.SelectedItem.ToString();

            string[] weekDates = selectedWeek.Split(new[] { " - " }, StringSplitOptions.None);
            DateTime weekStart = DateTime.Parse(weekDates[0]);
            DateTime weekEnd = DateTime.Parse(weekDates[1]);

            // Filter study sessions based on selected criteria
            displaysessionList = studySessionList
                .Where(s => (selectedModuleName == "All" || s.Module.Name == selectedModuleName) &&
                            (selectedSessionType == "All" ||
                             (selectedSessionType == "Study" && s.SessionType) ||
                             (selectedSessionType == "Break" && !s.SessionType)) &&
                            (s.SessionDate.Date >= weekStart && s.SessionDate.Date <= weekEnd))
                .ToList();

            ConfigureDataGridView();
        }
        private void ConfigureDataGridView()
        {
            // Clear existing data source and columns
            filtersessionGrid.DataSource = null;
            filtersessionGrid.Columns.Clear();
            filtersessionGrid.AutoGenerateColumns = false;
            filtersessionGrid.DataSource = displaysessionList;

            // Add custom columns
            filtersessionGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ModuleCode",
                HeaderText = "Module Code"
            });
            filtersessionGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionDate",
                HeaderText = "Session Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            filtersessionGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionTime",
                HeaderText = "Session Time (hours)"
            });
            filtersessionGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionTypeDisplay",
                HeaderText = "Session Type"
            });
            filtersessionGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Progress",
                HeaderText = "Progress (%)"
            });
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            ApplyFilters();
            List<StudySession> filteredSessions = filtersessionGrid.DataSource as List<StudySession>;
            if (filteredSessions != null && filteredSessions.Any())
            {
                ExportDataService.ExportToPdf(filteredSessions, weekListComboBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("No data available to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
