namespace PrestiProject_Models.Interfaces
{
    public interface IAddress
    {
        string ADR_City { get; set; }
        string ADR_Country { get; set; }
        string ADR_Number { get; set; }
        string ADR_Postal_Code { get; set; }
        string ADR_State { get; set; }
        string ADR_Street { get; set; }
        string ADR_Suite { get; set; }
        string UID { get; set; }
    }
}