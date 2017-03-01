using System;
using Npgsql;
using System.Collections.Generic;

namespace MyStockManager
{
	public class JedinicaMjere
	{
		public String IdJedinice { set; get;}
		public String NazivJedinice { set; get;}


		public JedinicaMjere ()
		{
		}

		public JedinicaMjere(NpgsqlDataReader dr) {
			if (dr != null) {
				IdJedinice = dr ["id_jedinice_mjere"].ToString ();
				NazivJedinice = dr ["naziv"].ToString ();
			}
		}

		public static List<JedinicaMjere> Dohvati() {
			List<JedinicaMjere> listaJedinica = new List<JedinicaMjere> ();
			String sqlQuery = "SELECT * FROM jedinica_mjere;";
			NpgsqlDataReader dr = DatabaseConnection.Instance.getDataReader (sqlQuery);
			while (dr.Read ()) {
				JedinicaMjere jm = new JedinicaMjere (dr);
				listaJedinica.Add (jm);
			}
			dr.Close ();
			return listaJedinica;
		}
	}
}

