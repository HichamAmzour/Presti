using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Service_Call : IService_Call
    {
        public string UID { get; set; }
        public string Caller_Info { get; set; }
        public string Call_Description { get; set; }
        public DateTime Date_time { get; set; }
        public string UID_Customer { get; set; }
    
    }
}
