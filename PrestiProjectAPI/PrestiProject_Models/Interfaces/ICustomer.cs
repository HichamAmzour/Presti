namespace PrestiProject_Models.Interfaces
{
    public interface ICustomer: IUser
    {
        string CUS_Notes { get; set; }
        string CUS_Notes_2 { get; set; }
        string CUS_Phone { get; set; }
        string CUS_Spouse_First_Name { get; set; }
        string CUS_Spouse_Last_Name { get; set; }
    }
}