using System;

namespace PresrtiProject_API.ID_Provider
{
    public sealed class UID_Provider
    {

        public static string GetUID() =>  Guid.NewGuid().ToString().ToUpper();
        
    }

    public enum UIDKeys
    {
        ADD,
        COL,
        COM,
        EMP,
        FIL,
        ORD,
        PBR,
        PCA,
        PCO,
        PCM,
        PCD,
        PST,
        PRO,
        PRJ,
        PRP,
        SCL,
        UPD
    }
}
