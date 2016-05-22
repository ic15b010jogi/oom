using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
 	public class PrivatMeter
	{
    private decimal pb_nr_tarif;

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
    public string FertigungsNr    { get; }

    /// <summary>
    /// Bestimmt die Kunden Nr.
    /// </summary>
    public string KundenNr { get; }


    /// <summary>
    /// Bestimmt die Kunden Nr.
    /// </summary>
    public GeraeteID ID { get; }

    /// <summary>
    /// Updates the book's price.
    /// </summary>
    /// <param name="newPrice">Price must not be negative.</param>
    /// <param name="newCurrency">Currency.</param>
    public void update_pb_nr (Tarifmodell modell)
       {
       switch (modell)
           {
           case Tarifmodell.PRIVAT_STROM:         pb_nr_tarif = 1;   break;
           case Tarifmodell.PRIVAT_STROM_WEB:     pb_nr_tarif = 51;  break;
           case Tarifmodell.PRIVAT_STROM_PREMIUM: pb_nr_tarif = 101; break;
           default: throw new ArgumentException("Kein Kundentarif", nameof(modell)); 
           }
       }
    public decimal getPB_nr()
       {
       return pb_nr_tarif;
       }
    }
}
