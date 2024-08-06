using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformanceTracker.Models;
using Newtonsoft.Json;

namespace PerformanceTracker.Services
{
    internal class ModuleService
    {
        private readonly string baseUrl;
        public ModuleService(string url)
        {
            baseUrl = url;
        }
        public async Task<List<Module>> LoadAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}/api/modules");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Module> modules = JsonConvert.DeserializeObject<List<Module>>(responseBody);

                    return modules;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Module>();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Module>();
                }
            }
        }
        public async Task<bool> SaveModuleAsync(Module module)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(module);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/api/modules", content);
                    response.EnsureSuccessStatusCode();

                    return true;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public async Task<bool> UpdateModuleAsync(Module module)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(module);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{baseUrl}/api/modules/{module.Id}", content);
                    response.EnsureSuccessStatusCode();

                    return true;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public async Task<bool> DeleteModuleAsync(int moduleId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/api/modules/{moduleId}");
                    response.EnsureSuccessStatusCode();
                    return true;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public static bool ValidateModule(Module module, List<Module> moduleList )
        {
            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(module.Name) || string.IsNullOrWhiteSpace(module.Code))
            {
                MessageBox.Show("Please enter all fields (Name, Code).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the code already exist
            if (moduleList.Any(s => s.Code == module.Code))
            {
                MessageBox.Show($"Module with code '{module.Code}' already exists.", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the code contains spaces
            if (module.Code.Contains(" "))
            {
                MessageBox.Show("Module code should not contain spaces.", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
