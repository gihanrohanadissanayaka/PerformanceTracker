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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PerformanceTracker.Views
{
    public partial class StudySessionSetup : Form
    {
        private readonly StudySessionService studySessionService;
        private List<Module> moduleList;
        private List<StudySession> studySessionList;
        public StudySessionSetup(List<Module> modules, List<StudySession> studySessions)
        {
            InitializeComponent();
            studySessionService = new StudySessionService(Dashboard.baseUrl);
            moduleList = modules;
            studySessionList = studySessions;
            ConfigureDataGridView();
            PopulateComboBox();
            SetEditMode(false);
            session.Checked = true;
            timespendCnt.DecimalPlaces = 2;
            timespendCnt.Increment = 0.50M;
            progressRate.Increment = 5;
        }
        private void ConfigureDataGridView()
        {
            sessionDataGrid.Columns.Clear();
            sessionDataGrid.AutoGenerateColumns = false;

            // Add custom columns
            sessionDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ModuleCode",
                HeaderText = "Module Code"
            });
            sessionDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionDate",
                HeaderText = "Session Date",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });
            sessionDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionTime",
                HeaderText = "Session Time (hours)"
            });
            sessionDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SessionTypeDisplay",
                HeaderText = "Session Type"
            });
            sessionDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Progress",
                HeaderText = "Progress (%)"
            });

            sessionDataGrid.DataSource = null;
            sessionDataGrid.DataSource = studySessionList;
        }
        private void PopulateComboBox()
        {
            moduleComboBox.Items.Clear();

            foreach (var module in moduleList)
            {
                moduleComboBox.Items.Add(module.Name);
            }
            if (moduleComboBox.Items.Count > 0)
            {
                moduleComboBox.SelectedIndex = 0;
            }
        }
        private async void save_Click(object sender, EventArgs e)
        {
            Module selectedModule = null;
            if (moduleComboBox.SelectedIndex >= 0)
            {
                selectedModule = moduleList[moduleComboBox.SelectedIndex];
            }
            else
            {
                MessageBox.Show("Please select a module.", "Module not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sessionType = session.Checked;
            DateTime sessionDate = logDateTime.Value.Date;
            double sessionTime = (double)timespendCnt.Value;
            double progress = (double)progressRate.Value;

            StudySession newSession = new StudySession
            {
                Module = selectedModule,
                ModuleId = selectedModule.Id,
                SessionDate = sessionDate,
                SessionTime = sessionTime,
                SessionType = sessionType,
                Progress = progress
            };

            if (!StudySessionService.ValidateSession(newSession, studySessionList))
                return;

            bool isSaved = await studySessionService.AddStudySessionAsync(newSession);

            if (isSaved)
            {
                MessageBox.Show("Study session saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                studySessionList = await studySessionService.LoadAsync();
                ConfigureDataGridView();
                ResetInputFields();
            }
            else
            {
                MessageBox.Show("Failed to save the study session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            if (sessionDataGrid.SelectedRows.Count == 1)
            {
                StudySession selectedSession = sessionDataGrid.SelectedRows[0].DataBoundItem as StudySession;
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the session for module '{selectedSession.Module.Code}' on {selectedSession.SessionDate:yyyy-MM-dd}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool isDeleted = await studySessionService.DeleteStudySessionAsync(selectedSession.Id);

                    if (isDeleted)
                    {
                        MessageBox.Show("Study session deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        studySessionList.Remove(selectedSession);
                        ConfigureDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the study session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (sessionDataGrid.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please select only one session to delete.", "Multiple Sessions Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please select a session to delete.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void editBtn_Click(Object sender, EventArgs e)
        {
            // Check if a row is selected
            if (sessionDataGrid.SelectedRows.Count == 1)
            {

                StudySession selectedSession = sessionDataGrid.SelectedRows[0].DataBoundItem as StudySession;

                session.Checked = selectedSession.SessionType;
                breakType.Checked = !selectedSession.SessionType;
                moduleComboBox.SelectedIndex = moduleComboBox.Items.IndexOf(selectedSession.Module.Name);
                logDateTime.Value = selectedSession.SessionDate;
                timespendCnt.Value = (decimal)selectedSession.SessionTime;
                progressRate.Value = (decimal)selectedSession.Progress;
                SetEditMode(true);
            }
            else
            {
                if (sessionDataGrid.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please select only one session to edit.", "Multiple sessions Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please select a session to edit.", "No session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private async void updateBtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (sessionDataGrid.SelectedRows.Count == 1)
            {
                StudySession selectedSession = sessionDataGrid.SelectedRows[0].DataBoundItem as StudySession;

                if (selectedSession == null)
                {
                    MessageBox.Show($"Selected session does not exist.", "Session Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedSession.SessionType = session.Checked;
                selectedSession.SessionDate = logDateTime.Value.Date;
                selectedSession.SessionTime = (double)timespendCnt.Value;
                selectedSession.Progress = (double)progressRate.Value;

                if (!StudySessionService.ValidateSession(selectedSession, studySessionList))
                    return;

                bool isUpdated = await studySessionService.UpdateStudySessionAsync(selectedSession);

                if (isUpdated)
                {
                    MessageBox.Show("Study session updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfigureDataGridView();
                    ResetInputFields();
                    SetEditMode(false);
                }
                else
                {
                    MessageBox.Show("Failed to update the study session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a session to update.", "No Session Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshDataGridView()
        {
            sessionDataGrid.DataSource = null;
            
        }
        private void ResetInputFields()
        {
            session.Checked = true;
            breakType.Checked = false;
            moduleComboBox.SelectedIndex = 0;
            logDateTime.Value = DateTime.Now;
            timespendCnt.Value = 0;
            progressRate.Value = 0;
        }
        private void SetEditMode(bool isEditMode)
        {
            moduleComboBox.Enabled = !isEditMode;
            save.Visible = !isEditMode;
            updateBtn.Visible = isEditMode;
        }
    }
}
