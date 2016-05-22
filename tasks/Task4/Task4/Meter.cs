using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
 	public class PrivatMeter : IItem
	{
    private decimal pb_nr_tarif;
    private Tarifmodell Modell;

    /// <summary>
    /// Creates a new book object.
	/// </summary>
	/// <param name="title">Title must not be empty.</param>
	/// <param name="isbn">International Standard Book Number.</param>
	/// <param name="price">Price must not be negative.</param>
	public PrivatMeter(string fertigungs_nr, string kunden_nr, Tarifmodell modell, GeraeteID id)
        {
        if (string.IsNullOrWhiteSpace(fertigungs_nr)) throw new ArgumentException("Fertigungs Nr. must not be empty.", nameof(fertigungs_nr));
        if (string.IsNullOrWhiteSpace(kunden_nr)) throw new ArgumentException("Kunden Nr. must not be empty.", nameof(kunden_nr));

        FertigungsNr = fertigungs_nr;
        KundenNr     = kunden_nr;
        ID = id;
        update_pb_nr(modell);
        
        }

    /// <summary>
    /// Bestimmt die Fertigungs Nr.
    /// </summary>
    public string FertigungsNr    { get; private set; }

    /// <summary>
    /// Bestimmt die Kunden Nr.
    /// </summary>
    public string KundenNr { get; private set; }
        
    /// <summary>
    /// Bestimmt die Kunden Nr.
    /// </summary>
    public GeraeteID ID { get; private set; }

     /// <summary>
     /// Geraet ist Installiert 
     /// </summary>
     public void Installed()
      {
            if (IsInstalled) throw new InvalidOperationException($"Meter {FertigungsNr} ist bereits installiert.");
            IsInstalled = true;
      }

     /// <summary>
     /// Interne Variable fuer die Bestimmung ob Meter bereits installiert ist.
     /// </summary>
     public bool IsInstalled { get; private set; }

     /// <summary>
     /// Update Parameterblock Nr.
     /// </summary>
     public void update_pb_nr (Tarifmodell modell)
       {
       Modell = modell;
       switch (modell)
           {
           case Tarifmodell.PRIVAT_STROM:         pb_nr_tarif = 1;   break;
           case Tarifmodell.PRIVAT_STROM_WEB:     pb_nr_tarif = 51;  break;
           case Tarifmodell.PRIVAT_STROM_PREMIUM: pb_nr_tarif = 101; break;
           default: throw new ArgumentException("Kein Kundentarif", nameof(modell)); 
           }
       }
     /// <summary> 

     #region IItem implementation

     /// <summary>
     /// Bestimmen der internen Parameterblock Nr.
     /// </summary>   
     public string GerateBeschreibung => "Meter: " + FertigungsNr;


     /// Bestimmen der internen Parameterblock Nr.
     /// </summary>
     public string getPB_nr()
       {
       return $"{pb_nr_tarif};";
       }

     #endregion
    }
}
