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
			String sqlQuery = "SELECT * FROM kategorija ORDER BY id_kategorija";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				Kategorija k = new Kategorija (dr);
				listaKategorije.Add (k);
			}
			dr.Close ();
			return listaKategorije;
		}

		public int Spremi() {
			String sqlQuery = "";
			if (IdKategorija == 0) {
				sqlQuery = "INSERT INTO kategorija VALUES(DEFAULT, '" + NazivKategorija + "', '" + Opis + "')";
			} else {
				sqlQuery = "UPDATE kategorija SET id_kategorija = " + IdKategorija
				+ ", naziv = '" + NazivKategorija
					+ "', opis = '" + Opis + "' WHERE id_kategorija = " + IdKategorija;
			}
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}

		public int Obrisi() {
			String sqlQuery = "DELETE FROM kategorija WHERE id_kategorija = " + IdKategorija + ";";
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}
	}
}

