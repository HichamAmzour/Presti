using PrestiProject_Models.Interfaces;
using System;

namespace PrestiProject_Models.Models
{
    public abstract class User : IUser
    {
        public string UID { get; set; }
        public string USR_Username { get; set; }
        public string USR_First_Name { get; set; }
        public string USR_Last_Name { get; set; }
        public byte[]   USR_Hashed_Password { get; set; }
        public byte[]  USR_Salt { get; set; }
        public string USR_Phone_Mobile { get; set; }
        public string USR_Email { get; set; }
        public DateTime USR_Create_Date { get; set; }
        public DateTime USR_BirthDay { get; set; }
        public string UID_Address { get; set; }

    }
}
