using System;
using PrestiProject_Models.Interfaces;


namespace PrestiProject_Models.Models
{
    public class Product_Stock : IProduct_Stock
    {
        public string UID { get; set; }
        public int Init_Qte { get; set; }
        public int Current_Qte { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Product_UID { get; set; }

    }
}
