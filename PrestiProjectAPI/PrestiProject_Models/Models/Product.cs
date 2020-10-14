using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class Product : IProduct
    {
        public string UID { get; set; }
        public string PRO_Name { get; set; }
        public string PRO_Type { get; set; }
        public string PRO_Model_Number { get; set; }
        public float PRO_Price { get; set; }
        public float PRO_Supply_Price { get; set; }
        public string PRO_Video_URL { get; set; }
        public string PRO_Description { get; set; }
        public float PRO_Retail_Price { get; set; }
        public string PDTC_Unite { get; set; }
        public float PRO_Special_Price { get; set; }
        public float PRO_Retail_Tax { get; set; }
        public bool  PRO_Enable_Retail_Sales { get; set; }
        public string PRO_UID_Category { get; set; }
        public string PRO_UID_Brand { get; set; }
    }
}
