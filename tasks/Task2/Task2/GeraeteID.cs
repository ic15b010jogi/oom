using System;

namespace Task2
{
    public enum GeraeteID
    {
    // <summary>
    // 1 phasen Meter
    // </summary>
    VDK_1P,
    // <summary>
    // 3 phasen Meter 60A
    // </summary>
    VDK_3P_60A,
    // <summary>
    // 3 phasen Meter 100A
    // </summary>
    VDK_3P_100A,
   
    }

    public enum Tarifmodell
    {
    // <summary>
    // Privat Strom Normal
    // </summary>
    PRIVAT_STROM,
    // <summary>
    // Privat Strom mit Web-Portal
    // </summary>
    PRIVAT_STROM_WEB,
    // <summary>
    // Privat Strom Premium Kunde
    // </summary>
    PRIVAT_STROM_PREMIUM,
    // <summary>
    // Privat Strom Premium Kunde
    // </summary>
    FIRMA_STROM,
    }
}

