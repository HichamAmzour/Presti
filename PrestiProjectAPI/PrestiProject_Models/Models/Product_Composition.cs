using System;
using PrestiProject_Models.Interfaces;


namespace PrestiProject_Models.Models
{
    public class Product_Composition : IProduct_Composition
    {
        public string UID { get; set; }
        public int PDTC_Quantity { get; set; }
        public float PDTC_Price { get; set; }
        public string PDTC_Unite { get; set; }
        public string PDTC_Libelle { get; set; }
        public string PDTC_Description { get; set; }
        public float PDTC_Unit_Cost { get; set; }
        public float PDTC_Extended_Cost { get; set; }
        public string PDTC_UID_Composant { get; set; }
        public string PDTC_UID_Compose { get; set; }
    }
}
