using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void LSG_NoParameter()
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 2);
            Assert.IsTrue(lsg1.getPB_nr() == "");
            Assert.IsTrue(lsg1.MaxAnzRelais == 2);
            Assert.IsTrue(lsg1.AktRelais == 0);

        }

        [Test]
        public void LSG_2Parameter()
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 2);
            lsg1.Installed(2, LastSchaltprorgamm.KIRCHENBANK_HEIZUNG);
            lsg1.Installed(4, LastSchaltprorgamm.NACHT_SPEICHER);
            Assert.IsTrue(lsg1.getPB_nr() == "258;200;");
            Assert.IsTrue(lsg1.MaxAnzRelais == 2);
            Assert.IsTrue(lsg1.AktRelais == 2);


        }
        [Test]
        public void LSG_RelaisAnzTest1()
        { 
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 5);
            lsg1.Installed(2, LastSchaltprorgamm.KIRCHENBANK_HEIZUNG);
            lsg1.Installed(4, LastSchaltprorgamm.NACHT_SPEICHER);
            lsg1.Installed(0, LastSchaltprorgamm.NACHT_SPEICHER);
            Assert.IsTrue(lsg1.MaxAnzRelais == 5);
            Assert.IsTrue(lsg1.AktRelais    == 3);

        }
        [Test]
        public void LSG_FertigungsNr()
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 5);
            Assert.IsTrue(lsg1.FertigungsNr == "G23-520-C.00/212-002421");
           
        }
        [Test]
        public void LSG_ID()
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 5);
            Assert.IsTrue(lsg1.ID == GeraeteID.LSG);

        }
        [Test]
        public void LSG_KundenNr()
        {
            var lsg1 = new SwitchingUnit("G23-520-C.00/212-002421", "000112456", 5);
            Assert.IsTrue(lsg1.KundenNr == "000112456");

        }
        [Test]
        public void METER_KundenNr()
        {
            var meter = new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM, GeraeteID.VDK_3P_100A);
            Assert.IsTrue(meter.KundenNr == "000002345");

        }
        [Test]
        public void METER_ID()
        {
            var meter = new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM, GeraeteID.VDK_3P_100A);
            Assert.IsTrue(meter.ID == GeraeteID.VDK_3P_100A);

        }
        [Test]
        public void METER_Parameter_PRIVAT_STROM()
        {
            var meter = new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM, GeraeteID.VDK_3P_100A);
            Assert.IsTrue(meter.getPB_nr() == "1;"); ;

        }
        [Test]
        public void METER_Parameter_PRIVAT_STROM_WEB()
        {
            var meter = new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM_WEB, GeraeteID.VDK_3P_100A);
            Assert.IsTrue(meter.getPB_nr() == "51;"); ;

        }
        [Test]
        public void METER_Parameter_PRIVAT_STROM_PREMIUM()
        {
            var meter = new PrivatMeter("G23-510-C.00/234-000527", "000002345", Tarifmodell.PRIVAT_STROM_PREMIUM, GeraeteID.VDK_3P_100A);
            Assert.IsTrue(meter.getPB_nr() == "101;"); ;

        }
    }
        
}
