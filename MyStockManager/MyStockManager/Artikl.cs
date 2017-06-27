using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class Artikl
	{
		public int Id { set; get;}
		public int IdKategorija { set; get; }
		public String NazivKategorija { set; get; }
		public String Naziv { set; get;}
		public String Opis { set; get;}
		public decimal Cijena { set; get;}
		public int Stanje { set; get;}
		public int ZalihaMin { set; get; }
		public int ZalihaMax { set; get; }
		public String IdJedinica { set; get;}

		public Artikl ()
		{
		}

		public Artikl(NpgsqlDataReader dr) {
			if (dr != null) {
				Id = int.Parse (dr ["id_artikl"].ToString());
				IdKategorija = int.Parse(dr["id_kategorija"].ToString());
				NazivKategorija = dr["naziv_kategorija"].ToString();
				Naziv = dr["naziv"].ToString();
				Opis = dr["opis"].ToString();
				Cijena = decimal.Parse(dr ["cijena"].ToString());
				Stanje = int.Parse(dr ["stanje"].ToString());
				ZalihaMin = int.Parse(dr["zaliha_min"].ToString());
				ZalihaMax = int.Parse(dr["zaliha_max"].ToString());
				IdJedinica = dr ["id_jedinica_mjere"].ToString();
			}
		}

		public int Spremi() {
			String sqlQuery = "";
			if (Id == 0) {
				sqlQuery = "INSERT INTO artikl VALUES (DEFAULT, " + IdKategorija
					+ ", '" + Naziv + "', '" + Opis + "', " + Cijena + ", " + Stanje + ", " + ZalihaMin + ", " + ZalihaMax + ", '" + IdJedinica + "');";
			} else {
				sqlQuery = "UPDATE artikl SET id_kategorija = " + IdKategorija
					+ ", naziv = '" + Naziv
					+ "', opis = '" + Opis
					+ "', cijena = " + Cijena
					+ ", stanje = " + Stanje
					+ ", zaliha_min = " + ZalihaMin
					+ ", zaliha_max = " + ZalihaMax
					+ ", id_jedinica_mjere = '" + IdJedinica 
				+ "' WHERE id_artikl = " + Id + ";";
			}
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}

		public int Obrisi() {
			String sqlQuery = "DELETE FROM artikl WHERE id_artikl = " + Id + ";";
			return DatabaseConnection.Instance.executeQuery (sqlQuery);
		}

		public static Artikl DohvatiArtikl(int idArtikl) {
			String sqlUpit = "SELECT artikl.*, kategorija.naziv AS naziv_kategorija  FROM artikl, kategorija WHERE artikl.id_kategorija = kategorija.id_kategorija AND artikl.id_artikl = " + idArtikl;
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			Artikl a = null;
			if (dr.Read ()) {
				a = new Artikl (dr);
			}
			dr.Close ();
			return a;
		}

		public static List<Artikl> DohvatiArtikle() {
			List<Artikl> listaArtikli = new List<Artikl> ();
			String sqlQuery = "SELECT artikl.*, kategorija.naziv AS naziv_kategorija  FROM artikl, kategorija WHERE artikl.id_kategorija = kategorija.id_kategorija ORDER BY id_artikl;";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				Artikl a = new Artikl (dr);
				listaArtikli.Add (a);
			}
			dr.Close ();
			return listaArtikli;
		}

	}
}

