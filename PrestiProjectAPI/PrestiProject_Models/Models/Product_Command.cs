using System;
using PrestiProject_Models.Interfaces;


namespace PrestiProject_Models.Models
{
    public class Product_Command : IProduct_Command
    {
        public string UID { get; set; }
        public DateTime Date { get; set; }
        public string UID_Supplier { get; set; }
    }
}
