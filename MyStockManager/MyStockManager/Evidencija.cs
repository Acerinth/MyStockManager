using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Evidencija
	{
		public int IdArtikl { set; get; }
		public Artikl Artikl { set; get; }
		public DateTime Datum { set; get; }
		public int Stanje { set; get; }

		public Evidencija ()
		{
		}

		public Evidencija (NpgsqlDataReader dr) {
			IdArtikl = int.Parse (dr ["id_artikl"].ToString ());
			Datum = DateTime.Parse (dr ["datum"].ToString ());
			Stanje = int.Parse (dr ["stanje"].ToString ());
			Artikl = null;
		}

		public static List<Evidencija> DohvatiEvidenciju() {
			String sqlUpit = "SELECT * FROM evidencija";
			List<Evidencija> listaEvidencija = new List<Evidencija> ();
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			while (dr.Read ()) {
				Evidencija e = new Evidencija (dr);
				listaEvidencija.Add (e);
			}
			dr.Close ();
			foreach (Evidencija item in listaEvidencija) {
				item.Artikl = Artikl.DohvatiArtikl (item.IdArtikl);
			}

			return listaEvidencija;
		}

	}
}

