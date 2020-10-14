using System;

namespace PrestiProject_Models.Interfaces
{
    public interface IFile
    {
        DateTime Date { get; set; }
        string FIL_Name { get; set; }
        string FIL_Path { get; set; }
        string FIL_UID_Origin { get; set; }
        string UID { get; set; }
    }
}