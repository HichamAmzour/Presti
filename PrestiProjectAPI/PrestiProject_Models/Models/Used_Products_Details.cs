using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Used_Products_Details : IUsed_Products_Details
    {
        public string UID { get; set; }
        public DateTime Date { get; set; }
        public int Qte { get; set; }
        public int Damaged_numb { get; set; }
        public string UID_Project { get; set; }
        public string UID_PRO { get; set; }
        
    }
}
