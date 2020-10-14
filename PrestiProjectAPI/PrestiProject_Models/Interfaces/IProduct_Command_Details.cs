namespace PrestiProject_Models.Interfaces
{
    public interface IProduct_Command_Details
    {
        int PRO_Qte { get; set; }
        float Total_Price { get; set; }
        string UID { get; set; }
        string UID_PRO { get; set; }
        string UID_PRO_Command { get; set; }
    }
}