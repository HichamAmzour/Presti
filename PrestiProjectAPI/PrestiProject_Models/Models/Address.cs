using PrestiProject_Models.Interfaces;
using System;


namespace PrestiProject_Models.Models
{
    public class Address : IAddress
    {
        public string UID        { get; set; }
        public string ADR_Number { get; set; }
        public string ADR_Street { get; set; }
        public string ADR_Suite  { get; set; }
        public string ADR_Postal_Code { get; set; }
        public string ADR_City    { get; set; }
        public string ADR_State   { get; set; }
        public string ADR_Country { get; set; }
	   
    }
}
