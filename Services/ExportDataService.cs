using iTextSharp.text.pdf;
using iTextSharp.text;
using PerformanceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTracker.Services
{
    internal class ExportDataService
    {
        public static void ExportToPdf(List<StudySession> sessions, String filterDateRange )
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.AddExtension = true;

                // Get the current date and time
                string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                saveFileDialog.FileName = $"WeeklyReport_{currentDateTime}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog.FileName;

                    Document document = new Document();
                    PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                    document.Open();

                    document.Add(new Paragraph("Filtered Study Sessions"));
                    document.Add(new Paragraph("\n"));

                    string[] weekDates = filterDateRange.Split(new[] { " - " }, StringSplitOptions.None);
                    document.Add(new Paragraph($"Filter between {weekDates[0]} - {weekDates[1]}"));
                    document.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(5);
                    table.WidthPercentage = 100;

                    table.AddCell("Module Code");
                    table.AddCell("Session Date");
                    table.AddCell("Session Time ( h )");
                    table.AddCell("Session Type");
                    table.AddCell("Progress ( % )");

                    foreach (var session in sessions)
                    {
                        table.AddCell(session.Module.Code);
                        table.AddCell(session.SessionDate.ToShortDateString());
                        table.AddCell(session.SessionTime.ToString("F2"));
                        table.AddCell(session.SessionType ? "Study" : "Break");
                        table.AddCell(session.Progress.ToString("F0"));
                    }
                    document.Add(table);

                    Dictionary<string, double> studyTimeTotals = new Dictionary<string, double>();
                    Dictionary<string, double> breakTimeTotals = new Dictionary<string, double>();
                    foreach (var session in sessions)
                    {
                        string moduleCode = session.Module.Code;
                        double sessionTime = session.SessionTime;

                        if (session.SessionType)
                        {
                            if (!studyTimeTotals.ContainsKey(moduleCode))
                                studyTimeTotals[moduleCode] = 0;

                            studyTimeTotals[moduleCode] += sessionTime;
                        }
                        else
                        {
                            if (!breakTimeTotals.ContainsKey(moduleCode))
                                breakTimeTotals[moduleCode] = 0;

                            breakTimeTotals[moduleCode] += sessionTime;
                        }
                    }

                    // Add module-wise totals
                    document.Add(new Paragraph("\nModule-wise Totals:"));

                    foreach (var moduleCode in studyTimeTotals.Keys)
                    {
                        string totalStudyTime = studyTimeTotals[moduleCode].ToString("F2");
                        document.Add(new Paragraph($"{moduleCode} (Total Study Time): {totalStudyTime} hours"));
                    }

                    foreach (var moduleCode in breakTimeTotals.Keys)
                    {
                        string totalBreakTime = breakTimeTotals[moduleCode].ToString("F2");
                        document.Add(new Paragraph($"{moduleCode} (Total Break Time): {totalBreakTime} hours"));
                    }

                    document.Close();

                    MessageBox.Show($"PDF Report saved to {path}", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



    }
}
