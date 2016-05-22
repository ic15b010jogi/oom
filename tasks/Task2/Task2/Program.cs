using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var PrivatMeter = new[]
            {
                new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM,         GeraeteID.VDK_3P_100A),
                new PrivatMeter("G23-510-C.00/452-000347", "000010456", Tarifmodell.PRIVAT_STROM_PREMIUM, GeraeteID.VDK_3P_100A),
                new PrivatMeter("G23-511-C.00/231-001236", "000009876", Tarifmodell.PRIVAT_STROM_WEB,     GeraeteID.VDK_3P_60A),
                new PrivatMeter("G23-512-C.00/211-004523", "000011234", Tarifmodell.PRIVAT_STROM,         GeraeteID.VDK_1P),
                new PrivatMeter("G23-512-C.00/211-000527", "000981011", Tarifmodell.PRIVAT_STROM_WEB,     GeraeteID.VDK_1P),
                new PrivatMeter("G23-512-C.00/212-000980", "000981211", Tarifmodell.PRIVAT_STROM_PREMIUM, GeraeteID.VDK_1P),
               
            };

             foreach (var b in PrivatMeter)
            {
                Console.WriteLine("{0} {1,-40} {2}", b.FertigungsNr, b.KundenNr, b.getPB_nr() );
            }

            var PrivatMeterS = PrivatMeter.Select(x => x.KundenNr).OrderBy(x => x);
            Console.WriteLine();
            Console.WriteLine("Fertigungs Nr.:");
            foreach (var x in PrivatMeterS) Console.WriteLine(x);
        }
    }
}
