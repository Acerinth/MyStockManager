using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Prijevoznik
	{
		public int Id { set; get;}
		public String Naziv { set; get;}
		public String Kontakt { set; get;}
		public String Telefon { set; get;}
		public String Email { set; get;}
		public int IdMjesto { set; get; }
		public String NazivMjesta { set; get;}

		public Prijevoznik ()
		{
		}

		public Prijevoznik(NpgsqlDataReader dr) {
			if (dr != null) {
				Id = int.Parse (dr ["id_prijevoznik"].ToString());
				Naziv = dr["naziv"].ToString();
				Kontakt = dr["kontakt"].ToString();
				Telefon = dr ["telefon"].ToString();
				Email = dr ["email"].ToString();
				IdMjesto = int.Parse (dr ["id_mjesto"].ToString());
				NazivMjesta = dr ["naziv_mjesta"].ToString();
			}
		}

		public static Prijevoznik DohvatiPrijevoznika(int idPrijevoznik) {
			String sqlUpit = "SELECT prijevoznik.*, mjesto.naziv AS naziv_mjesta FROM prijevoznik, mjesto WHERE prijevoznik.id_mjesto=mjesto.id_mjesto AND id_prijevoznik = " + idPrijevoznik;
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			Prijevoznik p = null;
			if (dr.Read ()) {
				p = new Prijevoznik (dr);
			}
			dr.Close ();
			return p;
		}

		public static List<Prijevoznik> DohvatiPrijevoznike() {
			List<Prijevoznik> listaPrijevoznici = new List<Prijevoznik> ();
			String sqlQuery = "SELECT prijevoznik.*, mjesto.naziv AS naziv_mjesta FROM prijevoznik, mjesto WHERE prijevoznik.id_mjesto=mjesto.id_mjesto ORDER BY id_prijevoznik;";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				Prijevoznik p = new Prijevoznik (dr);
				listaPrijevoznici.Add (p);
			}
			dr.Close ();
			return listaPrijevoznici;
		}
	}
}

