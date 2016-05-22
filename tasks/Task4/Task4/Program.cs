using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 2);
            lsg1.Installed(2, LastSchaltprorgamm.KIRCHENBANK_HEIZUNG);
            lsg1.Installed(4, LastSchaltprorgamm.NACHT_SPEICHER);
            var lsg2 = new SwitchingUnit("G23-520-C.00/212-002190", "000198785", 1);
            lsg2.Installed(0, LastSchaltprorgamm.KIRCHENBANK_HEIZUNG);
            

            var items = new IItem []
           {
                new PrivatMeter  ("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM,         GeraeteID.VDK_3P_100A),
                new PrivatMeter  ("G23-510-C.00/452-000347", "000010456", Tarifmodell.PRIVAT_STROM_PREMIUM, GeraeteID.VDK_3P_100A),
                new PrivatMeter  ("G23-511-C.00/231-001236", "000009876", Tarifmodell.PRIVAT_STROM_WEB,     GeraeteID.VDK_3P_60A),
                new PrivatMeter  ("G23-512-C.00/211-004523", "000011234", Tarifmodell.PRIVAT_STROM,         GeraeteID.VDK_1P),
                new PrivatMeter  ("G23-512-C.00/211-000527", "000981011", Tarifmodell.PRIVAT_STROM_WEB,     GeraeteID.VDK_1P),
                new PrivatMeter  ("G23-512-C.00/212-000980", "000981211", Tarifmodell.PRIVAT_STROM_PREMIUM, GeraeteID.VDK_1P),
                lsg1,
                lsg2,
                new SwitchingUnit("G23-520-C.00/212-002567", "000112567",0),

            };

            foreach (var x in items)
            {
                Console.WriteLine($"{x.GerateBeschreibung} {x.getPB_nr ()}");
            }

            ///
            /// Json TestCode
            ///
            
            ///    // 1. serialize a single book to a JSON string
            Console.WriteLine(JsonConvert.SerializeObject(lsg1));
            // 2. ... with nicer formatting
            Console.WriteLine(JsonConvert.SerializeObject(lsg1, Formatting.Indented));
            // 3. serialize all items
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.All};
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // 4. store json string t5o file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            // 5. deserialize items from "items.json"
            // ... and print Description and Price of deserialized items
            var textFromFile = File.ReadAllText(filename);
            // Schaffe es nicht das ich keinen Fehler beim Einlesen bekomme ... Brauche zu diesem Thema etwas unterstützung ... 
            //var itemsFromFile = JsonConvert.DeserializeObject<IItem[]>(textFromFile, settings);
            //foreach (var x in itemsFromFile)
            //{
            //    Console.WriteLine($"{x.GerateBeschreibung} {x.getPB_nr()}");
            //}
        }
    }
}
