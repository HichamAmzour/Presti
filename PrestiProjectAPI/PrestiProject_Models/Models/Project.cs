using System;
using PrestiProject_Models.Interfaces;


namespace PrestiProject_Models.Models
{
    public class Project : IProject
    {
        public string UID { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Finished_Date { get; set; }
        public string Project_Title { get; set; }
        public string Progression { get; set; }
        public string Status { get; set; }
        public float Cost { get; set; }
        public string Canceled_or_stoped_cause { get; set; }
        public string UID_Property { get; set; }
    }
}
