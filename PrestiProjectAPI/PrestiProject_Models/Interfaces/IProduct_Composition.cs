namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Composition
    {
        string PDTC_Description { get; set; }
        float PDTC_Extended_Cost { get; set; }
        string PDTC_Libelle { get; set; }
        float PDTC_Price { get; set; }
        int PDTC_Quantity { get; set; }
        string PDTC_UID_Composant { get; set; }
        string PDTC_UID_Compose { get; set; }
        float PDTC_Unit_Cost { get; set; }
        string PDTC_Unite { get; set; }
        string UID { get; set; }
    }
}