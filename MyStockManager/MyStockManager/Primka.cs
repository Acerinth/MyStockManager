using System;
using System.Collections.Generic;
using Npgsql;

namespace MyStockManager
{
	public class Primka
	{
		public String IdPrimka { set; get; }
		public DateTime Datum { set; get; }
		public String BrojDostavnice { set; get; }
		public int IdPrijevoznik { set; get; }
		public Prijevoznik Prijevoznik { set; get; }
		public int IdDobavljac { set; get; }
		public Dobavljac Dobavljac {set;get; }
		public int IdZaposlenik { set; get; }
		public Zaposlenik Zaposlenik { set; get; }
		public List<Stavka> ListaStavki { set; get; }

		public Primka (String idPrim, DateTime dat, String brojDost, int idPrij, Prijevoznik p, int idDob, Dobavljac d, int idZap, Zaposlenik z, List<Stavka> stavke)
		{
			IdPrimka = idPrim;
			BrojDostavnice = brojDost;
			Datum = dat;
			IdPrijevoznik = idPrij;
			Prijevoznik = p;
			IdDobavljac = idDob;
			Dobavljac = d;
			IdZaposlenik = idZap;
			Zaposlenik = z;
			ListaStavki = stavke;
		}

		public Primka (NpgsqlDataReader dr) {
			if (dr != null) {
				IdPrimka = dr ["id_primka"].ToString ();
				Datum = DateTime.Parse(dr ["datum"].ToString ()); //TO DO: RIJEŠITI PRIKAZ DATUMA
				BrojDostavnice = dr ["broj_dostavnice"].ToString ();
				IdPrijevoznik = int.Parse (dr ["id_prijevoznik"].ToString ());
				IdDobavljac = int.Parse (dr ["id_dobavljac"].ToString ());
				IdZaposlenik = int.Parse (dr ["id_zaposlenik"].ToString ());
			}
		}

		public int Spremi() {
			String sqlUpit = "INSERT INTO primka VALUES ('" + IdPrimka + "', '" + Datum.ToString ("dd.MM.yyyy. HH:mm:ss") + "', '" 
				+ BrojDostavnice + "', " + IdPrijevoznik + ", " + IdDobavljac + ", " + IdZaposlenik + ")";
			int success = DatabaseConnection.Instance.executeQuery (sqlUpit);
			int generalSuccess = 1;

			if (success == 1) {
				foreach (Stavka s in ListaStavki) {
					String sqlUpitStavke = "INSERT INTO stavke_primke VALUES ('" + IdPrimka + "', " + s.IdArtikl + ", " + s.Kolicina + ")";
					int stavkaSuccess = DatabaseConnection.Instance.executeQuery (sqlUpitStavke);
					generalSuccess *= stavkaSuccess;
				}
			}
			return generalSuccess;

		}

		private void dohvatiPodatke() {
			Dobavljac = Dobavljac.DohvatiDobavljaca (IdDobavljac);
			Zaposlenik = Zaposlenik.DohvatiZaposlenika (IdZaposlenik);
			Prijevoznik = Prijevoznik.DohvatiPrijevoznika (IdPrijevoznik);
		}

		private void dohvatiStavke() {
			ListaStavki = Stavka.DohvatiStavke (IdPrimka, 0);
		}

		public static Primka DohvatiPrimku(String idPrimka) {
			String sqlUpit = "SELECT * FROM primka WHERE id_primka = '" + idPrimka + "'";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			Primka p = null;
			if (dr.Read ()) {
				p = new Primka (dr);
			}
			dr.Close ();
			p.dohvatiPodatke ();
			p.dohvatiStavke ();
			return p;
		}

		public static List<Primka> DohvatiPrimke() {
			List<Primka> listaPrimki = new List<Primka> ();
			String sqlUpit = "SELECT * FROM primka";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			while (dr.Read()) {
				Primka p = new Primka (dr);
				listaPrimki.Add (p);
			}
			dr.Close ();
			foreach (Primka item in listaPrimki) {
				item.dohvatiPodatke ();
			}
			return listaPrimki;
		}
	}
}

