using System;
using PrestiProject_Models.Interfaces;


namespace PrestiProject_Models.Models
{
    public class Product_Category : IProduct_Category
    {
        public string UID { get; set; }
        public string CAT_Name { get; set; }
        public string CAT_Description { get; set; }
        public DateTime CAT_Date { get; set; }
    }
}
