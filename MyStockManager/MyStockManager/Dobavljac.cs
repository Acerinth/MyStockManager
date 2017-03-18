using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Dobavljac
	{
		public int Id { set; get;}
		public String Naziv { set; get;}
		public String Kontakt { set; get;}
		public String Telefon { set; get;}
		public String Email { set; get;}
		public int IdMjesto { set; get; }
		public String NazivMjesta { set; get;}

		public Dobavljac ()
		{
		}

		public Dobavljac(NpgsqlDataReader dr) {
			if (dr != null) {
				Id = int.Parse (dr ["id_dobavljac"].ToString());
				Naziv = dr["naziv"].ToString();
				Kontakt = dr["kontakt"].ToString();
				Telefon = dr ["telefon"].ToString();
				Email = dr ["email"].ToString();
				IdMjesto = int.Parse (dr ["id_mjesto"].ToString());
				NazivMjesta = dr ["naziv_mjesta"].ToString();
			}
		}

		public int Spremi() {
			String sqlQuery = "";
			if (Id == 0) {
				sqlQuery = "INSERT INTO dobavljac VALUES (DEFAULT, '" + Naziv
					+ "', '" + Kontakt + "', '" + Telefon + "', '" + Email + "', " + IdMjesto + ");";
			} else {
				sqlQuery = "UPDATE dobavljac SET naziv = '" + Naziv
					+ "', kontakt = '" + Kontakt
					+ "', telefon = '" + Telefon
					+ "', email = '" + Email
					+ "', id_mjesto = " + IdMjesto
					+ " WHERE id_dobavljac = " + Id + ";";
			}
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}

		public int Obrisi() {
			String sqlQuery = "DELETE FROM dobavljac WHERE id_dobavljac = " + Id + ";";
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}

		public static List<Dobavljac> DohvatiDobavljace() {
			List<Dobavljac> listaDobavljaci = new List<Dobavljac> ();
			String sqlQuery = "SELECT dobavljac.*, mjesto.naziv AS naziv_mjesta FROM dobavljac, mjesto WHERE dobavljac.id_mjesto=mjesto.id_mjesto ORDER BY id_dobavljac;";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				Dobavljac d = new Dobavljac (dr);
				listaDobavljaci.Add (d);
			}
			dr.Close ();
			return listaDobavljaci;
		}


	}
}

