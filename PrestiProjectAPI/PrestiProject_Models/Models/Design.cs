using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Design : IDesign
    {
        public string UID { get; set; }
        public string Design_Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
