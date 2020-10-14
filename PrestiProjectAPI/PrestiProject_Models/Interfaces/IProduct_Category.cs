using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Category
    {
        DateTime CAT_Date { get; set; }
        string CAT_Description { get; set; }
        string CAT_Name { get; set; }
        string UID { get; set; }
    }
}