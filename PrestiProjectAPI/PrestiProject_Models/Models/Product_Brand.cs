using System;
using PrestiProject_Models.Interfaces;



namespace PrestiProject_Models.Models
{
    public class Product_Brand : IProduct_Brand
    {
        public string UID { get; set; }
        public string BRA_Name { get; set; }
        public string BRA_Description { get; set; }
        public DateTime BRA_Date { get; set; }

    }
}
