using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTracker.Models
{
    public class StudySession
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public DateTime SessionDate { get; set; }
        public double SessionTime { get; set; }
        public bool SessionType { get; set; }
        public double Progress { get; set; }

        public StudySession() { }

        public StudySession(int id, int moduleId, Module module, DateTime date, double sessionTime, bool sessionType, double progress)
        {
            Id = id;
            ModuleId = moduleId;
            Module = module;
            SessionDate = date;
            SessionTime = sessionTime;
            SessionType = sessionType;
            Progress = progress;
        }

        // Custom properties
        public string ModuleCode => Module?.Code;
        public string SessionTypeDisplay => SessionType ? "Study" : "Break";
    }
}
