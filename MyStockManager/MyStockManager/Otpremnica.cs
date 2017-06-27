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

		public Otpremnica (String idOtpr, DateTime dat, String brojNarKup, int idPrij, Prijevoznik p, int idZap, Zaposlenik z, List<Stavka> stavke)
		{
			IdOtpremnica = idOtpr;
			BrojNarudzbeKupca = brojNarKup;
			Datum = dat;
			IdPrijevoznik = idPrij;
			Prijevoznik = p;
			IdZaposlenik = idZap;
			Zaposlenik = z;
			ListaStavki = stavke;
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

		public int Spremi() {
			String sqlUpit = "INSERT INTO otpremnica VALUES ('" + IdOtpremnica + "', '" + Datum.ToString ("dd.MM.yyyy. HH:mm:ss") + "', '" 
				+ BrojNarudzbeKupca + "', " + IdPrijevoznik + ", " + IdZaposlenik + ")";
			int success = DatabaseConnection.Instance.executeQuery (sqlUpit);
			int generalSuccess = 1;

			if (success == 1) {
				foreach (Stavka s in ListaStavki) {
					String sqlUpitStavke = "INSERT INTO stavke_otpremnice VALUES ('" + IdOtpremnica + "', " + s.IdArtikl + ", " + s.Kolicina + ")";
					int stavkaSuccess = DatabaseConnection.Instance.executeQuery (sqlUpitStavke);
					generalSuccess *= stavkaSuccess;
				}
			}
			return generalSuccess;

		}

		private void dohvatiPodatke() {
			Zaposlenik = Zaposlenik.DohvatiZaposlenika (IdZaposlenik);
			Prijevoznik = Prijevoznik.DohvatiPrijevoznika (IdPrijevoznik);
		}

		private void dohvatiStavke() {
			ListaStavki = Stavka.DohvatiStavke (IdOtpremnica, 1);
		}

		public static Otpremnica DohvatiOtpremnicu(String idOtpremnica) {
			String sqlUpit = "SELECT * FROM otpremnica WHERE id_otpremnica = '" + idOtpremnica + "'";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			Otpremnica o = null;
			if (dr.Read ()) {
				o = new Otpremnica (dr);
			}
			dr.Close ();
			o.dohvatiPodatke ();
			o.dohvatiStavke ();
			return o;
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

