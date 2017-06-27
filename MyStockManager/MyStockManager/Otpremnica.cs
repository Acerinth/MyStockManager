using System;
using System.Collections.Generic;
using Npgsql;

namespace MyStockManager
{
	public class Otpremnica
	{
		public String IdOtpremnica { set; get; }
		public DateTime Datum { set; get; }
		public String BrojNarudzbeKupca { set; get; }
		public int IdPrijevoznik { set; get; }
		public Prijevoznik Prijevoznik { set; get; }
		public int IdZaposlenik { set; get; }
		public Zaposlenik Zaposlenik { set; get; }
		public List<Stavka> ListaStavki { set; get; }

		public Otpremnica ()
		{
		}

		public Otpremnica (NpgsqlDataReader dr) {
			if (dr != null) {
				IdOtpremnica = dr ["id_otpremnica"].ToString ();
				Datum = DateTime.Parse(dr ["datum"].ToString ());
				BrojNarudzbeKupca = dr ["broj_narudzbe_kupca"].ToString ();
				IdPrijevoznik = int.Parse (dr ["id_prijevoznik"].ToString ());
				IdZaposlenik = int.Parse (dr ["id_zaposlenik"].ToString ());
			}
		}

		public static List<Otpremnica> DohvatiOtpremnice() {
			String sqlUpit = "SELECT * FROM otpremnica";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			List<Otpremnica> listaOtpremnica = new List<Otpremnica> ();
			while (dr.Read ()) {
				Otpremnica o = new Otpremnica (dr);
				listaOtpremnica.Add (o);
			}
			dr.Close ();
			foreach (Otpremnica item in listaOtpremnica) {
				item.Prijevoznik = Prijevoznik.DohvatiPrijevoznika (item.IdPrijevoznik);
				item.Zaposlenik = Zaposlenik.DohvatiZaposlenika (item.IdZaposlenik);
				item.ListaStavki = Stavka.DohvatiStavke (item.IdOtpremnica, 1);
			}
			return listaOtpremnica;
		}
	}
}

