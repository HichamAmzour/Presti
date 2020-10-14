using PrestiProject_Models.Interfaces;
using System;


namespace PrestiProject_Models.Models
{
    public class Color : IColor
    {
        public string UID { get; set; }
        public string Color_Name { get; set; }
        public string Hex { get; set; }
        public string RGB { get; set; }
        public string UID_Product { get; set; }

    }
}
