using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Kategorija
	{
		public int IdKategorija { set; get; }
		public String NazivKategorija { set; get; }
		public String Opis { set; get;}

		public Kategorija ()
		{
		}

		public Kategorija(NpgsqlDataReader dr) {
			IdKategorija = int.Parse(dr ["id_kategorija"].ToString());
			NazivKategorija = dr["naziv"].ToString();
			Opis = dr ["opis"].ToString();
		}

		public static List<Kategorija> Dohvati() {
			List<Kategorija> listaKategorije = new List<Kategorija> ();
			String sqlQuery = "SELECT * FROM kategorija";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				Kategorija k = new Kategorija (dr);
				listaKategorije.Add (k);
			}
			dr.Close ();
			return listaKategorije;
		}
	}
}

