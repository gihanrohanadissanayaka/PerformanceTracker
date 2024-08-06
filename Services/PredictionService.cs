using Newtonsoft.Json;
using PerformanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTracker.Services
{
    internal class PredictionService
    {
        private readonly string baseUrl;
        public PredictionService(string url)
        {
            baseUrl = url;
        }
        public async Task<string> LoadPredictionAsync(DateTime date, int moduleId)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Construct the query parameters for the request
                    string endpointUrl = $"{baseUrl}/api/results/predictions?date={date:yyyy-MM-dd}&moduleId={moduleId}";

                    // Make the HTTP GET request
                    HttpResponseMessage response = await client.GetAsync(endpointUrl);
                    response.EnsureSuccessStatusCode();

                    // Read the response body as a string
                    string result = await response.Content.ReadAsStringAsync();

                    return result; // The result should be "Pass" or "Fail"
                }
                catch (HttpRequestException e)
                {
                    // Handle HTTP request errors
                    MessageBox.Show($"Request error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
                catch (Exception e)
                {
                    // Handle other potential errors
                    MessageBox.Show($"Unexpected error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Error";
                }
            }
        }

        public static double PredictFutureProgress(List<StudySession> sessions, DateTime futureDate )
        {
            if (sessions.Count == 0)
                throw new ArgumentException("Session list is empty.");

            List<double> dates = sessions.Select(s => s.SessionDate.ToOADate()).ToList();
            List<double> sessionTimes = sessions.Where(s => s.SessionType == true).Select(s => s.SessionTime).ToList();
            List<double> progresses = sessions.Select(s => s.Progress).ToList();

            double avgDate = dates.Average();
            double avgSession = sessionTimes.Average();
            double avgProgress = progresses.Average();

            double numerator1 = dates.Zip(progresses, (x, y) => (x - avgDate) * (y - avgProgress)).Sum();
            double numerator2 = sessionTimes.Zip(progresses, (t, y) => (t - avgSession) * (y - avgProgress)).Sum();
            double denominator1 = dates.Sum(x => Math.Pow(x - avgDate, 2));
            double denominator2 = sessionTimes.Sum(t => Math.Pow(t - avgSession, 2));

            double slope1 = numerator1 / denominator1;
            double slope2 = numerator2 / denominator2;
            double intercept = avgProgress - slope1 * avgDate - slope2 * avgSession;

            double futureDateAsNumber = futureDate.ToOADate();
            double predictedProgress = intercept + slope1 * futureDateAsNumber + slope2 * 1.5;

            // predict between 0 and 100
            predictedProgress = Math.Max(0, Math.Min(100, predictedProgress));

            return predictedProgress;
        }



        public static string GetGrade(double percentage)
        {
            if (percentage >= 90)
            {
                return "A+";
            }
            else if (percentage >= 85)
            {
                return "A";
            }
            else if (percentage >= 80)
            {
                return "A-";
            }
            else if (percentage >= 75)
            {
                return "B+";
            }
            else if (percentage >= 70)
            {
                return "B";
            }
            else if (percentage >= 65)
            {
                return "B-";
            }
            else if (percentage >= 60)
            {
                return "C+";
            }
            else if (percentage >= 55)
            {
                return "C";
            }
            else if (percentage >= 50)
            {
                return "C-";
            }
            else
            {
                return "F";
            }
        }
    }
}
