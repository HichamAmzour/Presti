using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IUser
    {
        string UID { get; set; }
        string UID_Address { get; set; }
        DateTime USR_BirthDay { get; set; }
        DateTime USR_Create_Date { get; set; }
        string USR_Email { get; set; }
        string USR_First_Name { get; set; }
        byte[] USR_Hashed_Password { get; set; }
        string USR_Last_Name { get; set; }
        string USR_Phone_Mobile { get; set; }
        byte[] USR_Salt { get; set; }
        string USR_Username { get; set; }
    }
}