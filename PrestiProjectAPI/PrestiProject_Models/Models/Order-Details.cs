using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Order_Details : IOrder_Details
    {
        public string UID { get; set; }
        public DateTime Date { get; set; }
        public string UID_Customer { get; set; }
        public string UID_Design { get; set; }
    }
}
