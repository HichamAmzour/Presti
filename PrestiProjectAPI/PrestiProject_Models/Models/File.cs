using System;
using PrestiProject_Models.Interfaces;

namespace PrestiProject_Models.Models
{
    public class File : IFile
    {
        public string UID { get; set; }
        public string FIL_Path { get; set; }
        public string FIL_Name { get; set; }
        public string FIL_UID_Origin { get; set; }
        public DateTime Date { get; set; }
    }
}
