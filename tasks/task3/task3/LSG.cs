using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class SwitchingUnit : IItem
    {
        private decimal       MaxAnzRelais;
        private decimal       AktRelais;
        private decimal [] pbNrLSG = new decimal [5];
        private bool[] pbNrLSG_is_used = new bool[5];
        
        /// <summary>
        /// Creates a new book object.
        /// </summary>
        /// <param name="title">Title must not be empty.</param>
        /// <param name="isbn">International Standard Book Number.</param>
        /// <param name="price">Price must not be negative.</param>
        public SwitchingUnit(string fertigungs_nr, string kunden_nr, decimal anz_relais)
        {
            if (string.IsNullOrWhiteSpace(fertigungs_nr)) throw new ArgumentException("Fertigungs Nr. must not be empty.", nameof(fertigungs_nr));
            if (string.IsNullOrWhiteSpace(kunden_nr)) throw new ArgumentException("Kunden Nr. must not be empty.", nameof(kunden_nr));
            if ((anz_relais < 0) || (anz_relais > 5)) throw new ArgumentException("Anzahl Relais ist nicht OK", nameof(anz_relais));


            FertigungsNr = fertigungs_nr;
            KundenNr = kunden_nr;
            MaxAnzRelais = anz_relais;
            AktRelais = 0;

        }

        /// <summary>
        /// Bestimmt die Fertigungs Nr.
        /// </summary>
        public string FertigungsNr { get; }

        /// <summary>
        /// Bestimmt die Kunden Nr.
        /// </summary>
        public string KundenNr { get; }

        /// <summary>
        /// Bestimmt die Kunden Nr.
        /// </summary>
        public GeraeteID ID { get; }

        /// <summary>
        /// Geraet ist Installiert 
        /// </summary>
        public void Installed(decimal relais_nr, LastSchaltprorgamm lsg_prg )
        {
            if ((relais_nr < 0) || (relais_nr > 5)) throw new ArgumentException("Relais Nr. ist nicht OK.", nameof(relais_nr));
            if (pbNrLSG_is_used[(int)relais_nr]) throw new ArgumentException("Relais ist schon bestueckt.", nameof(relais_nr));
            if ((AktRelais+1) > (MaxAnzRelais)) throw new ArgumentException("Nicht so viele Releais bestückt.", nameof(relais_nr));
            pbNrLSG_is_used[(int)relais_nr] = true;
            pbNrLSG[(int)relais_nr] = update_pb_nr(lsg_prg);
            AktRelais ++;
        }

        
        /// <summary>
        /// Update Parameterblock Nr.
        /// </summary>
        public decimal update_pb_nr (LastSchaltprorgamm lsg_prg)
        {
            switch (lsg_prg)
            {
                case LastSchaltprorgamm.NACHT_SPEICHER: return 200;
                case LastSchaltprorgamm.KIRCHENBANK_HEIZUNG: return 258;
                default: throw new ArgumentException("Kein Kundentarif", nameof(lsg_prg));
            }
        }
        /// <summary> 

        #region IItem implementation

        /// <summary>
        /// Bestimmen der internen Parameterblock Nr.
        /// </summary>   
        public string GerateBeschreibung => "SwitchingUnit: " + FertigungsNr;


        /// Bestimmen der internen Parameterblock Nr.
        /// </summary>
        public string getPB_nr()
        {
            string pb = "";
            for (int i_pb = 0; i_pb < 5; i_pb++)
            {
             if (pbNrLSG_is_used[i_pb])
                {
                    pb = pb + $"{pbNrLSG[i_pb]};";
                };
            }
            return pb;
        }

        #endregion
    }
}