namespace PrestiProject_Models.Interfaces
{
    public interface IColor
    {
        string Color_Name { get; set; }
        string Hex { get; set; }
        string RGB { get; set; }
        string UID { get; set; }
        string UID_Product { get; set; }
    }
}