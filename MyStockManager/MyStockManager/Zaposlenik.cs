using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Zaposlenik
	{
		public int IdZaposlenik { set; get; }
		public String Ime { set; get; }
		public String Prezime { set; get; }
		public String Telefon { set; get; }

		public Zaposlenik ()
		{
		}

		public Zaposlenik(NpgsqlDataReader dr) {
			if (dr != null) {
				IdZaposlenik = int.Parse (dr["id_zaposlenik"].ToString());
				Ime = dr ["ime"].ToString ();
				Prezime = dr ["prezime"].ToString ();
				Telefon = dr ["telefon"].ToString ();
			}
		}

		public static Zaposlenik DohvatiZaposlenika(int idZaposlenik) {
			String sqlUpit = "SELECT * FROM zaposlenik WHERE id_zaposlenik = " + idZaposlenik;
			Zaposlenik z = null;
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			if (dr.Read ()) {
				z = new Zaposlenik (dr);
			}
			dr.Close ();
			return z;
		}

		public static List<Zaposlenik> DohvatiZaposlenike() {
			List<Zaposlenik> listaZaposlenici = new List<Zaposlenik> ();
			String sqlUpit = "SELECT * FROM zaposlenik";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			while (dr.Read ()) {
				Zaposlenik z = new Zaposlenik (dr);
				listaZaposlenici.Add (z);
			}
			dr.Close ();
			return listaZaposlenici;
		}

		public override string ToString ()
		{
			return Ime + " " + Prezime;
		}
	}
}

