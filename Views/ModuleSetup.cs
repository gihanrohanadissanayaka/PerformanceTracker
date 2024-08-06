using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PerformanceTracker.Models;
using PerformanceTracker.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace PerformanceTracker.Views
{
    public partial class ModuleSetup : Form
    {
        private Dashboard dashboard;
        private readonly ModuleService moduleService;
        private List<Module> moduleList;
        public ModuleSetup(List<Module> modules)
        {
            InitializeComponent();
            moduleService = new ModuleService(Dashboard.baseUrl);
            moduleList = modules;
            RefreshDataGridView();
            SetEditMode(false);
        }

        private async void save_Click(object sender, EventArgs e)
        {
            Module module = CreateModuleFromInputs();

            if (module == null)
                return;

            if (!ModuleService.ValidateModule(module, moduleList))
                return;

            bool isSaved = await moduleService.SaveModuleAsync(module);

            if (isSaved)
            {
                MessageBox.Show("Module saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                moduleList = await moduleService.LoadAsync();
                RefreshDataGridView();
                ResetInputFields();
            }
        }
        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            // if a row is selected
            if ( moduleDataGrid.SelectedRows.Count == 1 )
            {
                Module selectedModule = moduleDataGrid.SelectedRows[0].DataBoundItem as Module;

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the module '{selectedModule.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool isDeleted = await moduleService.DeleteModuleAsync(selectedModule.Id);

                    if (isDeleted)
                    {
                        MessageBox.Show("Module deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        moduleList = await moduleService.LoadAsync();
                        RefreshDataGridView();
                    }
                }
            }
            else
            {
                if ( moduleDataGrid.SelectedRows.Count > 1 )
                {
                    MessageBox.Show("Please select only one module to delete.", "Multiple Modules Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please select a module to delete.", "No module Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            if ( moduleDataGrid.SelectedRows.Count == 1 )
            {
                Module selectedModule = moduleDataGrid.SelectedRows[0].DataBoundItem as Module;
                moduleCodeTxt.Text = selectedModule.Code;
                moduleNameTxt.Text = selectedModule.Name;
                SetEditMode(true);
            }
            else
            {
                if (moduleDataGrid.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please select only one module to edit.", "Multiple Modules Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please select a module to edit.", "No module Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private async void updateBtn_Click(object sender, EventArgs e)
        {
            string moduleCode = moduleCodeTxt.Text.Trim();
            Module existingModule = moduleList.FirstOrDefault(m => m.Code == moduleCode);

            if (existingModule == null)
            {
                MessageBox.Show($"Module with code '{moduleCode}' does not exist.", "Module Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            existingModule.Name = moduleNameTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(existingModule.Name))
            {
                MessageBox.Show("Please enter Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isUpdated = await moduleService.UpdateModuleAsync(existingModule);

            if (isUpdated)
            {
                MessageBox.Show("Module updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the module list and update the DataGridView
                moduleList = await moduleService.LoadAsync();
                RefreshDataGridView();

                ResetInputFields();
                SetEditMode(false);
            }
        }

        private void RefreshDataGridView()
        {
            moduleDataGrid.DataSource = null;
            moduleDataGrid.AutoGenerateColumns = false;
            moduleDataGrid.Columns.Clear();

            moduleDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Module ID",
                Name = "Id"
            });

            moduleDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Code",
                HeaderText = "Module Code",
                Name = "Code"
            });

            moduleDataGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Module Name",
                Name = "Name"
            });

            moduleDataGrid.DataSource = moduleList;
        }

        private Module CreateModuleFromInputs()
        {
            Module module = new Module();
            module.Code = moduleCodeTxt.Text.Trim();
            module.Name = moduleNameTxt.Text.Trim();
            return module;
        }
        private void ResetInputFields()
        {
            moduleCodeTxt.Text = "";
            moduleNameTxt.Text = "";
        }
        private void SetEditMode(bool isEditMode)
        {
            moduleCodeTxt.Enabled = !isEditMode;
            save.Visible = !isEditMode;
            updateBtn.Visible = isEditMode;
        } 
    }
}
