using System;
using System.Collections.Generic;
using Npgsql;

namespace MyStockManager
{
	public class Stavka
	{
		public String IdDokument { set; get; }
		public int IdArtikl { set; get; }
		public Artikl Artikl { set; get; }
		public int Kolicina { set; get; }

		public Stavka (string idDok, int idArt, Artikl a, int kol)
		{
			IdDokument = idDok;
			IdArtikl = idArt;
			Artikl = a;
			Kolicina = kol;
		}

		public Stavka(NpgsqlDataReader dr) {
			IdDokument = dr ["id_dokument"].ToString ();
			IdArtikl = int.Parse(dr ["id_artikl"].ToString ());
			Kolicina = int.Parse(dr ["kolicina"].ToString ());
		}


		/// <summary>
		/// Dohvaća stavke (artikle) dokumenta.
		/// </summary>
		/// <returns>Lista stavki dokumenta.</returns>
		/// <param name="IdDokument">ID dokumenta.</param>
		/// <param name="vrsta">Vrsta dokumenta: 0 - Primka; 1 - Otpremnica</param>
		public static List<Stavka> DohvatiStavke(String IdDokument, int vrsta) {
			List<Stavka> listaStavki = new List<Stavka> ();
			String sqlUpit = "";
			switch (vrsta) {
			case 0:
				sqlUpit = "SELECT id_primka AS id_dokument, id_artikl, kolicina FROM stavke_primke WHERE id_primka = '" + IdDokument + "'";
				break;
			case 1:
				sqlUpit = "SELECT id_otpremnica AS id_dokument, id_artikl, kolicina FROM stavke_otpremnice WHERE id_otpremnica = '" + IdDokument +"'";
				break;
			}
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlUpit);
			while (dr.Read ()) {
				Stavka s = new Stavka (dr);
				listaStavki.Add (s);
			}
			dr.Close ();
			foreach (Stavka item in listaStavki) {
				item.Artikl = Artikl.DohvatiArtikl (item.IdArtikl);
			}
			return listaStavki;
		}
	}
}

