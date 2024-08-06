using Newtonsoft.Json;
using PerformanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTracker.Services
{
    internal class StudySessionService
    {
        private readonly string baseUrl;
        public StudySessionService(string url)
        {
            baseUrl = url;
        }
        public async Task<List<StudySession>> LoadAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{baseUrl}/api/studySessions");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<StudySession> modules = JsonConvert.DeserializeObject<List<StudySession>>(responseBody);

                    return modules;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<StudySession>();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<StudySession>();
                }
            }
        }
        public async Task<bool> AddStudySessionAsync(StudySession studySession)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(studySession);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"{baseUrl}/api/studysessions", content);
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
        public async Task<bool> DeleteStudySessionAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/api/studysessions/{id}");
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
        public async Task<bool> UpdateStudySessionAsync(StudySession studySession)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(studySession);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{baseUrl}/api/studysessions/{studySession.Id}", content);
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

        public static bool ValidateSession( StudySession session, List<StudySession> studySessions )
        {
            if (session.SessionTime > 24 && session.SessionType )
            {
                MessageBox.Show("Study time should be less than 24 hours.", "Invalid Session Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            double totalSessionTime = studySessions
                .Where(s => s.SessionDate.Date == session.SessionDate.Date && s.SessionType)
                .Sum(s => s.SessionTime);

            if ( session.SessionType && totalSessionTime + session.SessionTime >= 24)
            {
                MessageBox.Show("Total study time for the day should be less than 24 hours.", "Invalid Session Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
