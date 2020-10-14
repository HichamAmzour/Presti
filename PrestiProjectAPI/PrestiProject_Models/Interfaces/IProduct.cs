namespace PrestiProject_Models.Interfaces
{
    public interface IProduct
    {
        string PDTC_Unite { get; set; }
        string PRO_Description { get; set; }
        bool PRO_Enable_Retail_Sales { get; set; }
        string PRO_Model_Number { get; set; }
        string PRO_Name { get; set; }
        float PRO_Price { get; set; }
        float PRO_Retail_Price { get; set; }
        float PRO_Retail_Tax { get; set; }
        float PRO_Special_Price { get; set; }
        float PRO_Supply_Price { get; set; }
        string PRO_Type { get; set; }
        string PRO_UID_Brand { get; set; }
        string PRO_UID_Category { get; set; }
        string PRO_Video_URL { get; set; }
        string UID { get; set; }
    }
}