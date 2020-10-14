namespace PrestiProject_Models.Interfaces
{
    public interface IEmployee : IUser
    {
        string EMP_Employee_Number { get; set; }
        string EMP_Employee_Service { get; set; }
        string EMP_Extension_Number { get; set; }
        string EMP_Last_Login_Date { get; set; }
        string EMP_Phone { get; set; }
    }
}