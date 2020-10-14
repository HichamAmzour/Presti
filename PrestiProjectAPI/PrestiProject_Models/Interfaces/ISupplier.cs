namespace PrestiProject_Models.Interfaces
{
    public interface ISupplier
    {
        string SUP_Contact_Name { get; set; }
        string SUP_Email { get; set; }
        string SUP_Name { get; set; }
        string SUP_Phone { get; set; }
        string SUP_Type { get; set; }
        string SUP_URL { get; set; }
        string UID { get; set; }
        string UID_Address { get; set; }
    }
}