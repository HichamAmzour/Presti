using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Product_Command_Details : IProduct_Command_Details
    {
        public string UID             { get; set; }
        public int PRO_Qte         { get; set; }
        public float Total_Price     { get; set; }
        public string UID_PRO         { get; set; }
        public string UID_PRO_Command { get; set; }

    }
}
